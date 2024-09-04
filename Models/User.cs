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
    public int Id { get; set;}
    public required string Name { get; set;}
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }

}
