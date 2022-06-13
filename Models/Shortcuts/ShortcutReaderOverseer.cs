using System.Windows.Input;
using RedRatShortcuts.Models.FileSystem;
using RedRatShortcuts.Models.Shortcuts;

namespace RedRatShortcuts.Models
{
    /// <summary>
    /// Overseers and controls the Shortcut reader system.
    /// </summary>
    public class ShortcutReaderOverseer
    {
        public event Action OnChangeRunState;
        
        private readonly ShortcutReader reader;
        private readonly ShortcutCollection collection;
        
        private bool doProcessing;

        public ShortcutReaderOverseer()
        {
            collection = new ShortcutCollection(ModifierKeys.Alt, OpenFile);
            reader = new ShortcutReader(Shortcuts);

            ShortcutHookManager.OnKeyboardRead += Read;
        }

        /// <summary>
        /// Set the shortcut processing process activity state.
        /// </summary>
        /// <param name="isActive">The state of detecting shortcut inputs.</param>
        public void ChangeProcessingState(bool isActive)
        {
            doProcessing = isActive;
            OnChangeRunState?.Invoke();
        }

        /// <summary>
        /// Switches the state of reading shortcut inputs to the opposite value.
        /// </summary>
        public void SwitchProcessingState() => ChangeProcessingState(!doProcessing);
        
        public void AddShortcut(string shortcutKeys, string path) => collection.Add(shortcutKeys, path);
        public void UpdateShortcut(int index, string shortcutKeys, string path) => collection.Update(index, shortcutKeys, path);
        public void RemoveShortcut(string shortcutKeys, string path) => collection.Remove(shortcutKeys, path);
        
        private void Read()
        {
            if (!doProcessing) return;
            reader.Read();
        }

        private void OpenFile(string path)
        {
            FileOpener.Open(path);
        }
        
        public bool DoProcessing { get => doProcessing; }
        public IList<ShortcutKey> Shortcuts => collection.Shortcuts;
        
    }
}

