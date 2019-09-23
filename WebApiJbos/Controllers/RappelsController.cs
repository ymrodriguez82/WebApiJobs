using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiJbos.Modele;
using WebApiJobs.Modele;

namespace WebApiJobs.Controllers
{
    [Route("api/rappel")]
    [ApiController]
    public class RappelsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public RappelsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rappels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rappel>>> GetRappel()
        {
            return await _context.Rappel.ToListAsync();
        }

        // GET: api/Rappels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rappel>> GetRappel(int id)
        {
            var rappel = await _context.Rappel.FindAsync(id);

            if (rappel == null)
            {
                return NotFound();
            }

            return rappel;
        }

        // PUT: api/Rappels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRappel(int id, Rappel rappel)
        {
            if (id != rappel.Id_rappel)
            {
                return BadRequest();
            }

            _context.Entry(rappel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RappelExists(id))
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

        // POST: api/Rappels
        [HttpPost]
        public async Task<ActionResult<Rappel>> PostRappel(Rappel rappel)
        {
            _context.Rappel.Add(rappel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRappel", new { id = rappel.Id_rappel }, rappel);
        }

        // DELETE: api/Rappels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rappel>> DeleteRappel(int id)
        {
            var rappel = await _context.Rappel.FindAsync(id);
            if (rappel == null)
            {
                return NotFound();
            }

            _context.Rappel.Remove(rappel);
            await _context.SaveChangesAsync();

            return rappel;
        }

        private bool RappelExists(int id)
        {
            return _context.Rappel.Any(e => e.Id_rappel == id);
        }
    }
}
