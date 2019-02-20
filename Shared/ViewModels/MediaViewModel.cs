using Shared.Models;
using System.Linq;

namespace Shared.ViewModels
{
    public class MediaViewModel
    {
        private readonly Media _media;

        public string Url { get; set; }

        public int WatchTime { get; set; }

        public string Id { get; set; }

        public MediaViewModel(Media media)
        {
            _media = media;
            Url = media.StreamData.Streams.First().Url;
            Id = media.MediaId;
        }
    }
}
