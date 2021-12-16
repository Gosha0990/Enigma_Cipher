using Enigma.Infrastructure.Commands;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using Enigma.MVVM.Model.Encryption;
using System.Windows;

namespace Enigma.MVVM.ViewModel
{
    class MainWindowVievModel : MainViewModel
    {

        private string _TextMasseg = "Hhhhhhhhh";

        public string TextMasseg
        {
            get => _TextMasseg;
            set => Set(ref _TextMasseg, value);
        }

        public ICommand TextMessegCommand { get; }

        public void OnTextMassegCommand(object p)
        {

        }

        private string _Start = "Start";

        public string Start
        {
            get => _Start;
            set => Set(ref _Start, value);
        }

        public ICommand StartCommand { get; }

        private void OnStartCommand(object p, MouseButtonEventArgs e)
        {
            var res = new EncryptionMain();
            res.Encrypt(_TextMasseg, _TextKey);
            
            if (e.LeftButton == MouseButtonState.Pressed)
                _TextMasseg = res.ToString();

        }
        private bool CanStartCommand(object p)
        {
            return true;
        }

        private string _TextKey = "New Key";

        public string TextKey
        {
            get => _TextKey;
            set => Set(ref _TextKey, value);
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
        public MainWindowVievModel()
        {
            SaveTextCommad = new LambdaCommand(OnSaveTextCommadExecuter, CanSaveTextCommadEcecute);
           
           
        }
    }
}
