using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class User
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Email is too long.")]
    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string Email { get; set; } = string.Empty;

    [ExcludeFromTable]
    public string Password { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    [ExcludeFromTable]
    public string? RegistrationKey { get; set; }

    [ExcludeFromTable]
    public DateTime RegistrationKeyExpires { get; set; }  = DateTime.Now.AddHours(24);
    public string Surname { get; set; } =string.Empty;
    public DateTime Dob { get; set; }

    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int UserRoleId { get; set; }

    [Required]
    [ExcludeFromTable]
    public int CompanyId { get; set; }
    #endregion

    #region Navigation Properties
    public Company Company { get; set; }
    public UserRole UserRole { get; set; }

    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; }
    #endregion
}
