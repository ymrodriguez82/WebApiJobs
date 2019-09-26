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
    [Route("api/offres")]
    [ApiController]
    public class OffresController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public OffresController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Offres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffre()
        {
            return await _context.Offre.ToListAsync();
        }

        // GET: api/Offres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offre>> GetOffre(string id)
        {
            var offre = await _context.Offre.FindAsync(id);

            if (offre == null)
            {
                return NotFound();
            }

            return offre;
        }

        // PUT: api/Offres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffre(string id, Offre offre)
        {
            if (id != offre.Id_offre)
            {
                return BadRequest();
            }

            _context.Entry(offre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffreExists(id))
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

        // POST: api/Offres
        [HttpPost]
        public async Task<ActionResult<int>> PostOffre(Offre offre)
        {
            int result;

            if (!OffreExists(offre.Id_offre))
            {
                _context.Offre.Add(offre);
                await _context.SaveChangesAsync();
                result = 1;

                // return CreatedAtAction("GetOffre", new { id = offre.Id_offre }, offre);
                return result;
            }
            result = 0;
            return result;
        }

        // DELETE: api/Offres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Offre>> DeleteOffre(string id)
        {
            var offre = await _context.Offre.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }

            _context.Offre.Remove(offre);
            await _context.SaveChangesAsync();

            return offre;
        }

        private bool OffreExists(string id)
        {
            return _context.Offre.Any(e => e.Id_offre == id);
        }
    }
}
