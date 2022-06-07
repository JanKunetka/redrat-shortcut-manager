using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Reads the current input and adjusts it to the shortcut.
    /// </summary>
    public class ShortcutReader
    {
        private readonly IList<ShortcutKey> shortcuts;
        private IList<ShortcutKey> possibilities;

        private bool modifiersPressed;
        private bool readyToProgress;
        private int progress;
        
        public ShortcutReader(IList<ShortcutKey> shortcuts)
        {
            this.shortcuts = shortcuts;
            CancelInput();
        }

        public void Read()
        {
            
            foreach (ShortcutKey key in possibilities)
            {
                if (progress >= key.Keys.Length) continue;
                if (!key.CanExecute) continue;
                Key keyCode = key.Keys[progress];
                if ((Keyboard.Modifiers & key.Modifier) <= 0) continue;
                if (!Keyboard.IsKeyDown(keyCode)) continue;

                if (progress == key.Keys.Length - 1)
                {
                    ConfirmInput(progress);
                    break;
                }
                
                progress++;
                possibilities = possibilities.Where(BothKeysAreSame).ToList();
                break;
                
                bool BothKeysAreSame(ShortcutKey possibleKey)
                {
                    return progress < possibleKey.Keys.Length - 1 && possibleKey.Keys[progress] == key.Keys[progress];
                }
            }
        }
        
        private void ConfirmInput(int shortcutIndex)
        {
            ShortcutKey key = shortcuts[shortcutIndex];
            key.Callback?.Invoke(key.Path);
            CancelInput();
        }
        
        private void CancelInput()
        {
            progress = 0;
            modifiersPressed = false;
            readyToProgress = false;
            possibilities = new List<ShortcutKey>(shortcuts);
        }

    }
}