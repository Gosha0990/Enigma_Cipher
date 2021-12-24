using Enigma.Infrastructure.Commands;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using Enigma.MVVM.Model.Encryption;
using System.Windows;
using System.Diagnostics;

namespace Enigma.MVVM.ViewModel
{
    class MainWindowViewModel : MainViewModel
    {
        private string _TextKey = "New Key";
        private string _TextMessag ="Hello World!";
        private string _TextResult;
        public string TextMessag
        {
            get => _TextMessag;
            set => Set(ref _TextMessag, value);
        }        
        public string TextKey
        {
            get => _TextKey;
            set => Set(ref _TextKey, value);
        }

        public string TextResult
        {
            get => _TextResult;
            set => Set(ref _TextResult, value);
        }
        private void SaveText (string text)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, text);
        }
        private string OpenText()
        {
            string text = null;
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var fileText = File.ReadAllText(fileName);
                return text = fileText;
            }
            else
                return text;
        }        
        #region OpenTextKey
        public ICommand OpanTextKeyCommand { get; private set; }
        private void OnOpanTextKeyCommadExecuter(object p)
        {
            string res = OpenText();
            TextKey = res;
        }
        public bool CanOpanTextKeyCommand(object p)
        {
            return true;
        }
        #endregion

        #region OpanTextMasseg
        public ICommand OpanTextMassegCommand { get; private set; }

        private void OnOpanTextMassegCommand(object p)
        {
            string res = OpenText();
            TextMessag = res;
        }
        private bool CanOpanTextMassegCommand(object p)
        {
            return true;
        }
        #endregion

        #region Encrypt
        public ICommand EncryptMessageCommand { get; private set; }
        public void OnDisplayMessageCommand(object p)
        {
            var encryption = new EncryptionMain();
            var res = encryption.Encrypt(TextMessag, TextKey);
            TextResult = res;
        }

        public bool CanDisplayMessageCommand(object p)
        {
            return true;
        }
        #endregion

        #region SaveTextMessag
        public ICommand SaveTextMessageCommand { get; private set; }
        private void OnSaveTextMessageCommand(object p)
        {            
            SaveText(TextMessag);
        }
        private bool CanSaveTextMessageCommand(object p)
        {
            return true;
        }
        #endregion

        #region SaveTextKey
        public ICommand SaveTextCommad { get; }

        private void OnSaveTextCommadExecuter(object p)
        {
            SaveText(TextKey);
        }

        private bool CanSaveTextCommadEcecute(object p)
        {
            return true;
        }
        #endregion

        #region SaveTextEncryption
        public ICommand SaveTextEncyptionCommand { get; private set; }

        public void OnSaveTextEncyptionCommand(object p)
        {
            SaveText(TextResult);
        }

        public bool CanSaveTextEncyptionCommand(object p)
        {
            return true;
        }
        #endregion
        public MainWindowViewModel()
        {
            SaveTextCommad = new LambdaCommand(OnSaveTextCommadExecuter, CanSaveTextCommadEcecute);
            EncryptMessageCommand = new LambdaCommand(OnDisplayMessageCommand, CanDisplayMessageCommand);
            OpanTextKeyCommand = new LambdaCommand(OnOpanTextKeyCommadExecuter, CanOpanTextKeyCommand);
            OpanTextMassegCommand = new LambdaCommand(OnOpanTextMassegCommand, CanOpanTextMassegCommand);
            SaveTextEncyptionCommand = new LambdaCommand(OnSaveTextEncyptionCommand, CanSaveTextEncyptionCommand);
            SaveTextMessageCommand = new LambdaCommand(OnSaveTextMessageCommand, CanSaveTextMessageCommand);
        }
    }
}
