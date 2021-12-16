using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestLogic.MVVM.ViewModel.Base
{
    internal class PressButtonViewModel : ICommand
    {
        PressButton _buttonViewCommand;

        public PressButtonViewModel(PressButton viewModel)
        {
            _buttonViewCommand = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _buttonViewCommand.OnExecute();
        }
    }
}
