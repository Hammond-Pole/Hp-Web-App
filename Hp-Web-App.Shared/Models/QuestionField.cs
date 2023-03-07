namespace Hp_Web_App.Shared.Models
{
    public class QuestionField
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int QuestionFieldTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public QuestionFieldType QuestionFieldType { get; set; } // navigation property
        public Document Document { get; set; } // navigation property
        public ICollection<QuestionValue>? Values { get; set; } // navigation property
    }
}