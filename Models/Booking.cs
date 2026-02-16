using System;

namespace _2026_PinRu_backend.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public required User User { get; set; }

        public int RoomId { get; set; }
        
        public required Room Room { get; set; }

        public string? RoomName { get; set; } 
        public string? CustomerName { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Status { get; set; } = "Pending";

        public string? Remarks { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}