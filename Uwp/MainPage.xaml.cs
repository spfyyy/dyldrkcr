using Shared;
using Shared.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Uwp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            // The data context needs to be set in code behind here, as it relies on the Ioc container.
            DataContext = Ioc.Get<ApplicationViewModel>();
            InitializeComponent();
        }
    }
}
