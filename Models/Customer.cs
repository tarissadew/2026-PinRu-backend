using System.ComponentModel.DataAnnotations;

namespace _2026_PinRu_backend.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string Status { get; set; } = "Active";

        // Menggunakan DateTimeKind.Utc secara eksplisit agar sinkron dengan PostgreSQL
        public DateTime CreatedDate { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

        public bool IsDeleted { get; set; } = false;
    }
}