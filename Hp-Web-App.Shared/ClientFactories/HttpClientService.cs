using Hp_Web_App.Shared.Migrations;
using Hp_Web_App.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Hp_Web_App.Shared.ClientFactories;

public interface IHttpClientService
{
    Task<string> GetAccessTokenAsync();
    Task<HttpResponseMessage> SendRegistrationEmailAsync(string email, string name, string token);
    Task<HttpResponseMessage> SendRegistrationEmailAsync(TrainingRequestModel training);
}

public class HttpClientService : IHttpClientService
{
    private readonly IConfidentialClientApplication _app;
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _mountPath;
    private readonly string _baseUrl;

    public HttpClientService(IHttpClientFactory clientFactory, IConfiguration config)
    {
        // Configure app builder
        var tenant = config.GetSection("AzureAd:TenantId").Value;
        var authority = $"https://login.microsoftonline.com/{tenant}";
        _app = ConfidentialClientApplicationBuilder
            .Create(config.GetSection("AzureAd:ClientId").Value)
                .WithClientSecret(config.GetSection("AzureAd:ClientSecret").Value)
                .WithAuthority(new Uri(authority))
                .Build();
        _clientFactory = clientFactory;
        _mountPath = config["FileShare"]!;
        _baseUrl = config["BaseUrl"]!;
    }

    public async Task<string> GetAccessTokenAsync()
    {
        // Acquire tokens for Graph API
        var scopes = new[] { "https://graph.microsoft.com/.default" };
        var authenticationResult = await _app.AcquireTokenForClient(scopes).ExecuteAsync();
        return authenticationResult.AccessToken;
    }

    public async Task<HttpResponseMessage> SendRegistrationEmailAsync(string email, string name, string token)
    {
        var baseUrl = "users/noreply@hammondpole.co.za/sendmail";
        var client = _clientFactory.CreateClient("graph");
        var authenticationResult = await GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.ToString());

        var templatePath = _mountPath + @"/Templates/Registration.html";
        

        string htmlTemplate = File.ReadAllText(templatePath);

        htmlTemplate = htmlTemplate.Replace("{{name}}", name);
        htmlTemplate = htmlTemplate.Replace("{{email}}", email);

        // Build the Uri from the current environment.
        var path = "/validate/" + token.ToString();
        var uriBuilder = new UriBuilder(_baseUrl)
        {
            Path = path
        };  
        
        htmlTemplate = htmlTemplate.Replace("{{url}}", uriBuilder.ToString());

        var message = new
        {
            Message = new
            {
                Subject = "Confirm your email address",
                Body = new
                {
                    ContentType = "Html",
                    Content = htmlTemplate
                },
                ToRecipients = new[]
                {
                    new
                    {
                        EmailAddress = new
                        {
                            Address = email
                        }
                    }
                }
            },
            SaveToSentItems = false
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
        var fullUrl = new UriBuilder(client.BaseAddress + baseUrl).ToString();
        var response = await client.PostAsync(fullUrl, content);

        response.EnsureSuccessStatusCode();

        return response;
    }


    public async Task<HttpResponseMessage> SendRegistrationEmailAsync(TrainingRequestModel training)
    {
        var baseUrl = "users/property@hammondpole.co.za/sendmail";
        var client = _clientFactory.CreateClient("graph");
        var authenticationResult = await GetAccessTokenAsync();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.ToString());

        var templatePath = _mountPath + @"/Templates/OrderTraining.html";


        string htmlTemplate = File.ReadAllText(templatePath);

        htmlTemplate = htmlTemplate.Replace("{{name}}", training.Name);
        htmlTemplate = htmlTemplate.Replace("{{email}}", training.Email);
        htmlTemplate = htmlTemplate.Replace("{{surname}}", training.Surname);
        htmlTemplate = htmlTemplate.Replace("{{company}}", training.CompanyName);
        htmlTemplate = htmlTemplate.Replace("{{role}}", training.Role);
        htmlTemplate = htmlTemplate.Replace("{{telephone}}", training.TelephoneNumber);
        htmlTemplate = htmlTemplate.Replace("{{address}}", training.OfficeAddress);
        htmlTemplate = htmlTemplate.Replace("{{topic}}", training.Topic);


        var message = new
        {
            Message = new
            {
                Subject = $"REAL ETSATE TRAINING REQUEST: {training.CompanyName}",
                Body = new
                {
                    ContentType = "Html",
                    Content = htmlTemplate
                },
                ToRecipients = new[]
                {
                    new
                    {
                        EmailAddress = new
                        {
                            Address = "alanj@hammondpole.co.za"
                        }
                    }
                }
            },
            SaveToSentItems = false
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
        var fullUrl = new UriBuilder(client.BaseAddress + baseUrl).ToString();
        var response = await client.PostAsync(fullUrl, content);

        response.EnsureSuccessStatusCode();

        return response;
    }

}