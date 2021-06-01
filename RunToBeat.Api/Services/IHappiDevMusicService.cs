using System.Collections.Generic;
using System.Threading.Tasks;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Interface for happi.dev Music Api
    /// </summary>
    public interface IHappiDevMusicService
    {
        /// <summary>
        /// Gets list of tracks by bpm.
        /// </summary>
        /// <param name="tempo">bpm for the tracks in the format "number-number"</param>
        /// <returns>tracks with the desired bpms</returns>
        Task<IEnumerable<TrackModel>> GetTracksByBpm(string tempo);
    }
}