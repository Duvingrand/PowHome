using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
