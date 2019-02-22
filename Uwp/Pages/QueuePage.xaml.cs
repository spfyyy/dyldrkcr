using Shared.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Uwp.Pages
{
    public sealed partial class QueuePage : Page
    {
        public QueuePage()
        {
            DataContext = Ioc.Resolve<QueuePageViewModel>();
            InitializeComponent();
        }
    }
}
