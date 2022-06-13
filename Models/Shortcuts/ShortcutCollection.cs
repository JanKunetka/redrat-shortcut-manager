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
            AddDefaultData();
        }

        public void Add(string shortcutKeys, string path)
        {
            Shortcuts.Add(new ShortcutKey(defaultModifier, StringToKeys(shortcutKeys), path, defaultAction));
        }

        public void Update(int index, string shortcutKeys, string path)
        {
            Shortcuts[index] = new ShortcutKey(defaultModifier, StringToKeys(shortcutKeys), path, defaultAction);
        }

        private Key[] StringToKeys(string keysString)
        {
            Key[] keys = new Key[keysString.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = (Key)(keyConverter.ConvertFromString(keysString[i].ToString()) ?? "");
            }
            return keys;
        }
        
        private void AddDefaultData()
        {
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Control | ModifierKeys.Alt, new [] {Key.S}, @"D:\User Files\Moje Projekty\Dávná Historie\Waluigi 3D Land EX", defaultAction));
            Shortcuts.Add(new ShortcutKey(ModifierKeys.Alt, new [] {Key.A, Key.U, Key.D}, @"D:\User Files\Obrázky\", defaultAction));
        }
        
    }
}