namespace Hp_Web_App.Shared.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<QuestionField>? QuestionFields { get; set; } // navigation property
    }
}