using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using RedRats.Safety;
using RedRatShortcuts.Models.FileSystem.Serialization;

namespace RedRatShortcuts.Models.FileSystem
{
    /// <summary>
    /// Handles Saving, Loading and Removing packs from external storage.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Save an asset to external storage.
        /// </summary>
        /// <param name="path">Destination of the save.</param>
        /// <param name="data">The data object to save.</param>
        /// <param name="newSerializedObject">A method that will create the create the serialized form of the object.</param>
        /// <typeparam name="T">The object to serialize.</typeparam>
        /// <typeparam name="TS">Serialized form of the object.</typeparam>
        /// <exception cref="IOException">IS thrown when the object could not be saved.</exception>
        public static void SaveFile<T,TS>(string path, T data, Func<T,TS> newSerializedObject) where TS : ISerializedObject<T>
        {
            SafetyNetIO.EnsurePathNotContainsInvalidCharacters(path);
            try
            {
                BinaryFormatter formatter = new();
                FileStream stream = new(path, FileMode.Create);
                TS formattedAsset = newSerializedObject(data);

                formatter.Serialize(stream, formattedAsset);
                stream.Close();
            }
            catch (IOException)
            {
                throw new IOException($"File '{Path.GetFileName(path)}' could not be saved.");
            }
        }

        /// <summary>
        /// Load a file under a specific path.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <typeparam name="T">Any type.</typeparam>
        /// <typeparam name="TS">A Serialized form of <see cref="T"/>.</typeparam>
        /// <returns>A deserialized form of the object.</returns>
        /// <exception cref="IOException">IS thrown when the object could not be loaded.</exception>
        public static T LoadFile<T, TS>(string path)  where TS : ISerializedObject<T>
        {
            SafetyNetIO.EnsureFileExists(path);
            try
            {
                BinaryFormatter formatter = new();
                FileStream stream = new(path, FileMode.Open);
                TS serializedObject = (TS) formatter.Deserialize(stream);
                stream.Close();
                return serializedObject.Deserialize();
            }
            catch (IOException)
            {
                throw new IOException($"File under the path '{path}' could not be loaded.");
            }
        }
        
        /// <summary>
        /// If it doesn't exist, creates a directory at specific path.
        /// </summary>
        /// <param name="path">The location to create the directory in.</param>
        /// <param name="name">The name of the directory.</param>
        public static void TryCreateDirectory(string path, string name)
        {
            TryCreateDirectory(Path.Combine(path, name));
        }
        /// <summary>
        /// If it doesn't exist, creates a directory at specific path.
        /// </summary>
        /// <param name="path">The location to create the directory in. (including directory title)</param>
        public static void TryCreateDirectory(string path)
        {
            SafetyNetIO.EnsurePathNotContainsInvalidCharacters(path);
            if (Directory.Exists(path)) return;
            Directory.CreateDirectory(path);
        }

    }
}