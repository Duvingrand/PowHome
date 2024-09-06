using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("users")] // name of the table

public class User
{
    [Key]
    public int Id { get; set; }
    
    [MinLength(5, ErrorMessage = "the Name field must be at least {1} chartes.")]
    [MaxLength(25, ErrorMessage = "the Name field must be at most {1} chartes.")]
    public required string Name { get; set; }

    [MinLength(5, ErrorMessage = "the Phone field must be at least {1} chartes.")]
    [MaxLength(25, ErrorMessage = "the Phone field must be at most {1} chartes.")]
    [DataType(DataType.PhoneNumber)]
    public required string Phone { get; set; }

    
    [EmailAddress(ErrorMessage = "the email is usuing an invalid format")]
    [MinLength(5, ErrorMessage = "the Email field must be at least {1} chartes.")]
    [MaxLength(100, ErrorMessage = "the Email field must be at most {1} chartes.")]
    public required string Email { get; set; }

    [MinLength(5, ErrorMessage = "the Email field must be at least {1} chartes.")]
    [MaxLength(100, ErrorMessage = "the Email field must be at most {1} chartes.")]
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }  

}
