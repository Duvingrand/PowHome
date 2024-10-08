using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowHome.Models;

[Table("adoption_centers")] // name of the table
public class AdoptionCenter
{
    [Key]
    public int Id { get; set; }

    [MinLength(2, ErrorMessage = "the name field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the name field must be at most {1} chartes.")]
    public required string Name { get; set; }

    [MinLength(5, ErrorMessage = "the Address field must be at least {1} chartes.")]
    [MaxLength(225, ErrorMessage = "the Address field must be at most {1} chartes.")]
    public required string Address { get; set; }

    [MinLength(5, ErrorMessage = "the Phone field must be at least {1} chartes.")]
    [MaxLength(25, ErrorMessage = "the Phone field must be at most {1} chartes.")]
    [DataType(DataType.PhoneNumber)]
    public required string Phone { get; set; }

    [EmailAddress(ErrorMessage = "the email is usuing an invalid format")]
    [MinLength(5, ErrorMessage = "the Email field must be at least {1} chartes.")]
    [MaxLength(100, ErrorMessage = "the Email field must be at most {1} chartes.")]
    public string? Email { get; set; }

}
