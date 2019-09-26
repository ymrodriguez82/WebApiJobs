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
        //Methode qui retourne la liste de Candidats avec ses favorites respectivament
        // GET: api/Candidat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidat>>> GetAll()
        {
            return await context.Candidat.Include(x => x.Favorites).ToListAsync();
        }
       
        // GET: api/Candidat/fav/5
        //Methode qui retourne les offres favorites d'un candidat
        [HttpGet("fav/{id}", Name = "GetFavorisById")]
        public async Task<ActionResult<CandidatFavoris>> GetFavorisById(int id)
        {
             var list = (from c in context.Candidat
                        join ord in context.Favoris on c.Id_candidat equals ord.Id_candidat into c_o
                        from t in c_o.DefaultIfEmpty()
                        join off in context.Offre on t.Id_offre equals off.Id_offre into f_o
                        from o in f_o.DefaultIfEmpty()
                        where t.Id_candidat == id
                        select new CandidatFavoris()
                        {
                            Titre = o.Titre,
                            Companie = o.Companie,
                            Location = o.Location,
                            Date_offre = o.Date_offre,
                            Descr = o.Descr,
                            Url = o.Url,
                            Postule = t.Postule,
                            Date_favoris = t.Date_favoris
                        }).
                        ToList();

            if (list == null)
            {
                return NotFound();
            }

            return new ObjectResult(list);
        }

        // POST: api/Candidat
        //Methode pour insere un nouveau candidat
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
        //Methode pour modifier les informations d'un candidat
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
        //Methode pour delete un candidat
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
