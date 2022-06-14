
namespace RedRatShortcuts.Models.FileSystem.Serialization
{
    /// <summary>
    /// A Serialized List, ready for saving on external storage.
    /// </summary>
    /// <typeparam name="T">Readable, non-serialized asset.</typeparam>
    /// <typeparam name="TS">Serialized Form of <see cref="T"/>Asset.</typeparam>
    [System.Serializable]
    public class SerializedList<T,TS>
    {
        private IList<TS> serializedList = new List<TS>();

        /// <summary>
        /// The Constructor.
        /// </summary>
        /// <param name="objectList">The List we want to serialize.</param>
        /// <param name="newSerializedObject">A method creating the Serialized Data Object this list is going to contain.</param>
        /// <param name="newDeserializedObject">A method that creates a deserialized form of the object.</param>
        public SerializedList(IList<T> objectList, Func<T,TS> newSerializedObject)
        {
            foreach (T listObject in objectList)
            {
                TS newObject = newSerializedObject(listObject);
                serializedList.Add(newObject);
            }
        }

        /// <summary>
        /// Deserializes the list into a Unity readable format.
        /// </summary>
        /// <returns>A list of deserialized objects.</returns>
        public IList<T> Deserialize(Func<TS, T> newDeserializedObject)
        {
            return serializedList.Select(newDeserializedObject).ToList();
        }

    }
}