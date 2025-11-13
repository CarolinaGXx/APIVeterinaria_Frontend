using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class Cita
{
    [JsonPropertyName("id_cita")]
    public string IdCita { get; set; } = string.Empty;
    
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }
    
    [JsonPropertyName("motivo")]
    public string Motivo { get; set; } = string.Empty;
    
    [JsonPropertyName("estado")]
    public string Estado { get; set; } = string.Empty;
    
    [JsonPropertyName("diagnostico")]
    public string? Diagnostico { get; set; }
    
    [JsonPropertyName("tratamiento")]
    public string? Tratamiento { get; set; }
    
    [JsonPropertyName("mascota_nombre")]
    public string? NombreMascota { get; set; }
    
    [JsonPropertyName("propietario_mascota")]
    public string? PropietarioMascota { get; set; }
    
    [JsonPropertyName("propietario_username")]
    public string? PropietarioUsername { get; set; }
    
    [JsonPropertyName("propietario_nombre")]
    public string? PropietarioNombre { get; set; }
    
    [JsonPropertyName("propietario_telefono")]
    public string? PropietarioTelefono { get; set; }
    
    [JsonPropertyName("veterinario")]
    public string? Veterinario { get; set; }  // Username del veterinario
    
    [JsonPropertyName("veterinario_nombre")]
    public string? VeterinarioNombre { get; set; }  // Nombre completo del veterinario
    
    [JsonPropertyName("veterinario_telefono")]
    public string? VeterinarioTelefono { get; set; }  // Teléfono del veterinario
    
    [JsonPropertyName("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }
    
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
}

public class CitaCreate
{
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }
    
    [JsonPropertyName("motivo")]
    public string Motivo { get; set; } = string.Empty;
    
    [JsonPropertyName("veterinario")]
    public string Veterinario { get; set; } = string.Empty;
}

public class CitaUpdate
{
    // NO incluimos IdMascota - no se puede cambiar la mascota de una cita
    
    [JsonPropertyName("fecha")]
    public DateTime? Fecha { get; set; }
    
    [JsonPropertyName("motivo")]
    public string? Motivo { get; set; }
    
    [JsonPropertyName("veterinario")]
    public string? Veterinario { get; set; }
    
    [JsonPropertyName("estado")]
    public string? Estado { get; set; }
    
    [JsonPropertyName("diagnostico")]
    public string? Diagnostico { get; set; }
    
    [JsonPropertyName("tratamiento")]
    public string? Tratamiento { get; set; }
}
