using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Interface for Spotify Authentication
    /// </summary>
    public interface ISpotifyAuthenticationService
    {
        /// <summary>
        /// Creates a new ClientCredentialsToken
        /// </summary>
        /// <returns></returns>
        Task<ClientCredentialsTokenResponse> GetRequestToken();
    }
}