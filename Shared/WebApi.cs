using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Shared
{
    public class WebApi
    {
        /// <summary>
        /// Retrieve a session ID to use for this session.
        /// </summary>
        /// <param name="deviceId">A GUID for this device. Can be generated if one isn't already saved.</param>
        /// <param name="auth">If specified and valid, will start a logged in session.</param>
        /// <returns>An awaitable Crunchyroll <see cref="Session"/>.</returns>
        public static async Task<Session> StartSessionAsync(string deviceId, string auth)
        {
            var encodedDeviceId = HttpUtility.UrlEncode(deviceId);
            var encodedAuth = auth;
            if (auth != null)
            {
                encodedAuth = HttpUtility.UrlEncode(auth);
            }
            var url = $"https://api.crunchyroll.com/start_session.0.json?device_type=com.crunchyroll.windows.desktop&device_id={encodedDeviceId}&access_token=LNDJgOit5yaRIWN&auth={encodedAuth}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var session = await WebRequestAsync<Session>(request);
            return session;
        }

        /// <summary>
        /// Log in and upgrade the given session ID to an authenticated one.
        /// </summary>
        /// <param name="account">The login name, either username or email.</param>
        /// <param name="password">The login password.</param>
        /// <param name="sessionId">The session ID to upgrade.</param>
        /// <returns>An awaitable Crunchyroll <see cref="Login"/>.</returns>
        public static async Task<Login> LoginAsync(string account, string password, string sessionId)
        {
            var encodedAccount = HttpUtility.UrlEncode(account);
            var encodedPassword = HttpUtility.UrlEncode(password);
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/login.0.json?account={encodedAccount}&password={encodedPassword}&session_id={encodedSessionId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var login = await WebRequestAsync<Login>(request);
            return login;
        }

        /// <summary>
        /// Helper method for sending a REST API request.
        /// </summary>
        /// <typeparam name="T">The type of object to try and parse from the response.</typeparam>
        /// <param name="request">The HTTP request.</param>
        /// <returns>An awaitable instance of <typeparamref name="T"/>.</returns>
        private static async Task<T> WebRequestAsync<T>(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(body);
                return result;
            }
        }
    }
}
