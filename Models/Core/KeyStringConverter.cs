using System.Text;
using System.Windows.Input;

namespace RedRatShortcuts.Models.Core
{
    /// <summary>
    /// Contains methods for working with Keys and <see cref="string"/>s.
    /// </summary>
    public static class KeyStringConverter
    {
        private static readonly KeyConverter keyConverter;
        static KeyStringConverter() => keyConverter = new KeyConverter();

        /// <summary>
        /// Convert a string to an array of <see cref="Key"/>s.
        /// </summary>
        /// <param name="keysString">The string of keys to convert.</param>
        /// <returns>An array of <see cref="Key"/>s.</returns>
        public static Key[] StringToKeys(string keysString)
        {
            Key[] keys = new Key[keysString.Length];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = (Key)(keyConverter.ConvertFromString(keysString[i].ToString()) ?? "");
            }
            return keys;
        }

        /// <summary>
        /// Convert an array of <see cref="Key"/>s to a <see cref="string"/>.
        /// </summary>
        /// <param name="keys">The array of keys to convert.</param>
        /// <returns>A <see cref="string"/> of keys.</returns>
        public static string KeysToString(Key[] keys)
        {
            StringBuilder builder = new();
            foreach (Key key in keys)
            {
                builder.Append(key.ToString());
            }
            return builder.ToString();
        }
    }
}