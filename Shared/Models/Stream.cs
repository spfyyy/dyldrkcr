using Newtonsoft.Json;

namespace Shared.Models
{
    public class Stream
    {
        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
