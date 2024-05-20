using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Note2Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Note2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Note2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note2>>> GetNote2()
        {
            return await _context.Note2.ToListAsync();
        }

        // GET: api/Note2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Note2>> GetNote2(long id)
        {
            var note2 = await _context.Note2.FindAsync(id);

            if (note2 == null)
            {
                return NotFound();
            }

            return note2;
        }

        // PUT: api/Note2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote2(long id, Note2 note2)
        {
            if (id != note2.Id)
            {
                return BadRequest();
            }

            _context.Entry(note2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Note2Exists(id))
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

        // POST: api/Note2
        [HttpPost]
        public async Task<ActionResult<Note2>> PostNote2(Note2 note2)
        {
            _context.Note2.Add(note2);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNote2), new { id = note2.Id }, note2);
        }

        // DELETE: api/Note2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote2(long id)
        {
            var note2 = await _context.Note2.FindAsync(id);
            if (note2 == null)
            {
                return NotFound();
            }

            _context.Note2.Remove(note2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Note2Exists(long id)
        {
            return _context.Note2.Any(e => e.Id == id);
        }
    }
}