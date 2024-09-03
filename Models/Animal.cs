using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;

public class Animal
{
    public Guid Id { get; set; }
    public string Breed { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Description { get; set; }
    public bool Sex { get; set; }
    public string Name { get; set; }
    public string Size { get; set; }
    public int SpecieID { get; set; }
    public string AdoptionCenterID { get; set; }

}
