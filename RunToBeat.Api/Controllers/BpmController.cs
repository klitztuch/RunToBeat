using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunToBeat.Api.Model;
using RunToBeat.Api.Services;

namespace RunToBeat.Api.Controllers
{
    /// <summary>
    /// Implements a controller for bpm interaction
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BpmController : ControllerBase
    {
        private readonly ILogger<BpmController> _logger;
        private readonly IHappiDevMusicService _musicService;

        /// <summary>
        /// Creates a new <see cref="BpmController"/>-object.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="musicService"></param>
        public BpmController(ILogger<BpmController> logger, IHappiDevMusicService musicService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _musicService = musicService ?? throw new ArgumentNullException(nameof(musicService));
        }

        /// <summary>
        /// Gets a list of tracks by bpms
        /// </summary>
        /// <param name="bpm">the requested bpm</param>
        /// <returns>a list of tracks with the requested bpm</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackModel>>> GetTracksByBpm(string bpm)
        {
            _logger.LogInformation("Getting tracks for tempo {Bpm}", bpm);
            var tracks = await _musicService.GetTracksByBpm(bpm);
            if (!tracks.Any())
            {
                return NoContent();
            }

            return Ok(tracks);
        }
        
    }
}