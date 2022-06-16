using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Reads the current input and adjusts it to the shortcut.
    /// </summary>
    public class ShortcutReader
    {
        public event Action<string> OnShortcutExecute;
        
        private IList<ShortcutKey> shortcuts;
        private IList<ShortcutKey> possibilities;

        private int progress;
        private bool markForProgress;
        private int triggerTicks;
        private ShortcutKey? detectedShortcut;
        
        public ShortcutReader(IList<ShortcutKey> shortcuts)
        {
            RefreshShortcuts(shortcuts);
        }

        /// <summary>
        /// Read Keyboard input.
        /// </summary>
        public void Read()
        {
            ProcessInput();

            if (triggerTicks > 0 || detectedShortcut == null) return;
            ConfirmInput(detectedShortcut);
        }

        /// <summary>
        /// Refreshes the internal list of shortcuts.
        /// </summary>
        /// <param name="shortcuts">The shortcut list with new data.</param>
        public void RefreshShortcuts(IList<ShortcutKey> shortcuts)
        {
            this.shortcuts = new List<ShortcutKey>(shortcuts);
            CancelInput();
        }
        
        /// <summary>
        /// Processes the entered input.
        /// </summary>
        private void ProcessInput()
        {
            
            if (markForProgress)
            {
                progress++;
                markForProgress = false;
            }
            else
            {
                if (detectedShortcut != null && (Keyboard.Modifiers & detectedShortcut.Modifier) != 0)
                {
                    triggerTicks--;
                }
            }
            
            foreach (ShortcutKey key in possibilities)
            {
                if (!key.CanExecute) continue;
                if (progress >= key.Keys.Length) continue;
                if ((Keyboard.Modifiers & key.Modifier) == 0) continue;
                Key keyCode = key.Keys[progress];
                if (!Keyboard.IsKeyDown(keyCode)) continue;
                detectedShortcut = null;
                triggerTicks = 1;
                
                if (progress == key.Keys.Length-1)
                    detectedShortcut = key;
                else markForProgress = true;
                
                // AdjustPossibilities(key, progress);
            }
        }
        
        /// <summary>
        /// Confirm an inputted shortcut.
        /// </summary>
        /// <param name="key">The shortcut to activate.</param>
        private void ConfirmInput(ShortcutKey key)
        {
            OnShortcutExecute?.Invoke(key.Path);
            CancelInput();
        }
        
        /// <summary>
        /// Reset input.
        /// </summary>
        private void CancelInput()
        {
            progress = 0;
            detectedShortcut = null;
            triggerTicks = 1;
            possibilities = new List<ShortcutKey>(shortcuts);
        }

        /// <summary>
        /// Decrease the pool of possible shortcuts based on the latest key.
        /// </summary>
        /// <param name="possibleKey">The last inputted key.</param>
        /// <param name="progress">The current progress through a shortcut sequence.</param>
        private void AdjustPossibilities(ShortcutKey possibleKey, int progress)
        {
            IList<ShortcutKey> original = new List<ShortcutKey>(possibilities);
            possibilities.Clear();
            foreach (ShortcutKey key in original)
            {
                if (progress >= key.Keys.Length) continue;
                if (possibleKey.Keys[progress] != key.Keys[progress]) continue;
                possibilities.Add(key);
            }
        }
    }
}