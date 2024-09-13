using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PowHome.Models;

[Table("conditions")] // name of the table

public class Condition
{
    [Key]
    public int Id { get; set; }

    [MinLength(4, ErrorMessage = "the Name field must be at least {1} chartes.")]
    [MaxLength(100, ErrorMessage = "the Name field must be at most {1} chartes.")]
    public required string Name { get; set; }
}
