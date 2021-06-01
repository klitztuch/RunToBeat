using System.Collections.Generic;
using Newtonsoft.Json;

namespace RunToBeat.Api.Model
{
    public class HappiDevMusicResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("bpm")]
        public string Bpm { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("tracks")]
        public List<TrackModel> Result { get; set; }
    }
}