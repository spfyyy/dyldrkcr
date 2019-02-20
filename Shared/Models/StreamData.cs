using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class StreamData
    {
        [JsonProperty("hardsub_lang")]
        public string SubtitleLanguage { get; set; }

        [JsonProperty("audio_lang")]
        public string AudioLanguage { get; set; }

        [JsonProperty("streams")]
        public List<Stream> Streams { get; set; }

        public class Stream
        {
            [JsonProperty("quality")]
            public string Quality { get; set; }

            [JsonProperty("expires")]
            public DateTime Expires { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
