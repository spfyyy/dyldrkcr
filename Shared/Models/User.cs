using Newtonsoft.Json;

namespace Shared.Models
{
    public class User
    {
        [JsonProperty("user_id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
