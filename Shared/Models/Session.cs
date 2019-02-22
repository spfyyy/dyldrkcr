using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class Session
    {
        [JsonProperty("session_id")]
        public string Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("auth")]
        public string AuthorizationToken { get; set; }
    }
}
