namespace Hp_Web_App.Client.AppConfiguration.Services;

public class InterfaceLayerInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IHelperFunctions, HelperFunctions>();
    }
}