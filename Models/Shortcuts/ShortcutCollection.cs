using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Contains the collection of in-app shortcuts.
    /// </summary>
    public class ShortcutCollection
    {
        private readonly KeyConverter keyConverter;
        private readonly Action<string> defaultAction;
        private readonly ModifierKeys defaultModifier;
        public IList<ShortcutKey> Shortcuts { get; }

        public ShortcutCollection(ModifierKeys defaultModifier, Action<string> defaultAction)
        {
            keyConverter = new KeyConverter();
            
            this.defaultModifier = defaultModifier;
            this.defaultAction = defaultAction;
            Shortcuts = new List<ShortcutKey>();
        }

        /// <summary>
        /// Add a new element to the collection.
        /// </summary>
        /// <param name="shortcutKeys">The Key sequence in a string format.</param>
        /// <param name="path">The path that the shortcut leads to.</param>
        public void Add(string shortcutKeys, string path)
        {
            Shortcuts.Add(new ShortcutKey(defaultModifier, StringToKeys(shortcutKeys), path, defaultAction));
        }

        /// <summary>
        /// Update an element in the collection.
        /// </summary>
        /// <param name="index">The index of the element to update.</param>
        /// <param name="shortcutKeys">The new Key sequence in a string format.</param>
        /// <param name="path">The new path that the shortcut leads to.</param>
        public void Update(int index, string shortcutKeys, string path)
        {
            Shortcuts[index] = new ShortcutKey(defaultModifier, StringToKeys(shortcutKeys), path, defaultAction);
        }

        /// <summary>
        /// Remove an element from the collection.
        /// </summary>
        /// <param name="shortcutKeys">The Key sequence in a string format.</param>
        /// <param name="path">The path that the shortcut leads to.</param>
        public void Remove(string shortcutKeys, string path)
        {
            Key[] keys = StringToKeys(shortcutKeys);
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                ShortcutKey key = Shortcuts[i];
                if (key.Path != path) continue;
                if (key.Keys.Length != keys.Length) continue;
                if (!key.Keys.SequenceEqual(keys)) continue;
                Shortcuts.RemoveAt(i);
                break;
            }
        }
        
        /// <summary>
        /// Convert a string to an array of <see cref="Key"/>s.
        /// </summary>
        /// <param name="keysString">The string of keys to convert.</param>
        /// <returns>An array of <see cref="Key"/>s.</returns>
        private Key[] StringToKeys(string keysString)
        {
            Key[] keys = new Key[keysString.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = (Key)(keyConverter.ConvertFromString(keysString[i].ToString()) ?? "");
            }
            return keys;
        }

    }
}