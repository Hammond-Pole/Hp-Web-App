using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hp_Web_App.Shared.Models;

public abstract class QuestionValue
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    public DateTime DateValueChanged { get; set; }
    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int DocumentId { get; set; }

    [Required]
    [ExcludeFromTable]
    public int QuestionFieldID { get; set; }

    [Required]
    [ExcludeFromTable]
    public int DocumentsAttachedId { get; set; }
    #endregion

    #region Navigation Properties
    public DocumentsAttached DocumentsAttached { get; set; }
    public QuestionField QuestionField { get; set; }
    public Document Document { get; set; }

    public ICollection<QuestionValues>? QuestionValues { get; set; }
    #endregion
}

public class QuestionValues : QuestionValue
{
    public DateTime? DateValue { get; set; }

    [StringLength(255)]
    public string? StringValue { get; set; }

    public bool? BoolValue { get; set; }

    public int? IntValue { get; set; }

    public double? FloatValue { get; set; }

    public string? MemoValue { get; set; }

    [NotMapped]
    public object? ActualValue
    {
        get
        {
            if (DateValue.HasValue) return DateValue.Value;
            if (!string.IsNullOrEmpty(StringValue)) return StringValue;
            if (BoolValue.HasValue) return BoolValue.Value;
            if (IntValue.HasValue) return IntValue.Value;
            if (FloatValue.HasValue) return FloatValue.Value;
            if (!string.IsNullOrEmpty(MemoValue)) return MemoValue;
            return null;
        }
    }
}