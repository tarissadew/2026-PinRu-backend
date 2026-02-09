using System.ComponentModel.DataAnnotations;

namespace _2026_PinRu_backend.DTOs 
{
    // 1. DTO untuk input (Request)
    public class CustomerRequestDto
    {
        [Required(ErrorMessage = "Nama wajib diisi")] 
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email salah")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Address { get; set; }
        
        [RegularExpression("^(Active|Inactive)$", ErrorMessage = "Status hanya boleh Active atau Inactive")]
        public string Status { get; set; } = "Active";
    }

    // 2. DTO untuk output (Response) - Berada di file yang sama
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}