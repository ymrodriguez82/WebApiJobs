using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiJbos.Modele;

namespace WebApIJbos.Controllers
{
    [Route("api/candidat")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public CandidatController(AplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Candidat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetAll()
        {
            return await context.Candidat.ToListAsync();
        }
       
        // GET: api/Candidat/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Candidat>> GetById(int id)
        {
            var candidat = await context.Candidat.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            return candidat;
        }

        // POST: api/Candidat
        [HttpPost]
        public async Task<ActionResult<Candidat>>Post([FromBody] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                context.Candidat.Add(candidat);
                await context.SaveChangesAsync();
                //Retour OK et un objet de tipo candidat, Alors on fait redirection au method GetById
                //return CreatedAtAction(nameof(GetById), new { id = candidat.Id }, candidat);
                return new CreatedAtRouteResult("GetById", new { id = candidat.Id_candidat }, candidat);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Candidat/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody] Candidat candidat)
        {
            if (id != candidat.Id_candidat)
            {
                return BadRequest();
            }
            context.Entry(candidat).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //IActionResult interface que permettre de retourner entre autres NotFound
            var candidat = await context.Candidat.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            context.Candidat.Remove(candidat);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
