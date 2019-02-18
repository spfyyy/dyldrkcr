using Newtonsoft.Json;
using System;

namespace Shared.Models
{
    public class Media
    {
        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("temp")]
        public string EtpGuid { get; set; }

        [JsonProperty("collection_id")]
        public string CollectionId { get; set; }

        [JsonProperty("collection_etp_guid")]
        public string CollectionEtpGuid { get; set; }

        [JsonProperty("series_id")]
        public string SeriesId { get; set; }

        [JsonProperty("series_etp_guid")]
        public string SeriesEtpGuid { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("episode_number")]
        public string EpisodeNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("screenshot_image")]
        public Images ScreenshotImage { get; set; }

        [JsonProperty("bif_url")]
        public string BifUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("clip")]
        public bool Clip { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("premium_available")]
        public bool PremiumAvailable { get; set; }

        [JsonProperty("free_available")]
        public bool FreeAvailable { get; set; }

        [JsonProperty("available_time")]
        public DateTime AvailableTime { get; set; }

        [JsonProperty("unavailable_time")]
        public DateTime UnavailableTime { get; set; }

        [JsonProperty("premium_available_time")]
        public DateTime PremiumAvailableTime { get; set; }

        [JsonProperty("premium_unavailable_time")]
        public DateTime PremiumUnavailableTime { get; set; }

        [JsonProperty("free_available_time")]
        public DateTime FreeAvailableTime { get; set; }

        [JsonProperty("free_unavailable_time")]
        public DateTime FreeUnavailableTime { get; set; }

        [JsonProperty("availability_notes")]
        public string AvailabilityNotes { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
