using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PowHome.Models;
[Table("sponsorshipments")] // name of the table

public class Sponsorshipment
{
    [Key]
    public int Id { get; set; }
    public required double Amount { get; set; }
    public required DateOnly Date { get; set; }

    // foring key
    public required int UserId { get; set; }
    public required int AnimalId { get; set; }
    public required int AdoptionCenterId { get; set; }

    // conections Foreing
    [JsonIgnore]
    [ForeignKey("UserId")]
    public User User { get; set; }

    [JsonIgnore]
    [ForeignKey("AnimalId")]
    public Animal Animal { get; set; }

    [JsonIgnore]
    [ForeignKey("AdoptionCenterId")]
    public AdoptionCenter AdoptionCenter { get; set; }

}
