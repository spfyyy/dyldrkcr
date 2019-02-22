using Shared.Utilities;
using System;

namespace Shared.ViewModels
{
    public class LaunchPageViewModel : BaseViewModel
    {
        private readonly ApplicationState _appState;
        private readonly INavigation _navigation;
        private readonly ISettings _settings;

        private bool _startingSession = false;
        public bool StartingSession
        {
            get { return _startingSession; }
            set
            {
                _startingSession = value;
                NotifyPropertyChanged(nameof(StartingSession));
                StartSessionCommand.NotifyCanExecuteChanged();
            }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }

        public RelayCommand StartSessionCommand { get; set; }

        public LaunchPageViewModel(ApplicationState appState, INavigation navigation, ISettings settings)
        {
            _appState = appState;
            _navigation = navigation;
            _settings = settings;
            StartSessionCommand = new RelayCommand(CanStartSession, StartSession);
        }

        private bool CanStartSession(object _)
        {
            return !StartingSession;
        }

        private async void StartSession(object _)
        {
            ErrorMessage = "";
            StartingSession = true;
            try
            {
                //Retrieve the device ID. Generate one if there isn't one yet.
                var deviceId = _settings.Get<string>(SettingsKey.DEVICE_ID);
                if (deviceId is null)
                {
                    deviceId = Guid.NewGuid().ToString();
                    _settings.Save(SettingsKey.DEVICE_ID, deviceId);
                }
                // Start a session.
                var authToken = _settings.Get<string>(SettingsKey.AUTH_TOKEN);
                _appState.Session = await WebApi.StartSessionAsync(deviceId, authToken);
                _settings.Save(SettingsKey.AUTH_TOKEN, _appState.Session.AuthorizationToken);
                // If session is authenticated, go to queue. Otherwise go to login page.
                if (_appState.Session.User is null)
                {
                    await _navigation.Navigate<LoginPageViewModel>(null);
                }
                else
                {
                    await _navigation.Navigate<QueuePageViewModel>(null);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            StartingSession = false;
        }
    }
}
