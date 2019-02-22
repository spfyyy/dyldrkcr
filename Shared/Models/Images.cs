using Newtonsoft.Json;

namespace Shared.Models
{
    public class Images
    {
        /// <summary>
        /// May be portrait or landscape image.
        /// </summary>
        [JsonProperty("full_url")]
        public string FullUrl { get; set; }

        [JsonProperty("fwide_url")]
        public string WideUrl { get; set; }

        [JsonProperty("fwidestar_url")]
        public string WidePremiumUrl { get; set; }
    }
}
