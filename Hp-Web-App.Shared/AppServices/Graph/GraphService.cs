using Hp_Web_App.Shared.ClientFactories;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;

namespace Hp_Web_App.Shared.AppServices.Graph;
public class GraphService : IGraphService
{
    private readonly IConfiguration _config;
    private readonly IGraphClientFactory _graphClient;

    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _tenantId;
    private readonly string _scopes;


    public GraphService(IConfiguration config, IGraphClientFactory graphClient)
    {
        _config = config;
        _graphClient = graphClient;

        _clientId = _config.GetSection("AzureAd:ClientId").Value!;
        _clientSecret = _config.GetSection("AzureAd:ClientSecret").Value!;
        _tenantId = _config.GetSection("AzureAd:TenantId").Value!;
        _scopes = _config.GetSection("AzureAd:Scopes").Value!;
    }

    public async Task SendRegistrationEmail(string email, string name)
    {
        var graphClient = _graphClient.CreateClient(_clientId, _clientSecret, _tenantId);

        string body = string.Empty;       

        string htmlTemplate = System.IO.File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}{@"\wwwroot\Templates\Registration.html"}");

        // Create an email message that uses the Assets.EmailTemplates.Registration.html template.
        var message = new Message
        {
            OdataType = "#microsoft.graph.message",
            Subject = "Confirm your email address",
            Body = new ItemBody
            {
                ContentType = BodyType.Html,
                Content = htmlTemplate
            },
            ToRecipients = new List<Recipient>
            {
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = email
                    }
                }
            }
        };

        // Prepare the request message with the message object.
        var sendMailPostRequestBody = new SendMailPostRequestBody
        {
            Message = message,
            SaveToSentItems = false
        };

        await graphClient.Users["noreply@hammondpole.co.za"].SendMail.PostAsync(sendMailPostRequestBody);
    }
}
