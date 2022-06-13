﻿using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels.Navigation
{   
    /// <summary>
    /// Holds access to the current View Model of the application.
    /// </summary>
    public class NavigationStore
    {
        
        private ViewModelBase currentVM;
        public ViewModelBase CurrentVM
        {
            get => currentVM;
            set
            {
                currentVM = value;
            }
        }
    }
}