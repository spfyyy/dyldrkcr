using Shared.ViewModels;
using Windows.UI.Core.Preview;
using Windows.UI.Xaml.Controls;

namespace Uwp.Pages
{
    public sealed partial class VideoPage : Page
    {
        public VideoPage()
        {
            DataContext = Ioc.Resolve<VideoPageViewModel>();
            InitializeComponent();
            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += VideoPage_CloseRequested;
        }

        /// <summary>
        /// The <see cref="VideoPageViewModel"/> will only update watch playhead for a video when the video stream closes.
        /// This will capture when the user closes the app while watching a video. It can update the user's watch playhead before the app closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoPage_CloseRequested(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
        {
            var viewModel = DataContext as VideoPageViewModel;
            if (viewModel.EpisodeEndedCommand.CanExecute(null))
            {
                viewModel.EpisodeEndedCommand.Execute(null);
            }
        }
    }
}
