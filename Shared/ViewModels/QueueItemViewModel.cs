using Shared.Models;
using Shared.Utilities;
using System.Linq;

namespace Shared.ViewModels
{
    public class QueueItemViewModel : BaseViewModel
    {
        private readonly Media _episode;

        public string ThumbnailUrl { get; set; }

        public int WatchPercentage { get; set; }

        public string SeriesName { get; set; }

        public string EpisodeTitle { get; set; }

        public string Description { get; set; }

        public RelayCommand PlayCommand { get; set; }

        public QueueItemViewModel(Queue.QueueItem item)
        {
            _episode = item.MostLikely;
            var duration = (double)_episode.Duration;
            WatchPercentage = (int)(_episode.Playhead / duration * 100);
            ThumbnailUrl = _episode.PremiumOnly ? _episode.ScreenshotImage.FWideStarUrl : _episode.ScreenshotImage.FWideUrl;
            SeriesName = _episode.SeriesName;
            EpisodeTitle = $"Episode {_episode.EpisodeNumber} - {_episode.Name}";
            Description = _episode.Description;
            if (Description.Length == 0)
            {
                Description = "No description.";
            }
            PlayCommand = new RelayCommand(CanPlay, Play);
        }

        private bool CanPlay(object _)
        {
            return true;
        }

        private async void Play(object _)
        {
            var info = await WebApi.GetMediaInfo(_episode.MediaId, Application.Session.Data.SessionId);
            Application.CurrentMediaViewModel = new MediaViewModel(info.Data);
        }
    }
}
