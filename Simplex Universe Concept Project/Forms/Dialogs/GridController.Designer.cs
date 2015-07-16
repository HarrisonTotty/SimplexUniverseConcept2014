namespace SimplexUniverse
{
    partial class GridController
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
            this.Toggle3D = new MetroFramework.Controls.MetroToggle();
            this.Label3DMode = new MetroFramework.Controls.MetroLabel();
            this.LabelPointMode = new MetroFramework.Controls.MetroLabel();
            this.TogglePointMode = new MetroFramework.Controls.MetroToggle();
            this.LabelPPT = new MetroFramework.Controls.MetroLabel();
            this.ToggleParticleTrails = new MetroFramework.Controls.MetroToggle();
            this.LabelHD = new MetroFramework.Controls.MetroLabel();
            this.ToggleHighDefinition = new MetroFramework.Controls.MetroToggle();
            this.LabelGenerationCounter = new MetroFramework.Controls.MetroLabel();
            this.ToggleGenerationCounter = new MetroFramework.Controls.MetroToggle();
            this.LabelX = new MetroFramework.Controls.MetroLabel();
            this.XAxisIndex = new System.Windows.Forms.NumericUpDown();
            this.YAxisIndex = new System.Windows.Forms.NumericUpDown();
            this.LabelY = new MetroFramework.Controls.MetroLabel();
            this.ZAxisIndex = new System.Windows.Forms.NumericUpDown();
            this.LabelZ = new MetroFramework.Controls.MetroLabel();
            this.PTF = new System.Windows.Forms.NumericUpDown();
            this.LabelPTF = new MetroFramework.Controls.MetroLabel();
            this.PTL = new System.Windows.Forms.NumericUpDown();
            this.LabelPTL = new MetroFramework.Controls.MetroLabel();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.LFOV = new MetroFramework.Controls.MetroLabel();
            this.FOV = new System.Windows.Forms.NumericUpDown();
            this.PosTB = new MetroFramework.Controls.MetroTextBox();
            this.OrTB = new MetroFramework.Controls.MetroTextBox();
            this.LCameraOr = new MetroFramework.Controls.MetroLabel();
            this.LCameraPos = new MetroFramework.Controls.MetroLabel();
            this.LCamOptions = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.XAxisIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YAxisIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZAxisIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOV)).BeginInit();
            this.SuspendLayout();
            // 
            // Toggle3D
            // 
            this.Toggle3D.AutoSize = true;
            this.Toggle3D.Checked = true;
            this.Toggle3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Toggle3D.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.Toggle3D.Location = new System.Drawing.Point(168, 30);
            this.Toggle3D.Name = "Toggle3D";
            this.Toggle3D.Size = new System.Drawing.Size(80, 17);
            this.Toggle3D.Style = MetroFramework.MetroColorStyle.Blue;
            this.Toggle3D.TabIndex = 0;
            this.Toggle3D.TabStop = false;
            this.Toggle3D.Text = "On";
            this.Toggle3D.UseSelectable = true;
            this.Toggle3D.CheckedChanged += new System.EventHandler(this.Toggle3D_CheckedChanged);
            // 
            // Label3DMode
            // 
            this.Label3DMode.Location = new System.Drawing.Point(3, 28);
            this.Label3DMode.Name = "Label3DMode";
            this.Label3DMode.Size = new System.Drawing.Size(101, 23);
            this.Label3DMode.TabIndex = 1;
            this.Label3DMode.Text = "3D Mode";
            // 
            // LabelPointMode
            // 
            this.LabelPointMode.Location = new System.Drawing.Point(3, 51);
            this.LabelPointMode.Name = "LabelPointMode";
            this.LabelPointMode.Size = new System.Drawing.Size(158, 19);
            this.LabelPointMode.TabIndex = 3;
            this.LabelPointMode.Text = "Point Mode";
            // 
            // TogglePointMode
            // 
            this.TogglePointMode.AutoSize = true;
            this.TogglePointMode.Checked = true;
            this.TogglePointMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TogglePointMode.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.TogglePointMode.Location = new System.Drawing.Point(168, 53);
            this.TogglePointMode.Name = "TogglePointMode";
            this.TogglePointMode.Size = new System.Drawing.Size(80, 17);
            this.TogglePointMode.Style = MetroFramework.MetroColorStyle.Blue;
            this.TogglePointMode.TabIndex = 2;
            this.TogglePointMode.TabStop = false;
            this.TogglePointMode.Text = "On";
            this.TogglePointMode.UseSelectable = true;
            this.TogglePointMode.CheckedChanged += new System.EventHandler(this.TogglePointMode_CheckedChanged);
            // 
            // LabelPPT
            // 
            this.LabelPPT.Location = new System.Drawing.Point(3, 74);
            this.LabelPPT.Name = "LabelPPT";
            this.LabelPPT.Size = new System.Drawing.Size(158, 19);
            this.LabelPPT.TabIndex = 5;
            this.LabelPPT.Text = "Plot Particle Trails";
            this.LabelPPT.Click += new System.EventHandler(this.LabelPPT_Click);
            // 
            // ToggleParticleTrails
            // 
            this.ToggleParticleTrails.AutoSize = true;
            this.ToggleParticleTrails.Checked = true;
            this.ToggleParticleTrails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleParticleTrails.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.ToggleParticleTrails.Location = new System.Drawing.Point(168, 76);
            this.ToggleParticleTrails.Name = "ToggleParticleTrails";
            this.ToggleParticleTrails.Size = new System.Drawing.Size(80, 17);
            this.ToggleParticleTrails.Style = MetroFramework.MetroColorStyle.Blue;
            this.ToggleParticleTrails.TabIndex = 4;
            this.ToggleParticleTrails.TabStop = false;
            this.ToggleParticleTrails.Text = "On";
            this.ToggleParticleTrails.UseSelectable = true;
            this.ToggleParticleTrails.CheckedChanged += new System.EventHandler(this.ToggleParticleTrails_CheckedChanged);
            // 
            // LabelHD
            // 
            this.LabelHD.Location = new System.Drawing.Point(3, 97);
            this.LabelHD.Name = "LabelHD";
            this.LabelHD.Size = new System.Drawing.Size(158, 19);
            this.LabelHD.TabIndex = 7;
            this.LabelHD.Text = "High Definition";
            // 
            // ToggleHighDefinition
            // 
            this.ToggleHighDefinition.AutoSize = true;
            this.ToggleHighDefinition.Checked = true;
            this.ToggleHighDefinition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleHighDefinition.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.ToggleHighDefinition.Location = new System.Drawing.Point(168, 99);
            this.ToggleHighDefinition.Name = "ToggleHighDefinition";
            this.ToggleHighDefinition.Size = new System.Drawing.Size(80, 17);
            this.ToggleHighDefinition.Style = MetroFramework.MetroColorStyle.Blue;
            this.ToggleHighDefinition.TabIndex = 6;
            this.ToggleHighDefinition.TabStop = false;
            this.ToggleHighDefinition.Text = "On";
            this.ToggleHighDefinition.UseSelectable = true;
            this.ToggleHighDefinition.CheckedChanged += new System.EventHandler(this.ToggleHighDefinition_CheckedChanged);
            // 
            // LabelGenerationCounter
            // 
            this.LabelGenerationCounter.Location = new System.Drawing.Point(3, 120);
            this.LabelGenerationCounter.Name = "LabelGenerationCounter";
            this.LabelGenerationCounter.Size = new System.Drawing.Size(158, 19);
            this.LabelGenerationCounter.TabIndex = 9;
            this.LabelGenerationCounter.Text = "Generation Counter";
            // 
            // ToggleGenerationCounter
            // 
            this.ToggleGenerationCounter.AutoSize = true;
            this.ToggleGenerationCounter.Checked = true;
            this.ToggleGenerationCounter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleGenerationCounter.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.ToggleGenerationCounter.Location = new System.Drawing.Point(168, 122);
            this.ToggleGenerationCounter.Name = "ToggleGenerationCounter";
            this.ToggleGenerationCounter.Size = new System.Drawing.Size(80, 17);
            this.ToggleGenerationCounter.Style = MetroFramework.MetroColorStyle.Blue;
            this.ToggleGenerationCounter.TabIndex = 8;
            this.ToggleGenerationCounter.TabStop = false;
            this.ToggleGenerationCounter.Text = "On";
            this.ToggleGenerationCounter.UseSelectable = true;
            this.ToggleGenerationCounter.CheckedChanged += new System.EventHandler(this.ToggleGenerationCounter_CheckedChanged);
            // 
            // LabelX
            // 
            this.LabelX.Location = new System.Drawing.Point(3, 145);
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(158, 20);
            this.LabelX.TabIndex = 10;
            this.LabelX.Text = "X-Axis Index";
            // 
            // XAxisIndex
            // 
            this.XAxisIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XAxisIndex.Location = new System.Drawing.Point(167, 145);
            this.XAxisIndex.Name = "XAxisIndex";
            this.XAxisIndex.Size = new System.Drawing.Size(80, 20);
            this.XAxisIndex.TabIndex = 11;
            this.XAxisIndex.TabStop = false;
            this.XAxisIndex.ValueChanged += new System.EventHandler(this.XAxisIndex_ValueChanged);
            // 
            // YAxisIndex
            // 
            this.YAxisIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YAxisIndex.Location = new System.Drawing.Point(167, 171);
            this.YAxisIndex.Name = "YAxisIndex";
            this.YAxisIndex.Size = new System.Drawing.Size(80, 20);
            this.YAxisIndex.TabIndex = 13;
            this.YAxisIndex.TabStop = false;
            this.YAxisIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YAxisIndex.ValueChanged += new System.EventHandler(this.YAxisIndex_ValueChanged);
            // 
            // LabelY
            // 
            this.LabelY.Location = new System.Drawing.Point(3, 171);
            this.LabelY.Name = "LabelY";
            this.LabelY.Size = new System.Drawing.Size(158, 20);
            this.LabelY.TabIndex = 12;
            this.LabelY.Text = "Y-Axis Index";
            // 
            // ZAxisIndex
            // 
            this.ZAxisIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ZAxisIndex.Location = new System.Drawing.Point(167, 197);
            this.ZAxisIndex.Name = "ZAxisIndex";
            this.ZAxisIndex.Size = new System.Drawing.Size(80, 20);
            this.ZAxisIndex.TabIndex = 15;
            this.ZAxisIndex.TabStop = false;
            this.ZAxisIndex.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ZAxisIndex.ValueChanged += new System.EventHandler(this.ZAxisIndex_ValueChanged);
            // 
            // LabelZ
            // 
            this.LabelZ.Location = new System.Drawing.Point(3, 197);
            this.LabelZ.Name = "LabelZ";
            this.LabelZ.Size = new System.Drawing.Size(158, 20);
            this.LabelZ.TabIndex = 14;
            this.LabelZ.Text = "Z-Axis Index";
            // 
            // PTF
            // 
            this.PTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTF.Location = new System.Drawing.Point(167, 223);
            this.PTF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PTF.Name = "PTF";
            this.PTF.Size = new System.Drawing.Size(80, 20);
            this.PTF.TabIndex = 17;
            this.PTF.TabStop = false;
            this.PTF.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PTF.ValueChanged += new System.EventHandler(this.PTF_ValueChanged);
            // 
            // LabelPTF
            // 
            this.LabelPTF.Location = new System.Drawing.Point(3, 223);
            this.LabelPTF.Name = "LabelPTF";
            this.LabelPTF.Size = new System.Drawing.Size(158, 20);
            this.LabelPTF.TabIndex = 16;
            this.LabelPTF.Text = "Particle Trail Frequency";
            // 
            // PTL
            // 
            this.PTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTL.Location = new System.Drawing.Point(167, 249);
            this.PTL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PTL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PTL.Name = "PTL";
            this.PTL.Size = new System.Drawing.Size(80, 20);
            this.PTL.TabIndex = 19;
            this.PTL.TabStop = false;
            this.PTL.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.PTL.ValueChanged += new System.EventHandler(this.PTL_ValueChanged);
            // 
            // LabelPTL
            // 
            this.LabelPTL.Location = new System.Drawing.Point(3, 249);
            this.LabelPTL.Name = "LabelPTL";
            this.LabelPTL.Size = new System.Drawing.Size(158, 20);
            this.LabelPTL.TabIndex = 18;
            this.LabelPTL.Text = "Particle Trail Length";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // LFOV
            // 
            this.LFOV.AutoSize = true;
            this.LFOV.Location = new System.Drawing.Point(3, 362);
            this.LFOV.Name = "LFOV";
            this.LFOV.Size = new System.Drawing.Size(87, 19);
            this.LFOV.TabIndex = 25;
            this.LFOV.Text = "Field of View:";
            // 
            // FOV
            // 
            this.FOV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FOV.Location = new System.Drawing.Point(97, 362);
            this.FOV.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.FOV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FOV.Name = "FOV";
            this.FOV.Size = new System.Drawing.Size(154, 20);
            this.FOV.TabIndex = 24;
            this.FOV.TabStop = false;
            this.FOV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FOV.ValueChanged += new System.EventHandler(this.FOV_ValueChanged);
            // 
            // PosTB
            // 
            this.PosTB.Lines = new string[] {
        "<0, 0, 0>"};
            this.PosTB.Location = new System.Drawing.Point(97, 304);
            this.PosTB.MaxLength = 32767;
            this.PosTB.Name = "PosTB";
            this.PosTB.PasswordChar = '\0';
            this.PosTB.ReadOnly = true;
            this.PosTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PosTB.SelectedText = "";
            this.PosTB.Size = new System.Drawing.Size(154, 23);
            this.PosTB.Style = MetroFramework.MetroColorStyle.Blue;
            this.PosTB.TabIndex = 23;
            this.PosTB.TabStop = false;
            this.PosTB.Text = "<0, 0, 0>";
            this.PosTB.UseSelectable = true;
            // 
            // OrTB
            // 
            this.OrTB.Lines = new string[] {
        "<0, 0, 0>"};
            this.OrTB.Location = new System.Drawing.Point(97, 333);
            this.OrTB.MaxLength = 32767;
            this.OrTB.Name = "OrTB";
            this.OrTB.PasswordChar = '\0';
            this.OrTB.ReadOnly = true;
            this.OrTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OrTB.SelectedText = "";
            this.OrTB.Size = new System.Drawing.Size(154, 23);
            this.OrTB.Style = MetroFramework.MetroColorStyle.Blue;
            this.OrTB.TabIndex = 22;
            this.OrTB.TabStop = false;
            this.OrTB.Text = "<0, 0, 0>";
            this.OrTB.UseSelectable = true;
            // 
            // LCameraOr
            // 
            this.LCameraOr.AutoSize = true;
            this.LCameraOr.Location = new System.Drawing.Point(3, 333);
            this.LCameraOr.Name = "LCameraOr";
            this.LCameraOr.Size = new System.Drawing.Size(78, 19);
            this.LCameraOr.TabIndex = 21;
            this.LCameraOr.Text = "Orientation:";
            // 
            // LCameraPos
            // 
            this.LCameraPos.AutoSize = true;
            this.LCameraPos.Location = new System.Drawing.Point(3, 304);
            this.LCameraPos.Name = "LCameraPos";
            this.LCameraPos.Size = new System.Drawing.Size(57, 19);
            this.LCameraPos.TabIndex = 20;
            this.LCameraPos.Text = "Position:";
            // 
            // LCamOptions
            // 
            this.LCamOptions.Location = new System.Drawing.Point(3, 281);
            this.LCamOptions.Name = "LCamOptions";
            this.LCamOptions.Size = new System.Drawing.Size(245, 20);
            this.LCamOptions.TabIndex = 26;
            this.LCamOptions.Text = "CAMERA OPTIONS";
            this.LCamOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GridController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(255, 393);
            this.Controls.Add(this.LCamOptions);
            this.Controls.Add(this.LFOV);
            this.Controls.Add(this.FOV);
            this.Controls.Add(this.PosTB);
            this.Controls.Add(this.OrTB);
            this.Controls.Add(this.LCameraOr);
            this.Controls.Add(this.LCameraPos);
            this.Controls.Add(this.PTL);
            this.Controls.Add(this.LabelPTL);
            this.Controls.Add(this.PTF);
            this.Controls.Add(this.LabelPTF);
            this.Controls.Add(this.ZAxisIndex);
            this.Controls.Add(this.LabelZ);
            this.Controls.Add(this.YAxisIndex);
            this.Controls.Add(this.LabelY);
            this.Controls.Add(this.XAxisIndex);
            this.Controls.Add(this.LabelX);
            this.Controls.Add(this.LabelGenerationCounter);
            this.Controls.Add(this.ToggleGenerationCounter);
            this.Controls.Add(this.LabelHD);
            this.Controls.Add(this.ToggleHighDefinition);
            this.Controls.Add(this.LabelPPT);
            this.Controls.Add(this.ToggleParticleTrails);
            this.Controls.Add(this.LabelPointMode);
            this.Controls.Add(this.TogglePointMode);
            this.Controls.Add(this.Label3DMode);
            this.Controls.Add(this.Toggle3D);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "GridController";
            this.Padding = new System.Windows.Forms.Padding(1, 30, 1, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GridController";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GridController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.XAxisIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YAxisIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZAxisIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroToggle Toggle3D;
        private MetroFramework.Controls.MetroLabel Label3DMode;
        private MetroFramework.Controls.MetroLabel LabelPointMode;
        private MetroFramework.Controls.MetroToggle TogglePointMode;
        private MetroFramework.Controls.MetroLabel LabelPPT;
        private MetroFramework.Controls.MetroToggle ToggleParticleTrails;
        private MetroFramework.Controls.MetroLabel LabelHD;
        private MetroFramework.Controls.MetroToggle ToggleHighDefinition;
        private MetroFramework.Controls.MetroLabel LabelGenerationCounter;
        private MetroFramework.Controls.MetroToggle ToggleGenerationCounter;
        private MetroFramework.Controls.MetroLabel LabelX;
        private System.Windows.Forms.NumericUpDown XAxisIndex;
        private System.Windows.Forms.NumericUpDown YAxisIndex;
        private MetroFramework.Controls.MetroLabel LabelY;
        private System.Windows.Forms.NumericUpDown ZAxisIndex;
        private MetroFramework.Controls.MetroLabel LabelZ;
        private System.Windows.Forms.NumericUpDown PTF;
        private MetroFramework.Controls.MetroLabel LabelPTF;
        private System.Windows.Forms.NumericUpDown PTL;
        private MetroFramework.Controls.MetroLabel LabelPTL;
        private System.Windows.Forms.Timer UpdateTimer;
        private MetroFramework.Controls.MetroLabel LFOV;
        private System.Windows.Forms.NumericUpDown FOV;
        private MetroFramework.Controls.MetroTextBox PosTB;
        private MetroFramework.Controls.MetroTextBox OrTB;
        private MetroFramework.Controls.MetroLabel LCameraOr;
        private MetroFramework.Controls.MetroLabel LCameraPos;
        private MetroFramework.Controls.MetroLabel LCamOptions;
    }
}