using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("products")] // name of the table

public class Product
{
    [Key]
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = "the Name field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the Name field must be at most {1} chartes.")]
    public required string Name { get; set; }
    public required double Price { get; set; }

    [MinLength(5, ErrorMessage = "the Description field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the Description field must be at most {1} chartes.")]
    public required string Description { get; set; }
    public required double WeightKG { get; set; }
    public required int Quantity { get; set; }

}
