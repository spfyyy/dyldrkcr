using Shared.Models;

namespace Shared.ViewModels
{
    public class QueueItemViewModel
    {
        public string ThumbnailUrl { get; set; }

        public int WatchPercentage { get; set; }

        public string SeriesName { get; set; }

        public string EpisodeTitle { get; set; }

        public string Description { get; set; }

        public QueueItemViewModel(Queue.QueueItem item)
        {
            ThumbnailUrl = item.MostLikely.ScreenshotImage.FullUrl;
            var duration = (double)item.MostLikely.Duration;
            WatchPercentage = (int)(item.MostLikely.Playhead / duration * 100);
            SeriesName = item.MostLikely.SeriesName;
            EpisodeTitle = $"Episode {item.MostLikely.EpisodeNumber} - {item.MostLikely.Name}";
            Description = item.MostLikely.Description;
            if (Description.Length == 0)
            {
                Description = "No description.";
            }
        }
    }
}
