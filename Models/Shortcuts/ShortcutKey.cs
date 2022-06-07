using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Represents the Shortcut combination.
    /// </summary>
    public class ShortcutKey
    {
        public ModifierKeys Modifier { get; }
        public Key[] Keys { get; }
        public string Path { get; }
        public Action<string> Callback { get; }
        public bool CanExecute { get; }

        public ShortcutKey(ModifierKeys modifier, Key[] keys, string path, Action<string> callback, bool canExecute = true)
        {
            Modifier = modifier;
            Keys = keys;
            Path = path;
            Callback = callback;
            CanExecute = canExecute;
        }
    }
}