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
        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
        public static readonly DependencyProperty UrlProperty = DependencyProperty.Register(nameof(Url), typeof(string), typeof(CrunchyrollPlayer), new PropertyMetadata(null, OnUrlChanged));

        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }
        public static readonly DependencyProperty VolumeProperty = DependencyProperty.Register(nameof(Volume), typeof(double), typeof(CrunchyrollPlayer), null);

        public int WatchTime
        {
            get { return (int)GetValue(WatchTimeProperty); }
            set { SetValue(WatchTimeProperty, value); }
        }
        public static readonly DependencyProperty WatchTimeProperty = DependencyProperty.Register(nameof(WatchTime), typeof(int), typeof(CrunchyrollPlayer), null);

        public bool StreamOpen
        {
            get { return (bool)GetValue(StreamOpenProperty); }
            set { SetValue(StreamOpenProperty, value); }
        }
        public static readonly DependencyProperty StreamOpenProperty = DependencyProperty.Register(nameof(StreamOpen), typeof(bool), typeof(CrunchyrollPlayer), new PropertyMetadata(true, OnStreamOpenChanged));

        public bool Playing
        {
            get { return (bool)GetValue(PlayingProperty); }
            set { SetValue(PlayingProperty, value); }
        }
        public static readonly DependencyProperty PlayingProperty = DependencyProperty.Register(nameof(Playing), typeof(bool), typeof(CrunchyrollPlayer), null);

        public ICommand EndedCommand
        {
            get { return (ICommand)GetValue(EndedCommandProperty); }
            set { SetValue(EndedCommandProperty, value); }
        }
        public static readonly DependencyProperty EndedCommandProperty = DependencyProperty.Register(nameof(EndedCommand), typeof(ICommand), typeof(CrunchyrollPlayer), null);

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

        private async void Player_PositionChanged(MediaPlaybackSession sender, object args)
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
                if (EndedCommand.CanExecute(null))
                {
                    EndedCommand.Execute(null);
                }
            });
        }

        private static void OnStreamOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = d as CrunchyrollPlayer;
            var open = (args.NewValue is null) ? false : (args.NewValue as bool?).Value;
            if (!open)
            {
                control.Player.IsFullWindow = false;
                control.Player.MediaPlayer.Pause();
                control.Player.MediaPlayer.Source = null;
            }
        }

        private static async void OnUrlChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var control = d as CrunchyrollPlayer;
            var url = args.NewValue as string;
            if (url is null)
            {
                control.Player.MediaPlayer.Source = null;
                control.Player.SetMediaPlayer(null);
                return;
            }
            var sourceResult = await AdaptiveMediaSource.CreateFromUriAsync(new Uri(url));
            var source = sourceResult.MediaSource;
            source.DesiredMinBitrate = source.AvailableBitrates.Max();
            var player = new MediaPlayer
            {
                Source = MediaSource.CreateFromAdaptiveMediaSource(source)
            };
            player.Volume = control.Volume;
            player.VolumeChanged += control.Player_VolumeChanged;
            player.PlaybackSession.PositionChanged += control.Player_PositionChanged;
            player.MediaEnded += control.Player_MediaEnded;
            control.Player.SetMediaPlayer(player);
            control.Player.MediaPlayer.Play();
        }
    }
}
