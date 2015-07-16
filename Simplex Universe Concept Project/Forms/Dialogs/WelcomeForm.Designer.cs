namespace SimplexUniverse
{
    partial class WelcomeForm
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
            this.CreateNewUniverseButton = new MetroFramework.Controls.MetroTile();
            this.LoadPreviousUniverseButton = new MetroFramework.Controls.MetroTile();
            this.DescriptionLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // CreateNewUniverseButton
            // 
            this.CreateNewUniverseButton.ActiveControl = null;
            this.CreateNewUniverseButton.Location = new System.Drawing.Point(23, 163);
            this.CreateNewUniverseButton.Name = "CreateNewUniverseButton";
            this.CreateNewUniverseButton.Size = new System.Drawing.Size(448, 101);
            this.CreateNewUniverseButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CreateNewUniverseButton.TabIndex = 0;
            this.CreateNewUniverseButton.Text = "CREATE NEW UNIVERSE";
            this.CreateNewUniverseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CreateNewUniverseButton.UseSelectable = true;
            this.CreateNewUniverseButton.Click += new System.EventHandler(this.CreateNewUniverseButton_Click);
            // 
            // LoadPreviousUniverseButton
            // 
            this.LoadPreviousUniverseButton.ActiveControl = null;
            this.LoadPreviousUniverseButton.Location = new System.Drawing.Point(23, 270);
            this.LoadPreviousUniverseButton.Name = "LoadPreviousUniverseButton";
            this.LoadPreviousUniverseButton.Size = new System.Drawing.Size(448, 101);
            this.LoadPreviousUniverseButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LoadPreviousUniverseButton.TabIndex = 1;
            this.LoadPreviousUniverseButton.Text = "LOAD PREVIOUS UNIVERSE";
            this.LoadPreviousUniverseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoadPreviousUniverseButton.UseSelectable = true;
            this.LoadPreviousUniverseButton.Click += new System.EventHandler(this.LoadPreviousUniverseButton_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DescriptionLabel.Location = new System.Drawing.Point(20, 60);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(454, 100);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "Welcome to Simplex Universe!";
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(494, 391);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.LoadPreviousUniverseButton);
            this.Controls.Add(this.CreateNewUniverseButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.StartWizard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile CreateNewUniverseButton;
        private MetroFramework.Controls.MetroTile LoadPreviousUniverseButton;
        private MetroFramework.Controls.MetroLabel DescriptionLabel;


    }
}