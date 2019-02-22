using System.ComponentModel;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    /// <summary>
    /// Base viewmodel class. Implements basic functionality that all viewmodels should share.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize the view model with no parameters.
        /// </summary>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Initialize the view model with a parameter.
        /// </summary>
        /// <param name="parameter">The parameter to use for initialization.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify any listeners that a property changed.
        /// </summary>
        /// <param name="property">The name of the changed property.</param>
        protected void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
