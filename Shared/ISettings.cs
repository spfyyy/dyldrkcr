namespace Shared
{
    /// <summary>
    /// Interface for accessing saved application settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Save a setting value for a given key.
        /// </summary>
        /// <param name="key">The key for the setting.</param>
        /// <param name="value">The new value of the setting.</param>
        void Save(SettingsKey key, object value);

        /// <summary>
        /// Retrieve the currently stored setting for a given key.
        /// </summary>
        /// <typeparam name="T">The type of value to retrieve.</typeparam>
        /// <param name="key">The key for the setting.</param>
        /// <returns>The value of the setting, null if setting hasn't been saved yet.</returns>
        T Get<T>(SettingsKey key) where T : class;
    }
}
