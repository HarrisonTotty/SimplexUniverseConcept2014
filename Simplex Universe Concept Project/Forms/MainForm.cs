using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.Scripting;
using SimplexUniverse.Simulations;
using SimplexUniverse.VisualizationComponents;
using SimplexUniverse.IO;

namespace SimplexUniverse
{
    /// <summary>
    /// Represents the primary form we will display to the user.
    /// </summary>
    public partial class MainForm : MetroForm
    {
        /// <summary>
        /// The public visualization grid object that our user and simulation will interact with.
        /// </summary>
        public VisualizationGrid Grid = new VisualizationGrid();

        /// <summary>
        /// Our current simulation object.
        /// </summary>
        public Simulations.Simulation CurrentSimulation;

        /// <summary>
        /// Our current list of available scripts and other assets
        /// </summary>
        public LoadAssets LoadedAssets;

        /// <summary>
        /// Creates a new blank main form.
        /// </summary>
        public MainForm(LoadAssets LoadedAssets)
        {
            InitializeComponent();
            this.Padding = new Padding(0, 20, 0, 20);
            this.LoadedAssets = LoadedAssets;
        }

        public void Save_Simulation(Simulation SimulationToSave)
        {

        }

        /// <summary>
        /// Loads a simulation object as the current simulation (automatically displaying any neccessary dialogs)
        /// NOT DONE
        /// </summary>
        /// <param name="SimulationToLoad">The simulation object to load</param>
        public void Load_Simulation(Simulation SimulationToLoad)
        {
            //If we are given a null simulation to load, return
            if (SimulationToLoad == null) return;

            //If we were already working on a simulation:
            if (this.CurrentSimulation != null)
            {
                //Ask the user if they want to save their simulation
                var Result = MetroFramework.MetroMessageBox.Show(this, "Would you like to save your current simulation?", "Save Current Simulation?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Save the old simulation
                }
                else if (Result == System.Windows.Forms.DialogResult.Cancel)
                {
                    //Do nothing
                    return;
                }
            }

            //Load the simulation by copying over the reference
            this.CurrentSimulation = SimulationToLoad;
        }

