using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Implements <see cref="ISpotifyAuthenticationService"/>
    /// </summary>
    public class SpotifyAuthenticationService : ISpotifyAuthenticationService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        /// <summary>
        /// Creates an new instance of the <see cref="SpotifyAuthenticationService"/>-object.
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        public SpotifyAuthenticationService(string clientId, string clientSecret)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        }

        /// <inheritdoc />
        public async Task<ClientCredentialsTokenResponse> GetRequestToken()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(_clientId, _clientSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            return response;
        }
    }
}