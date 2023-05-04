namespace Hp_Web_App.Shared.Models;

public class CompanyDocument
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int DocumentId { get; set; }

    [Required]
    [ExcludeFromTable]
    public int CompanyId { get; set; }
    #endregion

    #region Navigation Properties
    [ExcludeFromTable]
    public Document? Document { get; set; } // navigation property
    
    [ExcludeFromTable]
    public Company? Company { get; set; } // navigation property
    #endregion
}