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
    class PersonData : BaseViewModel
    {
        private string _name;
        private Button _pressButton;
        public string Name
        {
            get => _name;
            set {
                _name = value;
                OnPropertyChenged();
            }
        }
        public Button PressButton
        {
            get => _pressButton;
            set => OnPropertyChenged();
        }
        public PersonData()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Random r = new Random();
                    Name = r.Next(1, 1000).ToString();
                    Debug.WriteLine($"Name : {Name}");
                    
                    Thread.Sleep(500);
                    if (PressButton)
                    {
                        Debug.WriteLine("Press");
                    }
                }
            });
        }
    }
}
