using System.Windows;

namespace Enigma.Infrastructure.Commands
{
    class CloseApplicationComand : Command
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter) => Application.Current.Shutdown();
        
    }
}
