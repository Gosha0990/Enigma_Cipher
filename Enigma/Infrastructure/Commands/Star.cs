using Enigma.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Infrastructure.Commands
{
    class Star : Command
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter) => Show();
        

        public void Show()
        {
            var res = new MainWindowViewModel();
            res.Star();
        }
    }
}
