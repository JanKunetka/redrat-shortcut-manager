using RedRatShortcuts.Models;
using RedRatShortcuts.Models.FileSystem;
using RedRatShortcuts.Models.Shortcuts;
using RedRatShortcuts.ViewModels.Core;
using RedRatShortcuts.ViewModels.Navigation;
using MessageBox = System.Windows.MessageBox;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// The Main Runner for View Models.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private readonly NavigationService navigation;
        public ViewModelBase CurrentVM => navigation.CurrentVM;

        public MainVM()
        {
            ShortcutReaderOverseer.Instance.ChangeProcessingState(true);
            ShortcutHookManager.SetupSystemHook();
            
            navigation = NavigationService.Instance;
            navigation.OnViewModelChanged += WhenVMChanges;
            navigation.Navigate(new ShortcutsScreenVM());
            
            FileOpener.OnErrorPathNotExist += ShowError;
        }

        private void WhenVMChanges() => OnPropertyChanged(nameof(CurrentVM));

        private void ShowError(string message) => MessageBox.Show(message);

    }
}