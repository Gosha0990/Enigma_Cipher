using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestLogic.MVVM.ViewModel.Base
{
    class PressButton 
    {
        public PressButtonViewModel ButtonCommand { get; set; }

        public PressButton()
        {
            ButtonCommand = new PressButtonViewModel(this); 
        }

        public void OnExecute()
        {
            MessageBox.Show("Press Key");
        }
    }
}
