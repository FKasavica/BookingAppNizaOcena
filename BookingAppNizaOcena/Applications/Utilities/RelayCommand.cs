using System;
using System.Windows.Input;

namespace BookingAppNizaOcena.Utilities
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool>? canExecute = null) // Dodaj ? za canExecute
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); // Osiguraj da _execute nije null
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
