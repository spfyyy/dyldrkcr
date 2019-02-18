using Shared;
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
            var result = _settings.Values[key.ToString()] as T;
            return result;
        }

        public void Save(SettingsKey key, object value)
        {
            _settings.Values[key.ToString()] = value;
        }
    }
}
