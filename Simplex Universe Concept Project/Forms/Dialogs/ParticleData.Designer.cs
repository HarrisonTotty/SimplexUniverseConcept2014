namespace SimplexUniverse
{
    partial class ParticleData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ParticleGrid = new MetroFramework.Controls.MetroGrid();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit_SelectedParticles = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.View_RefreshInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.RFI_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RFI_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.RFI_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RadiusC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ParticleGrid)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParticleGrid
            // 
            this.ParticleGrid.AllowUserToAddRows = false;
            this.ParticleGrid.AllowUserToDeleteRows = false;
            this.ParticleGrid.AllowUserToResizeRows = false;
            this.ParticleGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ParticleGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParticleGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ParticleGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticleGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ParticleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParticleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectID,
            this.RadiusC,
            this.NFC,
            this.AccC,
            this.VelC,
            this.PosC,
            this.NameColumn,
            this.DescriptionColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParticleGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ParticleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParticleGrid.EnableHeadersVisualStyles = false;
            this.ParticleGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ParticleGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ParticleGrid.Location = new System.Drawing.Point(1, 84);
            this.ParticleGrid.Name = "ParticleGrid";
            this.ParticleGrid.ReadOnly = true;
            this.ParticleGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParticleGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ParticleGrid.RowHeadersVisible = false;
            this.ParticleGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ParticleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParticleGrid.Size = new System.Drawing.Size(787, 416);
            this.ParticleGrid.TabIndex = 1;
            this.ParticleGrid.SelectionChanged += new System.EventHandler(this.ParticleGrid_SelectionChanged);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.Menu_Edit,
            this.Menu_View});
            this.MainMenu.Location = new System.Drawing.Point(1, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(787, 24);
            this.MainMenu.TabIndex = 15;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Menu_Edit
            // 
            this.Menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit_SelectedParticles});
            this.Menu_Edit.Name = "Menu_Edit";
            this.Menu_Edit.Size = new System.Drawing.Size(39, 20);
            this.Menu_Edit.Text = "Edit";
            // 
            // Edit_SelectedParticles
            // 
            this.Edit_SelectedParticles.Name = "Edit_SelectedParticles";
            this.Edit_SelectedParticles.Size = new System.Drawing.Size(188, 22);
            this.Edit_SelectedParticles.Text = "Edit Selected Particles";
            this.Edit_SelectedParticles.Click += new System.EventHandler(this.Edit_SelectedParticles_Click);
            // 
            // Menu_View
            // 
            this.Menu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_RefreshInterval});
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(44, 20);
            this.Menu_View.Text = "View";
            // 
            // View_RefreshInterval
            // 
            this.View_RefreshInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RFI_1,
            this.RFI_100,
            this.RFI_1000});
            this.View_RefreshInterval.Name = "View_RefreshInterval";
            this.View_RefreshInterval.Size = new System.Drawing.Size(155, 22);
            this.View_RefreshInterval.Text = "Refresh Interval";
            // 
            // RFI_1
            // 
            this.RFI_1.Name = "RFI_1";
            this.RFI_1.Size = new System.Drawing.Size(117, 22);
            this.RFI_1.Text = "1 ms";
            this.RFI_1.Click += new System.EventHandler(this.RFI_1_Click);
            // 
            // RFI_100
            // 
            this.RFI_100.Name = "RFI_100";
            this.RFI_100.Size = new System.Drawing.Size(117, 22);
            this.RFI_100.Text = "100 ms";
            this.RFI_100.Click += new System.EventHandler(this.RFI_100_Click);
            // 
            // RFI_1000
            // 
            this.RFI_1000.Enabled = false;
            this.RFI_1000.Name = "RFI_1000";
            this.RFI_1000.Size = new System.Drawing.Size(117, 22);
            this.RFI_1000.Text = "1000 ms";
            this.RFI_1000.Click += new System.EventHandler(this.RFI_1000_Click);
            // 
            // ObjectID
            // 
            this.ObjectID.HeaderText = "ID";
            this.ObjectID.Name = "ObjectID";
            this.ObjectID.ReadOnly = true;
            // 
            // RadiusC
            // 
            this.RadiusC.HeaderText = "Radius";
            this.RadiusC.Name = "RadiusC";
            this.RadiusC.ReadOnly = true;
            this.RadiusC.Width = 50;
            // 
            // NFC
            // 
            this.NFC.HeaderText = "Net Force Magnitude";
            this.NFC.Name = "NFC";
            this.NFC.ReadOnly = true;
            this.NFC.Width = 150;
            // 
            // AccC
            // 
            this.AccC.HeaderText = "Accel. Magnitude";
            this.AccC.Name = "AccC";
            this.AccC.ReadOnly = true;
            this.AccC.Width = 150;
            // 
            // VelC
            // 
            this.VelC.HeaderText = "Velocity Magnitude";
            this.VelC.Name = "VelC";
            this.VelC.ReadOnly = true;
            this.VelC.Width = 150;
            // 
            // PosC
            // 
            this.PosC.HeaderText = "Position";
            this.PosC.Name = "PosC";
            this.PosC.ReadOnly = true;
            this.PosC.Width = 200;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.MinimumWidth = 100;
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            // 
            // ParticleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(789, 520);
            this.Controls.Add(this.ParticleGrid);
            this.Controls.Add(this.MainMenu);
            this.Name = "ParticleData";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.Text = "Particle Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParticleData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParticleGrid)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid ParticleGrid;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem Edit_SelectedParticles;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem View_RefreshInterval;
        private System.Windows.Forms.ToolStripMenuItem RFI_1;
        private System.Windows.Forms.ToolStripMenuItem RFI_100;
        private System.Windows.Forms.ToolStripMenuItem RFI_1000;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RadiusC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccC;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
    }
}