using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PowHome.Models;
[Table("animal_conditions")] // name of the table
public class AnimalCondition
{
    [Key]
    public int Id { get; set; }
    // foring key
    public required int AnimalId { get; set; }
    public required int ConditionId { get; set; }

    // conections Foreing
    [JsonIgnore]
    [ForeignKey("ConditionId")]
    public Condition Condition { get; set; }


    [JsonIgnore]
    [ForeignKey("AnimalId")]
    public Animal Animal { get; set; }
}
