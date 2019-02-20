using Newtonsoft.Json;

namespace Shared.Models
{
    public class MediaInfo
    {
        [JsonProperty("data")]
        public Media Data { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
