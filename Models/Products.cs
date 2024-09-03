using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;

public class Products
{
    public int Id { get; set;}
    public string Name { get; set;}
    public double Price { get; set; }
    public string Description { get; set; }
    public double WeightKG { get; set; }
    public int Quantity { get; set; }

}
