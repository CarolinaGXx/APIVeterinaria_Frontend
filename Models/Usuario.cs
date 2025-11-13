using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaApp.Models;

public class Usuario
{
    [JsonPropertyName("id_usuario")]
    public string IdUsuario { get; set; } = string.Empty;
    
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [JsonPropertyName("telefono")]
    public string Telefono { get; set; } = string.Empty;
    
    [JsonPropertyName("role")]
    public string Role { get; set; } = string.Empty;
    
    [JsonPropertyName("fecha_creacion")]
    public DateTime FechaCreacion { get; set; }
    
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }
}

public class LoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;
    
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = "bearer";
    
    [JsonPropertyName("usuario")]
    public Usuario Usuario { get; set; } = new();
}

public class UsuarioCreate
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 100 caracteres")]
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La contraseña es requerida")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El nombre completo es requerido")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 200 caracteres")]
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La edad es requerida")]
    [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120 años")]
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [Required(ErrorMessage = "El teléfono es requerido")]
    [Phone(ErrorMessage = "El teléfono no es válido")]
    [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 caracteres")]
    [JsonPropertyName("telefono")]
    public string Telefono { get; set; } = string.Empty;
    
    [JsonPropertyName("role")]
    public string Role { get; set; } = "cliente";
}

public class UsuarioPrivilegedCreate
{
    [Required(ErrorMessage = "El nombre de usuario es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 100 caracteres")]
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La contraseña es requerida")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El nombre completo es requerido")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 200 caracteres")]
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La edad es requerida")]
    [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120 años")]
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [Required(ErrorMessage = "El teléfono es requerido")]
    [Phone(ErrorMessage = "El teléfono no es válido")]
    [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 20 caracteres")]
    [JsonPropertyName("telefono")]
    public string Telefono { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El rol es requerido")]
    [JsonPropertyName("role")]
    public string Role { get; set; } = "veterinario";
}

public class UsuarioUpdate
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    
    [JsonPropertyName("nombre")]
    public string? Nombre { get; set; }
    
    [JsonPropertyName("edad")]
    public int? Edad { get; set; }
    
    [JsonPropertyName("telefono")]
    public string? Telefono { get; set; }
}

public class UsuarioUpdateResponse
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [JsonPropertyName("edad")]
    public int Edad { get; set; }
    
    [JsonPropertyName("telefono")]
    public string Telefono { get; set; } = string.Empty;
}
