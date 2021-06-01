using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RunToBeat.Api.Model;

namespace RunToBeat.Api.Services
{
    public class HappiDevMusicService : IHappiDevMusicService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public HappiDevMusicService(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<IEnumerable<TrackModel>> GetTracksByBpm(string tempo)
        {
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
            return tracks;
        }
    }
}