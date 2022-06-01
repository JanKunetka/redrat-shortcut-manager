namespace RedRatShortcuts.ViewModels.Core
{
    [Serializable]
    public class ObservableKeyValuePair<TKey,TValue> : ViewModelBase
    {
        private TKey key;
        private TValue value;

        public TKey Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged();
            }
        }

        public TValue Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged();
            }
        } 
    }
}