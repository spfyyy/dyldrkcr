using Newtonsoft.Json;
using System;

namespace Shared.Models
{
    public class Media
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("collection_id")]
        public string CollectionId { get; set; }

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

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("availability_notes")]
        public string AvailabilityNotes { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("series_name")]
        public string SeriesName { get; set; }

        [JsonProperty("premium_only")]
        public bool PremiumOnly { get; set; }

        [JsonProperty("playhead")]
        public int Playhead { get; set; }

        [JsonProperty("stream_data")]
        public StreamData StreamData { get; set; }
    }
}
