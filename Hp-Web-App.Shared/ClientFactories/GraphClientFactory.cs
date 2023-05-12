using Azure.Identity;
using Hp_Web_App.Shared.Authentication.Graph;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Hp_Web_App.Shared.ClientFactories;

public class GraphClientFactory : IGraphClientFactory
{
    public GraphClientFactory()
    {
    }

    public GraphServiceClient CreateClient(string clientId, string clientSecret, string tenantId)
    {
        // Setup the connection to Azure.
        var managedIdentityCredential = new ManagedIdentityCredential();
        var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

        var credential = new ChainedTokenCredential(managedIdentityCredential, clientSecretCredential);

        // Get a token.
        var token = new GraphAccessTokenProvider(credential);

        // Set the authentication provider.
        var authProvider = new BaseBearerTokenAuthenticationProvider(token);

        GraphServiceClient graphClient = new GraphServiceClient(authProvider);

        return graphClient;
    }
}