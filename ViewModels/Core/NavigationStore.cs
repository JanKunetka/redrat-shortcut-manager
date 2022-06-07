namespace RedRatShortcuts.ViewModels.Core
{   
    /// <summary>
    /// Holds access to the current View Model of the application.
    /// </summary>
    public class NavigationStore
    {
        public event Action OnViewModelChanged;
        private ViewModelBase currentVM;

        #region Singleton Pattern
        private static NavigationStore? instance;
        private static readonly object padlock = new();
        public static NavigationStore Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance ??= new NavigationStore();
                }
            }
        }
        #endregion
        
        private NavigationStore() { }
        
        public ViewModelBase CurrentVM
        {
            get => currentVM;
            set
            {
                currentVM = value;
                OnViewModelChanged?.Invoke();
            }
        }
    }
}