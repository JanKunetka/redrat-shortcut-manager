using System.Collections.ObjectModel;
using System.Windows;
using RedRatShortcuts.Models;
using RedRatShortcuts.Models.Shortcuts;
using RedRatShortcuts.ViewModels.Commands;
using RedRatShortcuts.ViewModels.Core;
using RedRatShortcuts.ViewModels.Navigation;

namespace RedRatShortcuts.ViewModels
{
    public class ShortcutsScreenVM : ViewModelBase
    {
        private readonly ShortcutReaderOverseer overseer;
        
        public ObservableCollection<ShortcutVM> Shortcuts { get; }
        
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

        private string runButtonTitle;
        public string RunButtonTitle
        {
            get => runButtonTitle;
            set
            {
                runButtonTitle = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenAddDialogCommand { get; }
        public RelayCommand ExitCommand { get; }
        public RelayCommand RunCommand { get; }

        public ShortcutsScreenVM()
        {
            overseer = new ShortcutReaderOverseer();
            overseer.OnChangeRunState += UpdateRunningState;
            
            Shortcuts = new ObservableCollection<ShortcutVM>();
            
            OpenAddDialogCommand = new RelayCommand(OpenAddDialog);
            ExitCommand = new RelayCommand(QuitApp);
            RunCommand = new RelayCommand(SwitchRunningState);

            ShortcutHookManager.SetupSystemHook();
            LoadShortcuts();
            overseer.ChangeProcessingState(true);
        }

        /// <summary>
        /// Add/Update a shortcut based on it's existence in the internal collection.
        /// </summary>
        /// <param name="shortcut"></param>
        public void ProcessShortcut(ShortcutVM shortcut)
        {
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                if (Shortcuts[i] != shortcut) continue;
                
                Shortcuts[i] = shortcut;
                overseer.UpdateShortcut(i, shortcut.ShortcutKeys, shortcut.Path);
                break;
            }
            
            Shortcuts.Add(shortcut);
            overseer.AddShortcut(shortcut.ShortcutKeys, shortcut.Path);
        }
        
        private void QuitApp(object _)
        {
            ShortcutHookManager.ShutdownSystemHook();
            Application.Current.Shutdown();
        }

        private void SwitchRunningState(object _) => overseer.SwitchProcessingState();
        private void UpdateRunningState()
        {
            RunButtonTitle = (overseer.DoProcessing) ? "Stop" : "Run";
            WriteInfoText((overseer.DoProcessing) ? "App is Running" : "App is not Running");
        }

        private void OpenAddDialog(object _)
        {
            NavigationService.Instance.Navigate(new ShortcutEditScreenVM(new ShortcutVM("", "")));
        }

        private void WriteInfoText(string message)
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

    }
}