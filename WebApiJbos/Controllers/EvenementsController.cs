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
    [Route("api/evenement")]
    [ApiController]
    public class EvenementsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EvenementsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Evenements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evenement>>> GetEvenement()
        {
            return await _context.Evenement.ToListAsync();
        }

        // GET: api/Evenements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evenement>> GetEvenement(int id)
        {
            var evenement = await _context.Evenement.FindAsync(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return evenement;
        }

        // PUT: api/Evenements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenement(int id, Evenement evenement)
        {
            if (id != evenement.Id_evenement)
            {
                return BadRequest();
            }

            _context.Entry(evenement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
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

        // POST: api/Evenements
        [HttpPost]
        public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
        {
            _context.Evenement.Add(evenement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvenement", new { id = evenement.Id_evenement }, evenement);
        }

        // DELETE: api/Evenements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evenement>> DeleteEvenement(int id)
        {
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            _context.Evenement.Remove(evenement);
            await _context.SaveChangesAsync();

            return evenement;
        }

        private bool EvenementExists(int id)
        {
            return _context.Evenement.Any(e => e.Id_evenement == id);
        }
    }
}
