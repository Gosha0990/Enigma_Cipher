using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestLogic.MVVM.ViewModel.Base;


namespace TestLogic.MVVM.ViewModel
{
    internal class PersonData : BaseViewModel
    {
        private string _name;

        public string Name
        {
            get => _name;
            set {
                _name = value;
                OnPropertyChenged();
            }
        }

        public PersonData()
        {
            
        }
        public void Test()
        {
            var t = "Test";
            Name = t;
        }
    }
    internal class Star : Commands
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter) => Run();


        public void Run()
        {
            
        }
    }
}
