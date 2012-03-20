using System.Windows.Forms;

namespace DotNetScripting
{
    /// <summary>
    /// Holds settings for the plugin.
    /// </summary>
    public class Settings
    {
        public bool ShortcutKeyUseShift { get; set; }
        public bool ShortcutKeyUseCtrl { get; set; }
        public bool ShortcutKeyUseAlt { get; set; }
        public Keys ShortcutKey { get; set; }
    }
}
