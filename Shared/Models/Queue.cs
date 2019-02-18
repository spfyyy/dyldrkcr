using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shared.Models
{
    public class Queue
    {
        [JsonProperty("data")]
        public List<QueueItem> Data { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class QueueItem
        {
            [JsonProperty("queue_entry_id")]
            public int QueueEntryId { get; set; }

            [JsonProperty("ordering")]
            public int Ordering { get; set; }

            [JsonProperty("series")]
            public Series Series { get; set; }

            [JsonProperty("playhead")]
            public int Playhead { get; set; }

            [JsonProperty("last_watched_media")]
            public Media LastWatched { get; set; }

            [JsonProperty("last_watched_media_playhead")]
            public int? LastWatchedPlayhead { get; set; }

            [JsonProperty("most_likely_media")]
            public Media MostLikely { get; set; }

            [JsonProperty("most_likely_media_playhead")]
            public int MostLikelyPlayhead { get; set; }
        }
    }
}
