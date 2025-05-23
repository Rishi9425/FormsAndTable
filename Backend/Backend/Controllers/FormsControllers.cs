using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/forms
        [HttpGet]
        public async Task<IActionResult> GetForms()
        {
            var forms = await _context.Forms.ToListAsync();
            return Ok(forms);
        }

        // GET: api/forms/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null)
                return NotFound();
            return Ok(form);
        }

        // POST: api/forms
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] Forms form)
        {
            try
            {
                // Check model state for validation errors
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new {
                            Field = x.Key,
                            Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                        })
                        .ToArray();

                    return BadRequest(new { message = "Validation failed", errors });
                }

                _context.Forms.Add(form);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetForm), new { id = form.Id }, form);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while saving the form", error = ex.Message });
            }
        }

        // PUT: api/forms/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm(int id, [FromBody] Forms form)
        {
            if (id != form.Id)
                return BadRequest();

            _context.Entry(form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Forms.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/forms/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null)
                return NotFound();

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
