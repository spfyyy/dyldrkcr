using Shared.Models;

namespace Shared.ViewModels
{
    public class QueueItemViewModel
    {
        public string ThumbnailUrl { get; set; }

        public int WatchPercentage { get; set; }

        public QueueItemViewModel(Queue.QueueItem item)
        {
            ThumbnailUrl = item.MostLikely.ScreenshotImage.FullUrl;
            var duration = (double)item.MostLikely.Duration;
            WatchPercentage = (int)(item.MostLikely.Playhead / duration * 100);
        }
    }
}
