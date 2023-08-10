using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;
public class TrainingRequestModel
{
    #region Primary Key
    [Required]
    public int Id { get; set; }
    #endregion

    #region User Properties

    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(25, ErrorMessage = "Surname is too long.")]
    public string Surname { get; set; } = string.Empty;
     
    [StringLength(50, ErrorMessage = "Company Name is too long.")]
    public string CompanyName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Email is too long.")]
    [EmailAddress(ErrorMessage = "Not a valid email")]
    [Required]
    public string Email { get; set; }

    [RegularExpression(@"^(\+27|0)[1-8][0-9]{8}$", ErrorMessage = "Not a valid South African phone number")]
    public string TelephoneNumber { get; set; }


    public string OfficeAddress { get; set; }
    public string Topic { get; set; }
    #endregion
}