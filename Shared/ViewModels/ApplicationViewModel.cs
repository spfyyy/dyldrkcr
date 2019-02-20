using Shared.Models;
using Shared.Utilities;

namespace Shared.ViewModels
{
    /// <summary>
    /// The viewmodel for the application.
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        private readonly ISettings _settings;

        private MediaViewModel _currentMediaViewModel;
        public MediaViewModel CurrentMediaViewModel
        {
            get { return _currentMediaViewModel; }
            set
            {
                if (_currentMediaViewModel != null)
                {
                    var seconds = _currentMediaViewModel.WatchTime;
                    var id = _currentMediaViewModel.Id;
                    UpdateWatchTime(id, seconds);
                }
                _currentMediaViewModel = value;
                NotifyPropertyChanged(nameof(CurrentMediaViewModel));
            }
        }

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private double _volume;
        public double Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                _settings.Save(SettingsKey.VOLUME, value.ToString());
                NotifyPropertyChanged(nameof(Volume));
            }
        }

        public Session Session { get; set; }

        public RelayCommand CloseVideoCommand { get; set; }

        public ApplicationViewModel(ISettings settings)
        {
            _settings = settings;
            var storedVolume = _settings.Get<string>(SettingsKey.VOLUME);
            if (storedVolume is null)
            {
                storedVolume = "1";
            }
            Volume = double.Parse(storedVolume);
            CloseVideoCommand = new RelayCommand(CanCloseVideo, CloseVideo);
        }

        public void Navigate<T>() where T : BaseViewModel
        {
            CurrentViewModel = Ioc.Get<T>();
        }

        public void Start()
        {
            Navigate<LaunchPageViewModel>();
        }

        private bool CanCloseVideo(object _)
        {
            return true;
        }

        private void CloseVideo(object _)
        {
            CurrentMediaViewModel = null;
        }

        private async void UpdateWatchTime(string mediaId, int seconds)
        {
            await WebApi.UpdatePlayhead(mediaId, seconds, Session.Data.SessionId);
        }
    }
}
