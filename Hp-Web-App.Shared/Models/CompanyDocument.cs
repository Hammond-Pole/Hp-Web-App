namespace Hp_Web_App.Shared.Models;

public class CompanyDocument
{
    [ExcludeFromTable]
    public int DocumentId { get; set; }
    
    [ExcludeFromTable]
    public int CompanyId { get; set; }

    public Document? Document { get; set; } // navigation property
    public Company? Company { get; set; } // navigation property
}