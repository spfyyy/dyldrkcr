using Shared.Utilities;
using System;

namespace Shared.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly ApplicationState _appState;
        private readonly ISettings _settings;
        private readonly INavigation _navigation;

        private bool _loggingIn = false;
        private bool LoggingIn
        {
            get { return _loggingIn; }
            set
            {
                _loggingIn = value;
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        private string _account = "";
        public string Account
        {
            get { return _account; }
            set
            {
                _account = value;
                NotifyPropertyChanged(nameof(Account));
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
                LoginCommand.NotifyCanExecuteChanged();
            }
        }

        private string _loginMessage = "";
        public string LoginMessage
        {
            get { return _loginMessage; }
            set
            {
                _loginMessage = value;
                NotifyPropertyChanged(nameof(LoginMessage));
            }
        }

        public RelayCommand LoginCommand { get; set; }

        public LoginPageViewModel(ApplicationState appState, ISettings settings, INavigation navigation)
        {
            _appState = appState;
            _settings = settings;
            _navigation = navigation;
            LoginCommand = new RelayCommand(CanLogin, Login);
        }

        private bool CanLogin(object _)
        {
            return Account.Length > 0 && Password.Length > 0 && !LoggingIn;
        }

        private async void Login(object _)
        {
            LoggingIn = true;
            LoginMessage = "";
            try
            {
                var login = await WebApi.LoginAsync(Account, Password, _appState.Session.Id);
                _settings.Save(SettingsKey.AUTH_TOKEN, login.AuthorizationToken);
                _appState.Session.User = login.User;
                await _navigation.Navigate<QueuePageViewModel>(null);
            }
            catch (Exception e)
            {
                LoginMessage = e.Message;
            }
            LoggingIn = false;
        }
    }
}
