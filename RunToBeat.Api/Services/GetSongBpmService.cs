using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetSongBpm.Net.Models;
using Microsoft.Extensions.Logging;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    public class GetSongBpmService : IBpmService
    {
        private readonly GetSongBpm.Net.GetSongBpm _getSongBpm;
        private readonly ILogger<GetSongBpmService> _logger;

        public GetSongBpmService(GetSongBpm.Net.GetSongBpm getSongBpm, ILogger<GetSongBpmService> logger)
        {
            _getSongBpm = getSongBpm ?? throw new ArgumentNullException(nameof(getSongBpm));
            _logger = logger;
            
        }

        public async Task<IEnumerable<Tempo>> GetTracksByBpm(string tempo)
        {
            var songsByTempo = await _getSongBpm.GetSongsByTempo(tempo);
            return songsByTempo.Select(o => o.ToTrackModel);
        }
    }
}