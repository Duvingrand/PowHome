using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;

public class Sponsorshipment
{
    public int Id { get; set;}
    public double Amount { get; set; }
    public DateOnly Date { get; set; }
    public int UserId { get; set; }
    public int AnimalId { get; set; }
    public int AdoptionCenterId { get; set; }

}
