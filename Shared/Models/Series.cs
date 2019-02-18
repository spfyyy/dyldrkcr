using Newtonsoft.Json;

namespace Shared.Models
{
    public class Series
    {
        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("series_id")]
        public string SeriesId { get; set; }

        [JsonProperty("etp_guid")]
        public string EtpGuid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("landscape_image")]
        public Images LandscapeImage { get; set; }

        [JsonProperty("portrait_image")]
        public Images PortraitImage { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
