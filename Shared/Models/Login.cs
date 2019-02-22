using Newtonsoft.Json;

namespace Shared.Models
{
    public class Login
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("auth")]
        public string AuthorizationToken { get; set; }
    }
}
