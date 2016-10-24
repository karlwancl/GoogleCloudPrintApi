using GoogleCloudPrintApi.Helpers;
using GoogleCloudPrintApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    public abstract class GoogleOAuth2ProviderBase : IOAuth2Provider
    {
        const string GoogleOAuth2Uri = "https://accounts.google.com/o/oauth2/auth";
        const string OAuth2RedirectUri = "urn:ietf:wg:oauth:2.0:oob";
        const string OAuth2ResponseType = "code";
        const string OAuth2ApprovalPromptForce = "force";
        const string OAuth2AccessTypeOffline = "offline";

        const string GoogleAccountOAuth2TokenUri = "https://accounts.google.com/o/oauth2/token";
        const string OAuth2GrantTypeAuthCode = "authorization_code";

        const string GoogleApiOAuth2TokenUri = "https://www.googleapis.com/oauth2/v3/token";
        const string OAuth2GrantTypeRefreshToken = "refresh_token";

        public GoogleOAuth2ProviderBase(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        string _clientId, _clientSecret;

        /// <summary>
        /// Client Id for oAuth2
        /// </summary>
        public string ClientId =>  _clientId;

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
        /// <returns>Authorization url</returns>
        public string BuildAuthorizationUrl()
        {
            return (new UrlBuilder(GoogleOAuth2Uri))
                .Param("redirect", GoogleOAuth2Uri)
                .Param("response_type", OAuth2ResponseType)
                .Param("client_id", _clientId)
                .Param("scope", Scope)
                .Param("approval_propmpt", OAuth2ApprovalPromptForce)
                .Param("access_type", OAuth2AccessTypeOffline)
                .Build();
        }

        /// <summary>
        /// Get refresh token from authorization code
        /// </summary>
        /// <param name="authorizationCode">Authorization code</param>
        /// <returns>Refresh token & access token</returns>
        public async Task<Token> GenerateRefreshTokenAsync(string authorizationCode)
        {
            return await (new EasyRestClient(GoogleAccountOAuth2TokenUri))
                .Param("code", authorizationCode)
                .Param("client_id", _clientId)
                .Param("client_secret", _clientSecret)
                .Param("redirect_uri", OAuth2RedirectUri)
                .Param("grant_type", OAuth2GrantTypeAuthCode)
                .PostAsync<Token>();
        }

        /// <summary>
        /// Get access token from refresh token
        /// </summary>
        /// <param name="refreshToken">Refresh token</param>
        /// <returns>Refresh token & access token</returns>
        public async Task<Token> GenerateAccessTokenAsync(string refreshToken)
        {
            return await (new EasyRestClient(GoogleApiOAuth2TokenUri))
                .Param("client_id", _clientId)
                .Param("client_secret", _clientSecret)
                .Param("refresh_token", refreshToken)
                .Param("grant_type", OAuth2GrantTypeRefreshToken)
                .PostAsync<Token>();
        }
    }
}
