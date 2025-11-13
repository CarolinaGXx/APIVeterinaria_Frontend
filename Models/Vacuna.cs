using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class Vacuna
{
    [JsonPropertyName("id_vacuna")]
    public string IdVacuna { get; set; } = string.Empty;
    
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("mascota_nombre")]
    public string MascotaNombre { get; set; } = string.Empty;
    
    [JsonPropertyName("propietario_username")]
    public string? PropietarioUsername { get; set; }
    
    [JsonPropertyName("propietario_nombre")]
    public string? PropietarioNombre { get; set; }
    
    [JsonPropertyName("propietario_telefono")]
    public string? PropietarioTelefono { get; set; }
    
    [JsonPropertyName("tipo_vacuna")]
    public string TipoVacuna { get; set; } = string.Empty;
    
    [JsonPropertyName("fecha_aplicacion")]
    public DateTime FechaAplicacion { get; set; }
    
    [JsonPropertyName("lote_vacuna")]
    public string LoteVacuna { get; set; } = string.Empty;
    
    [JsonPropertyName("proxima_dosis")]
    public DateTime? ProximaDosis { get; set; }
    
    [JsonPropertyName("veterinario")]
    public string? Veterinario { get; set; }  // Username del veterinario
    
    [JsonPropertyName("veterinario_nombre")]
    public string? VeterinarioNombre { get; set; }  // Nombre completo del veterinario
    
    [JsonPropertyName("veterinario_telefono")]
    public string? VeterinarioTelefono { get; set; }  // Teléfono del veterinario
    
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
}

public class VacunaCreate
{
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("tipo_vacuna")]
    public string TipoVacuna { get; set; } = string.Empty;
    
    [JsonPropertyName("lote_vacuna")]
    public string LoteVacuna { get; set; } = string.Empty;
    
    [JsonPropertyName("proxima_dosis")]
    public DateTime? ProximaDosis { get; set; }
}

public class VacunaUpdate
{
    [JsonPropertyName("tipo_vacuna")]
    public string? TipoVacuna { get; set; }
    
    [JsonPropertyName("fecha_aplicacion")]
    public DateTime? FechaAplicacion { get; set; }
    
    [JsonPropertyName("lote_vacuna")]
    public string? LoteVacuna { get; set; }
    
    [JsonPropertyName("proxima_dosis")]
    public DateTime? ProximaDosis { get; set; }
}
