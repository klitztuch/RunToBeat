using System.Collections.Generic;
using System.Threading.Tasks;
using GetSongBpm.Net.Models;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Interface for happi.dev Music Api
    /// </summary>
    public interface IBpmService
    {
        /// <summary>
        /// Gets list of tracks by bpm.
        /// </summary>
        /// <param name="tempo">bpm for the tracks in the format "number-number"</param>
        /// <returns>tracks with the desired bpms</returns>
        Task<IEnumerable<Tempo>> GetTracksByBpm(string tempo);
    }
}