        /// <summary>
        /// Performs the neccessary tasks for shutting down (but does not actually shut down the application)
        /// </summary>
        public void PerformShutdownTasks()
        {
            //If we were already working on a simulation:
            if (this.CurrentSimulation != null)
            {
                this.CurrentSimulation.Stop();

                //Ask the user if they want to save their simulation
                var Result = MetroFramework.MetroMessageBox.Show(this, "Would you like to save your current simulation?", "Save Current Simulation?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Save the old simulation
                }
                else if (Result == System.Windows.Forms.DialogResult.Cancel)
                {
                    //Do nothing
                    return;
                }
                else if (Result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            //Apply styles to the main menu - NO LONGER NEEDED
            ApplyThemeColor();

            //Attach the visualization grid to the panel
            this.GridPanel.Controls.Add(this.Grid);
            this.Grid.Focus();

            //Add the button event handlers for the grid
            this.Grid.KeyDown += Grid_KeyDown;

            //Populate neccessary menus
            PopulateUniverseBoundaryMenu();
            PopulateUpdateScriptMenu();

            //Show the welcome form
            (new WelcomeForm(this)).ShowDialog();
        }

        /// <summary>
        /// Populates the update script menu with the scripts that were loaded with the load assets
        /// </summary>
        public void PopulateUpdateScriptMenu()
        {
            this.Interactions_UpdateScript.DropDownItems.Clear();
            foreach (UpdateScript US in this.LoadedAssets.AvailableScripts.ExtractScripts<UpdateScript>())
            {
                this.Interactions_UpdateScript.DropDownItems.Add(US.Name);
            }
            foreach (var Item in this.Interactions_UpdateScript.DropDownItems) if (Item is ToolStripMenuItem) { (Item as ToolStripMenuItem).Click += UpdateScript_Click; }

            if (this.CurrentSimulation != null)
            {
                if (this.CurrentSimulation.LinkedUpdateScript != null)
                {
                    foreach (var Item in this.Interactions_UpdateScript.DropDownItems)
                    {
                        if (Item is ToolStripMenuItem)
                        {
                            if ((Item as ToolStripMenuItem).Text == this.CurrentSimulation.LinkedUpdateScript.Name)
                            {
                                (Item as ToolStripMenuItem).Enabled = false;
                            }
                            else
                            {
                                (Item as ToolStripMenuItem).Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var Item in this.Interactions_UpdateScript.DropDownItems)
                    {
                        (Item as ToolStripMenuItem).Enabled = true;
                    }
                }
            }
            ApplyThemeColor();
        }

        void UpdateScript_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                ToolStripMenuItem me = (sender as ToolStripMenuItem);
                if (!this.LoadedAssets.AvailableScripts.HasScript<UpdateScript>(me.Text)) return;
                UpdateScript US = this.LoadedAssets.AvailableScripts.ExtractScript<UpdateScript>(me.Text);
                this.CurrentSimulation.LinkedUpdateScript = US;
                PopulateUpdateScriptMenu();
            }
        }

        public void PopulateUniverseBoundaryMenu()
        {
            this.Universe_Boundary.DropDownItems.Clear();
            this.Universe_Boundary.DropDownItems.Add(this.Boundary_Infinite);
            this.Universe_Boundary.DropDownItems.Add(this.Boundary_Seperator);
            foreach (BoundaryScript BS in this.LoadedAssets.AvailableScripts.ExtractScripts<BoundaryScript>())
            {
                this.Universe_Boundary.DropDownItems.Add(BS.Name);
            }

            foreach (var Item in this.Universe_Boundary.DropDownItems) if (Item is ToolStripMenuItem) { (Item as ToolStripMenuItem).Click += BoundaryItem_Click; }

            if (this.CurrentSimulation != null)
            {
                if (this.CurrentSimulation.SimUniverse != null)
                {
                    if (this.CurrentSimulation.SimUniverse.Boundary != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary.ResolveScript != null)
                        {
                            this.Boundary_Infinite.Enabled = true;
                            foreach (var Item in this.Universe_Boundary.DropDownItems)
                            {
                                if (Item is ToolStripMenuItem)
                                {
                                    if ((Item as ToolStripMenuItem).Text == this.CurrentSimulation.SimUniverse.Boundary.ResolveScript.Name)
                                    {
                                        (Item as ToolStripMenuItem).Enabled = false;
                                    }
                                    else
                                    {
                                        (Item as ToolStripMenuItem).Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Boundary_Infinite.Enabled = false;
                            foreach (var Item in this.Universe_Boundary.DropDownItems)
                            {
                                if (Item is ToolStripMenuItem)
                                {
                                    (Item as ToolStripMenuItem).Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
            ApplyThemeColor();
        }

        void SetRadiusTextBoxText()
        {
            if (this.CurrentSimulation != null)
            {
                if (this.CurrentSimulation.SimUniverse != null)
                {
                    if (this.CurrentSimulation.SimUniverse.Boundary != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary.Radius == double.PositiveInfinity)
                        {
                            Radius_RadiusBox.Text = "Infinity";
                        }
                        else
                        {
                            if (this.CurrentSimulation.SimUniverse.Boundary.Radius < 1)
                            {
                                Radius_RadiusBox.Text = this.CurrentSimulation.SimUniverse.Boundary.Radius.ToString("n4");
                            }
                            else
                            {
                                Radius_RadiusBox.Text = this.CurrentSimulation.SimUniverse.Boundary.Radius.ToString("n1");
                            }
                        }
                    }
                }
            }
        }

        void BoundaryItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (this.CurrentSimulation.SimUniverse != null)
                {
                    if (this.CurrentSimulation.SimUniverse.Boundary != null)
                    {
                        ToolStripMenuItem me = (sender as ToolStripMenuItem);
                        if (!this.LoadedAssets.AvailableScripts.HasScript<BoundaryScript>(me.Text)) return;
                        BoundaryScript BS = this.LoadedAssets.AvailableScripts.ExtractScript<BoundaryScript>(me.Text);
                        this.CurrentSimulation.SimUniverse.Boundary.ResolveScript = BS;
                        PopulateUniverseBoundaryMenu();
                    }
                }
            }
        }

        void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (Simulation_Resume.Enabled)
                {
                    Simulation_Resume.PerformClick();
                }
                else if (Simulation_Pause.Enabled)
                {
                    Simulation_Pause.PerformClick();
                }
            }
            else if (e.KeyData == Keys.OemOpenBrackets)
            {
                if (this.CurrentSimulation != null)
                {
                    if (this.CurrentSimulation.SimUniverse != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary != null)
                        {
                            if (this.CurrentSimulation.SimUniverse.Boundary.Radius > 0)
                            {
                                this.CurrentSimulation.SimUniverse.Boundary.Radius -= 0.1 * this.CurrentSimulation.SimUniverse.Boundary.Radius;
                                SetRadiusTextBoxText();
                            }
                        }
                    }
                }
            }
            else if (e.KeyData == Keys.OemCloseBrackets)
            {
                if (this.CurrentSimulation != null)
                {
                    if (this.CurrentSimulation.SimUniverse != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary != null)
                        {
                            if (this.CurrentSimulation.SimUniverse.Boundary.Radius < double.PositiveInfinity)
                            {
                                this.CurrentSimulation.SimUniverse.Boundary.Radius += 0.1 * this.CurrentSimulation.SimUniverse.Boundary.Radius;
                                SetRadiusTextBoxText();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows the new simulation wizard
        /// </summary>
        public void Show_NewSimulationWizard()
        {
            (new NewSimulationWizard(this)).ShowDialog();
        }

        private void File_ShowWelcomeForm_Click(object sender, EventArgs e)
        {
            (new WelcomeForm(this)).ShowDialog();
        }

        private void Help_About_Click(object sender, EventArgs e)
        {
            (new About()).ShowDialog();
        }

        private void Window_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Window_Normalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Window_Maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Simulation_Start_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation == null) return;
            try
            {
                this.CurrentSimulation.Start();
                Simulation_Start.Enabled = true;
                Simulation_Resume.Enabled = false;
                Simulation_Pause.Enabled = true;
                Simulation_Stop.Enabled = true;
            }
            catch (Exception) { }
        }

        private void UpdateInterval_1_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (!this.UpdateInterval_1.Checked)
                {
                    this.UpdateInterval_1.Checked = true;
                    this.UpdateInterval_10.Checked = false;
                    this.UpdateInterval_50.Checked = false;
                    this.UpdateInterval_100.Checked = false;
                    this.UpdateInterval_1000.Checked = false;
                    this.CurrentSimulation.UpdateTimer.Interval = 1;
                }
            }
        }

        private void UpdateInterval_10_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (!this.UpdateInterval_10.Checked)
                {
                    this.UpdateInterval_1.Checked = false;
                    this.UpdateInterval_10.Checked = true;
                    this.UpdateInterval_50.Checked = false;
                    this.UpdateInterval_100.Checked = false;
                    this.UpdateInterval_1000.Checked = false;
                    this.CurrentSimulation.UpdateTimer.Interval = 10;
                }
            }
        }

        private void UpdateInterval_50_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (!this.UpdateInterval_50.Checked)
                {
                    this.UpdateInterval_1.Checked = false;
                    this.UpdateInterval_10.Checked = false;
                    this.UpdateInterval_50.Checked = true;
                    this.UpdateInterval_100.Checked = false;
                    this.UpdateInterval_1000.Checked = false;
                    this.CurrentSimulation.UpdateTimer.Interval = 50;
                }
            }
        }

        private void UpdateInterval_100_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (!this.UpdateInterval_100.Checked)
                {
                    this.UpdateInterval_1.Checked = false;
                    this.UpdateInterval_10.Checked = false;
                    this.UpdateInterval_50.Checked = false;
                    this.UpdateInterval_100.Checked = true;
                    this.UpdateInterval_1000.Checked = false;
                    this.CurrentSimulation.UpdateTimer.Interval = 100;
                }
            }
        }

