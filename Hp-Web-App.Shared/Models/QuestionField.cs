using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models
{
    public class QuestionField
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int QuestionFieldTypeId { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Desc is too long.")]
        public string? Description { get; set; }
        public QuestionFieldType? QuestionFieldType { get; set; } // navigation property
        public Document? Document { get; set; } // navigation property
        public ICollection<QuestionValue>? Values { get; set; } // navigation property

        public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
    }
}