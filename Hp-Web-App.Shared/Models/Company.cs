using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class Company
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;
    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int CompanyTypeId { get; set; }
    #endregion

    #region Navigation Properties
    public CompanyType CompanyType { get; set; }  // navigation property

    [ExcludeFromTable]
    public ICollection<CompanyDocument>? CompanyDocuments { get; set; } // navigation property

    [ExcludeFromTable]
    public ICollection<User>? Users { get; set; } // navigation property

    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
    #endregion
}