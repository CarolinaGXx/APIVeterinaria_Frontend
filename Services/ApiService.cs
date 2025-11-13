using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace VeterinariaApp.Services;

public class ApiService
{
    // HttpClient estático compartido globalmente
    private static HttpClient? _sharedHttpClient;
    
    private readonly JsonSerializerOptions _jsonOptions;
    
    // Token estático compartido entre todas las instancias
    private static string? _authToken;

    public ApiService(IConfiguration configuration)
    {
        // Inicializar HttpClient solo una vez
        if (_sharedHttpClient == null)
        {
            var baseUrl = configuration["ApiConfiguration:BaseUrl"] ?? "http://localhost:8000";
            _sharedHttpClient = new HttpClient 
            { 
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(configuration.GetValue<int>("ApiConfiguration:Timeout", 30))
            };
            Console.WriteLine($"API configurada: {baseUrl}");
        }
        
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        // Configurar token automáticamente si existe
        if (!string.IsNullOrEmpty(_authToken))
        {
            _sharedHttpClient!.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _authToken);
        }
    }

    public void SetAuthToken(string token)
    {
        _authToken = token;  // Guardar en estático
        _sharedHttpClient!.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
        Console.WriteLine($"Token configurado: {token}");
    }

    public void ClearAuthToken()
    {
        _authToken = null;  // Limpiar estático
        _sharedHttpClient!.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _sharedHttpClient!.GetAsync(endpoint);
            
            // Si el token expiró, lanzar excepción específica
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ClearAuthToken();
                throw new UnauthorizedAccessException("Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
            }
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }
        catch (UnauthorizedAccessException)
        {
            throw; // Re-lanzar para que las páginas lo capturen
        }
        catch (HttpRequestException)
        {
            throw;
        }
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var response = await _sharedHttpClient!.PostAsJsonAsync(endpoint, data, _jsonOptions);
            
            // Si el token expiró, lanzar excepción específica
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine($"⚠️ Token expirado o inválido en POST {endpoint}");
                ClearAuthToken();
                throw new UnauthorizedAccessException("Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
            }
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error POST {endpoint}: {ex.Message}");
            throw;
        }
    }

    public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var response = await _sharedHttpClient!.PutAsJsonAsync(endpoint, data, _jsonOptions);
            
            // Si el token expiró, lanzar excepción específica
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine($"⚠️ Token expirado o inválido en PUT {endpoint}");
                ClearAuthToken();
                throw new UnauthorizedAccessException("Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
            }
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error PUT {endpoint}: {ex.Message}");
            throw;
        }
    }

    public async Task<TResponse?> PatchAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), endpoint)
            {
                Content = JsonContent.Create(data, options: _jsonOptions)
            };
            
            var response = await _sharedHttpClient!.SendAsync(request);
            
            // Si el token expiró, lanzar excepción específica
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine($"⚠️ Token expirado o inválido en PATCH {endpoint}");
                ClearAuthToken();
                throw new UnauthorizedAccessException("Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
            }
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error PATCH {endpoint}: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(string endpoint)
    {
        try
        {
            var response = await _sharedHttpClient!.DeleteAsync(endpoint);
            
            // Si el token expiró, lanzar excepción específica
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine($"⚠️ Token expirado o inválido en DELETE {endpoint}");
                ClearAuthToken();
                throw new UnauthorizedAccessException("Tu sesión ha expirado. Por favor inicia sesión nuevamente.");
            }
            
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("No tienes permisos para realizar esta acción.");
            }
            
            return response.IsSuccessStatusCode;
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error DELETE {endpoint}: {ex.Message}");
            return false;
        }
    }
}
