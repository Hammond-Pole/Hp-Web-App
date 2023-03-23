namespace Hp_Web_App.Shared.Models
{
    public class CompanyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Company>? Companies { get; set; } // navigation property
    }
}