using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PinRu_backend.Data;
using _2026_PinRu_backend.Models;
using _2026_PinRu_backend.DTOs; 

namespace _2026_PinRu_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // 1. READ ALL (Melihat Semua Data)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDto>>> GetCustomers()
        {
            // Kita hanya mengambil data yang IsDeleted = false (Soft Delete)
            var customers = await _context.Customers
                .Where(c => !c.IsDeleted)
                .Select(c => new CustomerResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    Status = c.Status
                })
                .ToListAsync();

            return Ok(customers);
        }

        // 2. READ BY ID (Melihat 1 Data Detail)
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (customer == null)
            {
                return NotFound(new { message = "Customer tidak ditemukan." });
            }

            var response = new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Status = customer.Status
            };

            return Ok(response);
        }

        // 3. CREATE (Menambah Data Baru)
        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> PostCustomer(CustomerRequestDto request)
        {
            // Mapping dari DTO ke Entity
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                Status = request.Status,
                // CreatedDate otomatis menggunakan default UTC dari Model
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Mapping kembali ke Response DTO untuk dikembalikan ke user
            var response = new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Status = customer.Status
            };

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, response);
        }

        // 4. UPDATE (Mengubah Data)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerRequestDto request)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null || customer.IsDeleted)
            {
                return NotFound();
            }

            // Update field yang diperbolehkan saja
            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Phone = request.Phone;
            customer.Address = request.Address;
            customer.Status = request.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // 5. DELETE (Hapus Data - Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null || customer.IsDeleted)
            {
                return NotFound();
            }

            // Implementasi Soft Delete sesuai instruksi Tugas 9
            customer.IsDeleted = true;
            
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data berhasil dihapus (soft delete)." });
        }
    }
}