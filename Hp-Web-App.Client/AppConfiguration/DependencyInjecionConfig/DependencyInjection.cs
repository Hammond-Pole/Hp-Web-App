using Hp_Web_App.Client.AppConfiguration.ServiceInstaller;

namespace Hp_Web_App.Client.AppConfiguration.DependencyInjecionConfig;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices(
           this IServiceCollection services,
           IConfiguration configuration,
           params Assembly[] assemblies)
    {
        // Add all services from all assemblies
        var serviceInstallers = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IServiceInstaller>();

        // Install all services.
        foreach (var serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        var credentials = new DefaultAzureCredential();

        // Add a single client instance for the lifetime of the application
        services.AddSingleton<GraphServiceClient>(sp => {
            return new GraphServiceClient(credentials);
        });

        // Add the authentication state provider and the protected session storage.
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

        // Return the service collection.
        return services;

        // Function to identify if a type is assignable to another type.
        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo.AsType()) &&
            !typeInfo.IsInterface &&
            !typeInfo.IsAbstract;
    }
}
