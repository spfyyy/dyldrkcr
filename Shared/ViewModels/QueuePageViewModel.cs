using Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class QueuePageViewModel : BaseViewModel
    {
        private readonly ApplicationState _appState;
        private readonly INavigation _navigation;

        private List<MediaViewModel> _queue;
        public List<MediaViewModel> Queue
        {
            get { return _queue; }
            set
            {
                _queue = value;
                NotifyPropertyChanged(nameof(Queue));
            }
        }

        private MediaViewModel _selectedItem;
        public MediaViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
                WatchCommand.NotifyCanExecuteChanged();
            }
        }

        private bool _loadingQueue = false;
        public bool LoadingQueue
        {
            get { return _loadingQueue; }
            set
            {
                _loadingQueue = value;
                NotifyPropertyChanged(nameof(LoadingQueue));
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

        public RelayCommand WatchCommand { get; set; }

        public QueuePageViewModel(ApplicationState appState, INavigation navigation)
        {
            _appState = appState;
            _navigation = navigation;
            WatchCommand = new RelayCommand(CanWatch, Watch);
        }

        private bool CanWatch(object _)
        {
            return SelectedItem != null;
        }

        private async void Watch(object _)
        {
            await _navigation.Navigate<VideoPageViewModel>(SelectedItem.Id);
        }

        public override async Task InitializeAsync()
        {
            await InitializeAsync(null);
        }

        public override async Task InitializeAsync(object _)
        {
            LoadingQueue = true;
            ErrorMessage = "";
            try
            {
                var queue = await WebApi.GetQueueAsync(_appState.Session.Id);
                Queue = queue.Select(item => new MediaViewModel(item)).ToList();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            LoadingQueue = false;
        }
    }
}
