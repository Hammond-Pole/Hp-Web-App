namespace Hp_Web_App.Client.AppConfiguration.ServiceInstaller;
public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}