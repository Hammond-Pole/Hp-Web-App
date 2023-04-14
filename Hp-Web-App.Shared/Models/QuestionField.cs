using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public class QuestionField
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(250, ErrorMessage = "Description is too long.")]
    public string Description { get; set; } = string.Empty;

    public bool IsVisible { get; set; }
    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int DocumentId { get; set; }
 
    [Required]
    [ExcludeFromTable]
    public int QuestionFieldTypeId { get; set; }
   #endregion

    #region Navigation Properties
    public QuestionFieldType QuestionFieldType { get; set; }
    public Document Document { get; set; }

    [ExcludeFromTable]
    public ICollection<QuestionValue>? Values { get; set; }

    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; }
    #endregion
}