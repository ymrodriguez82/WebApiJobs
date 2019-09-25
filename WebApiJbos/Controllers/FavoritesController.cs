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
    [Route("api/favorite")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public FavoritesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Favorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favoris>>> GetFavoris()
        {
            return await _context.Favoris.ToListAsync();
        }

        // GET: api/Favorites/5
        // Method qui obtient de la liste de favorit pour chaque candidat
        [HttpGet("fav/{id}")]
        public async Task<ActionResult<List<Favoris>>> GetFavorite(int id)
        {
            //var favorite = await _context.Favoris.FindAsync(id);
            var favorite = _context.Favoris.Where(x => x.Id_candidat == id).Include(x => x.Offre);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite.ToList();
        }

        // PUT: api/Favorites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favoris favorite)
        {
            if (id != favorite.Id_candidat)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        [HttpPost]
        public async Task<ActionResult<Favoris>> PostFavorite(Favoris favorite)
        {
            _context.Favoris.Add(favorite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriteExists(favorite.Id_candidat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavorite", new { id = favorite.Id_candidat }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Favoris>> DeleteFavorite(int id)
        {
            var favorite = await _context.Favoris.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favoris.Remove(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favoris.Any(e => e.Id_candidat == id);
        }
    }
}
