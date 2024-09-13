using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PowHome.Data;
using PowHome.Models;


namespace PowHome.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly string _jwtSecret;

        public AuthController(MyDbContext context)
        {
            _context = context;
            _jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "default_secret_key";
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

        // Método para generar un JWT
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    // Agrega más claims según sea necesario
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Ajusta el tiempo de expiración según tus necesidades
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            var userfind = await _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email);

            if (userfind == null || !VerifyPassword(auth.Password, userfind.Password))
            {
                return Unauthorized("Invalid email or password");
            }

            var token = GenerateJwtToken(userfind);
            return Ok(new { Token = token });
        }
    }
}