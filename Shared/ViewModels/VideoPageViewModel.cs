using Shared.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class VideoPageViewModel : BaseViewModel
    {
        private readonly ApplicationState _appState;
        private readonly ISettings _settings;
        private readonly INavigation _navigation;

        public string Id { get; set; }

        private bool _mediaLoading = true;
        public bool MediaLoading
        {
            get { return _mediaLoading; }
            set
            {
                _mediaLoading = value;
                NotifyPropertyChanged(nameof(MediaLoading));
                GoBackCommand.NotifyCanExecuteChanged();
            }
        }

        private string _streamUrl;
        public string StreamUrl
        {
            get { return _streamUrl; }
            set
            {
                _streamUrl = value;
                NotifyPropertyChanged(nameof(StreamUrl));
            }
        }

        private bool _streamOpen = true;
        public bool StreamOpen
        {
            get { return _streamOpen; }
            set
            {
                _streamOpen = value;
                NotifyPropertyChanged(nameof(StreamOpen));
            }
        }

        private int _position;
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyPropertyChanged(nameof(Position));
            }
        }

        private double _volume;
        public double Volume
        {
            get { return _volume; }
            set
            {
                _settings.Save(SettingsKey.VOLUME, value.ToString());
                _volume = value;
                NotifyPropertyChanged(nameof(Volume));
            }
        }

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }

        public RelayCommand GoBackCommand { get; set; }

        public RelayCommand EpisodeEndedCommand { get; set; }

        public VideoPageViewModel(ApplicationState appState, ISettings settings, INavigation navigation)
        {
            _appState = appState;
            _settings = settings;
            _navigation = navigation;
            GoBackCommand = new RelayCommand(CanGoBack, GoBack);
            EpisodeEndedCommand = new RelayCommand(CanEpisodeEnded, EpisodeEnded);
        }

        private bool CanGoBack(object _)
        {
            return !MediaLoading;
        }

        private async void GoBack(object _)
        {
            StreamOpen = false;
            await WebApi.UpdatePlayhead(Id, Position, _appState.Session.Id);
            await _navigation.GoBack();
        }

        private bool CanEpisodeEnded(object _)
        {
            return true;
        }

        private void EpisodeEnded(object arg)
        {
            GoBack(arg);
        }

        public override Task InitializeAsync()
        {
            throw new Exception("No media ID given.");
        }

        public override async Task InitializeAsync(object parameter)
        {
            Id = parameter as string;
            MediaLoading = true;
            try
            {
                var volumeSetting = _settings.Get<string>(SettingsKey.VOLUME);
                Volume = (volumeSetting is null) ? 0 : double.Parse(volumeSetting);
                var media = await WebApi.GetMedia(Id, _appState.Session.Id);
                var stream = media.StreamData.Streams.FirstOrDefault();
                if (stream is null)
                {
                    throw new Exception("Stream is unavailable");
                }
                StreamUrl = stream.Url;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            MediaLoading = false;
        }
    }
}
