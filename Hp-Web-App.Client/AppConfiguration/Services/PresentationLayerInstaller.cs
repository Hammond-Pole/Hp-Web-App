namespace Hp_Web_App.Client.AppConfiguration.Services;

public class PresentationLayerInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddBlazoredModal();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }
}