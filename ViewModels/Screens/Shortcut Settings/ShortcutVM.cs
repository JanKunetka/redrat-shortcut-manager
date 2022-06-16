using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RedRatShortcuts.Models.Core;
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

        private string fileName;
        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                OnPropertyChanged();
            }
        }
        
        private ImageSource iconImage;
        public ImageSource IconImage
        {
            get => iconImage;
            set
            {
                iconImage = value;
                OnPropertyChanged();
            }
        }

        public ShortcutVM(string shortcutKeysKeys, string path)
        {
            ShortcutKeys = shortcutKeysKeys;
            Path = path;
            // FileName = path.Split('')
        }

        public ShortcutVM(ShortcutVM shortcut)
        {
            ShortcutKeys = shortcut.ShortcutKeys;
            Path = shortcut.Path;
        }
        
        public ShortcutVM(ShortcutKey key)
        {
            ShortcutKeys = KeyStringConverter.KeysToString(key.Keys);
            Path = key.Path;
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

        /// <summary>
        /// Build an icon from the assigned path.
        /// </summary>
        public void TryBuildIcon()
        {
            if (Path == "") return;
            FileAttributes attr = File.GetAttributes(Path);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                string? absolutePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"..\..\..\..\Views\Resource\img\img_ProgramIcon_Default.png");
                IconImage = new BitmapImage(new Uri(absolutePath));
                return;
            }
            Icon? icon = Icon.ExtractAssociatedIcon(Path);
            IconImage = icon.ToImageSource();
        }
        
    }
}