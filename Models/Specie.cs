using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("species")] // name of the table

public class Specie
{
    [Key]
    public int Id { get; set;}
    
    [MinLength(5, ErrorMessage = "the Name field must be at least {1} chartes.")]
    [MaxLength(25, ErrorMessage = "the Name field must be at most {1} chartes.")]
    public required string Name { get; set;}

}
