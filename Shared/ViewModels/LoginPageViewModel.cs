using Shared.Utilities;

namespace Shared.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly ISettings _settings;

        private bool _loggingIn;
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

        public LoginPageViewModel(ISettings settings)
        {
            _settings = settings;
            LoginCommand = new RelayCommand(CanLogin, Login);
            LoggingIn = false;
        }

        public RelayCommand LoginCommand { get; set; }
        private bool CanLogin(object _)
        {
            return Account.Length > 0 && Password.Length > 0 && !LoggingIn;
        }
        private async void Login(object _)
        {
            LoggingIn = true;
            var login = await WebApi.LoginAsync(Account, Password, Application.Session.Data.SessionId);
            if (!login.Error)
            {
                _settings.Save(SettingsKey.AUTH_TOKEN, login.Data.Auth);
                Application.Session.Data.User = login.Data.User;
                Application.Navigate<QueuePageViewModel>();
            }
            else
            {
                LoggingIn = false;
            }
        }
    }
}
