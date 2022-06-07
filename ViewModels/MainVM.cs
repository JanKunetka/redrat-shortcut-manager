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
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentVM => navigationStore.CurrentVM;

        public MainVM()
        {
            navigationStore = NavigationStore.Instance;
            navigationStore.CurrentVM = new ShortcutsScreenVM();
            navigationStore.OnViewModelChanged += WhenVMChanges;
            
            FileOpener.OnErrorPathNotExist += ShowError;
        }

        private void WhenVMChanges() => OnPropertyChanged(nameof(CurrentVM));

        private void ShowError(string message) => MessageBox.Show(message);
    }
}