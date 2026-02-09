using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Models;

namespace _2026_PinRu_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeder dengan format waktu UTC yang benar
            var seedDate = new DateTime(2026, 2, 9, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Budi Santoso", Email = "budi@mail.com", Phone = "08123456789", Address = "Jakarta", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 2, Name = "Siti Aminah", Email = "siti@mail.com", Phone = "08223456789", Address = "Surabaya", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 3, Name = "Andi Wijaya", Email = "andi@mail.com", Phone = "08323456789", Address = "Bandung", Status = "Inactive", CreatedDate = seedDate },
                new Customer { Id = 4, Name = "Dewi Lestari", Email = "dewi@mail.com", Phone = "08423456789", Address = "Medan", Status = "Active", CreatedDate = seedDate },
                new Customer { Id = 5, Name = "Eko Prasetyo", Email = "eko@mail.com", Phone = "08523456789", Address = "Semarang", Status = "Active", CreatedDate = seedDate }
            );
        }
    }
}