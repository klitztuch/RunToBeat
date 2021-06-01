using System.Collections.Generic;
using System.Threading.Tasks;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    public interface IHappiDevMusicService
    {
        Task<IEnumerable<TrackModel>> GetTracksByBpm(string tempo);
    }
}