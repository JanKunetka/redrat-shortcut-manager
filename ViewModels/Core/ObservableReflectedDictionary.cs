using System.Collections;

namespace RedRatShortcuts.ViewModels.Core
{
    public class ObservableReflectedDictionary<TKey, TValue> : IDictionary<TKey, TValue> where TKey : notnull
    {
        private readonly IDictionary<TKey, TValue> root;
        private ObservableDictionary<TKey, TValue> reflect;

        public ObservableReflectedDictionary(IDictionary<TKey, TValue> root)
        {
            this.root = root;
            Refresh();
        }

        /// <summary>
        /// Refreshes the reflected dictionary with data from the root.
        /// </summary>
        public void Refresh()
        {
            reflect = new ObservableDictionary<TKey, TValue>(root);
        }
        
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            reflect.Clear();
            root.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return reflect.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            reflect.CopyTo(array, arrayIndex);
            root.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool wasRemoved = root.Remove(item);
            reflect.Remove(item);
            return wasRemoved;
        }

        public int Count { get => reflect.Count; }
        public bool IsReadOnly { get => reflect.IsReadOnly; }
        public void Add(TKey key, TValue value)
        {
            reflect.Add(key, value);
            root.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return reflect.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            bool wasRemoved = root.Remove(key);
            reflect.Remove(key);
            return wasRemoved;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return reflect.TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get => reflect[key];
            set => reflect[key] = value;
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => reflect.GetEnumerator();

        public ICollection<TKey>? Keys { get => reflect.Keys; }
        public ICollection<TValue>? Values { get => reflect.Values; }
    }
}