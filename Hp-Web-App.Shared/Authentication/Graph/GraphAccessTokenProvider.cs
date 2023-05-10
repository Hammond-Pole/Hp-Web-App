using Azure.Core;
using Microsoft.Kiota.Abstractions.Authentication;

namespace Hp_Web_App.Shared.Authentication.Graph;

public class GraphAccessTokenProvider : IAccessTokenProvider
{
    private readonly TokenCredential _credential;
    private readonly AllowedHostsValidator _allowedHostsValidator;

    public GraphAccessTokenProvider(TokenCredential credential)
    {
        _credential = credential;
        _allowedHostsValidator = new AllowedHostsValidator(new[] { "graph.microsoft.com" });
    }

    public AllowedHostsValidator AllowedHostsValidator => _allowedHostsValidator;

    public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        if (!_allowedHostsValidator.IsUrlHostValid(uri))
        {
            return string.Empty;
        }

        var tokenRequestContext = new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" });
        var token = await _credential.GetTokenAsync(tokenRequestContext, cancellationToken);
        return token.Token;
    }
}