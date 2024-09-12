using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("food_Donations")] // name of the table

public class FoodDonations
{
    [Key]
    public int Id { get; set; }
    public required DateOnly DayOfDonation { get; set; }

    // Foreign Key
    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? AdoptionCenterId { get; set; }

    // conections Foreing
    [JsonIgnore]
    [ForeignKey("UserId")]
    public User? User { get; set; }

    [JsonIgnore]
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }

    [JsonIgnore]
    [ForeignKey("AdoptionCenterId")]
    public AdoptionCenter? AdoptionCenter { get; set; }

}
