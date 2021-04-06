using RotateScreen.Native;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RotateScreen
{
    public partial class RotateScreenForm : Form
    {
        public static string AppName = "RotateScreen";
        public static StartupEntry StartupEntry = new StartupEntry(AppName);
        private readonly KeyboardHook _hook = new KeyboardHook();

        private bool _hidden = false;
        private bool _exit = false;

        public RotateScreenForm()
        {
            InitializeComponent();

            rotate0ToolStripMenuItem.Click += delegate(object sender, EventArgs args)
            {
                Display.Rotate(1, Display.Orientations.DEGREES_CW_0);
            };

            rotate90ToolStripMenuItem.Click += delegate(object sender, EventArgs args)
            {
                Display.Rotate(1, Display.Orientations.DEGREES_CW_90);
            };


            rotate180ToolStripMenuItem.Click += delegate(object sender, EventArgs args)
            {
                Display.Rotate(1, Display.Orientations.DEGREES_CW_180);
            };

            rotate270ToolStripMenuItem.Click += delegate(object sender, EventArgs args)
            {
                Display.Rotate(1, Display.Orientations.DEGREES_CW_270);
            };


            runAtStartupToolStripMenuItem.Click += delegate(object sender, EventArgs e)
            {
                var current = StartupEntry.Value;
                StartupEntry.Value = current == null ? Application.ExecutablePath : null;
            };

            contextMenuStrip1.Opening +=
                delegate { runAtStartupToolStripMenuItem.Checked = StartupEntry.Value != null; };

            // register the event that is fired after the key press.
            _hook.KeyPressed +=
                hook_KeyPressed;

            RegisterGlobalHotKeys();

            ShowInTaskbar = false;
        }


        private void TryRegisterHotKey(ModifierKeys modifiers, Keys key)
        {
            try
            {
                _hook.RegisterHotKey(modifiers, key);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    $@"Can not register {modifiers} + {key}, is it already registered by other application?");
            }
        }


        private static (ModifierKeys, Keys) KeyToModifier(Keys key)
        {
            ModifierKeys modifiers = 0;
            var retKey = key & Keys.KeyCode;

            if (key.HasFlag(Keys.Alt)) modifiers |= Native.ModifierKeys.Alt;
            if (key.HasFlag(Keys.Control)) modifiers |= Native.ModifierKeys.Control;
            if (key.HasFlag(Keys.Shift)) modifiers |= Native.ModifierKeys.Shift;

            //if (key.HasFlag(Keys.????)) modifiers = modifiers | Native.ModifierKeys.Win;

            return (modifiers, retKey);
        }

        private void RegisterGlobalHotKeys()
        {
            foreach (ToolStripItem i in contextMenuStrip1.Items)
                if (i is ToolStripMenuItem item)
                {
                    if (item.ShortcutKeys == Keys.None) continue;

                    var (modifiers, key) = KeyToModifier(item.ShortcutKeys);
                    TryRegisterHotKey(modifiers, key);
                }
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            foreach (ToolStripItem i in contextMenuStrip1.Items)
                if (i is ToolStripMenuItem item)
                {
                    var (modifiers, key) = KeyToModifier(item.ShortcutKeys);
                    if (modifiers == e.Modifier && key == e.Key) item.PerformClick();
                }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Native.ShowMe.WM_SHOWME) ShowMe();

            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;

            // get our current "TopMost" value (ours will always be false though)
            var top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _exit = true;
            Application.Exit();
        }

        private void rotateScreenIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_hidden) // this.WindowState == FormWindowState.Minimized)
            {
                // this.WindowState = FormWindowState.Normal;
                Show();
                _hidden = false;
            }
            else
            {
                // this.WindowState = FormWindowState.Minimized;
                Hide();
                _hidden = true;
            }
        }


        private void RotateScreenForm_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            Hide();
            _hidden = true;
        }

        private void RotateScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exit)
            {
                Hide();
                _hidden = true;
                e.Cancel = true;
                rotateScreenIcon.ShowBalloonTip(3000, null, "Still run in background", ToolTipIcon.None);
            }
        }

        private void RotateScreenForm_Load(object sender, EventArgs e)
        {
            if (StartupEntry.Value != null && StartupEntry.Value != Application.ExecutablePath)
                MessageBox.Show($"Current exe: {Application.ExecutablePath}\n\nStartupEntry: {StartupEntry.Value}",
                    @"Multiple exe detected!");
        }
    }
}