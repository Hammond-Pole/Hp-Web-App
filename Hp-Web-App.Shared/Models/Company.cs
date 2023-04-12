using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class Company
{

    [ExcludeFromTable]
    public int Id { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [ExcludeFromTable]
    public int CompanyTypeId { get; set; }
    public CompanyType CompanyType { get; set; }  // navigation property
    [ExcludeFromTable]
    public ICollection<CompanyDocument>? CompanyDocuments { get; set; } // navigation property
    [ExcludeFromTable]
    public ICollection<User>? Users { get; set; } // navigation property
    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
}