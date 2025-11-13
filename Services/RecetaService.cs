using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class RecetaService
{
    private readonly ApiService _apiService;

    public RecetaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<PaginatedResponse<Receta>?> GetRecetasAsync(
        int page = 1, 
        int pageSize = 10, 
        string? veterinario = null,
        string? mascota = null,
        bool includeDeleted = false)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/recetas/?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";
        
        if (!string.IsNullOrEmpty(veterinario))
            query += $"&veterinario={veterinario}";
        
        if (!string.IsNullOrEmpty(mascota))
            query += $"&mascota={mascota}";

        return await _apiService.GetAsync<PaginatedResponse<Receta>>(query);
    }

    public async Task<Receta?> GetRecetaAsync(string id)
    {
        return await _apiService.GetAsync<Receta>($"/recetas/{id}");
    }

    public async Task<PaginatedResponse<Receta>?> GetRecetasByMascotaAsync(
        string mascotaId, 
        int page = 1, 
        int pageSize = 100, 
        bool includeDeleted = false)
    {
        // Endpoint especial para historial clínico completo de una mascota
        // Devuelve TODAS las recetas de esa mascota (no solo las del veterinario actual)
        var query = $"/mascotas/{mascotaId}/recetas?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";

        return await _apiService.GetAsync<PaginatedResponse<Receta>>(query);
    }

    public async Task<Receta?> CreateRecetaAsync(RecetaCreate receta)
    {
        return await _apiService.PostAsync<RecetaCreate, Receta>("/recetas/", receta);
    }

    public async Task<Receta?> UpdateRecetaAsync(string id, RecetaUpdate receta)
    {
        return await _apiService.PutAsync<RecetaUpdate, Receta>($"/recetas/{id}", receta);
    }

    public async Task<bool> DeleteRecetaAsync(string id)
    {
        return await _apiService.DeleteAsync($"/recetas/{id}");
    }

    public async Task<bool> RestoreRecetaAsync(string id)
    {
        try
        {
            var response = await _apiService.PostAsync<object, object>($"/recetas/{id}/restore", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }
}
