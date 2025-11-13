using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class CitaService
{
    private readonly ApiService _apiService;

    public CitaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<PaginatedResponse<Cita>?> GetCitasAsync(int page = 1, int pageSize = 10, string? estado = null, bool includeDeleted = true)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/citas/?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";
        if (!string.IsNullOrEmpty(estado))
            query += $"&estado={estado}";

        return await _apiService.GetAsync<PaginatedResponse<Cita>>(query);
    }

    public async Task<Cita?> GetCitaAsync(string id)
    {
        return await _apiService.GetAsync<Cita>($"/citas/{id}");
    }

    public async Task<PaginatedResponse<Cita>?> GetCitasByMascotaAsync(
        string mascotaId, 
        int page = 1, 
        int pageSize = 100, 
        bool includeDeleted = true)
    {
        // Endpoint especial para historial clínico completo de una mascota
        // Devuelve TODAS las citas de esa mascota (no solo las del veterinario actual)
        var query = $"/mascotas/{mascotaId}/citas?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";

        return await _apiService.GetAsync<PaginatedResponse<Cita>>(query);
    }

    public async Task<Cita?> CreateCitaAsync(CitaCreate cita)
    {
        return await _apiService.PostAsync<CitaCreate, Cita>("/citas/", cita);
    }

    public async Task<Cita?> UpdateCitaAsync(string id, CitaUpdate cita)
    {
        return await _apiService.PutAsync<CitaUpdate, Cita>($"/citas/{id}", cita);
    }

    public async Task<bool> CancelCitaAsync(string id)
    {
        return await _apiService.DeleteAsync($"/citas/{id}");
    }
}
