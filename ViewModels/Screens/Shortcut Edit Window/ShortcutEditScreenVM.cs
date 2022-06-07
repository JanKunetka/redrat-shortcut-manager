using System.Windows;
using RedRatShortcuts.ViewModels.Commands;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// A ViewModel of the Shortcut edit window.
    /// </summary>
    public class ShortcutEditScreenVM : ViewModelBase
    {
        private string shortcutText;
        public string ShortcutText
        {
            get => shortcutText;
            set
            {
                shortcutText = value;
                OnPropertyChanged();
            }
        }
        private string pathText;
        public string PathText
        {
            get => pathText;
            set
            {
                pathText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand OpenFileDialogCommand { get; }
        
        public ShortcutEditScreenVM()
        {
            shortcutText = "PATAR";
            pathText = "Patar je borec";
            SaveCommand = new RelayCommand(WhenSaved);
            CancelCommand = new RelayCommand(WhenCancelled);
            OpenFileDialogCommand = new RelayCommand(WhenOpenFileDialog);
        }

        private void WhenOpenFileDialog(object _)
        {
            NavigationStore.Instance.CurrentVM = new ShortcutsScreenVM();
        }

        private void WhenCancelled(object _)
        {
            NavigationStore.Instance.CurrentVM = new ShortcutsScreenVM();
        }

        private void WhenSaved(object _)
        {
            NavigationStore.Instance.CurrentVM = new ShortcutsScreenVM();
        }
    }
}