using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowHome.Data;
using PowHome.Models;

namespace PowHome.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AuthController(MyDbContext context)
        {
            _context = context;
        }

        // Método para hacer hash de la contraseña
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

         // Método para verificar la contraseña hasheada
        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

                // POST: api/Users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  Login auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lógica para verificar el usuario
            var userfind = await _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email);
            bool password;

            if (userfind == null) // Asegúrate de que la función VerifyPassword compare las contraseñas correctamente
            {
                return Unauthorized("Usuario no encontrado");
            }else
            {
                password = VerifyPassword(auth.Password, userfind.Password);
            }

            if (!password)
            {
                return Unauthorized("Invalid email or password");
            }

            // Retornar una respuesta exitosa si la verificación es correcta
            return Ok(userfind);
        }
    }
}