using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LPTKF.Infrastructure.Commands.Base {
    class Command : ICommand {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public virtual bool CanExecute(object parameter) {
            throw new NotImplementedException();
        }

        public virtual void Execute(object parameter) {
            throw new NotImplementedException();
        }
    }
}
