using Shared;
using System;
using Windows.Storage;

namespace Uwp
{
    /// <summary>
    /// UWP implementation of ISettings.
    /// </summary>
    public class UwpSettings : ISettings
    {
        private readonly ApplicationDataContainer _settings = ApplicationData.Current.LocalSettings;

        public T Get<T>(SettingsKey key) where T : class
        {
            var keyValue = GetKeyString(key);
            var result = _settings.Values[keyValue] as T;
            return result;
        }

        public void Save(SettingsKey key, object value)
        {
            var keyValue = GetKeyString(key);
            _settings.Values[keyValue] = value;
        }

        /// <summary>
        /// UWP settings are stored as key-value pairs, where the key is a string. This will return the string representation of the given key.
        /// </summary>
        /// <param name="key">The key to retrieve the string representation for.</param>
        /// <returns>The string representation of the requested key.</returns>
        private string GetKeyString(SettingsKey key)
        {
            switch (key)
            {
                case SettingsKey.DEVICE_ID:
                    return "device_id";
                case SettingsKey.AUTH_TOKEN:
                    return "auth_token";
            }
            throw new Exception($"{key} has no string value defined.");
        }
    }
}
