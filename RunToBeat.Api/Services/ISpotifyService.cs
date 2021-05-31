using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Interface for Spotify interaction
    /// </summary>
    public interface ISpotifyService
    {
        Task<FullTrack> GetTrackById(string id);
    }
}