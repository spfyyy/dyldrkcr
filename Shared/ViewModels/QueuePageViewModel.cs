using System.Collections.Generic;
using System.Linq;

namespace Shared.ViewModels
{
    public class QueuePageViewModel : BaseViewModel
    {
        private List<QueueItemViewModel> _queue;
        public List<QueueItemViewModel> Queue
        {
            get { return _queue; }
            set
            {
                _queue = value;
                NotifyPropertyChanged(nameof(Queue));
            }
        }

        public QueuePageViewModel()
        {
            Fetch();
        }

        public async void Fetch()
        {
            var queue = await WebApi.GetQueueAsync(Application.Session.Data.SessionId);
            Queue = queue.Data.Select(q => new QueueItemViewModel(q)).ToList();
        }
    }
}
