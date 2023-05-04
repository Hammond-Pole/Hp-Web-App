namespace Hp_Web_App.Shared.Models;

public class DocumentsAttached
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    public DateTime? UploadDate { get; set; } = DateTime.Now;
    
    [ExcludeFromTable]
    public string FileName { get; set; } = string.Empty;

    public string FileDescription { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;
    #endregion

    #region Foreign Keys
    [Required]
    [ExcludeFromTable]
    public int UserId { get; set; }

    [Required]
    [ExcludeFromTable]
    public int DocumentId { get; set; }

    [Required]
    [ExcludeFromTable]
    public int CompanyId { get; set; }
    #endregion

    #region Navigation Properties
    public User? User { get; set; }
    public Company? Company { get; set; }
    public Document? Document { get; set; }
    
    [ExcludeFromTable]
    public ICollection<QuestionValue>? QuestionValues { get; set; }
    #endregion
}