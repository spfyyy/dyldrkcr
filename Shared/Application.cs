using Shared.Models;
using Shared.ViewModels;

namespace Shared
{
    /// <summary>
    /// The current running state of the application.
    /// </summary>
    public static class Application
    {
        public static ApplicationViewModel ViewModel { get; set; } = new ApplicationViewModel();

        public static Session Session { get; set; }

        public static void Navigate<T>() where T : BaseViewModel, new()
        {
            ViewModel.CurrentViewModel = new T();
        }
    }
}
