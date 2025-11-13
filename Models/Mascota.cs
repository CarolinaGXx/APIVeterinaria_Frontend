using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaApp.Models;

public class Mascota
{
    [JsonPropertyName("id_mascota")]
    public string IdMascota { get; set; } = string.Empty;
    
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
    
    [JsonPropertyName("raza")]
    public string Raza { get; set; } = string.Empty;
    
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [JsonPropertyName("peso")]
    public float Peso { get; set; }
    
    [JsonPropertyName("propietario")]
    public string Propietario { get; set; } = string.Empty;
    
    [JsonPropertyName("telefono_propietario")]
    public string? TelefonoPropietario { get; set; }
    
    [JsonPropertyName("propietario_nombre")]
    public string? PropietarioNombre { get; set; }
    
    [JsonPropertyName("propietario_telefono")]
    public string? PropietarioTelefono { get; set; }
    
    [JsonPropertyName("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }
    
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
}

public class MascotaCreate
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El tipo es requerido")]
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La raza es requerida")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "La raza debe tener entre 2 y 50 caracteres")]
    [JsonPropertyName("raza")]
    public string Raza { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La edad es requerida")]
    [Range(0, 50, ErrorMessage = "La edad debe estar entre 0 y 50 años")]
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [Required(ErrorMessage = "El peso es requerido")]
    [Range(0.1, 500, ErrorMessage = "El peso debe estar entre 0.1 y 500 kg")]
    [JsonPropertyName("peso")]
    public float Peso { get; set; }
    
    // NO se envía propietario - el backend lo toma del usuario autenticado
}

public class MascotaUpdate
{
    [JsonPropertyName("nombre")]
    public string? Nombre { get; set; }
    
    [JsonPropertyName("tipo")]
    public string? Tipo { get; set; }
    
    [JsonPropertyName("raza")]
    public string? Raza { get; set; }
    
    [JsonPropertyName("edad")]
    public int? Edad { get; set; }
    
    [JsonPropertyName("peso")]
    public float? Peso { get; set; }
}

// Estructura que coincide con el backend
public class PaginatedResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("data")]
    public List<T> Data { get; set; } = new();
    
    [JsonPropertyName("pagination")]
    public PaginationMeta Pagination { get; set; } = new();
    
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }
    
    // Propiedades de compatibilidad para código existente
    public List<T> Items => Data;
    public int Total => Pagination.TotalItems;
    public int Page => Pagination.Page;
    public int PageSize => Pagination.PageSize;
    public int TotalPages => Pagination.TotalPages;
}

public class PaginationMeta
{
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }
    
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("has_next")]
    public bool HasNext { get; set; }
    
    [JsonPropertyName("has_previous")]
    public bool HasPrevious { get; set; }
}
