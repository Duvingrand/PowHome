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
    public int Id { get; set;}
    public required string Name { get; set;}
    public required double Price { get; set; }
    public required string Description { get; set; }
    public required double WeightKG { get; set; }
    public required int Quantity { get; set; }

}
