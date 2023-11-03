using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hp_Web_App.Shared.Models;
public class Clients_Details
{
    #region Primary Key
    [Required]
    [ExcludeFromTable]
    public int Id { get; set; }
    #endregion

    #region User Properties
    [StringLength(25, ErrorMessage = "Hp reference is too long.")]
    public string HP_Reference { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Email is too long.")]
    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string Email { get; set; } = string.Empty;

    public DateTime SentDate { get; set; } = DateTime.Now.AddHours(24);

    [ExcludeFromTable]
    public string? RegistrationKey { get; set; }

    [ExcludeFromTable]
    public DateTime RegistrationKeyExpires { get; set; } = DateTime.Now.AddHours(24);
       
    #endregion  
}
