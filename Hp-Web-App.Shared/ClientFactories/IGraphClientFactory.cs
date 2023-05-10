using Microsoft.Graph;

namespace Hp_Web_App.Shared.ClientFactories;

public interface IGraphClientFactory
{
    GraphServiceClient CreateClient(string clientId, string clientSecret, string tenantId);
}