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
        /// Get the watch queue for the user of the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID of the current user.</param>
        /// <returns>An awaitable Crunchyroll <see cref="Queue"/>.</returns>
        public static async Task<Queue> GetQueueAsync(string sessionId)
        {
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/queue.0.json?session_id={encodedSessionId}&fields=media.media_id%2Cmedia.name%2Cmedia.series_id%2Cmedia.series_name%2Cmedia.description%2Cmedia.premium_only%2Cmedia.screenshot_image%2Cmedia.available_time%2Cmedia.premium_available_time%2Cmedia.premium_available%2Cmedia.episode_number%2Cmedia.duration%2Cmedia.playhead";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var queue = await WebRequestAsync<Queue>(request);
            return queue;
        }

        /// <summary>
        /// Get the media info/metadata using a media ID and a session ID.
        /// </summary>
        /// <param name="mediaId">The ID of the request media.</param>
        /// <param name="sessionId">The session ID of the current user. If the user is not premium, it will affect the number of streams returned. 0 if the video is premium-only.</param>
        /// <returns>An awaitable Crunchyroll <see cref="MediaInfo"/>.</returns>
        public static async Task<MediaInfo> GetMediaInfo(string mediaId, string sessionId)
        {
            var encodedMediaId = HttpUtility.UrlEncode(mediaId);
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/info.0.json?media_id={encodedMediaId}&session_id={encodedSessionId}&fields=media.media_id%2Cmedia.name%2Cmedia.series_id%2Cmedia.series_name%2Cmedia.collection_id%2Cmedia.duration%2Cmedia.playhead%2Cmedia.stream_data%2Cmedia.bif_url%2Cmedia.episode_number";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var info = await WebRequestAsync<MediaInfo>(request);
            return info;
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
