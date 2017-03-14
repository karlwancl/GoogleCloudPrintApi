using GoogleCloudPrintApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    interface IOAuth2Provider
    {
        string ClientId { get; }

        string ClientSecret { get; }

        string BuildAuthorizationUrl(string redirectUri = null);

        Task<Token> GenerateRefreshTokenAsync(string authorizationCode, string redirectUrl = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<Token> GenerateAccessTokenAsync(string refreshToken, CancellationToken cancellationToken = default(CancellationToken));
    }
}
