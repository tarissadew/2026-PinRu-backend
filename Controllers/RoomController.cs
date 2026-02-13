using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models;

namespace _2026_PinRu_backend.Controllers
{
    [Route("api/[controller]")] // Ini akan membuat URL menjadi: api/Room
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        // Endpoint untuk mengambil semua data ruangan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // Endpoint untuk menambah ruangan (Solusi pesan Gagal Menambah Ruangan)
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom([FromBody] Room room)
        {
            if (room == null) return BadRequest();

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return Ok(room);
        }
    }
}