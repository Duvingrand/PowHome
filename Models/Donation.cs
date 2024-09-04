using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("donations")] // name of the table

public class Donation
{
    [Key]
    public int Id { get; set; }
    public required double Amount { get; set; }
    public required DateOnly DayOfDonation { get; set; }

    // Foreign Key
    public required int UserId { get; set; }

    // conections Foreing
    [ForeignKey("UserId")]
    public  User  user { get; set; }

}
