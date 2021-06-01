using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    /// <summary>
    /// Implements <see cref="IHappiDevMusicService"/>
    /// </summary>
    public class HappiDevMusicService : IHappiDevMusicService
    {
        private readonly ILogger<HappiDevMusicService> _logger;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public HappiDevMusicService(string baseUrl, string apiKey,ILogger<HappiDevMusicService> logger = null)
        {
            _logger = logger;
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<IEnumerable<TrackModel>> GetTracksByBpm(string tempo)
        {
            _logger.LogDebug("Getting track by bpms");
            var uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = _baseUrl,
                Path = $"music/bpm/playlist/{tempo}",
            };
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["apikey"] = _apiKey;
            query["limit"] = "50";

            uriBuilder.Query = query.ToString() ?? string.Empty;

            var client = new HttpClient();
            var response = client.GetAsync(uriBuilder.ToString()).Result;
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<HappiDevMusicResponseModel>(responseContent);
            var tracks = responseModel?.Result;
            _logger.LogDebug("Successfully received tracks");
            return tracks;
        }
    }
}