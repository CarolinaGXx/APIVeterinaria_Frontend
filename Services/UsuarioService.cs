using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class UsuarioService
{
    private readonly ApiService _apiService;

    public UsuarioService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<VeterinarioSimple>?> GetVeterinariosAsync()
    {
        return await _apiService.GetAsync<List<VeterinarioSimple>>("/usuarios/veterinarios");
    }

    public async Task<PaginatedResponse<Usuario>?> GetUsuariosAsync(
        int page = 1,
        int pageSize = 10,
        string? role = null,
        bool includeDeleted = false)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/usuarios/?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";
        
        if (!string.IsNullOrEmpty(role))
            query += $"&role={role}";

        return await _apiService.GetAsync<PaginatedResponse<Usuario>>(query);
    }

    public async Task<Usuario?> GetMiPerfilAsync()
    {
        return await _apiService.GetAsync<Usuario>("/usuarios/me");
    }

    public async Task<Usuario?> GetUsuarioAsync(string id)
    {
        return await _apiService.GetAsync<Usuario>($"/usuarios/{id}");
    }

    public async Task<UsuarioUpdateResponse?> UpdateMiPerfilAsync(UsuarioUpdate usuario)
    {
        return await _apiService.PutAsync<UsuarioUpdate, UsuarioUpdateResponse>("/usuarios/me", usuario);
    }

    public async Task<bool> DeleteMiCuentaAsync()
    {
        return await _apiService.DeleteAsync("/usuarios/me");
    }

    public async Task<bool> RestoreMiCuentaAsync()
    {
        try
        {
            var response = await _apiService.PostAsync<object, object>("/usuarios/me/restore", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }

    // Admin methods
    public async Task<Usuario?> ChangeUserRoleAsync(string userId, string newRole)
    {
        try
        {
            var payload = new { role = newRole };
            // PATCH request to change role
            var response = await _apiService.PatchAsync<object, Usuario>($"/usuarios/{userId}/role", payload);
            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteUsuarioAsync(string userId)
    {
        try
        {
            return await _apiService.DeleteAsync($"/usuarios/{userId}");
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RestoreUsuarioAsync(string userId)
    {
        try
        {
            var response = await _apiService.PostAsync<object, object>($"/usuarios/{userId}/restore", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Usuario?> CreatePrivilegedUserAsync(UsuarioPrivilegedCreate usuario)
    {
        try
        {
            return await _apiService.PostAsync<UsuarioPrivilegedCreate, Usuario>("/usuarios/admin/create", usuario);
        }
        catch
        {
            return null;
        }
    }
}
