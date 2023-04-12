using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class User
{
    // Primary Key
    [ExcludeFromTable]
    public int Id { get; set; }

    // User Properties
    [Required]
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50, ErrorMessage = "Email is too long.")]
    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [ExcludeFromTable]
    public string Password { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; }

    // Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int UserRoleId { get; set; }
    
    [Required]
    [ExcludeFromTable]
    public int CompanyId { get; set; }

    // Navigation Properties
    public Company Company { get; set; }
    public UserRole UserRole { get; set; }

    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
}
