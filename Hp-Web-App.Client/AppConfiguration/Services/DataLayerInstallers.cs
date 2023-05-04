namespace Hp_Web_App.Client.AppConfiguration.Services;

public class DataLayerInstallers : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbWebAppContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
    }
}