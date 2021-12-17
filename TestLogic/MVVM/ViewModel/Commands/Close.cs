using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestLogic.MVVM.ViewModel.Commands
{
    class Close : Command
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter) => DisplayMesseg();

        public void DisplayMesseg()
        {
            var res = 5+5;
            MessageBox.Show(res.ToString());
        }
    }
}
