using System.Windows.Input;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Detects user inputted shortcuts.
    /// </summary>
    public class ShortcutReader
    {
        private bool doReading;

        public ShortcutReader()
        {
            doReading = true;
        }

        public void ReceiveInput(KeyEventArgs args)
        {
        }
    }
}