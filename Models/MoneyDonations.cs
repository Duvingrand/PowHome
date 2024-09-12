using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("money_donations")] // name of the table

public class MoneyDonations
{
    [Key]
    public int Id { get; set; }
    public required double Amount { get; set; }
    public required DateOnly DayOfDonation { get; set; }

    // Foreign Key
    public required int UserId { get; set; }

    public int? AdoptionCenterId { get; set; }

    // conections Foreing
    [JsonIgnore]
    [ForeignKey("UserId")]
    public  User  User { get; set; }

    // conections Foreing
    [JsonIgnore]
    [ForeignKey("AdoptionCenterId")]
    public AdoptionCenter AdoptionCenter { get; set; }

}
