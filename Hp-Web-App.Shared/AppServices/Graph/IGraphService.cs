namespace Hp_Web_App.Shared.AppServices.Graph;

public interface IGraphService
{
    Task SendRegistrationEmail(string email, string name);
}