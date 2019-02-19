using System;
using System.Windows.Input;

namespace Shared.Utilities
{
    /// <summary>
    /// Useful utility class for implementing an ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Create an ICommand.
        /// </summary>
        /// <param name="canExecute">The <see cref="Func{T, TResult}"/> to run when checking if the command is executable.</param>
        /// <param name="execute">The <see cref="Action{T}"/> to run when when the command is executed.</param>
        public RelayCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
