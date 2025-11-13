using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class FacturaService
{
    private readonly ApiService _apiService;

    public FacturaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<PaginatedResponse<Factura>?> GetFacturasAsync(
        int page = 1, 
        int pageSize = 10, 
        string? estado = null,
        string? veterinario = null,
        bool includeDeleted = false)
    {
        // Backend usa page (0-indexed) y page_size
        var query = $"/facturas/?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";
        
        if (!string.IsNullOrEmpty(estado))
            query += $"&estado={estado}";
        
        if (!string.IsNullOrEmpty(veterinario))
            query += $"&veterinario={veterinario}";

        return await _apiService.GetAsync<PaginatedResponse<Factura>>(query);
    }

    public async Task<Factura?> GetFacturaAsync(string id)
    {
        return await _apiService.GetAsync<Factura>($"/facturas/{id}");
    }

    public async Task<PaginatedResponse<Factura>?> GetFacturasByMascotaAsync(
        string mascotaId, 
        int page = 1, 
        int pageSize = 100, 
        bool includeDeleted = false)
    {
        // Endpoint especial para historial de facturas de una mascota
        // PRIVACIDAD: Cliente ve todas, Veterinario solo las suyas, Admin ve todas
        var query = $"/mascotas/{mascotaId}/facturas?page={page - 1}&page_size={pageSize}&include_deleted={includeDeleted.ToString().ToLower()}";

        return await _apiService.GetAsync<PaginatedResponse<Factura>>(query);
    }

    public async Task<Factura?> CreateFacturaAsync(FacturaCreate factura)
    {
        return await _apiService.PostAsync<FacturaCreate, Factura>("/facturas/", factura);
    }

    public async Task<Factura?> UpdateFacturaAsync(string id, FacturaUpdate factura)
    {
        return await _apiService.PutAsync<FacturaUpdate, Factura>($"/facturas/{id}", factura);
    }

    public async Task<bool> DeleteFacturaAsync(string id)
    {
        return await _apiService.DeleteAsync($"/facturas/{id}");
    }

    public async Task<bool> RestoreFacturaAsync(string id)
    {
        try
        {
            var response = await _apiService.PostAsync<object, object>($"/facturas/{id}/restore", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }

    public async Task<Factura?> MarcarComoPagadaAsync(string id)
    {
        try
        {
            // Usar el endpoint específico /facturas/{id}/pagar del backend
            return await _apiService.PostAsync<object, Factura>($"/facturas/{id}/pagar", new { });
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> AnularFacturaAsync(string id)
    {
        try
        {
            // Usar el endpoint específico /facturas/{id}/anular del backend
            var response = await _apiService.PostAsync<object, object>($"/facturas/{id}/anular", new { });
            return response != null;
        }
        catch
        {
            return false;
        }
    }
}
