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
        public IList<ShortcutKey> Shortcuts { get; private set; }
        private bool doProcessing;

        public ShortcutReaderOverseer()
        {
            Shortcuts = new List<ShortcutKey>(); 
            AddDefaultData();

            ShortcutHookManager.OnKeyboardRead += Read;
        }
        
        public void Start() => doProcessing = true;
        public void End() => doProcessing = false;

        private void Read()
        {
            foreach(ShortcutKey shortcut in Shortcuts)
            {
                if (shortcut.Pressed && Keyboard.IsKeyUp(shortcut.Key)) shortcut.Pressed = false;
                
                if (shortcut.Pressed) continue;
                if ((Keyboard.Modifiers & shortcut.Modifier) <= 0) continue;
                if (!Keyboard.IsKeyDown(shortcut.Key)) continue;
                if (!shortcut.CanExecute) continue;

                shortcut.Callback?.Invoke(shortcut.Path);
                shortcut.Pressed = true;

            }
        }

        private void OpenFile(string path)
        {
            FileOpener.Open(path);
        }
        
        private void AddDefaultData()
        {
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Control | ModifierKeys.Alt, Key.S, @"D:\User Files\Obrázky\", OpenFile));
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Alt, Key.K, @"C:\Program Files\Audacity\Audacity.exe", OpenFile));
        }
        
    }
}

