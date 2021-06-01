using Newtonsoft.Json;

namespace RunToBeat.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TrackModel
    {
        [JsonProperty("bmp")]
        public int Bmp { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("id_track")]
        public int IdTrack { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("id_artist")]
        public int IdArtist { get; set; }

        [JsonProperty("id_album")]
        public int IdAlbum { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("haslyrics")]
        public bool Haslyrics { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("api_artist")]
        public string ApiArtist { get; set; }

        [JsonProperty("api_albums")]
        public string ApiAlbums { get; set; }

        [JsonProperty("api_album")]
        public string ApiAlbum { get; set; }

        [JsonProperty("api_tracks")]
        public string ApiTracks { get; set; }

        [JsonProperty("api_track")]
        public string ApiTrack { get; set; }

        [JsonProperty("api_lyrics")]
        public string ApiLyrics { get; set; }
    }
}