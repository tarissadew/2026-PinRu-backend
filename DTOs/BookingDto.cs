using System.ComponentModel.DataAnnotations;

namespace _2026_PinRu_backend.DTOs
{
    // Digunakan saat user mengisi form pinjam ruangan
    public class BookingRequestDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Remarks { get; set; }
    }

    // Digunakan saat menampilkan daftar pinjaman di Frontend
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}