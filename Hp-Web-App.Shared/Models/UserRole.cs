namespace Hp_Web_App.Shared.Models;

public class UserRole
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    #endregion

    #region Navigation Properties
    public ICollection<User>? Users { get; set; } // navigation property
    #endregion
}