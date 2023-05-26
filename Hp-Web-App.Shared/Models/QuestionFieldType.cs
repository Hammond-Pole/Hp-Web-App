using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hp_Web_App.Shared.Models;

public class QuestionFieldType
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [ExcludeFromTable]
    public string SqlDataType { get; set; } = string.Empty;

    [ExcludeFromTable]
    public string SystemType { get; set; } = string.Empty;

    [Required]
    public string DisplayName { get; set; } = string.Empty;

    [ExcludeFromTable]
    public string ComponentName { get; set; } = string.Empty;

    [ExcludeFromTable]
    [NotMapped]
    public Type ComponentType { get; set; } = typeof(QuestionFieldType);
    #endregion

    #region Navigation Properties
    [ExcludeFromTable]
    public ICollection<QuestionField>? QuestionFields { get; set; } // navigation property
    #endregion
}