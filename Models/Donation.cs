using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;

public class Donation
{
    public int Id { get; set;}
    public int UserId { get; set;}
    public double Amount { get; set; }
    public DateOnly DayOfDonation { get; set; }

}
