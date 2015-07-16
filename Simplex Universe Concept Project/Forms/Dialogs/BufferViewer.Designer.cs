namespace SimplexUniverse
{
    partial class BufferViewer
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
            this.Menu = new SimplexUniverse.Drawing.MetroMenu();
            this.Menu_Playback = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Playback_Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerationTracker = new MetroFramework.Controls.MetroTrackBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Playback_Loop = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Playback});
            this.Menu.Location = new System.Drawing.Point(1, 60);
            this.Menu.MetroColor = MetroFramework.MetroColorStyle.Blue;
            this.Menu.MetroTheme = MetroFramework.MetroThemeStyle.Light;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(518, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "metroMenu1";
            // 
            // Menu_Playback
            // 
            this.Menu_Playback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Playback.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Playback_Start,
            this.Playback_Pause,
            this.toolStripSeparator1,
            this.Playback_Loop});
            this.Menu_Playback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Playback.Name = "Menu_Playback";
            this.Menu_Playback.Size = new System.Drawing.Size(66, 20);
            this.Menu_Playback.Text = "Playback";
            // 
            // Playback_Start
            // 
            this.Playback_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Playback_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Playback_Start.Name = "Playback_Start";
            this.Playback_Start.Size = new System.Drawing.Size(152, 22);
            this.Playback_Start.Text = "Start / Resume";
            // 
            // Playback_Pause
            // 
            this.Playback_Pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Playback_Pause.Enabled = false;
            this.Playback_Pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Playback_Pause.Name = "Playback_Pause";
            this.Playback_Pause.Size = new System.Drawing.Size(152, 22);
            this.Playback_Pause.Text = "Pause";
            // 
            // GenerationTracker
            // 
            this.GenerationTracker.BackColor = System.Drawing.Color.Transparent;
            this.GenerationTracker.Dock = System.Windows.Forms.DockStyle.Top;
            this.GenerationTracker.Location = new System.Drawing.Point(1, 84);
            this.GenerationTracker.Name = "GenerationTracker";
            this.GenerationTracker.Size = new System.Drawing.Size(518, 23);
            this.GenerationTracker.TabIndex = 2;
            this.GenerationTracker.Value = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // Playback_Loop
            // 
            this.Playback_Loop.Checked = true;
            this.Playback_Loop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Playback_Loop.Name = "Playback_Loop";
            this.Playback_Loop.Size = new System.Drawing.Size(152, 22);
            this.Playback_Loop.Text = "Loop";
            // 
            // BufferViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(520, 459);
            this.Controls.Add(this.GenerationTracker);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "BufferViewer";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 1);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Buffered Simulation Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BufferViewer_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Drawing.MetroMenu Menu;
        private System.Windows.Forms.ToolStripMenuItem Menu_Playback;
        private System.Windows.Forms.ToolStripMenuItem Playback_Start;
        private System.Windows.Forms.ToolStripMenuItem Playback_Pause;
        private MetroFramework.Controls.MetroTrackBar GenerationTracker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Playback_Loop;

    }
}