using Azure.Identity;
using Hp_Web_App.Shared.Authentication.Graph;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Hp_Web_App.Shared.ClientFactories;

/// <summary>
/// Class that creates Graph Service Clients.
/// </summary>
public class GraphClientFactory : IGraphClientFactory
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GraphClientFactory"/> class.
    /// </summary>
    public GraphClientFactory()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="GraphServiceClient"/> class using the provided parameters.
    /// </summary>
    /// <param name="clientId">The Azure AD application client ID.</param>
    /// <param name="clientSecret">The Azure AD application client secret.</param>
    /// <param name="tenantId">The Azure AD tenant ID.</param>
    /// <returns>A new instance of the <see cref="GraphServiceClient"/> class.</returns>
    public GraphServiceClient CreateClient(string clientId, string clientSecret, string tenantId)
    {
        // Validate parameters.
        if (string.IsNullOrEmpty(clientId))
        {
            throw new ArgumentException(nameof(clientId));
        }

        if (string.IsNullOrEmpty(clientSecret))
        {
            throw new ArgumentException(nameof(clientSecret));
        }

        if (string.IsNullOrEmpty(tenantId))
        {
            throw new ArgumentException(nameof(tenantId));
        }

        // Setup the connection to Azure.
        var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

        // Get a token.
        var token = new GraphAccessTokenProvider(credential);

        // Set the authentication provider.
        var authProvider = new BaseBearerTokenAuthenticationProvider(token);

        // Create a new Graph client.
        GraphServiceClient graphClient = new GraphServiceClient(authProvider);

        return graphClient;
    }
}