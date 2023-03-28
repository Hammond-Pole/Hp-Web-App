namespace Hp_Web_App.Shared.Models;

public class DocumentsAttached
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime UploadDate { get; set; }
    public int DocumentId { get; set; }
    public int CompanyId { get; set; }
    public string? FileName { get; set; }
    public string? FileDescription { get; set; }
    public string? FileUrl { get; set; }
    public User? User { get; set; }
    public Company? Company { get; set; }
    public Document? Document { get; set; }

    public ICollection<QuestionValue>? QuestionValues { get; set; }
}
