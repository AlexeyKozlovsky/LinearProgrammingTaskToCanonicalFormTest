using LPTKF.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.Infrastructure.Commands {
    class LambdaCommand : Command {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override void Execute(object parameter) => execute(parameter);
        public override bool CanExecute(object parameter) => canExecute(parameter);
    }
}
