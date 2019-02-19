namespace Shared.ViewModels
{
    /// <summary>
    /// The viewmodel for the application.
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel = new LaunchPageViewModel();
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
