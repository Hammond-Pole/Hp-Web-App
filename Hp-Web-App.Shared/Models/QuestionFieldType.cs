using System.ComponentModel.DataAnnotations.Schema;

namespace Hp_Web_App.Shared.Models;

public class QuestionFieldType
{

    [ExcludeFromTable]
    public int Id { get; set; }

    [ExcludeFromTable]
    public string SqlDataType { get; set; } = string.Empty;

    [ExcludeFromTable]
    public string SystemType { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    [ExcludeFromTable]
    public string ComponentName { get; set; } = string.Empty;

    [ExcludeFromTable]
    [NotMapped]
    public Type ComponentType { get; set; } = typeof(QuestionFieldType);

    [ExcludeFromTable]
    public ICollection<QuestionField>? QuestionFields { get; set; } // navigation property
}