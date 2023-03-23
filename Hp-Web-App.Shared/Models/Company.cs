namespace Hp_Web_App.Shared.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CompanyTypeId { get; set; }
        public CompanyType? CompanyType { get; set; }  // navigation property
        public ICollection<CompanyDocument>? CompanyDocuments { get; set; } // navigation property
        public ICollection<User>? Users { get; set; } // navigation property
        public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
    }
}