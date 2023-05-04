﻿namespace Hp_Web_App.Shared.Models;

public class Document
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [Required]
    [StringLength(25, ErrorMessage = "Name is too long.")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(250, ErrorMessage = "Desc is too long.")]
    public string Description { get; set; } = string.Empty;
    #endregion

    #region Navigation Properties
    [ExcludeFromTable]
    public ICollection<QuestionField> QuestionFields { get; set; } // navigation property

    [ExcludeFromTable]
    public ICollection<CompanyDocument>? CompanyDocuments { get; set; } // navigation property
    
    [ExcludeFromTable]
    public ICollection<DocumentsAttached>? DocumentsAttached { get; set; } // navigation property
    #endregion
}