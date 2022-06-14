using RedRatShortcuts.ViewModels.Commands;
using RedRatShortcuts.ViewModels.Core;
using RedRatShortcuts.ViewModels.Navigation;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// A ViewModel of the Shortcut edit window.
    /// </summary>
    public class ShortcutEditScreenVM : ViewModelBase
    {
        private ShortcutVM original;
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
        private string headerText;
        public string HeaderText
        {
            get => headerText;
            set
            {
                headerText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }
        public RelayCommand OpenFileDialogCommand { get; }
        public RelayCommand OpenDirectoryDialogCommand { get; }
        
        public ShortcutEditScreenVM(ShortcutVM shortcut, string headerText)
        {
            original = shortcut;
            ShortcutText = shortcut.ShortcutKeys;
            PathText = shortcut.Path;
            HeaderText = headerText;
            SaveCommand = new RelayCommand(WhenSaved);
            CancelCommand = new RelayCommand(WhenCancelled);
            OpenFileDialogCommand = new RelayCommand(WhenOpenFileDialog);
            OpenDirectoryDialogCommand = new RelayCommand(WhenOpenDirectoryDialog);
        }

        private void WhenCancelled(object _)
        {
            ShortcutsScreenVM vm = new();
            NavigationService.Instance.Navigate(vm);
            vm.AddShortcut(original);
        }

        private void WhenSaved(object _)
        {
            ShortcutsScreenVM vm = new();
            NavigationService.Instance.Navigate(vm);
            vm.AddShortcut(new ShortcutVM(ShortcutText, PathText));
        }
        
        private void WhenOpenFileDialog(object _)
        {
            OpenFileDialog dialog = new();
            dialog.FileName = "Document";

            bool? result = dialog.ShowDialog();
            PathText = (result == true) ? dialog.FileName : "";
        }

        private void WhenOpenDirectoryDialog(object _)
        {
            using FolderBrowserDialog fileDialog = new();
            DialogResult result = fileDialog.ShowDialog();
            PathText = (result == DialogResult.OK) ? fileDialog.SelectedPath : "";
        }
    }
}