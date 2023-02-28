namespace Hp_Web_App.Shared.Models
{
    public abstract class QuestionValue // base class
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int QuestionFieldID { get; set; }
        public DateTime? DateValueChanged { get; set; }
    }

    public class QuestionDateValue : QuestionValue // subclass
    {
        public DateTime? DateValue { get; set; }
    }

    public class QuestionStringValue : QuestionValue // subclass
    {
        public string? StringValue { get; set; }
    }
    public class QuestionBitValue : QuestionValue // subclass
    {
        public bool? BoolValue { get; set; }
    }
    public class QuestionIntValue : QuestionValue // subclass
    {
        public int IntValue { get; set; }
    }
    public class QuestionFloatValue : QuestionValue // subclass
    {
        public double FloatValue { get; set; }
    }
    public class QuestionMemoValue : QuestionValue // subclass
    {
        public string? MemoValue { get; set; }
    }
}
