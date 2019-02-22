using Newtonsoft.Json;
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
    }
}
