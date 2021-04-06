using Microsoft.Win32;

namespace RotateScreen.Native
{
    /// <summary>
    /// Make an exe to run at startup by adding exePath to the registry.
    /// </summary>
    /// <code>
    /// var startup = new StartupEntry("myApp");
    /// startup.Value = exePath;
    /// startup.Value = null;
    /// </code>
    public class StartupEntry
    {
        private const string RegPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public readonly string Name;

        public StartupEntry(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The full path of the exe to run at startup.
        ///
        /// Assign null to remove the entry.
        /// </summary>
        public string Value
        {
            get
            {
                using var reg = Registry.CurrentUser.OpenSubKey(RegPath, false);
                var value = reg!.GetValue(Name);
                return value?.ToString();
            }
            set
            {
                using var key = Registry.CurrentUser.OpenSubKey(RegPath, true);
                if (value != null)
                    key!.SetValue(Name, value);
                else
                    key!.DeleteValue(Name, false);
            }
        }
    }
}