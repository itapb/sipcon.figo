using Data; // Tu namespace para servicios personalizados
using Microsoft.AspNetCore.Localization;
using Scalar.AspNetCore;
using System.Globalization;
using System.Reflection;


// 1. CreateBuilder
var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("en-US");
var supportedCultures = new[] { cultureInfo };


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Establecer la cultura por defecto
    options.DefaultRequestCulture = new RequestCulture(cultureInfo);

    // Forzar el uso de solo en-US en la lista de culturas soportadas
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // MUY IMPORTANTE: Cambiar el orden de los proveedores. 
    // Usaremos un proveedor que no se base en el encabezado del navegador.
    // Aunque no está FixedRequestCultureProvider, al configurar DefaultRequestCulture
    // y limitar las SupportedCultures, se logra el efecto deseado.

    // Opcionalmente, puedes eliminar todos los proveedores y confiar en DefaultRequestCulture
    // options.RequestCultureProviders.Clear(); 

    // Si usas un proveedor que se basa en la Query String (opcional)
    // options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider()); 
});


// 2. Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


// 3. Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v1", options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    var modelsXml = "Models.xml";
    var modelsPath = Path.Combine(AppContext.BaseDirectory, modelsXml);

    if (File.Exists(xmlPath))
    {
        options.AddDocumentTransformer((document, context, cancellationToken) => Task.CompletedTask);
    }

    if (File.Exists(modelsPath))
    {
        options.AddDocumentTransformer((document, context, cancellationToken) => Task.CompletedTask);
    }
});

// 4. Servicios personalizados

builder.Services.AddScoped<dMaster>();
builder.Services.AddScoped<dTransaction>();
builder.Services.AddSingleton<RefreshTokenStore>();

// 5. crear app
var app = builder.Build();


app.UseRouting();
app.UseCors("AllowAll");
app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 204; // No Content
        await context.Response.CompleteAsync();
        return;
    }
    await next();
});

//*****************
app.MapOpenApi();
app.MapScalarApiReference(options =>
{

    options.OpenApiRoutePattern = "/openapi/{documentName}.json";
    options.WithTitle("WebApi");
    options.WithTheme(ScalarTheme.BluePlanet);

});
//*****************

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRequestLocalization();


// 7. app run
app.Run();

// Clase para almacenar refresh tokens en memoria
public class RefreshTokenStore
{
    private readonly Dictionary<string, string> _refreshTokens = new();
    public void Save(string username, string refreshToken) =>
        _refreshTokens[username] = refreshToken;

    public string? Get(string username) =>
        _refreshTokens.TryGetValue(username, out var token) ? token : null;

    public void Remove(string username) =>
        _refreshTokens.Remove(username);
}




