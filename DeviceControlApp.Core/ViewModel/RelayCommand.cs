using System;
using System.Windows.Input;

namespace DeviceControlApp.Core.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        private readonly Action<object> _executeParam;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _canExecute = canExecute ?? (() => true);
            _execute = execute;
        }

        public RelayCommand(Action<object> execute, Func<bool> canExecute = null)
        {
            _canExecute = canExecute ?? (() => true);
            _executeParam = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
            _executeParam?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}