using System.ComponentModel.DataAnnotations;

namespace PowHome.Models
{
    public class Login
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}