        private void UpdateInterval_1000_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (!this.UpdateInterval_1000.Checked)
                {
                    this.UpdateInterval_1.Checked = false;
                    this.UpdateInterval_10.Checked = false;
                    this.UpdateInterval_50.Checked = false;
                    this.UpdateInterval_100.Checked = false;
                    this.UpdateInterval_1000.Checked = true;
                    this.CurrentSimulation.UpdateTimer.Interval = 1000;
                }
            }
        }

        /// <summary>
        /// Closes this form and stops the application (performing any neccessary shutdown tasks)
        /// </summary>
        public void CLOSE()
        {
            PerformShutdownTasks();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CLOSE();
            }
        }

        private void File_Exit_Click(object sender, EventArgs e)
        {
            CLOSE();
        }

        private void Interactions_Select_Click(object sender, EventArgs e)
        {
            InteractionSelector x = new InteractionSelector(this);
            x.Location = new Point(this.GridPanel.Location.X + this.GridPanel.Width - x.Width, this.GridPanel.Location.Y);
            x.Height = this.GridPanel.Height;
            x.Theme = this.Theme;
            x.Style = this.Style;
            x.Show();
        }

        private void View_ObjectTable_Click(object sender, EventArgs e)
        {
            ObjectTable x = new ObjectTable(this);
            x.Theme = this.Theme;
            x.Style = this.Style;
            x.Show();
        }

        private void View_ParticleData_Click(object sender, EventArgs e)
        {
            ParticleData x = new ParticleData(this);
            x.Theme = this.Theme;
            x.Style = this.Style;
            x.Show();
        }

        private void ClearGrid()
        {
            //Clear the grid
            try
            {
                this.Grid.Series[0].Points.Clear();
            }
            catch (Exception) { }
        }

        private void Debug_HardInit_Click(object sender, EventArgs e)
        {
            try { this.CurrentSimulation.Stop(); } catch (Exception){}
            this.Grid.VG_ClearPointWatchers();
            this.Grid.VG_ClearPoints();
            this.CurrentSimulation = new Simulation(this.Grid);
            this.CurrentSimulation.SimUniverse = new Universe(3);
            this.CurrentSimulation.SimUniverse.Boundary = new UniverseBoundary(100, this.LoadedAssets.AvailableScripts.ExtractScript<BoundaryScript>("Perfectly Inelastic"));
            this.CurrentSimulation.LinkedUpdateScript = this.LoadedAssets.AvailableScripts.ExtractScript<UpdateScript>("Basic");
            this.CurrentSimulation.Interactions = new InteractionScripts();
            this.CurrentSimulation.Interactions.Add(this.LoadedAssets.AvailableScripts.ExtractScript<ParticleInteractionScript>("Classical Gravity"));
            this.CurrentSimulation.Parameters = new SimulationParameters();
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MaximumVelocity", 10));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MinimumAcceleration", 0.1));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("GravitationalConstant", PhysicsConstants.GravitationalConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("ElectrostaticConstant", PhysicsConstants.ElectrostaticConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MagneticPermeability", PhysicsConstants.MagneticPermeability * 1E30));
            this.CurrentSimulation.SimUniverse.Particles = DEBUG_InitializeParticles(20, this.CurrentSimulation.SimUniverse.Boundary.Radius, SimMath.GenerateRandomDouble(1, 3), this.CurrentSimulation.SimUniverse.NumberDimensions);


            this.Grid.VG_3DMode = true;
            this.Grid.VG_3DCameraPosition[2] = -300;
            this.Grid.VG_Point3DCameraToOrigin();
            this.Grid.VG_PlotPointWatcherTrails = true;
            ((VG_Series)(this.Grid.Series[0])).VG_PointMode_OFF();
            this.Grid.VG_PointWatcherTrailFrequency = 1;
            this.Grid.VG_ClearPointWatchers();
            foreach (Particle P in this.CurrentSimulation.SimUniverse.Particles) this.Grid.VG_AddPointWatcher(P, 20, true);
            PopulateUniverseBoundaryMenu();
            PopulateUpdateScriptMenu();
            ApplyThemeColor();
            SetRadiusTextBoxText();
            this.CurrentSimulation.PlotParticles();
        }

        /// <summary>
        /// Creates a fresh new list of particles with random positions and mass.
        /// </summary>
        /// <param name="NumParticles">The number of particles to create</param>
        /// <param name="GridSize">The "radius" of the grid</param>
        /// <param name="StartingVelocity">The starting velocity of particles</param>
        public static List<Particle> DEBUG_InitializeParticles(int NumParticles, double GridSize, double StartingVelocity, int Dimensions)
        {
            //Create a new list of particles
            List<Particle> NewList = new List<Particle>(NumParticles);

            //Create a new property type called "Mass" that will be inherited by all of our particles
            PropertyType Mass = new PropertyType("Mass", 0, double.PositiveInfinity, false, false);

            //Create charge
            PropertyType Charge = new PropertyType("Charge", double.NegativeInfinity, double.PositiveInfinity, false, false);

            //For each requested number of particles:
            for (int i = 0; i < NumParticles; i++)
            {
                //Create a new 3D particle
                Particle NewParticle = new Particle(Dimensions);

                //Randomize a 3D starting position within the given grid size
                NewParticle.Position = SimMath.RandomEuclideanPosition(Dimensions, GridSize);

                //Randomize the velocity if given
                NewParticle.Velocity = SimMath.RandomDirection(3);
                NewParticle.Velocity.Magnitude *= StartingVelocity;

                //Set the size for the particles
                NewParticle.Radius = 1;

                //Give each particle a random mass and charge
                ParticleProperty NewParticleMass = new ParticleProperty(Mass);
                ParticleProperty NewParticleCharge = new ParticleProperty(Charge);
                NewParticleMass.Value = SimMath.GenerateRandomDouble(1, 10000);
                int Choice = SimMath.GenerateRandomInteger(1, 3);
                if (SimMath.GenerateRandomBool())
                {
                    NewParticleCharge.Value = PhysicsConstants.ElementaryCharge * 1E12;
                }
                else
                {
                    NewParticleCharge.Value = -PhysicsConstants.ElementaryCharge * 1E12;
                }
                NewParticle.Properties.Add(NewParticleMass);
                NewParticle.Properties.Add(NewParticleCharge);

                //Add a copy of this particle to the list of particles
                NewList.Add(NewParticle);
            }
            return NewList;
        }

        private void Simulation_Resume_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation == null) return;
            try
            {
                this.CurrentSimulation.Resume();
                Simulation_Start.Enabled = false;
                Simulation_Resume.Enabled = false;
                Simulation_Pause.Enabled = true;
                Simulation_Stop.Enabled = true;
            }
            catch (Exception) { }
        }

        private void Simulation_Pause_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation == null) return;
            try
            {
                this.CurrentSimulation.Pause();
                Simulation_Start.Enabled = true;
                Simulation_Resume.Enabled = true;
                Simulation_Pause.Enabled = false;
                Simulation_Stop.Enabled = true;
            }
            catch (Exception) { }
        }

        private void Simulation_Stop_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation == null) return;
            try
            {
                this.CurrentSimulation.Stop();
                Simulation_Start.Enabled = true;
                Simulation_Resume.Enabled = false;
                Simulation_Pause.Enabled = false;
                Simulation_Stop.Enabled = false;
            }
            catch (Exception) { }
        }

        private void Simulation_Parameters_Click(object sender, EventArgs e)
        {
            ParameterEditor x = new ParameterEditor(this);
            x.Location = new Point(this.GridPanel.Location.X + this.GridPanel.Width - x.Width, this.GridPanel.Location.Y + this.GridPanel.Height / 2);
            x.Height = this.GridPanel.Height / 2;
            x.Show();
        }

        private void Boundary_Infinite_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                if (this.CurrentSimulation.SimUniverse != null)
                {
                    if (this.CurrentSimulation.SimUniverse.Boundary != null)
                    {
                        this.CurrentSimulation.SimUniverse.Boundary.ResolveScript = null;
                        PopulateUniverseBoundaryMenu();
                    }
                }
            }
        }

        private void Radius_RadiusBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.CurrentSimulation != null)
                {
                    if (this.CurrentSimulation.SimUniverse != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary != null)
                        {
                            if (this.Radius_RadiusBox.Text.ToLower() == "infinity")
                            {
                                this.CurrentSimulation.SimUniverse.Boundary.Radius = double.PositiveInfinity;
                            }
                            else if (this.Radius_RadiusBox.Text != string.Empty)
                            {
                                try
                                {
                                    double val = Convert.ToDouble(this.Radius_RadiusBox.Text);
                                    this.CurrentSimulation.SimUniverse.Boundary.Radius = val;
                                }
                                catch (Exception) { }
                            }
                        }
                    }
                }
            }
        }

        private void Radius_RadiusBox_VisibleChanged(object sender, EventArgs e)
        {
            if (Radius_RadiusBox.Visible)
            {
                if (this.CurrentSimulation != null)
                {
                    if (this.CurrentSimulation.SimUniverse != null)
                    {
                        if (this.CurrentSimulation.SimUniverse.Boundary != null)
                        {
                            
                        }
                    }
                }
            }
        }

        private void View_GridOptions_Click(object sender, EventArgs e)
        {
            GridController x = new GridController(this.Grid);
            x.Location = new Point(Grid.Location.X, GridPanel.Location.Y + GridPanel.Height - x.Height);
            x.Theme = this.Theme;
            x.Style = this.Style;
            x.Show();
        }

        /// <summary>
        /// Re-applies the theme and style color to the form
        /// </summary>
        private void ApplyThemeColor()
        {
            try
            {
                Color BC = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
                Color FC = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
                Color Border = MetroFramework.Drawing.MetroPaint.BorderColor.Form(this.Theme);
                this.GridPanel.BackColor = BC;
                this.GridPanel.ForeColor = FC;
                this.Grid.VG_Theme = this.Theme;
                this.Grid.VG_ColorStyle = this.Style;
                this.Menu.ChangeStyle(this.Theme, this.Style);
            }
            catch (Exception) { }
            this.Refresh();
            this.Grid.Focus();
        }

        /// <summary>
        /// Applies a certain forecolor and backcolor to a toolstripmenuitem and all sub-items
        /// </summary>
        private void ApplyColorsToMenuItem(Color BC, Color FC, object Item)
        {
            if (Item is ToolStripMenuItem)
            {
                (Item as ToolStripMenuItem).BackColor = BC;
                (Item as ToolStripMenuItem).ForeColor = FC;
                if ((Item as ToolStripMenuItem).HasDropDownItems)
                {
                    foreach (dynamic I in (Item as ToolStripMenuItem).DropDownItems)
                    {
                        ApplyColorsToMenuItem(BC, FC, (I as ToolStripMenuItem));
                    }
                }
            }
        }

        private void Theme_Dark_Click(object sender, EventArgs e)
        {
            this.Theme_Dark.Enabled = false;
            this.Theme_Light.Enabled = true;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ApplyThemeColor();
        }

        private void Theme_Light_Click(object sender, EventArgs e)
        {
            this.Theme_Dark.Enabled = true;
            this.Theme_Light.Enabled = false;
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            ApplyThemeColor();
        }

        private void Color_Blue_Click(object sender, EventArgs e)
        {
            Color_Blue.Enabled = false;
            Color_Green.Enabled = true;
            Color_Orange.Enabled = true;
            Color_Purple.Enabled = true;
            Color_Red.Enabled = true;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            ApplyThemeColor();
        }

        private void Color_Green_Click(object sender, EventArgs e)
        {
            Color_Blue.Enabled = true;
            Color_Green.Enabled = false;
            Color_Orange.Enabled = true;
            Color_Purple.Enabled = true;
            Color_Red.Enabled = true;
            this.Style = MetroFramework.MetroColorStyle.Green;
            ApplyThemeColor();
        }

        private void Color_Orange_Click(object sender, EventArgs e)
        {
            Color_Blue.Enabled = true;
            Color_Green.Enabled = true;
            Color_Orange.Enabled = false;
            Color_Purple.Enabled = true;
            Color_Red.Enabled = true;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            ApplyThemeColor();
        }

        private void Color_Purple_Click(object sender, EventArgs e)
        {
            Color_Blue.Enabled = true;
            Color_Green.Enabled = true;
            Color_Orange.Enabled = true;
            Color_Purple.Enabled = false;
            Color_Red.Enabled = true;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            ApplyThemeColor();
        }

        private void Color_Red_Click(object sender, EventArgs e)
        {
            Color_Blue.Enabled = true;
            Color_Green.Enabled = true;
            Color_Orange.Enabled = true;
            Color_Purple.Enabled = true;
            Color_Red.Enabled = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            ApplyThemeColor();
        }

        private void hardInitializeLargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { this.CurrentSimulation.Stop(); }
            catch (Exception) { }
            this.Grid.VG_ClearPointWatchers();
            this.Grid.VG_ClearPoints();
            this.CurrentSimulation = new Simulation(this.Grid);
            this.CurrentSimulation.SimUniverse = new Universe(3);
            this.CurrentSimulation.SimUniverse.Boundary = new UniverseBoundary(100, this.LoadedAssets.AvailableScripts.ExtractScript<BoundaryScript>("Perfectly Inelastic"));
            this.CurrentSimulation.LinkedUpdateScript = this.LoadedAssets.AvailableScripts.ExtractScript<UpdateScript>("Basic");
            this.CurrentSimulation.Interactions = new InteractionScripts();
            this.CurrentSimulation.Interactions.Add(this.LoadedAssets.AvailableScripts.ExtractScript<ParticleInteractionScript>("Classical Gravity"));
            this.CurrentSimulation.Parameters = new SimulationParameters();
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MaximumVelocity", 10));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MinimumAcceleration", 0.1));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("GravitationalConstant", PhysicsConstants.GravitationalConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("ElectrostaticConstant", PhysicsConstants.ElectrostaticConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MagneticPermeability", PhysicsConstants.MagneticPermeability * 1E30));
            this.CurrentSimulation.SimUniverse.Particles = DEBUG_InitializeParticles(100, this.CurrentSimulation.SimUniverse.Boundary.Radius, SimMath.GenerateRandomDouble(1, 5), this.CurrentSimulation.SimUniverse.NumberDimensions);


            this.Grid.VG_3DMode = true;
            this.Grid.VG_HighDefinition = false;
            this.Grid.VG_3DCameraPosition[2] = -300;
            this.Grid.VG_Point3DCameraToOrigin();
            this.Grid.VG_PlotPointWatcherTrails = true;
            ((VG_Series)(this.Grid.Series[0])).VG_PointMode_OFF();
            this.Grid.VG_PointWatcherTrailFrequency = 1;
            this.Grid.VG_ClearPointWatchers();
            foreach (Particle P in this.CurrentSimulation.SimUniverse.Particles) this.Grid.VG_AddPointWatcher(P, 5, true);
            PopulateUniverseBoundaryMenu();
            PopulateUpdateScriptMenu();
            ApplyThemeColor();
            SetRadiusTextBoxText();
            this.CurrentSimulation.PlotParticles();
        }

        private void hardInitializeVeryLargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { this.CurrentSimulation.Stop(); }
            catch (Exception) { }
            this.Grid.VG_ClearPointWatchers();
            this.Grid.VG_ClearPoints();
            this.CurrentSimulation = new Simulation(this.Grid);
            this.CurrentSimulation.SimUniverse = new Universe(3);
            this.CurrentSimulation.SimUniverse.Boundary = new UniverseBoundary(150, this.LoadedAssets.AvailableScripts.ExtractScript<BoundaryScript>("Perfectly Inelastic"));
            this.CurrentSimulation.LinkedUpdateScript = this.LoadedAssets.AvailableScripts.ExtractScript<UpdateScript>("Basic");
            this.CurrentSimulation.Interactions = new InteractionScripts();
            this.CurrentSimulation.Interactions.Add(this.LoadedAssets.AvailableScripts.ExtractScript<ParticleInteractionScript>("Classical Gravity"));
            this.CurrentSimulation.Parameters = new SimulationParameters();
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MaximumVelocity", 10));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MinimumAcceleration", 0.1));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("GravitationalConstant", PhysicsConstants.GravitationalConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("ElectrostaticConstant", PhysicsConstants.ElectrostaticConstant * 1E12));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MagneticPermeability", PhysicsConstants.MagneticPermeability * 1E30));
            this.CurrentSimulation.SimUniverse.Particles = DEBUG_InitializeParticles(150, this.CurrentSimulation.SimUniverse.Boundary.Radius, SimMath.GenerateRandomDouble(1, 5), this.CurrentSimulation.SimUniverse.NumberDimensions);


            this.Grid.VG_3DMode = true;
            this.Grid.VG_3DCameraPosition[2] = -300;
            this.Grid.VG_Point3DCameraToOrigin();
            this.Grid.VG_PlotPointWatcherTrails = false;
            this.Grid.VG_HighDefinition = false;
            ((VG_Series)(this.Grid.Series[0])).VG_PointMode_OFF();
            this.Grid.VG_PointWatcherTrailFrequency = 1;
            this.Grid.VG_ClearPointWatchers();
            foreach (Particle P in this.CurrentSimulation.SimUniverse.Particles) this.Grid.VG_AddPointWatcher(P, 5, false);
            PopulateUniverseBoundaryMenu();
            PopulateUpdateScriptMenu();
            ApplyThemeColor();
            SetRadiusTextBoxText();
            this.CurrentSimulation.PlotParticles();
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Simulation_Buffer_Click(object sender, EventArgs e)
        {
            if (this.CurrentSimulation != null)
            {
                (new BufferSimulation(this.CurrentSimulation, this.Theme, this.Style)).Show();
            }
        }

        private void hardInitializeGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { this.CurrentSimulation.Stop(); }
            catch (Exception) { }
            this.Grid.VG_ClearPointWatchers();
            this.Grid.VG_ClearPoints();
            this.CurrentSimulation = new Simulation(this.Grid);
            this.CurrentSimulation.SimUniverse = new Universe(3);
            this.CurrentSimulation.SimUniverse.Boundary = new UniverseBoundary(100, this.LoadedAssets.AvailableScripts.ExtractScript<BoundaryScript>("Perfectly Inelastic"));
            this.CurrentSimulation.LinkedUpdateScript = this.LoadedAssets.AvailableScripts.ExtractScript<UpdateScript>("Basic");
            this.CurrentSimulation.Interactions = new InteractionScripts();
            //this.CurrentSimulation.Interactions.Add(this.LoadedAssets.AvailableScripts.ExtractScript<ParticleInteractionScript>("Classical Gravity"));
            this.CurrentSimulation.Parameters = new SimulationParameters();
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("k", 1.0));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MaximumVelocity", 20));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MinimumAcceleration", 0.1));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("GravitationalConstant", 1.0));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("ElectrostaticConstant", 1.0));
            this.CurrentSimulation.Parameters.Add(new SimulationParameter("MagneticPermeability", 1.0));
            this.CurrentSimulation.SimUniverse.Particles = DEBUG_InitializeParticles(20, this.CurrentSimulation.SimUniverse.Boundary.Radius, SimMath.GenerateRandomDouble(1, 3), this.CurrentSimulation.SimUniverse.NumberDimensions);


            this.Grid.VG_3DMode = true;
            this.Grid.VG_3DCameraPosition[2] = -300;
            this.Grid.VG_Point3DCameraToOrigin();
            this.Grid.VG_PlotPointWatcherTrails = true;
            ((VG_Series)(this.Grid.Series[0])).VG_PointMode_OFF();
            this.Grid.VG_PointWatcherTrailFrequency = 1;
            this.Grid.VG_ClearPointWatchers();
            foreach (Particle P in this.CurrentSimulation.SimUniverse.Particles) this.Grid.VG_AddPointWatcher(P, 20, true);
            PopulateUniverseBoundaryMenu();
            PopulateUpdateScriptMenu();
            ApplyThemeColor();
            SetRadiusTextBoxText();
            this.CurrentSimulation.PlotParticles();
        }
    }
}
