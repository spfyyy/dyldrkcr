using Newtonsoft.Json;

namespace Shared.Models
{
    public class QueueItem
    {
        [JsonProperty("queue_entry_id")]
        public int Id { get; set; }

        [JsonProperty("ordering")]
        public int Order { get; set; }

        [JsonProperty("most_likely_media")]
        public Media Episode { get; set; }

        [JsonProperty("most_likely_media_playhead")]
        public int Playhead { get; set; }
    }
}
