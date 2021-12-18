﻿using Enigma.Infrastructure.Commands;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using Enigma.MVVM.Model.Encryption;
using System.Windows;

namespace Enigma.MVVM.ViewModel
{
    class MainWindowViewModel : MainViewModel
    {

        private string _TextMasseg ="h";
        private string _TextKey = "New Key";
        
        public string TextMasseg
        {
            get => _TextMasseg;
            set => Set(ref _TextMasseg, value);
        }        
        public string TextKey
        {
            get => _TextKey;
            set => Set(ref _TextKey, value);
        }
        public string Star()
        {
           return TextMasseg += TextKey;
        }
        public ICommand DisplayMessageCommand { get; private set; }
        public void OnDisplayMessageCommand(object p)
        {
            var res = TextMasseg + TextKey;
            TextKey = res;
        }

        public bool CanDisplayMessageCommand(object p)
        {
            return true;
        }
        #region SaveText
        public ICommand SaveTextCommad { get; }

        private void OnSaveTextCommadExecuter(object p)
        {
            TextBox textBox = new TextBox();
            textBox.Text = _TextKey;
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
        }

        private bool CanSaveTextCommadEcecute(object p)
        {
            return true;
        }
        #endregion
        public MainWindowViewModel()
        {
            SaveTextCommad = new LambdaCommand(OnSaveTextCommadExecuter, CanSaveTextCommadEcecute);
            DisplayMessageCommand = new LambdaCommand(OnDisplayMessageCommand, CanDisplayMessageCommand);

        }
    }
}
