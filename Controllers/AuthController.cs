using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;
using _2026_PinRu_backend.Data;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginData)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginData.Username && u.Password == loginData.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Username atau password salah" });
            }

            return Ok(new
            {
                fullName = user.FullName,
                role = user.Role
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Username == user.Username);
            if (existingUser)
            {
                return BadRequest(new { message = "Username sudah digunakan" });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registrasi berhasil", user.FullName });
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] string role)
        {
            var users = await _context.Users
                .Where(u => u.Role == role)
                .Select(u => new { u.Id, u.FullName, u.Username })
                .ToListAsync();

            return Ok(users);
        }
    }
}