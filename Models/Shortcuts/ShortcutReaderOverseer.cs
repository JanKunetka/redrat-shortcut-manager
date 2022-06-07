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
        private ShortcutReader reader;
        public IList<ShortcutKey> Shortcuts { get; private set; }
        private bool doProcessing;

        public ShortcutReaderOverseer()
        {
            Shortcuts = new List<ShortcutKey>();
            AddDefaultData();
            reader = new ShortcutReader(Shortcuts);

            ShortcutHookManager.OnKeyboardRead += Read;
        }
        
        public void Start() => doProcessing = true;
        public void End() => doProcessing = false;

        private void Read()
        {
            reader.Read();
        }

        private void OpenFile(string path)
        {
            FileOpener.Open(path);
        }
        
        private void AddDefaultData()
        {
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Control | ModifierKeys.Alt, new [] {Key.S}, @"D:\User Files\Obrázky\", OpenFile));
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Alt, new [] {Key.A, Key.U, Key.D}, @"D:\User Files\Obrázky\", OpenFile));
        }
        
    }
}

