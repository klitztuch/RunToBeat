using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunToBeat.Api.Services;
using SpotifyAPI.Web;

namespace RunToBeat.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly ILogger<SpotifyController> _logger;
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ILogger<SpotifyController> logger, ISpotifyService spotifyService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _spotifyService = spotifyService ?? throw new ArgumentNullException(nameof(spotifyService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<FullTrack>> Get(string id)
        {
            _logger.LogInformation("Getting Track by id {Id}", id);
            var track = await _spotifyService.GetTrackById(id);
            return Ok(track);
        }
    }
}