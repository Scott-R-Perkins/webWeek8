using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webWeek8.Data;
using webWeek8.Models;

namespace webWeek8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TestDbContext _context;

        public TutorController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/Tutor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutor_1()
        {
          if (_context.Tutor_1 == null)
          {
              return NotFound();
          }
            return await _context.Tutor_1.ToListAsync();
        }

        // GET: api/Tutor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
          if (_context.Tutor_1 == null)
          {
              return NotFound();
          }
            var tutor = await _context.Tutor_1.FindAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            return tutor;
        }

        // PUT: api/Tutor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, Tutor tutor)
        {
            if (id != tutor.tutorId)
            {
                return BadRequest();
            }

            _context.Entry(tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tutor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(Tutor tutor)
        {
          if (_context.Tutor_1 == null)
          {
              return Problem("Entity set 'TestDbContext.Tutor_1'  is null.");
          }
            _context.Tutor_1.Add(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutor", new { id = tutor.tutorId }, tutor);
        }

        // DELETE: api/Tutor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            if (_context.Tutor_1 == null)
            {
                return NotFound();
            }
            var tutor = await _context.Tutor_1.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutor_1.Remove(tutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TutorExists(int id)
        {
            return (_context.Tutor_1?.Any(e => e.tutorId == id)).GetValueOrDefault();
        }
    }
}
