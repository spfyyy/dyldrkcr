using Shared.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Uwp.Pages
{
    public sealed partial class LaunchPage : Page
    {
        public LaunchPage()
        {
            DataContext = Ioc.Resolve<LaunchPageViewModel>();
            InitializeComponent();
        }
    }
}
