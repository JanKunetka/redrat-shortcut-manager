using System.Windows.Input;
using RedRatShortcuts.Models.Shortcuts;

namespace RedRatShortcuts.Models.FileSystem.Serialization
{
    /// <summary>
    /// Serialized form of the <see cref="ShortcutList"/> class.
    /// </summary>
    [System.Serializable]
    public class SerializedShortcutList : ISerializedObject<ShortcutList>
    {
        private SerializedList<ShortcutKey, SerializedShortcutKey> shortcuts;
        private int defaultModifier;

        public SerializedShortcutList(ShortcutList collection)
        {
            shortcuts = new SerializedList<ShortcutKey, SerializedShortcutKey>(collection, key => new SerializedShortcutKey(key));
            defaultModifier = (int)collection.DefaultModifier;
        }
        
        public ShortcutList Deserialize()
        {
            return new ShortcutList((ModifierKeys)defaultModifier, shortcuts.Deserialize(skey => skey.Deserialize()));
        }
    }
}