using System;

namespace _2026_PinRu_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }
        
        // Relasi ke Customer yang sudah kamu buat sebelumnya
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // Relasi ke Ruangan
        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        // Sesuai tugas: Pengelolaan Status (misal: Pending, Approved, Rejected)
        public string Status { get; set; } = "Pending";
        
        public string? Remarks { get; set; } // Catatan tambahan
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}