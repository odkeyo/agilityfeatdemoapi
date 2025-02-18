using Microsoft.EntityFrameworkCore;
using Backend.Core.Interfaces;
using Backend.Data;
using Backend.Repositories;
using Backend.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var connectionString = "Data Source=database.sqlite";

// Verificar si la conexión es válida
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Error: La cadena de conexión a PostgreSQL no está configurada.");
}

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins(
            "http://localhost:3000", // Desarrollo local
            "https://calm-tree-00984470f.4.azurestaticapps.net" // Frontend en Azure
        )
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<TransactionService>();


var app = builder.Build();


// Habilitar Swagger en cualquier entorno, no solo en desarrollo
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Aplicar CORS antes de los middlewares de seguridad
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Modelo de WeatherForecast
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
