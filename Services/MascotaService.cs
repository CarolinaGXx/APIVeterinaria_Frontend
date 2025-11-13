using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class MascotaService
{
    private readonly ApiService _apiService;

    public MascotaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<PaginatedResponse<Mascota>?> GetMascotasAsync(int page = 1, int pageSize = 10, string? propietario = null, bool includeDeleted = true)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/mascotas/?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";
        if (!string.IsNullOrEmpty(propietario))
            query += $"&propietario={propietario}";

        return await _apiService.GetAsync<PaginatedResponse<Mascota>>(query);
    }

    public async Task<Mascota?> GetMascotaAsync(string id)
    {
        return await _apiService.GetAsync<Mascota>($"/mascotas/{id}");
    }

    public async Task<List<Mascota>?> SearchMascotasAsync(string searchTerm, int limit = 20, bool includeDeleted = false)
    {
        // Real-time search for autocomplete (returns simple list, not paginated)
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<Mascota>();

        var query = $"/mascotas/search?q={Uri.EscapeDataString(searchTerm)}&limit={limit}&include_deleted={includeDeleted.ToString().ToLower()}";
        return await _apiService.GetAsync<List<Mascota>>(query);
    }

    public async Task<Mascota?> CreateMascotaAsync(MascotaCreate mascota)
    {
        return await _apiService.PostAsync<MascotaCreate, Mascota>("/mascotas/", mascota);
    }

    public async Task<Mascota?> UpdateMascotaAsync(string id, MascotaUpdate mascota)
    {
        return await _apiService.PutAsync<MascotaUpdate, Mascota>($"/mascotas/{id}", mascota);
    }

    public async Task<bool> DeleteMascotaAsync(string id)
    {
        return await _apiService.DeleteAsync($"/mascotas/{id}");
    }

    public async Task<bool> RestoreMascotaAsync(string id)
    {
        try
        {
            var response = await _apiService.PostAsync<object, object>($"/mascotas/{id}/restore", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }
}
