using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
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
        /// <param name="authToken">If specified and valid, will start a logged in session.</param>
        /// <returns>An awaitable Crunchyroll <see cref="Session"/>.</returns>
        public static async Task<Session> StartSessionAsync(string deviceId, string authToken)
        {
            var encodedDeviceId = HttpUtility.UrlEncode(deviceId);
            var encodedAuth = authToken;
            if (authToken != null)
            {
                encodedAuth = HttpUtility.UrlEncode(authToken);
            }
            var url = $"https://api.crunchyroll.com/start_session.0.json?device_type=com.crunchyroll.windows.desktop&device_id={encodedDeviceId}&access_token=LNDJgOit5yaRIWN&auth={encodedAuth}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await WebRequestAsync<Response<Session>>(request);
            if (response.Error)
            {
                throw new Exception(response.Message);
            }
            return response.Data;
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
            var response = await WebRequestAsync<Response<Login>>(request);
            if (response.Error)
            {
                throw new Exception(response.Message);
            }
            return response.Data;
        }

        /// <summary>
        /// Get the watch queue for the user of the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID of the current user.</param>
        /// <returns>An awaitable Crunchyroll <see cref="List{QueueItem}"/>.</returns>
        public static async Task<List<QueueItem>> GetQueueAsync(string sessionId)
        {
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/queue.0.json?session_id={encodedSessionId}&fields=media.media_id%2Cmedia.name%2Cmedia.series_id%2Cmedia.series_name%2Cmedia.description%2Cmedia.premium_only%2Cmedia.screenshot_image%2Cmedia.episode_number%2Cmedia.duration%2Cmedia.playhead";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await WebRequestAsync<Response<List<QueueItem>>>(request);
            if (response.Error)
            {
                throw new Exception(response.Message);
            }
            return response.Data;
        }

        /// <summary>
        /// Get the media info/metadata using a media ID and a session ID.
        /// </summary>
        /// <param name="mediaId">The ID of the request media.</param>
        /// <param name="sessionId">The session ID of the current user. If the user is not premium, it will affect the number of streams returned. 0 if the video is premium-only.</param>
        /// <returns>An awaitable Crunchyroll <see cref="Media"/>.</returns>
        public static async Task<Media> GetMedia(string mediaId, string sessionId)
        {
            var encodedMediaId = HttpUtility.UrlEncode(mediaId);
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/info.0.json?media_id={encodedMediaId}&session_id={encodedSessionId}&fields=media.media_id%2Cmedia.name%2Cmedia.series_id%2Cmedia.series_name%2Cmedia.description%2Cmedia.premium_only%2Cmedia.screenshot_image%2Cmedia.episode_number%2Cmedia.duration%2Cmedia.playhead%2Cmedia.stream_data";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await WebRequestAsync<Response<Media>>(request);
            if (response.Error)
            {
                throw new Exception(response.Message);
            }
            return response.Data;
        }

        /// <summary>
        /// Update the watch time for a specific media item.
        /// </summary>
        /// <param name="mediaId">The ID of the media item.</param>
        /// <param name="seconds">The watch time, in seconds.</param>
        /// <param name="sessionId">The session ID of the current user.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public static async Task UpdatePlayhead(string mediaId, int seconds, string sessionId)
        {
            var encodedMediaId = HttpUtility.UrlEncode(mediaId);
            var encodedSessionId = HttpUtility.UrlEncode(sessionId);
            var url = $"https://api.crunchyroll.com/log.0.json?event=playback_status&media_id={encodedMediaId}&playhead={seconds}&session_id={encodedSessionId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await WebRequestAsync<Response<object>>(request);
            if (response.Error)
            {
                throw new Exception(response.Message);
            }
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
