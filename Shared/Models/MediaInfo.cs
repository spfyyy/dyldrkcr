using Newtonsoft.Json;

namespace Shared.Models
{
    public class MediaInfo
    {
        [JsonProperty("data")]
        public MediaInfoData Data { get; set; }

        [JsonProperty("debug")]
        public MediaInfoDebug Debug { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class MediaInfoData
        {
            [JsonProperty("stream_data")]
            public StreamData StreamData { get; set; }
        }

        public class MediaInfoDebug
        {
            [JsonProperty("to_data")]
            public double ToData { get; set; }
        }
    }
}
