using Newtonsoft.Json;

namespace Shared.Models
{
    public class Images
    {
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty("small_url")]
        public string SmallUrl { get; set; }

        [JsonProperty("medium_url")]
        public string MediumUrl { get; set; }

        [JsonProperty("large_url")]
        public string LargeUrl { get; set; }

        [JsonProperty("full_url")]
        public string FullUrl { get; set; }

        [JsonProperty("wide_url")]
        public string WideUrl { get; set; }

        [JsonProperty("widestar_url")]
        public string WideStarUrl { get; set; }

        [JsonProperty("fwide_url")]
        public string FWideUrl { get; set; }

        [JsonProperty("fwidestar_url")]
        public string FWideStarUrl { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
