using System.Windows.Input;
using RedRatShortcuts.Models.Core;
using RedRatShortcuts.Models.Shortcuts;

namespace RedRatShortcuts.Models.FileSystem.Serialization
{
    /// <summary>
    /// Serialized form of the <see cref="ShortcutKey"/> class.
    /// </summary>
    [System.Serializable]
    public class SerializedShortcutKey : ISerializedObject<ShortcutKey>
    {
        private int modifier;
        private string keys;
        private string path;
        private bool canExecute;

        public SerializedShortcutKey(ShortcutKey shortcut)
        {
            modifier = (int)shortcut.Modifier;
            keys = KeyStringConverter.KeysToString(shortcut.Keys);
            path = shortcut.Path;
            canExecute = shortcut.CanExecute;
        }

        public ShortcutKey Deserialize()
        {
            return new ShortcutKey((ModifierKeys) modifier,
                                    KeyStringConverter.StringToKeys(keys),
                                    path,
                                    canExecute);
        }
    }
}