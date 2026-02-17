using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;

namespace _2026_PinRu_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2026, 2, 9, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "123", FullName = "Admin PinRu", Role = "Admin" },
                new User { Id = 2, Username = "tarissa", Password = "123", FullName = "Tarissa", Role = "Mahasiswa" }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Ruang Meeting A", Location = "Lantai 1", Capacity = 10, IsAvailable = true },
                new Room { Id = 2, Name = "Aula Utama", Location = "Lantai 2", Capacity = 100, IsAvailable = true },
                new Room { Id = 3, Name = "Laboratorium Komputer", Location = "Lantai 3", Capacity = 30, IsAvailable = true }
            );

            modelBuilder.Entity<Booking>().HasData(new
            {
                Id = 1,
                UserId = 1, 
                RoomId = 1, 
                BookingDate = seedDate,
                StartTime = seedDate.AddHours(9),
                EndTime = seedDate.AddHours(11),
                Status = "Approved",
                CreatedAt = seedDate
            });

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany()
                .HasForeignKey(b => b.RoomId);
        }
    }
}