using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.DTOs; // Tambahkan namespace DTO

namespace _2026_PinRu_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Fitur Login (Task 10)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginData)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginData.Username && u.Password == loginData.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Username atau password salah" });
            }

            return Ok(new
            {
                userId = user.Id, // Tambahkan ID untuk kebutuhan Foreign Key Booking
                fullName = user.FullName,
                role = user.Role
            });
        }

        // 2. Fitur Registrasi (Task 10)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerData)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Username == registerData.Username);
            if (existingUser)
            {
                return BadRequest(new { message = "Username sudah digunakan" });
            }

            // Map DTO ke Model User
            var user = new User
            {
                Username = registerData.Username,
                Password = registerData.Password, // Ke depannya sebaiknya di-hash
                FullName = registerData.FullName,
                Role = registerData.Role ?? "Mahasiswa"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registrasi berhasil", fullName = user.FullName });
        }

        // 3. Ambil Daftar User (Untuk Master Customer)
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] string? role)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(role))
            {
                query = query.Where(u => u.Role == role);
            }

            // Gunakan UserResponseDto agar password tidak ikut terkirim
            var users = await query
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FullName = u.FullName,
                    Role = u.Role
                })
                .ToListAsync();

            return Ok(users);
        }
    }
}