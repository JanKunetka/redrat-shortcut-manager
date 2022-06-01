using System.Collections.ObjectModel;

namespace RedRatShortcuts.ViewModels.Core
{
    [Serializable]
    public class ObservableDictionary<TKey,TValue> : ObservableCollection<ObservableKeyValuePair<TKey,TValue>>, IDictionary<TKey,TValue> where TKey : notnull
    {
        public ObservableDictionary() { }
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary.Count <= 0) return;
            foreach (KeyValuePair<TKey,TValue> pair in dictionary)
            {
                Add(pair.Key, pair.Value);
            }
        }
        
        #region IDictionary<TKey,TValue> Members
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key)) throw new ArgumentException("The dictionary already contains the key.");

            ObservableKeyValuePair<TKey, TValue>? item = new();
            item.Value = value;
            item.Key = key;
            base.Add(item);
        }

        public bool ContainsKey(TKey key)
        {
            ObservableKeyValuePair<TKey, TValue>? pair = ThisAsCollection().FirstOrDefault((i) => Equals(key, i.Key));
            return !Equals(default, pair);
        }

        bool Equals<TKey>(TKey a, TKey b)
        {
            return EqualityComparer<TKey>.Default.Equals(a, b);
        }

        private ObservableCollection<ObservableKeyValuePair<TKey, TValue>> ThisAsCollection()
        {
            return this;
        }

        public ICollection<TKey> Keys
        {
            get => (from i in ThisAsCollection() select i.Key).ToList();
        }

        public bool Remove(TKey key)
        {
            List<ObservableKeyValuePair<TKey, TValue>> removePairs = ThisAsCollection().Where(pair => Equals(key, pair.Key)).ToList();
            foreach (ObservableKeyValuePair<TKey, TValue> pair in removePairs)
            {
                ThisAsCollection().Remove(pair);
            }
            return removePairs.Count > 0;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            ObservableKeyValuePair<TKey, TValue> r = GetPairByKey(key);
            if (!Equals(r, default)) return false;
            value = r.Value;
            return true;
        }

        private ObservableKeyValuePair<TKey, TValue> GetPairByKey(TKey key)
        {
            return ThisAsCollection().FirstOrDefault((i) => i.Key.Equals(key));
        }

        public ICollection<TValue> Values
        {
            get => (from i in ThisAsCollection() select i.Value).ToList();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out TValue result)) throw new ArgumentException("Key not found");
                return result;
            }
            set
            {
                if (ContainsKey(key)) GetPairByKey(key).Value = value;
                else Add(key, value);
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            ObservableKeyValuePair<TKey, TValue> r = GetPairByKey(item.Key);
            if (Equals(r, default)) return false;
            return Equals(r.Value, item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            ObservableKeyValuePair<TKey, TValue> removePair = GetPairByKey(item.Key);
            if (Equals(removePair, default)) return false;
            if (!Equals(removePair.Value,item.Value)) return false;
            return ThisAsCollection().Remove(removePair);
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (from i in ThisAsCollection() select new KeyValuePair<TKey, TValue>(i.Key, i.Value)).ToList().GetEnumerator();
        }

        #endregion
    }
}
