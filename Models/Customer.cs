using System.ComponentModel.DataAnnotations;

namespace YourProjectName.Models
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

        public string Status { get; set; } = "Active"; // Active/Inactive

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Untuk Soft Delete (Opsional sesuai Task 9)
        public bool IsDeleted { get; set; } = false;
    }
}