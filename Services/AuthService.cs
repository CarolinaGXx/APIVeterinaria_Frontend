using Blazored.LocalStorage;
using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class AuthService
{
    private readonly ApiService _apiService;
    private readonly ILocalStorageService _localStorage;
    private const string TokenKey = "authToken";
    private const string UserKey = "currentUser";

    // Estado estático compartido entre todas las instancias
    private static Usuario? _currentUser;
    private static bool _initialized = false;

    public Usuario? CurrentUser => _currentUser;
    public bool IsAuthenticated => _currentUser != null;
    public bool IsInitialized => _initialized;

    public static event Action? OnAuthStateChanged;

    public AuthService(ApiService apiService, ILocalStorageService localStorage)
    {
        _apiService = apiService;
        _localStorage = localStorage;
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;
        
        try
        {
            var token = await _localStorage.GetItemAsync<string>(TokenKey);
            var user = await _localStorage.GetItemAsync<Usuario>(UserKey);

            if (!string.IsNullOrEmpty(token) && user != null)
            {
                _currentUser = user;
                _apiService.SetAuthToken(token);
                _initialized = true;
                NotifyAuthStateChanged();
            }
            else
            {
                _initialized = true;
            }
        }
        catch
        {
            _initialized = true;
        }
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            var request = new LoginRequest { Username = username, Password = password };
            var response = await _apiService.PostAsync<LoginRequest, LoginResponse>("/auth/login", request);

            if (response != null)
            {
                Console.WriteLine($"   Login exitoso. Token recibido del backend:");
                Console.WriteLine($"   Longitud: {response.AccessToken.Length}");
                Console.WriteLine($"   Primeros 50 chars: {response.AccessToken.Substring(0, Math.Min(50, response.AccessToken.Length))}");
                
                await _localStorage.SetItemAsync(TokenKey, response.AccessToken);
                await _localStorage.SetItemAsync(UserKey, response.Usuario);
                
                _currentUser = response.Usuario;
                _apiService.SetAuthToken(response.AccessToken);
                
                NotifyAuthStateChanged();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error en login: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> RegisterAsync(UsuarioCreate usuario)
    {
        try
        {
            var response = await _apiService.PostAsync<UsuarioCreate, Usuario>("/usuarios/", usuario);
            return response != null;
        }
        catch
        {
            return false;
        }
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync(TokenKey);
        await _localStorage.RemoveItemAsync(UserKey);
        
        _currentUser = null;
        _initialized = false;
        _apiService.ClearAuthToken();
        
        NotifyAuthStateChanged();
    }

    private void NotifyAuthStateChanged() => OnAuthStateChanged?.Invoke();
}
