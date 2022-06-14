
namespace RedRatShortcuts.Models.FileSystem.Serialization
{
    /// <summary>
    /// A base for all serialized forms of objects.
    /// <typeparam name="T">The non-serialized form of the object.</typeparam>
    /// </summary>
    public interface ISerializedObject<out T>
    {
        /// <summary>
        /// Deserializes the object, so that it can be read by the program.
        /// </summary>
        /// <returns>The data in a Unity readable form.</returns>
        public T Deserialize();
    }
}