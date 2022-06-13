using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels.Navigation
{
    public class NavigationService
    {
        public event Action? OnViewModelChanged;
        private readonly NavigationStore store;

        #region Singleton Pattern
        private static NavigationService? instance;
        private static readonly object padlock = new();
        public static NavigationService Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance ??= new NavigationService();
                }
            }
        }
        #endregion
        
        private NavigationService()
        {
            store = new NavigationStore();
        }
        
        public void Navigate(ViewModelBase view)
        {
            store.CurrentVM = view;
            OnViewModelChanged?.Invoke();
        }

        public ViewModelBase CurrentVM => store.CurrentVM;
    }
}