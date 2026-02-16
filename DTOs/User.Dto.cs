using System.ComponentModel.DataAnnotations;

namespace _2026_PinRu_backend.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Username wajib diisi")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi")]
        [MinLength(3, ErrorMessage = "Password minimal 3 karakter")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama Lengkap wajib diisi")]
        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = "Mahasiswa"; 
    }

    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}