using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Controllers.Auth;
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
                return BadRequest("El Id ingresado no es valido.");
            }

            return User;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            // Hash de la contraseña antes de guardar
            user.Password = AuthController.HashPassword(user.Password);

            // verifica que el email no este repetido
            if (EmailExists(user.Email))
            {
                return BadRequest("El correo electrónico ya está en uso.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/Users method works with search Id
        [HttpPut]
        public async Task<IActionResult> PutUser([FromBody] User userPut)
        {

            if (!UserExists(userPut.Id))  // Verifica que el objeto tiene un ID válido
            {
                return BadRequest("El Id ingresado no es valido.");
            }

            userPut.Password = AuthController.HashPassword(userPut.Password);
            _context.Entry(userPut).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return BadRequest("El Id ingresado no es valido.");
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // verifica que le user por medio del id no exista aun
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // verifica que el email ingresado exita o no exista
        private bool EmailExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }

    }

}