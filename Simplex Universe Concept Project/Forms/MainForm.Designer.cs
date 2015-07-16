namespace SimplexUniverse
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Menu = new SimplexUniverse.Drawing.MetroMenu();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.File_ShowWelcomeForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ObjectTable = new System.Windows.Forms.ToolStripMenuItem();
            this.View_ParticleData = new System.Windows.Forms.ToolStripMenuItem();
            this.View_TimeGraphs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.View_GridOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Simulation = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Resume = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Pause = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Simulation_UpdateInterval = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInterval_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInterval_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInterval_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInterval_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInterval_1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.Simulation_Parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Simulation_Buffer = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Universe = new System.Windows.Forms.ToolStripMenuItem();
            this.Universe_Boundary = new System.Windows.Forms.ToolStripMenuItem();
            this.Boundary_Infinite = new System.Windows.Forms.ToolStripMenuItem();
            this.Boundary_Seperator = new System.Windows.Forms.ToolStripSeparator();
            this.Universe_Radius = new System.Windows.Forms.ToolStripMenuItem();
            this.Radius_RadiusBox = new System.Windows.Forms.ToolStripTextBox();
            this.Menu_Interactions = new System.Windows.Forms.ToolStripMenuItem();
            this.Interactions_UpdateScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Interactions_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.seedingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Minimize = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Normalize = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Maximize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Window_Theme = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_Dark = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_Light = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Color = new System.Windows.Forms.ToolStripMenuItem();
            this.Color_Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.Color_Green = new System.Windows.Forms.ToolStripMenuItem();
            this.Color_Orange = new System.Windows.Forms.ToolStripMenuItem();
            this.Color_Purple = new System.Windows.Forms.ToolStripMenuItem();
            this.Color_Red = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Debug = new System.Windows.Forms.ToolStripMenuItem();
            this.Debug_HardInit = new System.Windows.Forms.ToolStripMenuItem();
            this.hardInitializeLargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardInitializeVeryLargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.GridPanel = new MetroFramework.Controls.MetroPanel();
            this.hardInitializeGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Edit,
            this.Menu_View,
            this.Menu_Simulation,
            this.Menu_Universe,
            this.Menu_Interactions,
            this.seedingToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.Menu_Window,
            this.Menu_Help,
            this.Menu_Debug});
            this.Menu.Location = new System.Drawing.Point(1, 30);
            this.Menu.MetroColor = MetroFramework.MetroColorStyle.Blue;
            this.Menu.MetroTheme = MetroFramework.MetroThemeStyle.Light;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(728, 24);
            this.Menu.TabIndex = 4;
            this.Menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_ItemClicked);
            // 
            // Menu_File
            // 
            this.Menu_File.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_New,
            this.File_Open,
            this.File_Save,
            this.toolStripSeparator2,
            this.File_ShowWelcomeForm,
            this.toolStripSeparator1,
            this.File_Exit});
            this.Menu_File.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(37, 20);
            this.Menu_File.Text = "File";
            // 
            // File_New
            // 
            this.File_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.File_New.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.File_New.Name = "File_New";
            this.File_New.Size = new System.Drawing.Size(187, 22);
            this.File_New.Text = "New";
            // 
            // File_Open
            // 
            this.File_Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.File_Open.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.File_Open.Name = "File_Open";
            this.File_Open.Size = new System.Drawing.Size(187, 22);
            this.File_Open.Text = "Open";
            // 
            // File_Save
            // 
            this.File_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.File_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.File_Save.Name = "File_Save";
            this.File_Save.Size = new System.Drawing.Size(187, 22);
            this.File_Save.Text = "Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // File_ShowWelcomeForm
            // 
            this.File_ShowWelcomeForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.File_ShowWelcomeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.File_ShowWelcomeForm.Name = "File_ShowWelcomeForm";
            this.File_ShowWelcomeForm.Size = new System.Drawing.Size(187, 22);
            this.File_ShowWelcomeForm.Text = "Show Welcome Form";
            this.File_ShowWelcomeForm.Click += new System.EventHandler(this.File_ShowWelcomeForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // File_Exit
            // 
            this.File_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.File_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.File_Exit.Name = "File_Exit";
            this.File_Exit.Size = new System.Drawing.Size(187, 22);
            this.File_Exit.Text = "Exit";
            this.File_Exit.Click += new System.EventHandler(this.File_Exit_Click);
            // 
            // Menu_Edit
            // 
            this.Menu_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Edit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Edit.Name = "Menu_Edit";
            this.Menu_Edit.Size = new System.Drawing.Size(39, 20);
            this.Menu_Edit.Text = "Edit";
            // 
            // Menu_View
            // 
            this.Menu_View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_ObjectTable,
            this.View_ParticleData,
            this.View_TimeGraphs,
            this.toolStripSeparator6,
            this.View_GridOptions});
            this.Menu_View.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(44, 20);
            this.Menu_View.Text = "View";
            // 
            // View_ObjectTable
            // 
            this.View_ObjectTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.View_ObjectTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.View_ObjectTable.Name = "View_ObjectTable";
            this.View_ObjectTable.Size = new System.Drawing.Size(141, 22);
            this.View_ObjectTable.Text = "Object Table";
            this.View_ObjectTable.Click += new System.EventHandler(this.View_ObjectTable_Click);
            // 
            // View_ParticleData
            // 
            this.View_ParticleData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.View_ParticleData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.View_ParticleData.Name = "View_ParticleData";
            this.View_ParticleData.Size = new System.Drawing.Size(141, 22);
            this.View_ParticleData.Text = "Particle Data";
            this.View_ParticleData.Click += new System.EventHandler(this.View_ParticleData_Click);
            // 
            // View_TimeGraphs
            // 
            this.View_TimeGraphs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.View_TimeGraphs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.View_TimeGraphs.Name = "View_TimeGraphs";
            this.View_TimeGraphs.Size = new System.Drawing.Size(141, 22);
            this.View_TimeGraphs.Text = "Time Graphs";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(138, 6);
            // 
            // View_GridOptions
            // 
            this.View_GridOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.View_GridOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.View_GridOptions.Name = "View_GridOptions";
            this.View_GridOptions.Size = new System.Drawing.Size(141, 22);
            this.View_GridOptions.Text = "Grid Options";
            this.View_GridOptions.Click += new System.EventHandler(this.View_GridOptions_Click);
            // 
            // Menu_Simulation
            // 
            this.Menu_Simulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Simulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Simulation_Start,
            this.Simulation_Resume,
            this.Simulation_Pause,
            this.Simulation_Stop,
            this.toolStripSeparator3,
            this.Simulation_UpdateInterval,
            this.Simulation_Parameters,
            this.toolStripSeparator4,
            this.Simulation_Buffer});
            this.Menu_Simulation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Simulation.Name = "Menu_Simulation";
            this.Menu_Simulation.Size = new System.Drawing.Size(76, 20);
            this.Menu_Simulation.Text = "Simulation";
            // 
            // Simulation_Start
            // 
            this.Simulation_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Start.Name = "Simulation_Start";
            this.Simulation_Start.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Start.Text = "Start";
            this.Simulation_Start.Click += new System.EventHandler(this.Simulation_Start_Click);
            // 
            // Simulation_Resume
            // 
            this.Simulation_Resume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Resume.Enabled = false;
            this.Simulation_Resume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Resume.Name = "Simulation_Resume";
            this.Simulation_Resume.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Resume.Text = "Resume";
            this.Simulation_Resume.Click += new System.EventHandler(this.Simulation_Resume_Click);
            // 
            // Simulation_Pause
            // 
            this.Simulation_Pause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Pause.Enabled = false;
            this.Simulation_Pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Pause.Name = "Simulation_Pause";
            this.Simulation_Pause.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Pause.Text = "Pause";
            this.Simulation_Pause.Click += new System.EventHandler(this.Simulation_Pause_Click);
            // 
            // Simulation_Stop
            // 
            this.Simulation_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Stop.Enabled = false;
            this.Simulation_Stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Stop.Name = "Simulation_Stop";
            this.Simulation_Stop.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Stop.Text = "Stop";
            this.Simulation_Stop.Click += new System.EventHandler(this.Simulation_Stop_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // Simulation_UpdateInterval
            // 
            this.Simulation_UpdateInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_UpdateInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateInterval_1,
            this.UpdateInterval_10,
            this.UpdateInterval_50,
            this.UpdateInterval_100,
            this.UpdateInterval_1000});
            this.Simulation_UpdateInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_UpdateInterval.Name = "Simulation_UpdateInterval";
            this.Simulation_UpdateInterval.Size = new System.Drawing.Size(209, 22);
            this.Simulation_UpdateInterval.Text = "Update Interval";
            // 
            // UpdateInterval_1
            // 
            this.UpdateInterval_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpdateInterval_1.Checked = true;
            this.UpdateInterval_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpdateInterval_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UpdateInterval_1.Name = "UpdateInterval_1";
            this.UpdateInterval_1.Size = new System.Drawing.Size(147, 22);
            this.UpdateInterval_1.Text = "1 ms (default)";
            this.UpdateInterval_1.Click += new System.EventHandler(this.UpdateInterval_1_Click);
            // 
            // UpdateInterval_10
            // 
            this.UpdateInterval_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpdateInterval_10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UpdateInterval_10.Name = "UpdateInterval_10";
            this.UpdateInterval_10.Size = new System.Drawing.Size(147, 22);
            this.UpdateInterval_10.Text = "10 ms";
            this.UpdateInterval_10.Click += new System.EventHandler(this.UpdateInterval_10_Click);
            // 
            // UpdateInterval_50
            // 
            this.UpdateInterval_50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpdateInterval_50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UpdateInterval_50.Name = "UpdateInterval_50";
            this.UpdateInterval_50.Size = new System.Drawing.Size(147, 22);
            this.UpdateInterval_50.Text = "50 ms";
            this.UpdateInterval_50.Click += new System.EventHandler(this.UpdateInterval_50_Click);
            // 
            // UpdateInterval_100
            // 
            this.UpdateInterval_100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpdateInterval_100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UpdateInterval_100.Name = "UpdateInterval_100";
            this.UpdateInterval_100.Size = new System.Drawing.Size(147, 22);
            this.UpdateInterval_100.Text = "100 ms";
            this.UpdateInterval_100.Click += new System.EventHandler(this.UpdateInterval_100_Click);
            // 
            // UpdateInterval_1000
            // 
            this.UpdateInterval_1000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.UpdateInterval_1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UpdateInterval_1000.Name = "UpdateInterval_1000";
            this.UpdateInterval_1000.Size = new System.Drawing.Size(147, 22);
            this.UpdateInterval_1000.Text = "1000 ms";
            this.UpdateInterval_1000.Click += new System.EventHandler(this.UpdateInterval_1000_Click);
            // 
            // Simulation_Parameters
            // 
            this.Simulation_Parameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Parameters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Parameters.Name = "Simulation_Parameters";
            this.Simulation_Parameters.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Parameters.Text = "Parameters...";
            this.Simulation_Parameters.Click += new System.EventHandler(this.Simulation_Parameters_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            // 
            // Simulation_Buffer
            // 
            this.Simulation_Buffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Simulation_Buffer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Simulation_Buffer.Name = "Simulation_Buffer";
            this.Simulation_Buffer.Size = new System.Drawing.Size(209, 22);
            this.Simulation_Buffer.Text = "Buffer Current Simulation";
            this.Simulation_Buffer.Click += new System.EventHandler(this.Simulation_Buffer_Click);
            // 
            // Menu_Universe
            // 
            this.Menu_Universe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Universe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Universe_Boundary,
            this.Universe_Radius});
            this.Menu_Universe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Universe.Name = "Menu_Universe";
            this.Menu_Universe.Size = new System.Drawing.Size(64, 20);
            this.Menu_Universe.Text = "Universe";
            // 
            // Universe_Boundary
            // 
            this.Universe_Boundary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Universe_Boundary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Boundary_Infinite,
            this.Boundary_Seperator});
            this.Universe_Boundary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Universe_Boundary.Name = "Universe_Boundary";
            this.Universe_Boundary.Size = new System.Drawing.Size(125, 22);
            this.Universe_Boundary.Text = "Boundary";
            // 
            // Boundary_Infinite
            // 
            this.Boundary_Infinite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Boundary_Infinite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Boundary_Infinite.Name = "Boundary_Infinite";
            this.Boundary_Infinite.Size = new System.Drawing.Size(120, 22);
            this.Boundary_Infinite.Text = "INFINITE";
            this.Boundary_Infinite.Click += new System.EventHandler(this.Boundary_Infinite_Click);
            // 
            // Boundary_Seperator
            // 
            this.Boundary_Seperator.Name = "Boundary_Seperator";
            this.Boundary_Seperator.Size = new System.Drawing.Size(117, 6);
            // 
            // Universe_Radius
            // 
            this.Universe_Radius.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Universe_Radius.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Radius_RadiusBox});
            this.Universe_Radius.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Universe_Radius.Name = "Universe_Radius";
            this.Universe_Radius.Size = new System.Drawing.Size(125, 22);
            this.Universe_Radius.Text = "Radius";
            // 
            // Radius_RadiusBox
            // 
            this.Radius_RadiusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Radius_RadiusBox.Name = "Radius_RadiusBox";
            this.Radius_RadiusBox.Size = new System.Drawing.Size(150, 23);
            this.Radius_RadiusBox.Text = "Infinite";
            this.Radius_RadiusBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Radius_RadiusBox_KeyDown);
            this.Radius_RadiusBox.VisibleChanged += new System.EventHandler(this.Radius_RadiusBox_VisibleChanged);
            // 
            // Menu_Interactions
            // 
            this.Menu_Interactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Interactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Interactions_UpdateScript,
            this.toolStripSeparator5,
            this.Interactions_Select});
            this.Menu_Interactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Interactions.Name = "Menu_Interactions";
            this.Menu_Interactions.Size = new System.Drawing.Size(81, 20);
            this.Menu_Interactions.Text = "Interactions";
            // 
            // Interactions_UpdateScript
            // 
            this.Interactions_UpdateScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Interactions_UpdateScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Interactions_UpdateScript.Name = "Interactions_UpdateScript";
            this.Interactions_UpdateScript.Size = new System.Drawing.Size(170, 22);
            this.Interactions_UpdateScript.Text = "Update Script";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(167, 6);
            // 
            // Interactions_Select
            // 
            this.Interactions_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Interactions_Select.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Interactions_Select.Name = "Interactions_Select";
            this.Interactions_Select.Size = new System.Drawing.Size(170, 22);
            this.Interactions_Select.Text = "Select Interactions";
            this.Interactions_Select.Click += new System.EventHandler(this.Interactions_Select_Click);
            // 
            // seedingToolStripMenuItem
            // 
            this.seedingToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.seedingToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.seedingToolStripMenuItem.Name = "seedingToolStripMenuItem";
            this.seedingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.seedingToolStripMenuItem.Text = "Seeding";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // Menu_Window
            // 
            this.Menu_Window.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Window_Minimize,
            this.Window_Normalize,
            this.Window_Maximize,
            this.toolStripSeparator7,
            this.Window_Theme,
            this.Window_Color});
            this.Menu_Window.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Window.Name = "Menu_Window";
            this.Menu_Window.Size = new System.Drawing.Size(63, 20);
            this.Menu_Window.Text = "Window";
            // 
            // Window_Minimize
            // 
            this.Window_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Window_Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Window_Minimize.Name = "Window_Minimize";
            this.Window_Minimize.Size = new System.Drawing.Size(128, 22);
            this.Window_Minimize.Text = "Minimize";
            this.Window_Minimize.Click += new System.EventHandler(this.Window_Minimize_Click);
            // 
            // Window_Normalize
            // 
            this.Window_Normalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Window_Normalize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Window_Normalize.Name = "Window_Normalize";
            this.Window_Normalize.Size = new System.Drawing.Size(128, 22);
            this.Window_Normalize.Text = "Normalize";
            this.Window_Normalize.Click += new System.EventHandler(this.Window_Normalize_Click);
            // 
            // Window_Maximize
            // 
            this.Window_Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Window_Maximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Window_Maximize.Name = "Window_Maximize";
            this.Window_Maximize.Size = new System.Drawing.Size(128, 22);
            this.Window_Maximize.Text = "Maximize";
            this.Window_Maximize.Click += new System.EventHandler(this.Window_Maximize_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(125, 6);
            // 
            // Window_Theme
            // 
            this.Window_Theme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Window_Theme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Theme_Dark,
            this.Theme_Light});
            this.Window_Theme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Window_Theme.Name = "Window_Theme";
            this.Window_Theme.Size = new System.Drawing.Size(128, 22);
            this.Window_Theme.Text = "Theme";
            // 
            // Theme_Dark
            // 
            this.Theme_Dark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Theme_Dark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Theme_Dark.Name = "Theme_Dark";
            this.Theme_Dark.Size = new System.Drawing.Size(101, 22);
            this.Theme_Dark.Text = "Dark";
            this.Theme_Dark.Click += new System.EventHandler(this.Theme_Dark_Click);
            // 
            // Theme_Light
            // 
            this.Theme_Light.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Theme_Light.Enabled = false;
            this.Theme_Light.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Theme_Light.Name = "Theme_Light";
            this.Theme_Light.Size = new System.Drawing.Size(101, 22);
            this.Theme_Light.Text = "Light";
            this.Theme_Light.Click += new System.EventHandler(this.Theme_Light_Click);
            // 
            // Window_Color
            // 
            this.Window_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Window_Color.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Color_Blue,
            this.Color_Green,
            this.Color_Orange,
            this.Color_Purple,
            this.Color_Red});
            this.Window_Color.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Window_Color.Name = "Window_Color";
            this.Window_Color.Size = new System.Drawing.Size(128, 22);
            this.Window_Color.Text = "Color";
            // 
            // Color_Blue
            // 
            this.Color_Blue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_Blue.Enabled = false;
            this.Color_Blue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Color_Blue.Name = "Color_Blue";
            this.Color_Blue.Size = new System.Drawing.Size(113, 22);
            this.Color_Blue.Text = "Blue";
            this.Color_Blue.Click += new System.EventHandler(this.Color_Blue_Click);
            // 
            // Color_Green
            // 
            this.Color_Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_Green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Color_Green.Name = "Color_Green";
            this.Color_Green.Size = new System.Drawing.Size(113, 22);
            this.Color_Green.Text = "Green";
            this.Color_Green.Click += new System.EventHandler(this.Color_Green_Click);
            // 
            // Color_Orange
            // 
            this.Color_Orange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_Orange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Color_Orange.Name = "Color_Orange";
            this.Color_Orange.Size = new System.Drawing.Size(113, 22);
            this.Color_Orange.Text = "Orange";
            this.Color_Orange.Click += new System.EventHandler(this.Color_Orange_Click);
            // 
            // Color_Purple
            // 
            this.Color_Purple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_Purple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Color_Purple.Name = "Color_Purple";
            this.Color_Purple.Size = new System.Drawing.Size(113, 22);
            this.Color_Purple.Text = "Purple";
            this.Color_Purple.Click += new System.EventHandler(this.Color_Purple_Click);
            // 
            // Color_Red
            // 
            this.Color_Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Color_Red.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Color_Red.Name = "Color_Red";
            this.Color_Red.Size = new System.Drawing.Size(113, 22);
            this.Color_Red.Text = "Red";
            this.Color_Red.Click += new System.EventHandler(this.Color_Red_Click);
            // 
            // Menu_Help
            // 
            this.Menu_Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_About});
            this.Menu_Help.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Help.Name = "Menu_Help";
            this.Menu_Help.Size = new System.Drawing.Size(44, 20);
            this.Menu_Help.Text = "Help";
            // 
            // Help_About
            // 
            this.Help_About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Help_About.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Help_About.Name = "Help_About";
            this.Help_About.Size = new System.Drawing.Size(199, 22);
            this.Help_About.Text = "About Simplex Universe";
            this.Help_About.Click += new System.EventHandler(this.Help_About_Click);
            // 
            // Menu_Debug
            // 
            this.Menu_Debug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Debug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Debug_HardInit,
            this.hardInitializeLargeToolStripMenuItem,
            this.hardInitializeVeryLargeToolStripMenuItem,
            this.hardInitializeGToolStripMenuItem});
            this.Menu_Debug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Menu_Debug.Name = "Menu_Debug";
            this.Menu_Debug.Size = new System.Drawing.Size(54, 20);
            this.Menu_Debug.Text = "Debug";
            // 
            // Debug_HardInit
            // 
            this.Debug_HardInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Debug_HardInit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Debug_HardInit.Name = "Debug_HardInit";
            this.Debug_HardInit.Size = new System.Drawing.Size(212, 22);
            this.Debug_HardInit.Text = "Hard Initialize";
            this.Debug_HardInit.Click += new System.EventHandler(this.Debug_HardInit_Click);
            // 
            // hardInitializeLargeToolStripMenuItem
            // 
            this.hardInitializeLargeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hardInitializeLargeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hardInitializeLargeToolStripMenuItem.Name = "hardInitializeLargeToolStripMenuItem";
            this.hardInitializeLargeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.hardInitializeLargeToolStripMenuItem.Text = "Hard Initialize - Large";
            this.hardInitializeLargeToolStripMenuItem.Click += new System.EventHandler(this.hardInitializeLargeToolStripMenuItem_Click);
            // 
            // hardInitializeVeryLargeToolStripMenuItem
            // 
            this.hardInitializeVeryLargeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hardInitializeVeryLargeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hardInitializeVeryLargeToolStripMenuItem.Name = "hardInitializeVeryLargeToolStripMenuItem";
            this.hardInitializeVeryLargeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.hardInitializeVeryLargeToolStripMenuItem.Text = "Hard Initialize - Very Large";
            this.hardInitializeVeryLargeToolStripMenuItem.Click += new System.EventHandler(this.hardInitializeVeryLargeToolStripMenuItem_Click);
            // 
            // OFD
            // 
            this.OFD.Filter = "Simulation|*.sim|Buffered Simulation|*.bsim|All Files|*.*";
            this.OFD.Title = "Load Simulation/Universe...";
            // 
            // SFD
            // 
            this.SFD.Filter = "Simulation|*.sim|Buffered Simulation|*.bsim|All Files|*.*";
            // 
            // GridPanel
            // 
            this.GridPanel.BackColor = System.Drawing.Color.White;
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.HorizontalScrollbarBarColor = true;
            this.GridPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.GridPanel.HorizontalScrollbarSize = 10;
            this.GridPanel.Location = new System.Drawing.Point(1, 54);
            this.GridPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(728, 439);
            this.GridPanel.Style = MetroFramework.MetroColorStyle.Blue;
            this.GridPanel.TabIndex = 0;
            this.GridPanel.TabStop = true;
            this.GridPanel.VerticalScrollbarBarColor = true;
            this.GridPanel.VerticalScrollbarHighlightOnWheel = false;
            this.GridPanel.VerticalScrollbarSize = 10;
            // 
            // hardInitializeGToolStripMenuItem
            // 
            this.hardInitializeGToolStripMenuItem.Name = "hardInitializeGToolStripMenuItem";
            this.hardInitializeGToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.hardInitializeGToolStripMenuItem.Text = "Hard Initialize - G+";
            this.hardInitializeGToolStripMenuItem.Click += new System.EventHandler(this.hardInitializeGToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(730, 513);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.Menu);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 30, 1, 20);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Simplex Universe";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimplexUniverse.Drawing.MetroMenu Menu;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Simulation;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Window;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem File_Exit;
        private System.Windows.Forms.ToolStripMenuItem File_New;
        private System.Windows.Forms.ToolStripMenuItem File_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem File_ShowWelcomeForm;
        private System.Windows.Forms.ToolStripMenuItem Help_About;
        private System.Windows.Forms.ToolStripMenuItem Window_Minimize;
        private System.Windows.Forms.ToolStripMenuItem Window_Normalize;
        private System.Windows.Forms.ToolStripMenuItem Window_Maximize;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Start;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Resume;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Pause;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Stop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Simulation_UpdateInterval;
        private System.Windows.Forms.ToolStripMenuItem UpdateInterval_1;
        private System.Windows.Forms.ToolStripMenuItem UpdateInterval_10;
        private System.Windows.Forms.ToolStripMenuItem UpdateInterval_50;
        private System.Windows.Forms.ToolStripMenuItem UpdateInterval_100;
        private System.Windows.Forms.ToolStripMenuItem UpdateInterval_1000;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Menu_Interactions;
        private System.Windows.Forms.ToolStripMenuItem seedingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem File_Save;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Buffer;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripMenuItem Interactions_Select;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem Menu_Universe;
        private System.Windows.Forms.ToolStripMenuItem View_ObjectTable;
        private System.Windows.Forms.ToolStripMenuItem View_ParticleData;
        private System.Windows.Forms.ToolStripMenuItem View_TimeGraphs;
        private System.Windows.Forms.ToolStripMenuItem Menu_Debug;
        private System.Windows.Forms.ToolStripMenuItem Debug_HardInit;
        private System.Windows.Forms.ToolStripMenuItem Simulation_Parameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem Universe_Boundary;
        private System.Windows.Forms.ToolStripMenuItem Boundary_Infinite;
        private System.Windows.Forms.ToolStripSeparator Boundary_Seperator;
        private System.Windows.Forms.ToolStripMenuItem Universe_Radius;
        private System.Windows.Forms.ToolStripTextBox Radius_RadiusBox;
        private System.Windows.Forms.ToolStripMenuItem View_GridOptions;
        private System.Windows.Forms.ToolStripMenuItem Interactions_UpdateScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem Window_Theme;
        private System.Windows.Forms.ToolStripMenuItem Theme_Dark;
        private System.Windows.Forms.ToolStripMenuItem Theme_Light;
        private System.Windows.Forms.ToolStripMenuItem Window_Color;
        private System.Windows.Forms.ToolStripMenuItem Color_Blue;
        private System.Windows.Forms.ToolStripMenuItem Color_Red;
        private System.Windows.Forms.ToolStripMenuItem Color_Green;
        private System.Windows.Forms.ToolStripMenuItem Color_Orange;
        private System.Windows.Forms.ToolStripMenuItem Color_Purple;
        private System.Windows.Forms.ToolStripMenuItem hardInitializeLargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardInitializeVeryLargeToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel GridPanel;
        private System.Windows.Forms.ToolStripMenuItem hardInitializeGToolStripMenuItem;




    }
}

