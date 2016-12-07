using Flurl.Http;
using GoogleCloudPrintApi.Models;
using System.Threading.Tasks;
using Flurl;
using System.Threading;

namespace GoogleCloudPrintApi.Infrastructures
{
    // Reference: https://developers.google.com/identity/protocols/OAuth2WebServer
    public abstract class GoogleOAuth2ProviderBase : IOAuth2Provider
    {
        private const string GoogleOAuth2Uri = "https://accounts.google.com/o/oauth2/auth";
        private const string OAuth2RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        private const string OAuth2ResponseType = "code";
        private const string OAuth2ApprovalPromptForce = "force";
        private const string OAuth2AccessTypeOffline = "offline";

        private const string GoogleAccountOAuth2TokenUri = "https://accounts.google.com/o/oauth2/token";
        private const string OAuth2GrantTypeAuthCode = "authorization_code";

        private const string GoogleApiOAuth2TokenUri = "https://www.googleapis.com/oauth2/v3/token";
        private const string OAuth2GrantTypeRefreshToken = "refresh_token";

        public GoogleOAuth2ProviderBase(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        private string _clientId, _clientSecret;

        /// <summary>
        /// Client Id for oAuth2
        /// </summary>
        public string ClientId => _clientId;

        /// <summary>
        /// Client secret for oAuth2
        /// </summary>
        public string ClientSecret => _clientSecret;

        /// <summary>
        /// Define scope of the authorization
        /// </summary>
        protected abstract string Scope { get; }

        /// <summary>
        /// Get authorization url for google cloud print
        /// </summary>
        /// <param name="redirectUri">Redirect uri after authorization</param>
        /// <returns>Authorization url</returns>
        public string BuildAuthorizationUrl(string redirectUri = null)
        {
            return GoogleOAuth2Uri
                .SetQueryParam("redirect_uri", redirectUri ?? OAuth2RedirectUri)
                .SetQueryParam("response_type", OAuth2ResponseType)
                .SetQueryParam("client_id", _clientId)
                .SetQueryParam("scope", Scope)
                .SetQueryParam("approval_prompt", OAuth2ApprovalPromptForce)
                .SetQueryParam("access_type", OAuth2AccessTypeOffline)
                .ToString();
        }

        /// <summary>
        /// Get refresh token from authorization code
        /// </summary>
        /// <param name="authorizationCode">Authorization code</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Refresh token & access token</returns>
        public async Task<Token> GenerateRefreshTokenAsync(string authorizationCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GoogleAccountOAuth2TokenUri
                .PostUrlEncodedAsync(new
                {
                    code = authorizationCode,
                    client_id = _clientId,
                    client_secret = _clientSecret,
                    redirect_uri = OAuth2RedirectUri,
                    grant_type = OAuth2GrantTypeAuthCode
                }, cancellationToken)
                .ReceiveJson<Token>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get access token from refresh token
        /// </summary>
        /// <param name="refreshToken">Refresh token</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Refresh token & access token</returns>
        public async Task<Token> GenerateAccessTokenAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GoogleApiOAuth2TokenUri
                .PostUrlEncodedAsync( new
                {
                    client_id = _clientId,
                    client_secret = _clientSecret,
                    refresh_token = refreshToken,
                    grant_type = OAuth2GrantTypeRefreshToken
                }, cancellationToken)
                .ReceiveJson<Token>()
                .ConfigureAwait(false);
        }
    }
}