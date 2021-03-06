using System.Windows;

namespace Enigma.Infrastructure.Commands
{
    class MaxmazeApplicationCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
    }
}
