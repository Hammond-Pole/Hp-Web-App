using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class QuestionField
{
    public int Id { get; set; }

    [ExcludeFromTable]
    public int DocumentId { get; set; }

    [ExcludeFromTable]
    public int QuestionFieldTypeId { get; set; }
    [Required]
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(250, ErrorMessage = "Desc is too long.")]
    public string Description { get; set; } = string.Empty;

    
    public QuestionFieldType QuestionFieldType { get; set; } // navigation property

    [ExcludeFromTable]
    public Document Document { get; set; } // navigation property

    [ExcludeFromTable]
    public ICollection<QuestionValue>? Values { get; set; } // navigation property

    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
}