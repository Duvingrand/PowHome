using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PowHome.Data;
using PowHome.Models;

namespace PowHome.Controllers.Users
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        // GET: api/Users/5
        [HttpGet("{keyword}")]
        public async Task<ActionResult<User>> GetUserByKeyword(string keyword)
        {
            return Ok("HOLA");
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            // Aquí deberías hash la contraseña antes de guardar
            // User.Password = HashPassword(User.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, User);
        }


        // PUT: api/Users
        // PUT method works with search Id
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] User userPut)
        {
            if (userPut.Id == 0)  // Verifica que el objeto tiene un ID válido
            {
                return BadRequest("El usuario debe tener un ID.");
            }

            _context.Entry(userPut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userPut.Id))
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

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }

}