using System.Windows;
using RedRatShortcuts.Models.FileSystem;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// The Main Runner for View Models.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        public ViewModelBase CurrentVM { get; }

        public MainVM()
        {
            CurrentVM = new ShortcutsScreenVM();
            
            FileOpener.OnErrorPathNotExist += ShowError;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message);
        }

    }
}