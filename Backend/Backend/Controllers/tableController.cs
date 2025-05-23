
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TableController(ApplicationDbContext context)
        {
            _context = context;

        }

        //GET: api/table/customers
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Person
                .Include(p => p.Country)
                .Include(p => p.Representative)
                .ToListAsync();
            return Ok(customers);
        }

        
    }
}


