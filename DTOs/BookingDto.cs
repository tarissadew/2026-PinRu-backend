using System;
using System.ComponentModel.DataAnnotations;

namespace _2026_PinRu_backend.DTOs
{
    public class BookingRequestDto
    {
        [Required]
        public int UserId { get; set; } 

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Remarks { get; set; }
    }

    public class BookingResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty; 
        public string RoomName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class UpdateStatusDto
    {
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}