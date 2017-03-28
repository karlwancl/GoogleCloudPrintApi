using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCloudPrintApi.Models;
using System.Threading;

namespace GoogleCloudPrintApi.Infrastructures
{
    public abstract class GoogleClientBase
    {
        public GoogleClientBase(GoogleOAuth2ProviderBase oAuth2Provider, Token token)
        {
            if (oAuth2Provider == null)
                throw new ArgumentNullException(nameof(oAuth2Provider));
            _oAuth2Provider = oAuth2Provider;

            if (token == null || token.RefreshToken == null)
                throw new ArgumentNullException(nameof(token));
            _token = token;
        }

        protected GoogleOAuth2ProviderBase _oAuth2Provider;

        protected Token _token;

        public event EventHandler<Token> OnTokenUpdated;

        /// <summary>
        /// Update access token if it is expired
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Access token</returns>
        protected async Task UpdateTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_token.ExpireDateTime > DateTime.UtcNow.AddMinutes(-1))
                return;

            var nToken = await _oAuth2Provider.GenerateAccessTokenAsync(_token.RefreshToken, cancellationToken).ConfigureAwait(false);
            _token = new Token(nToken.AccessToken, nToken.TokenType, nToken.ExpiresIn, _token.RefreshToken, nToken.ExpireDateTime);
            OnTokenUpdated?.Invoke(this, _token);
        }

        /// <summary>
        /// Expose internal token for external web call
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Get internal token</returns>
        public async Task<Token> GetTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await UpdateTokenAsync(cancellationToken);
            return _token;
        }
    }
}
