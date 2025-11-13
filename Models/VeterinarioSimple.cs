using System.Text.Json.Serialization;

namespace VeterinariaApp.Models;

public class VeterinarioSimple
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [JsonPropertyName("telefono")]
    public string? Telefono { get; set; }
}
