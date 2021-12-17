using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogic.MVVM.ViewModel.Command
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute = null;
        public LambdaCommand(Action<object> Exucute, Func<object, bool> CanExecute = null)
        {
            _Execute = Exucute ?? throw new ArgumentNullException(nameof(Exucute));
            _CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        
        public override void Execute(object parameter) => _Execute(parameter);
        
    }
}
