using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class Factura
{
    [JsonPropertyName("id_factura")]
    public string IdFactura { get; set; } = string.Empty;
    
    [JsonPropertyName("numero_factura")]
    public string NumeroFactura { get; set; } = string.Empty;
    
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("id_cita")]
    public string? IdCita { get; set; }
    
    [JsonPropertyName("id_vacuna")]
    public string? IdVacuna { get; set; }
    
    [JsonPropertyName("fecha_factura")]
    public DateTime FechaFactura { get; set; }
    
    [JsonPropertyName("tipo_servicio")]
    public string TipoServicio { get; set; } = string.Empty;
    
    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;
    
    [JsonPropertyName("veterinario")]
    public string Veterinario { get; set; } = string.Empty;  // Username del veterinario
    
    [JsonPropertyName("veterinario_nombre")]
    public string? VeterinarioNombre { get; set; }  // Nombre completo del veterinario
    
    [JsonPropertyName("veterinario_telefono")]
    public string? VeterinarioTelefono { get; set; }  // Teléfono del veterinario
    
    [JsonPropertyName("valor_servicio")]
    public decimal ValorServicio { get; set; }
    
    [JsonPropertyName("iva")]
    public decimal Iva { get; set; }
    
    [JsonPropertyName("descuento")]
    public decimal Descuento { get; set; }
    
    [JsonPropertyName("estado")]
    public string Estado { get; set; } = "pendiente";
    
    [JsonPropertyName("total")]
    public decimal Total { get; set; }
    
    [JsonPropertyName("mascota_nombre")]
    public string? MascotaNombre { get; set; }
    
    [JsonPropertyName("mascota_tipo")]
    public string? MascotaTipo { get; set; }
    
    [JsonPropertyName("propietario_username")]
    public string? PropietarioUsername { get; set; }
    
    [JsonPropertyName("propietario_nombre")]
    public string? PropietarioNombre { get; set; }
    
    [JsonPropertyName("propietario_telefono")]
    public string? PropietarioTelefono { get; set; }
    
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
}

public class FacturaCreate
{
    [JsonPropertyName("id_cita")]
    public string? IdCita { get; set; }
    
    [JsonPropertyName("id_vacuna")]
    public string? IdVacuna { get; set; }
    
    [JsonPropertyName("tipo_servicio")]
    public string TipoServicio { get; set; } = string.Empty;
    
    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;
    
    [JsonPropertyName("valor_servicio")]
    public decimal ValorServicio { get; set; }
    
    [JsonPropertyName("iva")]
    public decimal Iva { get; set; }
    
    [JsonPropertyName("descuento")]
    public decimal Descuento { get; set; }
}

public class FacturaUpdate
{
    [JsonPropertyName("tipo_servicio")]
    public string? TipoServicio { get; set; }
    
    [JsonPropertyName("descripcion")]
    public string? Descripcion { get; set; }
    
    [JsonPropertyName("valor_servicio")]
    public decimal? ValorServicio { get; set; }
    
    [JsonPropertyName("iva")]
    public decimal? Iva { get; set; }
    
    [JsonPropertyName("descuento")]
    public decimal? Descuento { get; set; }
    
    [JsonPropertyName("estado")]
    public string? Estado { get; set; }
}
