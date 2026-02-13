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

        // 1. Menampilkan daftar peminjaman (Task 3.1 & 3.2)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingResponseDto>>> GetBookings([FromQuery] string? status)
        {
            var query = _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(b => b.Status == status);
            }

            var bookings = await query.Select(b => new BookingResponseDto
            {
                Id = b.Id,
                CustomerName = b.Customer != null ? b.Customer.Name : "Unknown",
                RoomName = b.Room != null ? b.Room.Name : "Unknown",
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                Status = b.Status
            }).ToListAsync();

            return Ok(bookings);
        }

        // 2. Menambah data peminjaman (Task 1.1)
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(BookingRequestDto request)
        {
            if (request.StartTime >= request.EndTime)
            {
                return BadRequest("Waktu mulai harus sebelum waktu selesai.");
            }

            var booking = new Booking
            {
                CustomerId = request.CustomerId,
                RoomId = request.RoomId,
                BookingDate = DateTime.UtcNow,
                // Memastikan waktu disimpan sebagai UTC agar PostgreSQL tidak error
                StartTime = DateTime.SpecifyKind(request.StartTime, DateTimeKind.Utc),
                EndTime = DateTime.SpecifyKind(request.EndTime, DateTimeKind.Utc),
                Remarks = request.Remarks,
                Status = "Pending"
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Menggunakan nameof(GetBookings) agar tidak error CS0103 lagi
            return CreatedAtAction(nameof(GetBookings), new { id = booking.Id }, booking);
        }

        // 3. Mengubah status peminjaman (Task 2.2)
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            var validStatuses = new[] { "Pending", "Approved", "Rejected" };
            if (!validStatuses.Contains(newStatus))
            {
                return BadRequest("Status tidak valid.");
            }

            booking.Status = newStatus;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Status peminjaman berhasil diubah menjadi {newStatus}" });
        }

        // 4. Menghapus data peminjaman (Task 1.4)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}