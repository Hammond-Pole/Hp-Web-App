namespace Hp_Web_App.Shared.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int UserRoleId { get; set; }
    public int CompanyId { get; set; }
    public bool IsActive { get; set; }
    public Company? Company { get; set; } // navigation property
    public UserRole? UserRole { get; set; }
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
}
