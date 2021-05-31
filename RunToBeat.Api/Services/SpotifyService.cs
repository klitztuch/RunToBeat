using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Implements <see cref="ISpotifyService"/>
    /// </summary>
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyAuthenticationService _spotifyAuthenticationService;
        private ClientCredentialsTokenResponse Token { get; set; }
        private SpotifyClient _spotifyClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spotifyAuthenticationService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SpotifyService(ISpotifyAuthenticationService spotifyAuthenticationService)
        {
            _spotifyAuthenticationService = spotifyAuthenticationService ?? throw new ArgumentNullException(nameof(spotifyAuthenticationService));
            Token = _spotifyAuthenticationService.GetRequestToken().Result;
            _spotifyClient = new SpotifyClient(Token.AccessToken);
        }

        public async Task<FullTrack> GetTrackById(string id)
        {
            var track = await _spotifyClient.Tracks.Get(id);
            return track;
        }
    }
}