using RedRatShortcuts.Models.Shortcuts;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// View Model representation of a shortcut.
    /// </summary>
    public class ShortcutVM : ViewModelBase
    {
        private string shortcut;
        public string Shortcut
        {
            get => shortcut;
            set
            {
                shortcut = value;
                OnPropertyChanged();
            }
        }

        private string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged();
            }
        }

        public ShortcutVM(ShortcutKey key)
        {
            Shortcut = $"{key.Modifier.ToString()} + {key.Keys.ToString()}";
            Path = key.Path;
        }
    }
}