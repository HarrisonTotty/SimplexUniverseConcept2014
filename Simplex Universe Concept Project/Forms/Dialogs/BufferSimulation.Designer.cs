namespace SimplexUniverse
{
    partial class BufferSimulation
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
            this.Tabs = new MetroFramework.Controls.MetroTabControl();
            this.Tab_Basic = new MetroFramework.Controls.MetroTabPage();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.L2 = new MetroFramework.Controls.MetroLabel();
            this.Basic_NumberGenerations = new System.Windows.Forms.NumericUpDown();
            this.L1 = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.Basic_StartFromCurrentGeneration = new MetroFramework.Controls.MetroCheckBox();
            this.Tab_Advanced = new MetroFramework.Controls.MetroTabPage();
            this.StartButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.Tabs.SuspendLayout();
            this.Tab_Basic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Basic_NumberGenerations)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Tab_Basic);
            this.Tabs.Controls.Add(this.Tab_Advanced);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tabs.Location = new System.Drawing.Point(1, 60);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(475, 300);
            this.Tabs.TabIndex = 0;
            this.Tabs.UseSelectable = true;
            // 
            // Tab_Basic
            // 
            this.Tab_Basic.Controls.Add(this.metroCheckBox2);
            this.Tab_Basic.Controls.Add(this.L2);
            this.Tab_Basic.Controls.Add(this.Basic_NumberGenerations);
            this.Tab_Basic.Controls.Add(this.L1);
            this.Tab_Basic.Controls.Add(this.metroCheckBox1);
            this.Tab_Basic.Controls.Add(this.Basic_StartFromCurrentGeneration);
            this.Tab_Basic.HorizontalScrollbarBarColor = true;
            this.Tab_Basic.HorizontalScrollbarHighlightOnWheel = false;
            this.Tab_Basic.HorizontalScrollbarSize = 10;
            this.Tab_Basic.Location = new System.Drawing.Point(4, 38);
            this.Tab_Basic.Name = "Tab_Basic";
            this.Tab_Basic.Size = new System.Drawing.Size(467, 258);
            this.Tab_Basic.TabIndex = 0;
            this.Tab_Basic.Text = "Basic Buffer Settings";
            this.Tab_Basic.VerticalScrollbarBarColor = true;
            this.Tab_Basic.VerticalScrollbarHighlightOnWheel = false;
            this.Tab_Basic.VerticalScrollbarSize = 10;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Location = new System.Drawing.Point(3, 87);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(227, 15);
            this.metroCheckBox2.TabIndex = 7;
            this.metroCheckBox2.Text = "Carry changes back over to live editing";
            this.metroCheckBox2.UseSelectable = true;
            this.metroCheckBox2.Visible = false;
            this.metroCheckBox2.CheckedChanged += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // L2
            // 
            this.L2.AutoSize = true;
            this.L2.Location = new System.Drawing.Point(179, 11);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(77, 19);
            this.L2.TabIndex = 6;
            this.L2.Text = "generations";
            // 
            // Basic_NumberGenerations
            // 
            this.Basic_NumberGenerations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Basic_NumberGenerations.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Basic_NumberGenerations.Location = new System.Drawing.Point(53, 10);
            this.Basic_NumberGenerations.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.Basic_NumberGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Basic_NumberGenerations.Name = "Basic_NumberGenerations";
            this.Basic_NumberGenerations.Size = new System.Drawing.Size(120, 20);
            this.Basic_NumberGenerations.TabIndex = 5;
            this.Basic_NumberGenerations.TabStop = false;
            this.Basic_NumberGenerations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // L1
            // 
            this.L1.AutoSize = true;
            this.L1.Location = new System.Drawing.Point(3, 10);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(44, 19);
            this.L1.TabIndex = 4;
            this.L1.Text = "Buffer";
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(3, 66);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(167, 15);
            this.metroCheckBox1.TabIndex = 3;
            this.metroCheckBox1.Text = "Only preserve position data";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.Visible = false;
            // 
            // Basic_StartFromCurrentGeneration
            // 
            this.Basic_StartFromCurrentGeneration.AutoSize = true;
            this.Basic_StartFromCurrentGeneration.Location = new System.Drawing.Point(3, 45);
            this.Basic_StartFromCurrentGeneration.Name = "Basic_StartFromCurrentGeneration";
            this.Basic_StartFromCurrentGeneration.Size = new System.Drawing.Size(185, 15);
            this.Basic_StartFromCurrentGeneration.TabIndex = 2;
            this.Basic_StartFromCurrentGeneration.Text = "Buffer from current generation";
            this.Basic_StartFromCurrentGeneration.UseSelectable = true;
            // 
            // Tab_Advanced
            // 
            this.Tab_Advanced.HorizontalScrollbarBarColor = true;
            this.Tab_Advanced.HorizontalScrollbarHighlightOnWheel = false;
            this.Tab_Advanced.HorizontalScrollbarSize = 10;
            this.Tab_Advanced.Location = new System.Drawing.Point(4, 38);
            this.Tab_Advanced.Name = "Tab_Advanced";
            this.Tab_Advanced.Size = new System.Drawing.Size(467, 258);
            this.Tab_Advanced.TabIndex = 1;
            this.Tab_Advanced.Text = "Advanced";
            this.Tab_Advanced.VerticalScrollbarBarColor = true;
            this.Tab_Advanced.VerticalScrollbarHighlightOnWheel = false;
            this.Tab_Advanced.VerticalScrollbarSize = 10;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(310, 366);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(163, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start Buffer";
            this.StartButton.UseSelectable = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(4, 366);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(163, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseSelectable = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BufferSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(477, 393);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Tabs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferSimulation";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 1);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Buffer Current Simulation";
            this.Load += new System.EventHandler(this.BufferSimulation_Load);
            this.Tabs.ResumeLayout(false);
            this.Tab_Basic.ResumeLayout(false);
            this.Tab_Basic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Basic_NumberGenerations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl Tabs;
        private MetroFramework.Controls.MetroTabPage Tab_Basic;
        private MetroFramework.Controls.MetroTabPage Tab_Advanced;
        private MetroFramework.Controls.MetroButton StartButton;
        private MetroFramework.Controls.MetroButton CancelButton;
        private MetroFramework.Controls.MetroCheckBox Basic_StartFromCurrentGeneration;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel L2;
        private System.Windows.Forms.NumericUpDown Basic_NumberGenerations;
        private MetroFramework.Controls.MetroLabel L1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
    }
}