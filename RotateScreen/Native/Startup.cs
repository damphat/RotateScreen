using Microsoft.Win32;

namespace RotateScreen.Native
{
    class Startup
    {
        /// <summary>
        /// Add application to Startup of windows
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="path"></param>
        public static void AddStartup(string appName, string path)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(appName, "\"" + path + "\"");
            }
        }

        /// <summary>
        /// Remove application from Startup of windows
        /// </summary>
        /// <param name="appName"></param>
        public static void RemoveStartup(string appName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(appName, false);
            }
        }

        /// <summary>
        /// Check if application is run at Startup of windows
        /// </summary>
        /// <param name="appName"></param>
        public static bool IsStartup(string appName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
            {
                return key.GetValue(appName) != null;
            }
        }
    }
}