namespace Hp_Web_App.Shared.Authentication;

public class UserSession
{
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Guid SessionId { get; set; } = Guid.NewGuid();
}