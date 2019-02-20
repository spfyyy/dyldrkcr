using Shared.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uwp.Controls
{
    /// <summary>
    /// A custom MediaPlayerElement wrapper for playing Crunchyroll streams.
    /// </summary>
    public sealed partial class CrunchyrollPlayer : UserControl
    {
        public MediaViewModel ViewModel
        {
            get { return (MediaViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel), typeof(MediaViewModel), typeof(CrunchyrollPlayer), new PropertyMetadata(null, OnViewModelChanged));

        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }
        public static readonly DependencyProperty VolumeProperty = DependencyProperty.Register(nameof(Volume), typeof(double), typeof(CrunchyrollPlayer), null);

        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(CrunchyrollPlayer), null);

        public int WatchTime
        {
            get { return (int)GetValue(WatchTimeProperty); }
            set { SetValue(WatchTimeProperty, value); }
        }
        public static readonly DependencyProperty WatchTimeProperty = DependencyProperty.Register(nameof(WatchTime), typeof(int), typeof(CrunchyrollPlayer), null);

        public CrunchyrollPlayer()
        {
            InitializeComponent();
        }

        private async void Player_VolumeChanged(MediaPlayer sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                Volume = sender.Volume;
            });
        }

        private async void PlaybackSession_PositionChanged(MediaPlaybackSession sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                WatchTime = (int)sender.Position.TotalSeconds;
            });
        }

        private async void Player_MediaEnded(MediaPlayer sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                if (CloseCommand != null && CloseCommand.CanExecute(null))
                {
                    CloseCommand.Execute(null);
                    Player.IsFullWindow = false;
                }
            });
        }

        private static async void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = d as CrunchyrollPlayer;
            var viewModel = args.NewValue as MediaViewModel;
            if (viewModel is null)
            {
                control.Player.MediaPlayer.Source = null;
                control.Player.SetMediaPlayer(null);
                return;
            }
            var sourceResult = await AdaptiveMediaSource.CreateFromUriAsync(new Uri(viewModel.Url));
            var source = sourceResult.MediaSource;
            source.DesiredMinBitrate = source.AvailableBitrates.Max();
            var player = new MediaPlayer
            {
                Source = MediaSource.CreateFromAdaptiveMediaSource(source)
            };
            player.Volume = control.Volume;
            player.VolumeChanged += control.Player_VolumeChanged;
            player.PlaybackSession.PositionChanged += control.PlaybackSession_PositionChanged;
            player.MediaEnded += control.Player_MediaEnded;
            control.Player.SetMediaPlayer(player);
            control.Player.MediaPlayer.Play();
        }

        private void UserControl_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CloseButton.Visibility = Visibility.Visible;
        }

        private void UserControl_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            CloseButton.Visibility = Visibility.Collapsed;
        }
    }
}
