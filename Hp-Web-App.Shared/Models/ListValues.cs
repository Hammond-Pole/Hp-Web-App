using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;
public class ListValue
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    public string Value { get; set; }
    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int QuestionFieldId { get; set; }
    #endregion

    #region Navigation Properties
    public QuestionField QuestionField { get; set; }
    #endregion
}
