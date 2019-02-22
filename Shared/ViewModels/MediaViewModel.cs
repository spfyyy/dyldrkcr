using Shared.Models;

namespace Shared.ViewModels
{
    public class MediaViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string SeriesId { get; set; }

        private string _thumbnailUrl;
        public string ThumbnailUrl
        {
            get { return _thumbnailUrl; }
            set
            {
                _thumbnailUrl = value;
                NotifyPropertyChanged(nameof(ThumbnailUrl));
            }
        }

        private string _episodeName;
        public string EpisodeName
        {
            get { return _episodeName; }
            set
            {
                _episodeName = value;
                NotifyPropertyChanged(nameof(EpisodeName));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        private string _seriesName;
        public string SeriesName
        {
            get { return _seriesName; }
            set
            {
                _seriesName = value;
                NotifyPropertyChanged(nameof(SeriesName));
            }
        }

        private int _watchPercentage;
        public int WatchPercentage
        {
            get { return _watchPercentage; }
            set
            {
                _watchPercentage = value;
                NotifyPropertyChanged(nameof(WatchPercentage));
            }
        }

        public MediaViewModel(Media media)
        {
            Id = media.Id;
            SeriesId = media.SeriesId;
            ThumbnailUrl = media.PremiumOnly ? media.ScreenshotImage.WidePremiumUrl : media.ScreenshotImage.WideUrl;
            EpisodeName = media.Name;
            Description = (media.Description.Length == 0) ? "No description." : media.Description;
            SeriesName = media.SeriesName;
            WatchPercentage = (int)((double)media.Playhead / media.Duration * 100);
        }

        public MediaViewModel(QueueItem item) : this(item.Episode)
        {
            WatchPercentage = (int)((double)item.Playhead / item.Episode.Duration * 100);
        }
    }
}
