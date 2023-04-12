using System.ComponentModel.DataAnnotations;

namespace Hp_Web_App.Shared.Models;

public abstract class QuestionValue
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public int QuestionFieldID { get; set; }
    public DateTime? DateValueChanged { get; set; }
    public int? DocumentsAttachedId { get; set; }
    public DocumentsAttached? DocumentsAttached { get; set; }
}

public class QuestionDateValue : QuestionValue
{
    public DateTime? DateValue { get; set; }
}

public class QuestionStringValue : QuestionValue
{
    [StringLength(255)]
    public string? StringValue { get; set; }
}
public class QuestionBitValue : QuestionValue
{
    public bool? BoolValue { get; set; }
}
public class QuestionIntValue : QuestionValue
{
    public int IntValue { get; set; }
}
public class QuestionFloatValue : QuestionValue
{
    public double FloatValue { get; set; }
}
public class QuestionMemoValue : QuestionValue
{
    public string? MemoValue { get; set; }
}