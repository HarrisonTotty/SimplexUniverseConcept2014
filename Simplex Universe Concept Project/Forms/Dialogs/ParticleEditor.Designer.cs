namespace SimplexUniverse
{
    partial class ParticleEditor
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
            this.Editor = new System.Windows.Forms.PropertyGrid();
            this.MainMenu = new SimplexUniverse.Drawing.MetroMenu();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Editor
            // 
            this.Editor.BackColor = System.Drawing.Color.White;
            this.Editor.CategorySplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.Editor.CommandsBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.HelpBackColor = System.Drawing.Color.White;
            this.Editor.HelpBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.Editor.Location = new System.Drawing.Point(1, 84);
            this.Editor.Name = "Editor";
            this.Editor.Size = new System.Drawing.Size(500, 299);
            this.Editor.TabIndex = 15;
            this.Editor.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File});
            this.MainMenu.Location = new System.Drawing.Point(1, 60);
            this.MainMenu.MetroColor = MetroFramework.MetroColorStyle.Blue;
            this.MainMenu.MetroTheme = MetroFramework.MetroThemeStyle.Light;
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(500, 24);
            this.MainMenu.TabIndex = 16;
            // 
            // Menu_File
            // 
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // ParticleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(502, 403);
            this.Controls.Add(this.Editor);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "ParticleEditor";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Particle Editor";
            this.Load += new System.EventHandler(this.ParticleEditor_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PropertyGrid Editor;
        private Drawing.MetroMenu MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
    }
}