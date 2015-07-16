namespace SimplexUniverse
{
    partial class BufferingForm
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
            this.PB = new MetroFramework.Controls.MetroProgressBar();
            this.StatusLabel = new MetroFramework.Controls.MetroLabel();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PB
            // 
            this.PB.HideProgressText = false;
            this.PB.Location = new System.Drawing.Point(23, 86);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(544, 23);
            this.PB.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(23, 60);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(544, 23);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Ready...";
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 1;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // BufferingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(590, 124);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferingForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Buffering Simulation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BufferForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar PB;
        private MetroFramework.Controls.MetroLabel StatusLabel;
        private System.Windows.Forms.Timer StartTimer;
    }
}