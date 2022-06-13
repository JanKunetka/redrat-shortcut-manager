using System.Text;
using System.Windows.Input;
using RedRatShortcuts.Models.Shortcuts;
using RedRatShortcuts.ViewModels.Core;

namespace RedRatShortcuts.ViewModels
{
    /// <summary>
    /// View Model representation of a shortcut.
    /// </summary>
    public class ShortcutVM : ViewModelBase
    {
        private string shortcutKeys;
        public string ShortcutKeys
        {
            get => shortcutKeys;
            set
            {
                shortcutKeys = value;
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

        public ShortcutVM(string shortcutKeysKeys, string path)
        {
            ShortcutKeys = shortcutKeysKeys;
            Path = path;
        }

        public ShortcutVM(ShortcutVM shortcut)
        {
            ShortcutKeys = shortcut.ShortcutKeys;
            Path = shortcut.Path;
        }
        
        public ShortcutVM(ShortcutKey key)
        {
            ShortcutKeys = KeysToString(key.Keys);
            Path = key.Path;
        }

        private string KeysToString(Key[] keys)
        {
            StringBuilder builder = new();
            foreach (Key key in keys)
            {
                builder.Append(key.ToString());
            }

            return builder.ToString();
        }
        
        public static bool operator ==(ShortcutVM a, ShortcutVM b) => a.Equals(b);
        public static bool operator !=(ShortcutVM a, ShortcutVM b) => !a.Equals(b);

        public override bool Equals(object? obj)
        {
            if (obj is not ShortcutVM other) return false;
            return shortcutKeys == other.ShortcutKeys && path == other.Path;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(shortcutKeys, path);
        }
    }
}