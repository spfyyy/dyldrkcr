using Shared.ViewModels;
using System.Threading.Tasks;

namespace Shared
{
    public interface INavigation
    {
        Task Navigate<T>() where T : BaseViewModel;
        Task Navigate<T>(object parameter) where T : BaseViewModel;
        Task GoBack();
    }
}
