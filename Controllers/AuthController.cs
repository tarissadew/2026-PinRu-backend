using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.DTOs;

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

        // 1. LOGIN (Support Username atau Email)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginData)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => (u.Username == loginData.Username || u.Email == loginData.Username) 
                                     && u.Password == loginData.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Username/Email atau password salah" });
            }

            return Ok(new
            {
                userId = user.Id,
                fullName = user.FullName,
                role = user.Role
            });
        }

        // 2. REGISTER (Menyimpan Username & Email Terpisah)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerData)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Username == registerData.Username || u.Email == registerData.Email);
            if (existingUser)
            {
                return BadRequest(new { message = "Username atau Email sudah digunakan" });
            }

            var user = new User
            {
                Username = registerData.Username,
                Email = registerData.Email, 
                Password = registerData.Password,
                FullName = registerData.FullName,
                Role = registerData.Role ?? "Mahasiswa"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registrasi berhasil", fullName = user.FullName });
        }

        // 3. GET USERS (Menampilkan Email di Database Pengguna)
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] string? role)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(role))
            {
                query = query.Where(u => u.Role == role);
            }

            var users = await query
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email, 
                    FullName = u.FullName,
                    Role = u.Role
                })
                .ToListAsync();

            return Ok(users);
        }

        // 4. DELETE USER 
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = "User tidak ditemukan" });

            var userBookings = _context.Bookings.Where(b => b.UserId == id);
            _context.Bookings.RemoveRange(userBookings);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Akun dan seluruh riwayat pinjaman berhasil dihapus" });
        }
    }
}