namespace SimplexUniverse
{
    partial class InteractionSelector
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
            this.ScriptSelector = new MetroFramework.Controls.MetroGrid();
            this.ISSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ISName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.toFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ScriptSelector)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScriptSelector
            // 
            this.ScriptSelector.AllowUserToAddRows = false;
            this.ScriptSelector.AllowUserToDeleteRows = false;
            this.ScriptSelector.AllowUserToResizeRows = false;
            this.ScriptSelector.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScriptSelector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptSelector.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ScriptSelector.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScriptSelector.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ScriptSelector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScriptSelector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISSelected,
            this.ISName,
            this.ISDescription});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ScriptSelector.DefaultCellStyle = dataGridViewCellStyle5;
            this.ScriptSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptSelector.EnableHeadersVisualStyles = false;
            this.ScriptSelector.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ScriptSelector.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScriptSelector.Location = new System.Drawing.Point(1, 84);
            this.ScriptSelector.MultiSelect = false;
            this.ScriptSelector.Name = "ScriptSelector";
            this.ScriptSelector.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScriptSelector.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ScriptSelector.RowHeadersVisible = false;
            this.ScriptSelector.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ScriptSelector.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ScriptSelector.Size = new System.Drawing.Size(298, 397);
            this.ScriptSelector.Style = MetroFramework.MetroColorStyle.Blue;
            this.ScriptSelector.TabIndex = 10;
            this.ScriptSelector.TabStop = false;
            this.ScriptSelector.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ScriptSelector_CellBeginEdit);
            this.ScriptSelector.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScriptSelector_CellClick);
            this.ScriptSelector.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScriptSelector_CellValueChanged_1);
            // 
            // ISSelected
            // 
            this.ISSelected.HeaderText = "";
            this.ISSelected.Name = "ISSelected";
            this.ISSelected.ReadOnly = true;
            this.ISSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ISSelected.Width = 25;
            // 
            // ISName
            // 
            this.ISName.HeaderText = "Name";
            this.ISName.Name = "ISName";
            this.ISName.ReadOnly = true;
            this.ISName.Width = 150;
            // 
            // ISDescription
            // 
            this.ISDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ISDescription.HeaderText = "Description";
            this.ISDescription.MinimumWidth = 400;
            this.ISDescription.Name = "ISDescription";
            this.ISDescription.ReadOnly = true;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 2000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Import,
            this.Menu_Export,
            this.createToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(1, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(298, 24);
            this.MainMenu.TabIndex = 13;
            // 
            // Menu_Import
            // 
            this.Menu_Import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem});
            this.Menu_Import.Name = "Menu_Import";
            this.Menu_Import.Size = new System.Drawing.Size(55, 20);
            this.Menu_Import.Text = "Import";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fromFileToolStripMenuItem.Text = "From File";
            // 
            // Menu_Export
            // 
            this.Menu_Export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toFileToolStripMenuItem});
            this.Menu_Export.Name = "Menu_Export";
            this.Menu_Export.Size = new System.Drawing.Size(52, 20);
            this.Menu_Export.Text = "Export";
            // 
            // toFileToolStripMenuItem
            // 
            this.toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
            this.toFileToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.toFileToolStripMenuItem.Text = "To File";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // InteractionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(300, 482);
            this.Controls.Add(this.ScriptSelector);
            this.Controls.Add(this.MainMenu);
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "InteractionSelector";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 1);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Interactions";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InteractionSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScriptSelector)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid ScriptSelector;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu_Import;
        private System.Windows.Forms.ToolStripMenuItem Menu_Export;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ISSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISDescription;
    }
}