using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotateScreen
{
    public partial class RotateScreenForm : Form
    {
        KeyboardHook hook = new KeyboardHook();

        private bool hidden = false;

        public RotateScreenForm()
        {
            InitializeComponent();

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                        
            tryRegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt,
                Keys.Left);
            tryRegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt,
                Keys.Right);
            tryRegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt,
                Keys.Up);
            tryRegisterHotKey(global::ModifierKeys.Control | global::ModifierKeys.Alt,
                Keys.Down);

            this.ShowInTaskbar = false;

        }

        void tryRegisterHotKey(ModifierKeys modifiers, Keys key)
        {
            try
            {
                hook.RegisterHotKey(modifiers, key);
            }
            catch (Exception)
            {
                MessageBox.Show($"Can not register {modifiers} + {key}, is it already registered by other application?");
            }
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {

            // show the keys pressed in a label.
            // label1.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
            Console.WriteLine(e.Modifier.ToString() + " + " + e.Key.ToString());
           switch(e.Key)
            {
                case Keys.Left:
                    Display.Rotate(1, Display.Orientations.DEGREES_CW_90);
                    break;
                case Keys.Right:
                    Display.Rotate(1, Display.Orientations.DEGREES_CW_270);
                    break;
                case Keys.Down:
                    Display.Rotate(1, Display.Orientations.DEGREES_CW_180);
                    break;
                case Keys.Up:
                    Display.Rotate(1, Display.Orientations.DEGREES_CW_0);
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            hidden = false;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RotateScreenForm_Load(object sender, EventArgs e)
        {

        }

        private void RotateScreenForm_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            hidden = true;

        }

        private void addToStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoRun.AddStartup("RotateScreen", Application.ExecutablePath);
        }

        private void removeFromStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoRun.RemoveStartup("RotaeScreen");
        }
    }
}
