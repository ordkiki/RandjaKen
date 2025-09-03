using Microsoft.EntityFrameworkCore;
using Ranjaken.Application.Commons.Extensions;
using RanjaKen.Api.Middleware;
using RanjaKen.Infrastructure.Commons.Extensions;
using RanjaKen.Infrastructure.Contexts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// CORS
string corsName = builder.Configuration["Cors:Policy"]!;
var corsOrigin = builder.Configuration.GetSection("Cors:Origin").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, policy =>
    {
        policy.WithOrigins(corsOrigin ?? Array.Empty<string>())
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
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
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<ExceptionHandling>();

app.UseCors(corsName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RanjaKen API V1");
        c.RoutePrefix = "swagger";// swagger à la racine
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
