using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models;
using _2026_PinRu_backend.DTOs;

namespace _2026_PinRu_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Ambil daftar peminjaman (Task 3)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingResponseDto>>> GetBookings([FromQuery] string? status)
        {
            var query = _context.Bookings
                .Include(b => b.User) // Ganti dari Customer ke User
                .Include(b => b.Room)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(b => b.Status == status);
            }

            var bookings = await query.Select(b => new BookingResponseDto
            {
                Id = b.Id,
                // Mengambil nama dari tabel User
                CustomerName = b.User != null ? b.User.FullName : "Unknown", 
                RoomName = b.Room != null ? b.Room.Name : "Unknown",
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                Status = b.Status
            }).ToListAsync();

            return Ok(bookings);
        }

        // 2. Tambah data peminjaman (Task 8 & 10)
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(BookingRequestDto request)
        {
            if (request.StartTime >= request.EndTime)
            {
                return BadRequest("Waktu mulai harus sebelum waktu selesai.");
            }

            // Mencari objek User dan Room agar syarat 'required' terpenuhi
            var user = await _context.Users.FindAsync(request.UserId);
            var room = await _context.Rooms.FindAsync(request.RoomId);

            if (user == null || room == null)
            {
                return BadRequest("User atau Ruangan tidak ditemukan.");
            }

            var booking = new Booking
            {
                UserId = request.UserId, // Menggunakan UserId
                RoomId = request.RoomId,
                User = user, // Mengisi required member agar tidak error CS9035
                Room = room,
                BookingDate = DateTime.UtcNow,
                StartTime = DateTime.SpecifyKind(request.StartTime, DateTimeKind.Utc),
                EndTime = DateTime.SpecifyKind(request.EndTime, DateTimeKind.Utc),
                Remarks = request.Remarks,
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        // 3. Hapus data peminjaman
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 4. Update Status (Approve/Reject)
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto dto)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            var validStatuses = new[] { "Pending", "Approved", "Rejected" };
            if (!validStatuses.Contains(dto.Status))
            {
                return BadRequest("Status tidak valid.");
            }

            booking.Status = dto.Status;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Status peminjaman berhasil diubah menjadi {dto.Status}" });
        }
    }
}