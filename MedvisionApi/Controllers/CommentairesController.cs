using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedvisionApi.Models;

namespace MedvisionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly MedvisiondbContext _context;

        public CommentairesController(MedvisiondbContext context)
        {
            _context = context;
        }

        //get   post 

        // GET: api/Commentaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaires()
        {
          if (_context.Commentaires == null)
          {
              return NotFound();
          }
            return await _context.Commentaires.ToListAsync();
        }

        // GET: api/Commentaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
          if (_context.Commentaires == null)
          {
              return NotFound();
          }
            var commentaire = await _context.Commentaires.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }

        // GET: api/PostCommentaires/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetpostCommentaire(int id)
        {
            if (_context.Commentaires == null)
            {
                return NotFound();
            }
            var commentaire = await _context.Commentaires.Where(x => x.PostId ==id ).ToListAsync();

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }
  */
        // PUT: api/Commentaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (id != commentaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/Commentaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commentaire>> PostCommentaire(Commentaire commentaire)
        {
          if (_context.Commentaires == null)
          {
              return Problem("Entity set 'MedvisiondbContext.Commentaires'  is null.");
          }
            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentaire", new { id = commentaire.Id }, commentaire);
        }

        // DELETE: api/Commentaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaire(int id)
        {
            if (_context.Commentaires == null)
            {
                return NotFound();
            }
            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentaireExists(int id)
        {
            return (_context.Commentaires?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
