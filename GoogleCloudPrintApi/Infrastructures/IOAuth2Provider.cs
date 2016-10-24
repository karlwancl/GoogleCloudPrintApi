using GoogleCloudPrintApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCloudPrintApi.Infrastructures
{
    interface IOAuth2Provider
    {
        string ClientId { get; }

        string ClientSecret { get; }

        string BuildAuthorizationUrl();

        Task<Token> GenerateRefreshTokenAsync(string authorizationCode);

        Task<Token> GenerateAccessTokenAsync(string refreshToken);
    }
}
