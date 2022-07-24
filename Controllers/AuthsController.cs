using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Web_Api.Data;
using MVC_Web_Api.models;

namespace MVC_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Auths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auth>>> GetAuth()
        {
          if (_context.Auth == null)
          {
              return NotFound();
          }
            return await _context.Auth.ToListAsync();
        }

        // GET: api/Auths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> GetAuth(string id)
        {
          if (_context.Auth == null)
          {
              return NotFound();
          }
            var auth = await _context.Auth.FindAsync(id);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        // PUT: api/Auths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuth(string id, Auth auth)
        {
            if (id != auth.email)
            {
                return BadRequest();
            }

            _context.Entry(auth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthExists(id))
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

        // POST: api/Auths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auth>> PostAuth(Auth auth)
        {
          if (_context.Auth == null)
          {
              return Problem("Entity set 'DataContext.Auth'  is null.");
          }
            _context.Auth.Add(auth);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthExists(auth.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuth", new { id = auth.email }, auth);
        }

        // DELETE: api/Auths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuth(string id)
        {
            if (_context.Auth == null)
            {
                return NotFound();
            }
            var auth = await _context.Auth.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }

            _context.Auth.Remove(auth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthExists(string id)
        {
            return (_context.Auth?.Any(e => e.email == id)).GetValueOrDefault();
        }
    }
}
