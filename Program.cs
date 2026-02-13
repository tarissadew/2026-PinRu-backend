using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models;
using System.Text.Json;

// 1. Perbaikan Timestamp untuk PostgreSQL (Task 10)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// 2. Konfigurasi Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Konfigurasi Controllers & JSON Naming (Penting agar data terbaca Frontend)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Memastikan backend bisa membaca format camelCase dari React (Task 7)
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// 4. Konfigurasi CORS (Solusi Error di Console image_dacfbb)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddOpenApi();

var app = builder.Build();

// 5. Urutan Middleware (Sangat Menentukan agar tidak 404 - image_dae23f)
app.UseRouting();

// Aktifkan CORS tepat di atas MapControllers agar izin diberikan (Task 10)
app.UseCors("AllowFrontend"); 

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();