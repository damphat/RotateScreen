
namespace RotateScreen
{
    partial class RotateScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotateScreenForm));
            this.rotateScreenIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rotate0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate270ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.runAtStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rotateScreenIcon
            // 
            this.rotateScreenIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.rotateScreenIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("rotateScreenIcon.Icon")));
            this.rotateScreenIcon.Text = "Rotate Screen Ctrl + Alt + Arrow Keys";
            this.rotateScreenIcon.Visible = true;
            this.rotateScreenIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.rotateScreenIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotate0ToolStripMenuItem,
            this.rotate90ToolStripMenuItem,
            this.rotate180ToolStripMenuItem,
            this.rotate270ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.runAtStartupToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 148);
            // 
            // rotate0ToolStripMenuItem
            // 
            this.rotate0ToolStripMenuItem.Name = "rotate0ToolStripMenuItem";
            this.rotate0ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Up)));
            this.rotate0ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.rotate0ToolStripMenuItem.Text = "Rotate 0°";
            // 
            // rotate90ToolStripMenuItem
            // 
            this.rotate90ToolStripMenuItem.Name = "rotate90ToolStripMenuItem";
            this.rotate90ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Right)));
            this.rotate90ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.rotate90ToolStripMenuItem.Text = "Rotate 90°";
            // 
            // rotate180ToolStripMenuItem
            // 
            this.rotate180ToolStripMenuItem.Name = "rotate180ToolStripMenuItem";
            this.rotate180ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Down)));
            this.rotate180ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.rotate180ToolStripMenuItem.Text = "Rotate 180°";
            // 
            // rotate270ToolStripMenuItem
            // 
            this.rotate270ToolStripMenuItem.Name = "rotate270ToolStripMenuItem";
            this.rotate270ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Left)));
            this.rotate270ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.rotate270ToolStripMenuItem.Text = "Rotate 270°";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 6);
            // 
            // runAtStartupToolStripMenuItem
            // 
            this.runAtStartupToolStripMenuItem.Name = "runAtStartupToolStripMenuItem";
            this.runAtStartupToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.runAtStartupToolStripMenuItem.Text = "Run at Startup";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(219, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 142);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ctrl + Alt + Arrow Keys to rotate your screen.";
            // 
            // RotateScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 142);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RotateScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotate Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RotateScreenForm_FormClosing);
            this.Shown += new System.EventHandler(this.RotateScreenForm_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon rotateScreenIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate90ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate180ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotate270ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem runAtStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

