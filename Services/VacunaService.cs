using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class VacunaService
{
    private readonly ApiService _apiService;

    public VacunaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<PaginatedResponse<Vacuna>?> GetVacunasAsync(
        int page = 1, 
        int pageSize = 10, 
        string? tipoVacuna = null,
        string? veterinario = null,
        string? idMascota = null,
        string? mascotaNombre = null,
        bool includeDeleted = false)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/vacunas/?page={page - 1}&page_size={pageSize}";
        
        if (!string.IsNullOrEmpty(tipoVacuna))
            query += $"&tipo_vacuna={tipoVacuna}";
        
        if (!string.IsNullOrEmpty(veterinario))
            query += $"&veterinario={Uri.EscapeDataString(veterinario)}";
        
        if (!string.IsNullOrEmpty(idMascota))
            query += $"&id_mascota={idMascota}";
        
        if (!string.IsNullOrEmpty(mascotaNombre))
            query += $"&mascota_nombre={Uri.EscapeDataString(mascotaNombre)}";
        
        if (includeDeleted)
            query += "&include_deleted=true";

        return await _apiService.GetAsync<PaginatedResponse<Vacuna>>(query);
    }

    public async Task<Vacuna?> GetVacunaAsync(string id)
    {
        return await _apiService.GetAsync<Vacuna>($"/vacunas/{id}");
    }

    public async Task<PaginatedResponse<Vacuna>?> GetVacunasByMascotaAsync(
        string mascotaId, 
        int page = 1, 
        int pageSize = 100, 
        bool includeDeleted = false)
    {
        // Endpoint especial para historial clínico completo de una mascota
        // Devuelve TODAS las vacunas de esa mascota (no solo las del veterinario actual)
        var query = $"/mascotas/{mascotaId}/vacunas?page={page - 1}&page_size={pageSize}";
        if (includeDeleted)
            query += "&include_deleted=true";

        return await _apiService.GetAsync<PaginatedResponse<Vacuna>>(query);
    }

    public async Task<Vacuna?> CreateVacunaAsync(VacunaCreate vacuna)
    {
        return await _apiService.PostAsync<VacunaCreate, Vacuna>("/vacunas/", vacuna);
    }

    public async Task<Vacuna?> UpdateVacunaAsync(string id, VacunaUpdate vacuna)
    {
        return await _apiService.PutAsync<VacunaUpdate, Vacuna>($"/vacunas/{id}", vacuna);
    }

    public async Task<bool> DeleteVacunaAsync(string id)
    {
        return await _apiService.DeleteAsync($"/vacunas/{id}");
    }
}
