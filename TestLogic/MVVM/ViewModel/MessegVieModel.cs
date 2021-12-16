using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLogic.MVVM.ViewModel.Command;

namespace TestLogic.MVVM.ViewModel
{
    class MessegVieModel
    {
        public string MessegeTextOne { get; set; }
        public string MessegeTextTwo { get; set; }
        public MessageCommand DisplayMessageCommand { get; private set; }
        public MessegVieModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMesseg);
        }

        public void DisplayMesseg()
        {
            var res = Convert.ToInt32(MessegeTextOne) + Convert.ToInt32(MessegeTextTwo);
            MessageBox.Show(res.ToString());
        }
    }
}
