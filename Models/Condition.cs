using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("animal_conditions")] // name of the table

public class Condition
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }

}
