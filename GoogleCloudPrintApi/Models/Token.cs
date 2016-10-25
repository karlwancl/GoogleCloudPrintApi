using Newtonsoft.Json;
using System;

namespace GoogleCloudPrintApi.Models
{
    public class Token
    {
        [JsonConstructor]
        public Token(string access_token, string token_type, long expires_in, string refresh_token)
            : this(access_token, token_type, expires_in, refresh_token, DateTime.Now.AddSeconds(expires_in))
        {

        }

        public Token(string access_token, string token_type, long expires_in, string refresh_token, DateTime expireDateTime)
        {
            AccessToken = access_token;
            TokenType = token_type;
            ExpiresIn = expires_in;
            RefreshToken = refresh_token;
            ExpireDateTime = expireDateTime;
        }

        /// <summary>
        /// Access token for api call
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        /// <summary>
        /// Type of access token
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        /// <summary>
        /// Timespan of access token
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; private set; }

        /// <summary>
        /// Refresh token for access token renewal
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Expiration date time
        /// </summary>
        public DateTime ExpireDateTime { get; private set; }
    }
}