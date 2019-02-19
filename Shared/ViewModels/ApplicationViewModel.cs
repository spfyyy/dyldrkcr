using Shared.Models;

namespace Shared.ViewModels
{
    /// <summary>
    /// The viewmodel for the application.
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public Session Session { get; set; }

        public void Navigate<T>() where T : BaseViewModel
        {
            CurrentViewModel = Ioc.Get<T>();
        }

        public void Start()
        {
            Navigate<LaunchPageViewModel>();
        }
    }
}
