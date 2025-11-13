using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VeterinariaApp;
using VeterinariaApp.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Register services as SCOPED (works like Singleton in Blazor WASM)
// ApiService ya no necesita HttpClient inyectado, usa uno estático
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MascotaService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<VacunaService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<RecetaService>();
builder.Services.AddScoped<EstadisticaService>();

await builder.Build().RunAsync();
