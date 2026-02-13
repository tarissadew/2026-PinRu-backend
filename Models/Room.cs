namespace _2026_PinRu_backend.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}