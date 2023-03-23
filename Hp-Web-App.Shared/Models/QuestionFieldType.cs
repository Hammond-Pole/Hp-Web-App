using System.ComponentModel.DataAnnotations.Schema;

namespace Hp_Web_App.Shared.Models
{
    public class QuestionFieldType
    {
        public int Id { get; set; }
        public string? SqlDataType { get; set; }
        public string? SystemType { get; set; }
        public string? DisplayName { get; set; }
        public string? ComponentName { get; set; }
        [NotMapped]
        public Type? ComponentType { get; set; }
        public ICollection<QuestionField>? QuestionFields { get; set; } // navigation property
    }
}
