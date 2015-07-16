namespace SimplexUniverse
{
    partial class ParameterEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ParamList = new MetroFramework.Controls.MetroGrid();
            this.ISName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.Import_FromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Import_Common = new System.Windows.Forms.ToolStripMenuItem();
            this.Import_Required = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.Export_ToFile = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ParamList)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 5000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // ParamList
            // 
            this.ParamList.AllowUserToAddRows = false;
            this.ParamList.AllowUserToDeleteRows = false;
            this.ParamList.AllowUserToResizeRows = false;
            this.ParamList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ParamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParamList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ParamList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParamList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ParamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISName,
            this.ValueC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParamList.DefaultCellStyle = dataGridViewCellStyle5;
            this.ParamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParamList.EnableHeadersVisualStyles = false;
            this.ParamList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ParamList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ParamList.Location = new System.Drawing.Point(1, 84);
            this.ParamList.MultiSelect = false;
            this.ParamList.Name = "ParamList";
            this.ParamList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParamList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ParamList.RowHeadersVisible = false;
            this.ParamList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ParamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParamList.Size = new System.Drawing.Size(298, 321);
            this.ParamList.Style = MetroFramework.MetroColorStyle.Blue;
            this.ParamList.TabIndex = 11;
            this.ParamList.TabStop = false;
            this.ParamList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParamList_CellValueChanged);
            // 
            // ISName
            // 
            this.ISName.Frozen = true;
            this.ISName.HeaderText = "Name";
            this.ISName.Name = "ISName";
            this.ISName.Width = 150;
            // 
            // ValueC
            // 
            this.ValueC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueC.HeaderText = "Value";
            this.ValueC.Name = "ValueC";
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Import,
            this.Menu_Export});
            this.MainMenu.Location = new System.Drawing.Point(1, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(298, 24);
            this.MainMenu.TabIndex = 12;
            // 
            // Menu_Import
            // 
            this.Menu_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Import_FromFile,
            this.Import_Common,
            this.Import_Required});
            this.Menu_Import.Name = "Menu_Import";
            this.Menu_Import.Size = new System.Drawing.Size(55, 20);
            this.Menu_Import.Text = "Import";
            // 
            // Import_FromFile
            // 
            this.Import_FromFile.Name = "Import_FromFile";
            this.Import_FromFile.Size = new System.Drawing.Size(183, 22);
            this.Import_FromFile.Text = "From File";
            // 
            // Import_Common
            // 
            this.Import_Common.Name = "Import_Common";
            this.Import_Common.Size = new System.Drawing.Size(183, 22);
            this.Import_Common.Text = "Common Paramters";
            // 
            // Import_Required
            // 
            this.Import_Required.Name = "Import_Required";
            this.Import_Required.Size = new System.Drawing.Size(183, 22);
            this.Import_Required.Text = "Required Parameters";
            // 
            // Menu_Export
            // 
            this.Menu_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Export_ToFile});
            this.Menu_Export.Name = "Menu_Export";
            this.Menu_Export.Size = new System.Drawing.Size(52, 20);
            this.Menu_Export.Text = "Export";
            // 
            // Export_ToFile
            // 
            this.Export_ToFile.Name = "Export_ToFile";
            this.Export_ToFile.Size = new System.Drawing.Size(109, 22);
            this.Export_ToFile.Text = "To File";
            // 
            // ParameterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(300, 406);
            this.Controls.Add(this.ParamList);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ParameterEditor";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 1);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Simulation Parameters";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ParameterEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParamList)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private MetroFramework.Controls.MetroGrid ParamList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueC;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu_Import;
        private System.Windows.Forms.ToolStripMenuItem Import_FromFile;
        private System.Windows.Forms.ToolStripMenuItem Import_Common;
        private System.Windows.Forms.ToolStripMenuItem Import_Required;
        private System.Windows.Forms.ToolStripMenuItem Menu_Export;
        private System.Windows.Forms.ToolStripMenuItem Export_ToFile;
    }
}