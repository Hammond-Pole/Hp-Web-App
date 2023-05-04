namespace Hp_Web_App.Client.AppConfiguration.Services;

public class AuthenticationAndSessionLayerInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ProtectedSessionStorage>();
    }
}