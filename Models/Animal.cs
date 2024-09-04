using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowHome.Models;

[Table("animals")] // name of the table
public class Animal
{
    [Key]
    public int Id { get; set; }

    [MinLength(5, ErrorMessage = "the name field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the name field must be at most {1} chartes.")]
    public string Name { get; set; }

    [MinLength(5, ErrorMessage = "the Breed field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the Breed field must be at most {1} chartes.")]
    public string? Breed { get; set; }
    public required DateOnly BirthDate { get; set; }

    [MinLength(5, ErrorMessage = "the Description field must be at least {1} chartes.")]
    [MaxLength(300, ErrorMessage = "the Description field must be at most {1} chartes.")]
    public required string Description { get; set; }
    public required bool Sex { get; set; }

    [MinLength(1, ErrorMessage = "the Size field must be at least {1} chartes.")]
    [MaxLength(50, ErrorMessage = "the Size field must be at most {1} chartes.")]
    public required string Size { get; set; }

    [MinLength(5, ErrorMessage = "the Location field must be at least {1} chartes.")]
    [MaxLength(300, ErrorMessage = "the Location field must be at most {1} chartes.")]
    public required string Location { get; set; }

    // foring key
    public int? SpecieID { get; set; }
    public required string AdoptionCenterID { get; set; }

    // conections Foreing
    [ForeignKey("SpecieID")]
    public Specie specie { get; set; }

    [ForeignKey("AdoptionCenterID")]
    public AdoptionCenter adoptionCenter { get; set; }
}
