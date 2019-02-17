using Newtonsoft.Json;
using System;

namespace Shared.Models
{
    public class User
    {
        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("etp_guid")]
        public string EtpGuid { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("premium")]
        public string Premium { get; set; }

        [JsonProperty("is_publisher")]
        public bool IsPublisher { get; set; }

        [JsonProperty("access_type")]
        public string AccessType { get; set; }

        [JsonProperty("created")]
        public DateTime? Created { get; set; }
    }
}
