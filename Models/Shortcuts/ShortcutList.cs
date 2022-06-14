using System.Collections;
using System.Windows.Input;
using RedRatShortcuts.Models.Core;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Contains the collection of in-app shortcuts.
    /// </summary>
    public class ShortcutList : IList<ShortcutKey>
    {
        public event Action OnChange;

        private readonly IList<ShortcutKey> shortcuts;
        public ModifierKeys DefaultModifier { get; }

        public ShortcutList(ModifierKeys defaultModifier, IList<ShortcutKey>? predefinedShortcuts = null)
        {
            this.DefaultModifier = defaultModifier;
            shortcuts = (predefinedShortcuts == null) ? new List<ShortcutKey>() : new List<ShortcutKey>(predefinedShortcuts);
        }

        /// <summary>
        /// Add a new element to the collection.
        /// </summary>
        /// <param name="shortcutKeys">The Key sequence in a string format.</param>
        /// <param name="path">The path that the shortcut leads to.</param>
        public void Add(string shortcutKeys, string path)
        {
            Add(new ShortcutKey(DefaultModifier, KeyStringConverter.StringToKeys(shortcutKeys), path));
        }

        /// <summary>
        /// Update an element in the collection.
        /// </summary>
        /// <param name="index">The index of the element to update.</param>
        /// <param name="shortcutKeys">The new Key sequence in a string format.</param>
        /// <param name="path">The new path that the shortcut leads to.</param>
        public void Update(int index, string shortcutKeys, string path)
        {
            shortcuts[index] = new ShortcutKey(DefaultModifier, KeyStringConverter.StringToKeys(shortcutKeys), path);
        }

        /// <summary>
        /// Remove an element from the collection.
        /// </summary>
        /// <param name="shortcutKeys">The Key sequence in a string format.</param>
        /// <param name="path">The path that the shortcut leads to.</param>
        public void Remove(string shortcutKeys, string path)
        {
            Key[] keys = KeyStringConverter.StringToKeys(shortcutKeys);
            for (int i = 0; i < shortcuts.Count; i++)
            {
                ShortcutKey key = shortcuts[i];
                if (key.Path != path) continue;
                if (key.Keys.Length != keys.Length) continue;
                if (!key.Keys.SequenceEqual(keys)) continue;
                RemoveAt(i);
                break;
            }
        }

        #region Overrides

        public IEnumerator<ShortcutKey> GetEnumerator()
        {
            return shortcuts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ShortcutKey item)
        {
            shortcuts.Add(item);
            OnChange?.Invoke();
        }

        public void Clear()
        {
            shortcuts.Clear();
            OnChange?.Invoke();
        }

        public bool Contains(ShortcutKey item)
        {
            return shortcuts.Contains(item);
        }

        public void CopyTo(ShortcutKey[] array, int arrayIndex)
        {
            shortcuts.CopyTo(array, arrayIndex);
        }

        public bool Remove(ShortcutKey item)
        {
            return shortcuts.Remove(item);
            OnChange?.Invoke();
        }

        public int Count { get => shortcuts.Count; }
        public bool IsReadOnly { get => shortcuts.IsReadOnly; }
        public int IndexOf(ShortcutKey item)
        {
            return shortcuts.IndexOf(item);
        }

        public void Insert(int index, ShortcutKey item)
        {
            shortcuts.Insert(index, item);
            OnChange?.Invoke();
        }

        public void RemoveAt(int index)
        {
            shortcuts.RemoveAt(index);
            OnChange?.Invoke();
        }

        public ShortcutKey this[int index]
        {
            get => shortcuts[index];
            set 
            { 
                shortcuts[index] = value; 
                OnChange?.Invoke(); 
            }
        }

        #endregion
    }
}