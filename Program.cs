using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. KONFIGURASI CORS: Mengizinkan Frontend (port 5173) mengakses API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173") // Alamat frontend kamu
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

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