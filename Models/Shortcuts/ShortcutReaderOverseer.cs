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
        private readonly ExternalStorageOverseer external;
        
        public ShortcutList Shortcuts { get; }
        public bool DoProcessing { get; private set; }

        #region Singleton Pattern
        private static ShortcutReaderOverseer? instance;
        private static readonly object padlock = new();

        public static ShortcutReaderOverseer Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance ??= new ShortcutReaderOverseer();
                }
            }
        }

        #endregion
        
        private ShortcutReaderOverseer()
        {
            external = new ExternalStorageOverseer();
            Shortcuts = new ShortcutList(ModifierKeys.Alt, external.Load());
            Shortcuts.OnChange += () => external.Save(Shortcuts);
           
            reader = new ShortcutReader(Shortcuts);
            ShortcutHookManager.OnKeyboardRead += Read;
            reader.OnShortcutExecute += OpenFile;
        }

        /// <summary>
        /// Set the shortcut processing process activity state.
        /// </summary>
        /// <param name="isActive">The state of detecting shortcut inputs.</param>
        public void ChangeProcessingState(bool isActive)
        {
            DoProcessing = isActive;
            OnChangeRunState?.Invoke();
        }

        /// <summary>
        /// Switches the state of reading shortcut inputs to the opposite value.
        /// </summary>
        public void SwitchProcessingState() => ChangeProcessingState(!DoProcessing);
        
        public void AddShortcut(string shortcutKeys, string path) => Shortcuts.Add(shortcutKeys, path);
        public void UpdateShortcut(int index, string shortcutKeys, string path) => Shortcuts.Update(index, shortcutKeys, path);
        public void RemoveShortcut(string shortcutKeys, string path) => Shortcuts.Remove(shortcutKeys, path);

        /// <summary>
        /// Process user input.
        /// </summary>
        private void Read()
        {
            if (!DoProcessing) return;
            reader.Read();
        }

        private void OpenFile(string path)
        {
            FileOpener.Open(path);
        }
    }
}

