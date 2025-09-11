using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ranjaken.Application.Commons.Extensions;
using RanjaKen.Api.Middleware;
using RanjaKen.Infrastructure.Commons.Extensions;
using RanjaKen.Infrastructure.Contexts;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// CORS
string? corsName = builder.Configuration["Cors:Policy"];
string []? corsOrigin = builder.Configuration.GetSection("Cors:Origin").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, policy =>
    {
        policy.WithOrigins(corsOrigin ?? Array.Empty<string>())
              .AllowAnyMethod()
              .AllowCredentials()
              .AllowAnyHeader();
    });
});

// Database
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("RanjaKen.Api")
    )
);

// Dependency Injection
builder.Services.AddValidation();
builder.Services.AddApplication();

// Controllers + JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// 5. API Versioning
builder.Services.AddApiVersioning(options =>
{ 
    options.DefaultApiVersion = new ApiVersion(1, 0); // v1.0 par défaut
    options.AssumeDefaultVersionWhenUnspecified = true; // si pas précisé => v1
    options.ReportApiVersions = true; // ajoute "api-supported-versions" dans la réponse
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // format : v1, v2, ...
    options.SubstituteApiVersionInUrl = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionHandling>();

app.UseCors(corsName);

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RanjaKen API V1");
        c.RoutePrefix = "swagger";// swagger à la racine
    });
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers(); //Activation de la routage
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Appliquer automatiquement les migrations si la base n'existe pas
    dbContext.Database.Migrate();
}

//app.Run("http://192.168.0.123:5555");
app.Run();
