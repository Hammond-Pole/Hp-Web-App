namespace Hp_Web_App.Shared.Models
{
    public class CompanyDocument
    {
        public int DocumentId { get; set; }
        public int CompanyId { get; set; }

        public Document? Document { get; set; } // navigation property
        public Company? Company { get; set; } // navigation property
    }
}