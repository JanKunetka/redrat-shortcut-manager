using System.Windows;
using RedRatShortcuts.Models;
using RedRatShortcuts.ViewModels.Commands;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    public class ShortcutsScreenVM : ViewModelBase
    {
        private readonly ShortcutReaderOverseer overseer;
        private readonly ObservableDictionary<string, string> shortcuts;

        public RelayCommand ExitCommand { get; }
        public RelayCommand RunCommand { get; }

        public ShortcutsScreenVM()
        {
            overseer = new ShortcutReaderOverseer();
            shortcuts = new ObservableDictionary<string, string>(overseer.Get());

            ExitCommand = new RelayCommand(QuitApp);
            RunCommand = new RelayCommand(SwitchRunningState);

        }

        private void QuitApp(object _)
        {
            Application.Current.Shutdown();
        }

        private void SwitchRunningState(object _)
        {
            
        }

        
        public ObservableDictionary<string, string> Shortcuts { get => shortcuts; }
    }
}