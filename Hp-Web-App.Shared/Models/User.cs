using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string? Name { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Email is too long.")]
    // Add a validation with a message that if the Email is not a valid email it should show "Not a valid email".
    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public int UserRoleId { get; set; }
    [Required]
    public int CompanyId { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public Company? Company { get; set; } // navigation property
    public UserRole? UserRole { get; set; }
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
}
