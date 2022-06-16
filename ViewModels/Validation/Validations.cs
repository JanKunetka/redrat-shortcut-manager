using System.IO;

namespace RedRatShortcuts.ViewModels.Validation
{
    /// <summary>
    /// Contains various validation methods.
    /// </summary>
    public static class Validations
    {
        /// <summary>
        /// Ensures a shortcut is safe.
        /// </summary>
        /// <param name="shortcut">The shortcut to check.</param>
        /// <param name="allShortcuts">The list of all existing shortcuts.</param>
        /// <exception cref="IOException">Is thrown when there is a problem with the path.</exception>
        /// <exception cref="ArgumentException">Is thrown when there is a problem with duplication.</exception>
        public static void IsShortcutSafe(ShortcutVM shortcut, IList<ShortcutVM> allShortcuts)
        {
            if (shortcut.ShortcutKeys == "")
            {
                MessageBox.Show("The shortcuts sequence cannot be empty." ,"Invalid Shortcut Sequence");
                throw new NullReferenceException("The shortcuts sequence cannot be empty.");
            }

            if (shortcut.ShortcutKeys.Length != 3)
            {
                MessageBox.Show("The shortcuts sequence must have at least 3 characters." ,"Invalid Shortcut Sequence");
                throw new ArgumentException("The shortcuts sequence must have at least 3 characters.");
            }
            
            if (shortcut.Path == "")
            {
                MessageBox.Show("The Path cannot be empty." ,"Invalid Path");
                throw new IOException("The Path cannot be empty.");
            }
            
            if (!Directory.Exists(shortcut.Path) && !File.Exists(shortcut.Path))
            {
                MessageBox.Show("The Path doesn't exist." ,"Invalid Path");
                throw new IOException("The Path does not exist.");
            }
            
            if (allShortcuts.Any(key => shortcut.ShortcutKeys == key.ShortcutKeys))
            {
                MessageBox.Show("A shortcut with the same key sequence already exists." ,"Same shortcut");
                throw new ArgumentException("A shortcut with the same key sequence already exists.");
            }
        }
    }
}