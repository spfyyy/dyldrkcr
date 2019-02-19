using System;
using System.ComponentModel;

namespace Shared.ViewModels
{
    /// <summary>
    /// Base viewmodel class. Implements basic functionality that all viewmodels should share.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected ApplicationViewModel Application
        {
            get { return Ioc.Get<ApplicationViewModel>(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
