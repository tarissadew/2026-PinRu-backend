using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Format email tidak valid (harus mengandung @)")] // Validasi Format
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = "Mahasiswa";
}