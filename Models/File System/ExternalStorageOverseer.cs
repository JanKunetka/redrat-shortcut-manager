using System.IO;
using System.Runtime.Serialization;
using System.Windows.Input;
using RedRatShortcuts.Models.FileSystem.Serialization;
using RedRatShortcuts.Models.Shortcuts;

namespace RedRatShortcuts.Models.FileSystem
{
    /// <summary>
    /// Overseers files stored on external storage.
    /// </summary>
    public class ExternalStorageOverseer
    {
        private readonly string path;

        public ExternalStorageOverseer()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FileSystem.TryCreateDirectory(Path.Combine(appdata, @"RedRats Productions"));
            FileSystem.TryCreateDirectory(Path.Combine(appdata, @"RedRats Productions\Shortcut Manager"));
            FileSystem.TryCreateDirectory(Path.Combine(appdata, @"RedRats Productions\Shortcut Manager\Data"));
            path = Path.Combine(appdata, @"RedRats Productions\Shortcut Manager\Data\shortcutdata.rrsm");
        }

        /// <summary>
        /// Save a shortcut collection under the given path.
        /// </summary>
        public void Save(ShortcutList collection)
        {
            FileSystem.SaveFile(path, collection, coll => new SerializedShortcutList(coll));
        }

        /// <summary>
        /// Load shortcuts from external storage.
        /// </summary>
        /// <returns>A list of found shortcuts.</returns>
        public ShortcutList Load()
        {
            if (!File.Exists(path)) return new ShortcutList(ModifierKeys.Alt);
            try { return FileSystem.LoadFile<ShortcutList, SerializedShortcutList>(path); }
            catch (SerializationException) { return new ShortcutList(ModifierKeys.Alt); }
        }
    }
}