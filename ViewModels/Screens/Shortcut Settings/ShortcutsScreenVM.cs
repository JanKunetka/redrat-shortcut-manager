using System.Collections.ObjectModel;
using System.Windows;
using RedRatShortcuts.Models;
using RedRatShortcuts.Models.Shortcuts;
using RedRatShortcuts.ViewModels.Commands;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    public class ShortcutsScreenVM : ViewModelBase
    {
        private readonly ShortcutReaderOverseer overseer;
        private readonly ObservableCollection<ShortcutVM> shortcuts;
        private string infoText;
        public string InfoText
        {
            get => infoText;
            set
            {
                infoText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenAddDialogCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand RunCommand { get; }

        public ShortcutsScreenVM()
        {
            overseer = new ShortcutReaderOverseer();
            shortcuts = new ObservableCollection<ShortcutVM>();
            infoText = "";
            
            ExitCommand = new RelayCommand(QuitApp);
            RunCommand = new RelayCommand(SwitchRunningState);
            OpenAddDialogCommand = new RelayCommand(OpenAddDialog);

            ShortcutHookManager.SetupSystemHook();
            LoadShortcuts();
            ChangeInfoText("App is Running");
        }

        private void QuitApp(object _)
        {
            ShortcutHookManager.ShutdownSystemHook();
            Application.Current.Shutdown();
        }

        private void SwitchRunningState(object _)
        {
            
        }

        private void OpenAddDialog(object _)
        {
            
        }

        private void ChangeInfoText(string message)
        {
            InfoText = message;
        }

        private void LoadShortcuts()
        {
            foreach (ShortcutKey key in overseer.Shortcuts)
            {
                Shortcuts.Add(new ShortcutVM(key));
            }
        }
        
        public ObservableCollection<ShortcutVM> Shortcuts { get => shortcuts; }
    }
}