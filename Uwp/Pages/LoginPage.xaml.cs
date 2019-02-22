using Shared.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Uwp.Pages
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            DataContext = Ioc.Resolve<LoginPageViewModel>();
            InitializeComponent();
        }
    }
}
