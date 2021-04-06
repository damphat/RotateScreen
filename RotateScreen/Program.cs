using RotateScreen.Native;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RotateScreen
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var mutex = new Mutex(true, "RotateScreen");

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new RotateScreenForm());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                ShowMe.PostMessage(
                    (IntPtr) ShowMe.HWND_BROADCAST,
                    ShowMe.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}