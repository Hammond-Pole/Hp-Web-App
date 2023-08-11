using Hp_Web_App.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Hp_Web_App.Shared.ClientFactories;

/// <summary>
/// Service for handling http clients
/// </summary>
public interface IHttpClientService
{
    /// <summary>
    /// Method to get access token asynchronously
    /// </summary>
    /// <returns>Access token string</returns>
    Task<string> GetAccessTokenAsync();

    /// <summary>
    /// Method to send registration email asynchronously for confirmation
    /// </summary>
    /// <param name="email">User email address</param>
    /// <param name="name">User name</param>
    /// <param name="token">Token for email validation</param>
    /// <returns>HttpResponseMessage object</returns>
    Task<HttpResponseMessage> SendRegistrationEmailAsync(string email, string name, string token);

    /// <summary>
    /// Method to send registration email asynchronously for training
    /// </summary>
    /// <param name="training">TrainingRequestModel object</param>
    /// <returns>HttpResponseMessage object</returns>
    Task<HttpResponseMessage> SendRegistrationEmailAsync(TrainingRequestModel training);
}

/// <summary>
/// Implementation for the HttpClientService interface
/// </summary>
public class HttpClientService : IHttpClientService
{
    private readonly IConfidentialClientApplication _app;
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _mountPath;
    private readonly string _baseUrl;
    private readonly string _InternalNotificationEmails0;
    private readonly string _InternalNotificationEmails1;

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
        _InternalNotificationEmails0 = config["SinglePage:InternalEmails0"]!;
        _InternalNotificationEmails1 = config["SinglePage:InternalEmails1"]!;
    }

    /// <summary>
    /// Method to get access token asynchronously
    /// </summary>
    /// <returns>Access token string</returns>
    public async Task<string> GetAccessTokenAsync()
    {
        // Acquire tokens for Graph API
        var scopes = new[] { "https://graph.microsoft.com/.default" };
        var authenticationResult = await _app.AcquireTokenForClient(scopes).ExecuteAsync();
        return authenticationResult.AccessToken;
    }

    /// <summary>
    /// Method to send registration email asynchronously for confirmation
    /// </summary>
    /// <param name="email">User email address</param>
    /// <param name="name">User name</param>
    /// <param name="token">Token for email validation</param>
    /// <returns>HttpResponseMessage object</returns>
    public async Task<HttpResponseMessage> SendRegistrationEmailAsync(string email, string name, string token)
    {
        var baseUrl = "users/noreply@hammondpole.co.za/sendmail";
        var client = _clientFactory.CreateClient("graph");
        var authenticationResult = await GetAccessTokenAsync();

        // Add authorization header with access token
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.ToString());

        // Read email template from file system
        var templatePath = _mountPath + @"/Templates/Registration.html";
        string htmlTemplate = File.ReadAllText(templatePath);

        // Replace placeholders with user details
        htmlTemplate = htmlTemplate.Replace("{{name}}", name);
        htmlTemplate = htmlTemplate.Replace("{{email}}", email);

        // Build Uri for email confirmation
        var path = "/validate/" + token.ToString();
        var uriBuilder = new UriBuilder(_baseUrl) { Path = path };

        // Build message payload
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

        // Send message and return HttpResponseMessage object
        var fullUrl = new UriBuilder(client.BaseAddress + baseUrl).ToString();
        var response = await client.PostAsync(fullUrl, content);

        return response;
    }

    /// <summary>
    /// Method to send registration email asynchronously for training requests to internal stackeholders
    /// </summary>
    /// <param name="training">TrainingRequestModel object</param>
    /// <returns>HttpResponseMessage object</returns>
    public async Task<HttpResponseMessage> SendRegistrationEmailAsync(TrainingRequestModel training)
    {
        var baseUrl = "users/property@hammondpole.co.za/sendmail";
        var client = _clientFactory.CreateClient("graph");
        var authenticationResult = await GetAccessTokenAsync();

        // Add authorization header with access token
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.ToString());

        // Read email template from file system
        var templatePath = _mountPath + @"/Templates/OrderTraining.html";
        string htmlTemplate = File.ReadAllText(templatePath);

        // Replace placeholders with user details
        htmlTemplate = htmlTemplate.Replace("{{name}}", training.Name);
        htmlTemplate = htmlTemplate.Replace("{{email}}", training.Email);
        htmlTemplate = htmlTemplate.Replace("{{surname}}", training.Surname);
        htmlTemplate = htmlTemplate.Replace("{{company}}", training.CompanyName);
        htmlTemplate = htmlTemplate.Replace("{{role}}", training.Role);
        htmlTemplate = htmlTemplate.Replace("{{telephone}}", training.TelephoneNumber);
        htmlTemplate = htmlTemplate.Replace("{{address}}", training.OfficeAddress);
        htmlTemplate = htmlTemplate.Replace("{{topic}}", training.Topic);

        // Build message payload
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
                            Address = _InternalNotificationEmails0
                        }
                    },
                    new
                    { 
                        EmailAddress = new
                        { 
                            Address = _InternalNotificationEmails1
                        }
                    }
                }
            },
            SaveToSentItems = false
        };

        var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");

        // Send message and return HttpResponseMessage object
        var fullUrl = new UriBuilder(client.BaseAddress + baseUrl).ToString();
        var response = await client.PostAsync(fullUrl, content);
        return response;
    }
}