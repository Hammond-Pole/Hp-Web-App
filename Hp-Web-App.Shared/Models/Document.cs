using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models
{
    public class Document
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Desc is too long.")]
        public string? Description { get; set; }
        public ICollection<QuestionField>? QuestionFields { get; set; } // navigation property
        public ICollection<CompanyDocument>? CompanyDocuments { get; set; } // navigation property
        public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
    }
}