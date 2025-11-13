using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class EstadisticasCliente
{
    [JsonPropertyName("mis_mascotas")]
    public int MisMascotas { get; set; }
    
    [JsonPropertyName("citas_pendientes")]
    public int CitasPendientes { get; set; }
    
    [JsonPropertyName("citas_completadas")]
    public int CitasCompletadas { get; set; }
    
    [JsonPropertyName("vacunas_aplicadas")]
    public int VacunasAplicadas { get; set; }
    
    [JsonPropertyName("facturas_pendientes")]
    public int FacturasPendientes { get; set; }
    
    [JsonPropertyName("facturas_pagadas")]
    public int FacturasPagadas { get; set; }
}

public class EstadisticasVeterinario
{
    [JsonPropertyName("mis_mascotas")]
    public int MisMascotas { get; set; }
    
    [JsonPropertyName("citas_asignadas")]
    public int CitasAsignadas { get; set; }
    
    [JsonPropertyName("citas_completadas")]
    public int CitasCompletadas { get; set; }
    
    [JsonPropertyName("vacunas_aplicadas")]
    public int VacunasAplicadas { get; set; }
    
    [JsonPropertyName("facturas_emitidas")]
    public int FacturasEmitidas { get; set; }
    
    [JsonPropertyName("facturas_cobradas")]
    public int FacturasCobradas { get; set; }
}

public class EstadisticasAdmin
{
    [JsonPropertyName("total_mascotas")]
    public int TotalMascotas { get; set; }
    
    [JsonPropertyName("total_usuarios")]
    public int TotalUsuarios { get; set; }
    
    [JsonPropertyName("citas_pendientes")]
    public int CitasPendientes { get; set; }
    
    [JsonPropertyName("citas_hoy")]
    public int CitasHoy { get; set; }
    
    [JsonPropertyName("vacunas_mes")]
    public int VacunasMes { get; set; }
    
    [JsonPropertyName("facturas_pendientes")]
    public int FacturasPendientes { get; set; }
    
    [JsonPropertyName("ingresos_mes")]
    public decimal IngresosMes { get; set; }
}

public class EstadisticasResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public object? Data { get; set; }
    
    // Helper methods para castear data según el rol
    public EstadisticasCliente? AsCliente() => 
        Data as EstadisticasCliente ?? 
        System.Text.Json.JsonSerializer.Deserialize<EstadisticasCliente>(
            System.Text.Json.JsonSerializer.Serialize(Data)
        );
    
    public EstadisticasVeterinario? AsVeterinario() => 
        Data as EstadisticasVeterinario ?? 
        System.Text.Json.JsonSerializer.Deserialize<EstadisticasVeterinario>(
            System.Text.Json.JsonSerializer.Serialize(Data)
        );
    
    public EstadisticasAdmin? AsAdmin() => 
        Data as EstadisticasAdmin ?? 
        System.Text.Json.JsonSerializer.Deserialize<EstadisticasAdmin>(
            System.Text.Json.JsonSerializer.Serialize(Data)
        );
}
