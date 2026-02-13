using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();