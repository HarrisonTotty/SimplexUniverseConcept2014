namespace SimplexUniverse
{
    partial class LoadSimulation
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
            this.StatusLabel = new MetroFramework.Controls.MetroLabel();
            this.PB = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Location = new System.Drawing.Point(236, 31);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(220, 29);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(23, 63);
            this.PB.MarqueeAnimationSpeed = 50;
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(433, 23);
            this.PB.TabIndex = 2;
            this.PB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoadSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 104);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadSimulation";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Loading Simulation...";
            this.Load += new System.EventHandler(this.LoadSimulation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel StatusLabel;
        private MetroFramework.Controls.MetroProgressBar PB;
    }
}