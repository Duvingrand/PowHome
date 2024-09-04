using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("sponsor_shipments")] // name of the table

public class Sponsorshipment
{
    [Key]
    public int Id { get; set;}
    public required double Amount { get; set; }
    public required DateOnly Date { get; set; }

    // foring key
    public required int UserId { get; set; }
    public required int AnimalId { get; set; }
    public required int AdoptionCenterId { get; set; }

}
