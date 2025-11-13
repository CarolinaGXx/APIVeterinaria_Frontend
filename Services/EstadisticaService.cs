using VeterinariaApp.Models;

namespace VeterinariaApp.Services;

public class EstadisticaService
{
    private readonly ApiService _apiService;

    public EstadisticaService(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<EstadisticasResponse?> GetEstadisticasDashboardAsync()
    {
        return await _apiService.GetAsync<EstadisticasResponse>("/estadisticas/dashboard");
    }
}
