using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Represents the Shortcut combination.
    /// </summary>
    public class ShortcutKey
    {
        public ModifierKeys Modifier { get; }
        public ModifierKeys Modifier2 { get; }
        public Key Key { get; }
        public string Path { get; }
        public Action<string> Callback { get; }
        public bool CanExecute { get; }
        public bool Pressed { get; set; }

        public ShortcutKey(ModifierKeys modifier, Key key, string path, Action<string> callback, ModifierKeys modifier2 = ModifierKeys.None, bool canExecute = true)
        {
            Modifier = modifier;
            Modifier2 = modifier2;
            Key = key;
            Path = path;
            Callback = callback;
            CanExecute = canExecute;
        }
    }
}