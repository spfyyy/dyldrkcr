using System;
using Newtonsoft.Json;

namespace Shared.Models
{
    public class Login
    {
        [JsonProperty("data")]
        public LoginData Data { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public class LoginData
        {
            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("auth")]
            public string Auth { get; set; }

            [JsonProperty("expires")]
            public DateTime? Expires { get; set; }
        }
    }
}
