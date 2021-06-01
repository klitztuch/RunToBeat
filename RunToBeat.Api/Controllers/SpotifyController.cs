using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunToBeat.Api.Services;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Controllers
{
    /// <summary>
    /// Implements a controller for Spotify interaction
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly ILogger<SpotifyController> _logger;
        private readonly ISpotifyService _spotifyService;

        /// <summary>
        /// Creates a new <see cref="SpotifyController"/>-object.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="spotifyService"></param>
        public SpotifyController(ILogger<SpotifyController> logger, ISpotifyService spotifyService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _spotifyService = spotifyService ?? throw new ArgumentNullException(nameof(spotifyService));
        }

        /// <summary>
        /// Gets a track by id.
        /// </summary>
        /// <param name="id">the track id</param>
        /// <returns>the full track</returns>
        [HttpGet]
        public async Task<ActionResult<FullTrack>> Get(string id)
        {
            _logger.LogInformation("Getting Track by id {Id}", id);
            var track = await _spotifyService.GetTrackById(id);
            return Ok(track);
        }
    }
}