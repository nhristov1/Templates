using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class RelayButton : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        private readonly Action<object> _executeWithParameter; 

        public RelayButton(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute; 
            _canExecute = canExecute; 
        }

        public RelayButton(Action<object> execute, Func<bool> canExecute = null)
        {
            _executeWithParameter = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value;  }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(); 
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute();
            else if (_executeWithParameter != null)
                _executeWithParameter(parameter); 
        }
    }
}
