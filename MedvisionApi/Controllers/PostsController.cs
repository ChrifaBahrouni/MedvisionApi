using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedvisionApi.Models;
using Microsoft.Extensions.Hosting;

namespace MedvisionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly MedvisiondbContext _context;

        public PostsController(MedvisiondbContext context)
        {
            _context = context;
        }

        
        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            return await _context.Posts.ToListAsync();
        }
        // GET: api/Posts
        [HttpGet("detail/{id}")]
        public async Task<ActionResult<Post>> detailposts(int?  id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post =  _context.Posts
               .Include(p => p.User)
               .Include(p => p.Photos)
               .Include(p => p.Commentaires)
             .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return  post;
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<Post>> detailsposts(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Id cannot be null");
                }

                var post = await _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Photos)
                    .Include(p => p.Commentaires)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (post == null)
                {
                    return NotFound();
                }

                return post;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
          if (_context.Posts == null)
          {
              return NotFound();
          }
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
          if (_context.Posts == null)
          {
              return Problem("Entity set 'MedvisiondbContext.Posts'  is null.");
          }
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
