using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public class Session
    {
        [JsonProperty("data")]
        public SessionData Data { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class SessionData
        {
            [JsonProperty("session_id")]
            public string SessionId { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("device_type")]
            public string DeviceType { get; set; }

            [JsonProperty("device_id")]
            public string DeviceId { get; set; }

            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("auth")]
            public string Auth { get; set; }

            [JsonProperty("expires")]
            public DateTime? Expires { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("ops")]
            public List<string> Ops { get; set; }

            [JsonProperty("connectivity_type")]
            public string ConnectivityType { get; set; }

            [JsonProperty("debug")]
            public SessionDataDebug Debug { get; set; }

            public class SessionDataDebug
            {
                [JsonProperty("init_app")]
                public double InitApp { get; set; }

                [JsonProperty("parsed_url")]
                public double ParsedUrl { get; set; }

                [JsonProperty("auth_an_client")]
                public double AuthAnClient { get; set; }

                [JsonProperty("locale")]
                public double Locale { get; set; }

                [JsonProperty("selector_fields")]
                public double SelectorFields { get; set; }

                [JsonProperty("translations")]
                public double Translations { get; set; }

                [JsonProperty("pre_view")]
                public double PreView { get; set; }

                [JsonProperty("require_once")]
                public double RequireOnce { get; set; }

                [JsonProperty("get_session")]
                public double GetSession { get; set; }

                [JsonProperty("connectivity_type")]
                public double ConnectivityType { get; set; }

                [JsonProperty("device_registry")]
                public double DeviceRegistry { get; set; }

                [JsonProperty("api_auth")]
                public double ApiAuth { get; set; }

                [JsonProperty("ops")]
                public double Ops { get; set; }
            }
        }
    }
}
