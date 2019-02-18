namespace Shared.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string account;
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                NotifyPropertyChanged(nameof(Account));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }
    }
}
