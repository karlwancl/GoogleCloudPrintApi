using Newtonsoft.Json;
using System;

namespace GoogleCloudPrintApi.Models
{
    public class Token
    {
        [JsonConstructor]
        public Token(string access_token, string token_type, long expires_in, string refresh_token, DateTime? expire_datetime = null)
        {
            AccessToken = access_token;
            TokenType = token_type;
            ExpiresIn = expires_in;
            RefreshToken = refresh_token;
            // Calculate the expire datetime if token is generated, read the expire datetime if token is read from file
            ExpireDateTime = expire_datetime ?? DateTime.Now.AddSeconds(expires_in);
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
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// Expiration date time
        /// </summary>
        [JsonProperty("expire_datetime")]
        public DateTime ExpireDateTime { get; private set; }
    }
}