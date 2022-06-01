using RedRatShortcuts.Models.Shortcuts;

namespace RedRatShortcuts.Models
{
    /// <summary>
    /// Overseers and controls the Shortcut reader system.
    /// </summary>
    public class ShortcutReaderOverseer
    {
        private ShortcutReader reader;
        
        private readonly IDictionary<string, string> shortcuts;
        
        private bool doProcessing;

        public ShortcutReaderOverseer()
        {
            reader = new ShortcutReader();
            
            shortcuts = new Dictionary<string, string>();
            AddDefaultData();
        }
        
        public void Start() => doProcessing = true;
        public void End() => doProcessing = false;
        public IDictionary<string, string> Get() => shortcuts;

        
        private void AddDefaultData()
        {
            shortcuts.Add("fred", "C:/Users/user/Saved Games");
            shortcuts.Add("aud", "C:/Program Files/Audacity/Audacity.exe");
            shortcuts.Add("ase", "D:/User Files/Obrázky/COLOR WHEEEL.jpg");
        }
        
    }
}

