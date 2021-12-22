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
        private string _TextMessag ="World!";
        private string _TextResult;
        public string TextMasseg
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
        public ICommand OpanTextKeyCommand { get; private set; }

        private void OnOpanTextKeyCommadExecuter(object p)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };            
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var fileText = File.ReadAllText(fileName);
                var retunText = fileText;
                TextKey = retunText;
                Debug.WriteLine(TextKey);
            }
        }
        public bool CanOpanTextKeyCommand(object p)
        {
            return true;
        }
        public ICommand OpanTextMassegCommand { get; private set; }

        private void OnOpanTextMassegCommand(object p)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var fileText = File.ReadAllText(fileName);
                var retunText = fileText;
                TextMasseg = retunText;                
            }
        }
        private bool CanOpanTextMassegCommand(object p)
        {
            return true;
        }
        public ICommand EncryptMessageCommand { get; private set; }
        public void OnDisplayMessageCommand(object p)
        {
            var encryption = new EncryptionMain();
            var res = encryption.Encrypt(_TextMessag, _TextKey);
            TextResult = res;
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
            EncryptMessageCommand = new LambdaCommand(OnDisplayMessageCommand, CanDisplayMessageCommand);
            OpanTextKeyCommand = new LambdaCommand(OnOpanTextKeyCommadExecuter, CanOpanTextKeyCommand);
            OpanTextMassegCommand = new LambdaCommand(OnOpanTextMassegCommand, CanOpanTextMassegCommand);
        }
    }
}
