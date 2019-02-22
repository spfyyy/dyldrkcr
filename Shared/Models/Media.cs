using Newtonsoft.Json;

namespace Shared.Models
{
    public class Media
    {
        [JsonProperty("media_id")]
        public string Id { get; set; }

        [JsonProperty("series_id")]
        public string SeriesId { get; set; }

        [JsonProperty("episode_number")]
        public string EpisodeNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("screenshot_image")]
        public Images ScreenshotImage { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("series_name")]
        public string SeriesName { get; set; }

        [JsonProperty("premium_only")]
        public bool PremiumOnly { get; set; }

        [JsonProperty("stream_data")]
        public StreamData StreamData { get; set; }

        [JsonProperty("playhead")]
        public int Playhead { get; set; }
    }
}
