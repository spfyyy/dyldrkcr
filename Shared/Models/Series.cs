using Newtonsoft.Json;

namespace Shared.Models
{
    public class Series
    {
        [JsonProperty("Id")]
        public string SeriesId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("landscape_image")]
        public Images LandscapeImage { get; set; }

        [JsonProperty("portrait_image")]
        public Images PortraitImage { get; set; }
    }
}
