namespace _2026_PinRu_backend.DTOs 
{
    // DTO untuk input (Request) dari pengguna saat Create atau Update
    public class CustomerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Status { get; set; } = "Active";
    }

    // DTO untuk output (Response) yang dikirim ke pengguna
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}