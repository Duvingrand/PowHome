using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;
[Table("animal_conditions")] // name of the table

public class AnimalCondition
{
    // foring key
    public required int AnimalId { get; set; }
    public required int ConditionId { get; set; }


}
