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
        public bool CanExecute { get; }

        public ShortcutKey(ModifierKeys modifier, Key[] keys, string path, bool canExecute = true)
        {
            Modifier = modifier;
            Keys = keys;
            Path = path;
            CanExecute = canExecute;
        }
    }
}