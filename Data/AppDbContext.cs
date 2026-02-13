using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;

namespace _2026_PinRu_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2026, 2, 9, 0, 0, 0, DateTimeKind.Utc);

            // 1. Seeder Customer (Data yang sudah ada)
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Budi Santoso", Email = "budi@mail.com", Phone = "08123456789", Address = "Jakarta", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 2, Name = "Siti Aminah", Email = "siti@mail.com", Phone = "08223456789", Address = "Surabaya", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 3, Name = "Andi Wijaya", Email = "andi@mail.com", Phone = "08323456789", Address = "Bandung", Status = "Inactive", CreatedDate = seedDate },
                new Customer { Id = 4, Name = "Dewi Lestari", Email = "dewi@mail.com", Phone = "08423456789", Address = "Medan", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 5, Name = "Eko Prasetyo", Email = "eko@mail.com", Phone = "08523456789", Address = "Semarang", Status = "Active", CreatedDate = seedDate }
            );

            // 2. Tambahkan Seeder Ruangan (Agar ada objek yang bisa dipinjam)
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Ruang Meeting A", Location = "Lantai 1", Capacity = 10, IsAvailable = true },
                new Room { Id = 2, Name = "Aula Utama", Location = "Lantai 2", Capacity = 100, IsAvailable = true },
                new Room { Id = 3, Name = "Laboratorium Komputer", Location = "Lantai 3", Capacity = 30, IsAvailable = true }
            );

            // 3. Tambahkan Seeder Booking (Data transaksi awal untuk testing)
            modelBuilder.Entity<Booking>().HasData(
                new Booking 
                { 
                    Id = 1, 
                    CustomerId = 1, 
                    RoomId = 1, 
                    BookingDate = seedDate, 
                    StartTime = seedDate.AddHours(9), 
                    EndTime = seedDate.AddHours(11), 
                    Status = "Approved", 
                    CreatedAt = seedDate 
                }
            );
        }
    }
}