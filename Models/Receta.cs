using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class RecetaLinea
{
    [JsonPropertyName("medicamento")]
    public string Medicamento { get; set; } = string.Empty;
    
    [JsonPropertyName("dosis")]
    public string? Dosis { get; set; }
    
    [JsonPropertyName("frecuencia")]
    public string? Frecuencia { get; set; }
    
    [JsonPropertyName("duracion")]
    public string? Duracion { get; set; }
}

public class Receta
{
    [JsonPropertyName("id_receta")]
    public string IdReceta { get; set; } = string.Empty;
    
    [JsonPropertyName("id_cita")]
    public string IdCita { get; set; } = string.Empty;
    
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("fecha_emision")]
    public DateTime FechaEmision { get; set; }
    
    [JsonPropertyName("indicaciones")]
    public string? Indicaciones { get; set; }
    
    [JsonPropertyName("lineas")]
    public List<RecetaLinea>? Lineas { get; set; }
    
    [JsonPropertyName("veterinario")]
    public string Veterinario { get; set; } = string.Empty;  // Username del veterinario
    
    [JsonPropertyName("veterinario_nombre")]
    public string? VeterinarioNombre { get; set; }  // Nombre completo del veterinario
    
    [JsonPropertyName("veterinario_telefono")]
    public string? VeterinarioTelefono { get; set; }  // Teléfono del veterinario
    
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

public class RecetaCreate
{
    [JsonPropertyName("id_cita")]
    public string IdCita { get; set; } = string.Empty;
    
    [JsonPropertyName("indicaciones")]
    public string? Indicaciones { get; set; }
    
    [JsonPropertyName("lineas")]
    public List<RecetaLinea>? Lineas { get; set; }
}

public class RecetaUpdate
{
    [JsonPropertyName("indicaciones")]
    public string? Indicaciones { get; set; }
    
    [JsonPropertyName("lineas")]
    public List<RecetaLinea>? Lineas { get; set; }
}

public class RecetaSummary
{
    [JsonPropertyName("id_receta")]
    public string IdReceta { get; set; } = string.Empty;
    
    [JsonPropertyName("id_cita")]
    public string IdCita { get; set; } = string.Empty;
    
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("mascota_nombre")]
    public string? MascotaNombre { get; set; }
    
    [JsonPropertyName("fecha_emision")]
    public DateTime FechaEmision { get; set; }
    
    [JsonPropertyName("veterinario")]
    public string Veterinario { get; set; } = string.Empty;  // Username del veterinario
    
    [JsonPropertyName("veterinario_nombre")]
    public string? VeterinarioNombre { get; set; }  // Nombre completo del veterinario
    
    [JsonPropertyName("veterinario_telefono")]
    public string? VeterinarioTelefono { get; set; }  // Teléfono del veterinario
    
    [JsonPropertyName("propietario_username")]
    public string? PropietarioUsername { get; set; }
    
    [JsonPropertyName("propietario_nombre")]
    public string? PropietarioNombre { get; set; }
    
    [JsonPropertyName("propietario_telefono")]
    public string? PropietarioTelefono { get; set; }
}
