using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestLogic.MVVM.ViewModel.Base;
using TestLogic.MVVM.ViewModel.Command;

namespace TestLogic.MVVM.ViewModel
{
    internal class MessegVieModel : BaseViewModel
    {
        private string _messegeTextOne;
        public string MessegeTextOne 
        {
            get => _messegeTextOne;
            set 
            {
                _messegeTextOne = value;
                OnPropertyChenged();
            }
        }
        public string MessegeTextTwo { get; set; }
        public MessageCommand DisplayMessageCommand { get; private set; }
        public MessegVieModel()
        {
            DisplayMessageCommand = new MessageCommand(DisplayMesseg);
        }

        public void DisplayMesseg()
        {
            //var res = Convert.ToInt32(MessegeTextOne) + Convert.ToInt32(MessegeTextTwo);
            //MessegeTextOne = res.ToString();
            //SetMesseg(res.ToString());
            var adres = @"C:\Users\Gosha\Documents\t.txt";
            var openText = new OpenFileDialog();
            
            if(openText.ShowDialog()==true)
            {
                var filename = openText.FileName;
                var filetext = File.ReadAllText(filename);
                var res = filetext;
                MessegeTextOne = res;
                Debug.WriteLine(MessegeTextOne);
            }


        }
        public void SetMesseg(string text)
        {
            MessegeTextOne = text;
        }
    }
}
