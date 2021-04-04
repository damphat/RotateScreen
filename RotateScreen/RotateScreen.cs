using RotateScreen.Native;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RotateScreen
{
    public partial class RotateScreenForm : Form
    {
        public static String appName = "RotateScreen";
        KeyboardHook hook = new KeyboardHook();

        private bool hidden = false;

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
                if (Startup.IsStartup(appName))
                {
                    Startup.RemoveStartup(appName);
                }
                else
                {
                    Startup.AddStartup(appName, Application.ExecutablePath);
                }
            };

            contextMenuStrip1.Opening += delegate(object sender, CancelEventArgs e)
            {
                runAtStartupToolStripMenuItem.Checked = Startup.IsStartup(appName);
            };

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            RegisterGlobalHotKeys();

            this.ShowInTaskbar = false;
        }


        void TryRegisterHotKey(ModifierKeys modifiers, Keys key)
        {
            try
            {
                hook.RegisterHotKey(modifiers, key);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    $"Can not register {modifiers} + {key}, is it already registered by other application?");
            }
        }

        static (ModifierKeys, Keys) KeyToModifier(Keys key)
        {
            ModifierKeys modifiers = 0;
            var retKey = key & Keys.KeyCode;

            if (key.HasFlag(Keys.Alt)) modifiers = modifiers | Native.ModifierKeys.Alt;
            if (key.HasFlag(Keys.Control)) modifiers = modifiers | Native.ModifierKeys.Control;
            if (key.HasFlag(Keys.Shift)) modifiers = modifiers | Native.ModifierKeys.Shift;

            //if (key.HasFlag(Keys.????)) modifiers = modifiers | Native.ModifierKeys.Win;

            return (modifiers, retKey);
        }

        void RegisterGlobalHotKeys()
        {
            foreach (ToolStripItem i in contextMenuStrip1.Items)
            {
                if (i is ToolStripMenuItem item)
                {
                    if (item.ShortcutKeys == Keys.None) continue;

                    var (modifiers, key) = KeyToModifier(item.ShortcutKeys);
                    TryRegisterHotKey(modifiers, key);
                }
            }
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            foreach (ToolStripItem i in contextMenuStrip1.Items)
            {
                if (i is ToolStripMenuItem item)
                {
                    var (modifiers, key) = KeyToModifier(item.ShortcutKeys);
                    if (modifiers == e.Modifier && key == e.Key)
                    {
                        item.PerformClick();
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Native.ShowMe.WM_SHOWME)
            {
                ShowMe();
            }

            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rotateScreenIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (hidden) // this.WindowState == FormWindowState.Minimized)
            {
                // this.WindowState = FormWindowState.Normal;
                this.Show();
                hidden = false;
            }
            else
            {
                // this.WindowState = FormWindowState.Minimized;
                this.Hide();
                hidden = true;
            }
        }


        private void RotateScreenForm_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            hidden = true;
        }

        private void RotateScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            hidden = true;
            e.Cancel = true;
            rotateScreenIcon.ShowBalloonTip(3000, null, "Still run in background", ToolTipIcon.None);
        }
    }
}