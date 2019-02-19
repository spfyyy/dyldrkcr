using System;

namespace Shared.ViewModels
{
    public class LaunchPageViewModel : BaseViewModel
    {
        private readonly ISettings _settings;

        public LaunchPageViewModel(ISettings settings)
        {
            _settings = settings;
            StartSession();
        }

        private async void StartSession()
        {
            // Retrieve the device ID. Generate one if there isn't one yet.
            var deviceId = _settings.Get<string>(SettingsKey.DEVICE_ID);
            if (deviceId is null)
            {
                deviceId = Guid.NewGuid().ToString();
            }
            // Start a session.
            var authToken = _settings.Get<string>(SettingsKey.AUTH_TOKEN);
            Application.Session = await WebApi.StartSessionAsync(deviceId, authToken);
            _settings.Save(SettingsKey.AUTH_TOKEN, Application.Session.Data.Auth);
            if (authToken is null)
            {
                Application.Navigate<LoginPageViewModel>();
            }
            else
            {
                // Logged in. Go to queue?
            }
        }
    }
}
