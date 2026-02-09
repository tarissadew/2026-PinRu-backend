using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models; // Pastikan folder sudah kamu rename jadi Entities

var builder = WebApplication.CreateBuilder(args);

// Ganti ke PostgreSQL sesuai kebutuhan tugas (Task 6)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Fitur OpenAPI bawaan .NET terbaru (Lebih ringan dan jarang error bentrok)
builder.Services.AddOpenApi();

var app = builder.Build();

// Jalankan database update otomatis atau manual nanti
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    // Ini adalah pengganti SwaggerUI di versi .NET terbaru
    app.MapOpenApi();
}

app.Run();