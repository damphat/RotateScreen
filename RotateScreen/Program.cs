using Native;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RotateScreen
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(true, "RotateScreen");

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
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}
