using Shared;
using Shared.ViewModels;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uwp
{
    public class UwpNavigation : INavigation
    {
        public async Task Navigate<T>() where T : BaseViewModel
        {
            var viewModel = NavigateToViewModel<T>();
            await viewModel.InitializeAsync();
        }

        public async Task Navigate<T>(object parameter) where T : BaseViewModel
        {
            var viewModel = NavigateToViewModel<T>();
            await viewModel.InitializeAsync(parameter);
        }

        public async Task GoBack()
        {
            var frame = Window.Current.Content as Frame;
            frame.GoBack();
            var viewModel = (frame.Content as Page).DataContext as BaseViewModel;
            await viewModel.InitializeAsync();
        }

        private Type PageType<T>() where T : BaseViewModel
        {
            var pageName = typeof(T).Name.Replace("ViewModel", "");
            var pageType = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == pageName).First();
            return pageType;
        }

        private BaseViewModel NavigateToViewModel<T>() where T : BaseViewModel
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(PageType<T>());
            var viewModel = (frame.Content as Page).DataContext as BaseViewModel;
            return viewModel;
        }
    }
}
