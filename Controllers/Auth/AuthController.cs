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
                    
             var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5154",
                audience: "http://localhost:5154",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userfind = await _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email);
            bool password;

            if (userfind == null)
            {
                return Unauthorized("Not founded user");
            }
            else
            {
                password = VerifyPassword(auth.Password, userfind.Password);
            }

            if (!password)
            {
                return Unauthorized("Invalid email or password");
            }

            var token = GenerateJwtToken(userfind);
            return Ok(new { Token = token });
        }

    }
}