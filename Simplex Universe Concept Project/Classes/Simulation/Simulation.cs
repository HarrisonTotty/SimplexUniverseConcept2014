using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.VisualizationComponents;
using SimplexUniverse.Scripting;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimplexUniverse.Simulations
{
    /// <summary>
    /// Handles running, plotting, recording, manipulating, and monitoring simulations.
    /// Bridges the connection between the user and the simulation itself.
    /// </summary>
    [Serializable()]
    public class Simulation
    {
        /// <summary>
        /// This timer is used to update the simulation every generation and re-draw the grid. Its update interval is usually set to 1 millisecond.
        /// Using a timer also gives the window enough time to re-draw the updated changes.
        /// </summary>
        [NonSerialized()]
        public System.Windows.Forms.Timer UpdateTimer;


        /// <summary>
        /// Represents the current generation of the simulation (number of updates that have been performed).
        /// </summary>
        public long CurrentGeneration = 0;


        /// <summary>
        /// A link to the visualization grid used for plotting points.
        /// Try not to manually change this reference from a remote class.
        /// </summary>
        [NonSerialized()]
        public VisualizationGrid Grid;


        /// <summary>
        /// A link to the universe to run the simulation on.
        /// </summary>
        public Universe SimUniverse;


        /// <summary>
        /// Whether the simulation will be updated everytime the update timer ticks.
        /// </summary>
        [NonSerialized()]
        public bool Running = false;
        

        /// <summary>
        /// Creates a new simulation controller with a reference grid to plot points on.
        /// </summary>
        /// <param name="GridReference">The VisualizationGrid object you want the controller to plot points on</param>
        public Simulation(VisualizationGrid GridReference)
        {
            //Link the grid reference
            this.Grid = GridReference;

            //Initialize the update timer
            this.UpdateTimer = new System.Windows.Forms.Timer();
            this.UpdateTimer.Interval = 1;

            //Link the handler for the update timer's "tick"
            this.UpdateTimer.Tick += UpdateTimer_Tick;
        }


        /// <summary>
        /// Creates a new blank simulation controller
        /// </summary>
        public Simulation()
        {
            //Initialize the update timer
            this.UpdateTimer = new System.Windows.Forms.Timer();
            this.UpdateTimer.Interval = 1;

            //Link the handler for the update timer's "tick"
            this.UpdateTimer.Tick += UpdateTimer_Tick;
        }

        /// <summary>
        /// The list of parameters present in this simulation
        /// </summary>
        public SimulationParameters Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// The script used to update a single particle against other particles
        /// </summary>
        public UpdateScript LinkedUpdateScript
        {
            get;
            set;
        }

        /// <summary>
        /// The list of available interaction scripts
        /// </summary>
        public InteractionScripts Interactions
        {
            get;
            set;
        }


        /// <summary>
        /// Handles the "tick" event for the update timer
        /// </summary>
        void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //Stop the timer
            this.UpdateTimer.Stop();

            //If the simulation is running, update the simulation
            lock (Simplex.ObjectRegistry)
            {
                if (this.Running) this.Update();
            }

            //Re-draw the particles
            PlotParticles();
            try
            {
                this.Grid.VG_UpdatePointWatchers(this.SimUniverse.Particles);
            }
            catch (Exception) { }

            //Start the timer
            this.UpdateTimer.Start();
        }


        /// <summary>
        /// Starts a new run of the simulation at Generation 0
        /// </summary>
        public void Start()
        {
            //Stop the simulation and update timer if they are running
            this.Running = false;
            this.UpdateTimer.Stop();

            //Make sure we have a universe and it has particles
            if (this.SimUniverse == null) return;
            if (this.SimUniverse.Particles == null) return;
            if (this.SimUniverse.Particles.Count == 0) return;

            //Clear the grid
            try
            {
                this.Grid.Series[0].Points.Clear();
            }
            catch (Exception) { }

            //Reset the generation count
            this.CurrentGeneration = 0;

            //Setup the grid
            PlotParticles();

            //Start the simulation
            this.Running = true;
            this.UpdateTimer.Start();
        }


        /// <summary>
        /// Stops a currently running simulation and runs any post-simulation scripts (such as saving data to files, etc.)
        /// </summary>
        public void Stop()
        {
            //If we are running, stop running
            this.Running = false;
            this.UpdateTimer.Stop();
        }


        /// <summary>
        /// Resumes a previously paused simulation
        /// </summary>
        public void Resume()
        {
            //If we are not running, start running
            if (!this.Running) this.Running = true;
        }


        /// <summary>
        /// Pauses a currently running simulation
        /// </summary>
        public void Pause()
        {
            //If we are running, stop running
            if (this.Running) this.Running = false;
        }


        /// <summary>
        /// Updates the simulation by one generation by executing the linked update script
        /// This method is typically called by the "UpdateTimer_Tick" event handler. Try not to call this method manually.
        /// </summary>
        public void Update()
        {
            //Make sure we have an update script and universe with boundary
            if (this.SimUniverse == null) return;
            if (this.SimUniverse.Boundary == null) return;
            if (this.LinkedUpdateScript == null) return;

            //Unregister all objects
            foreach (Particle P in this.SimUniverse.Particles) P.Unregister();

            //Execute the update script
            this.LinkedUpdateScript.Update(this);

            //Register all objects
            foreach (Particle P in this.SimUniverse.Particles) P.Register();

            //Check for and resolve boundary violations
            this.SimUniverse.Boundary_CheckViolations();

            //Increase the generation count and re-draw it
            this.CurrentGeneration++;
            try
            {
                this.Grid.Titles[0].Text = "Generation " + this.CurrentGeneration.ToString();
            }
            catch (Exception) { }
        }


        /// <summary>
        /// Re-plots the positions of the topmost layer of particles on the visualization grid
        /// </summary>
        public void PlotParticles()
        {
            try
            {
                //If we are in 3D mode:
                if (this.Grid.VG_3DMode)
                {
                    //Plot the entire list of particles
                    this.Grid.VG_PlotList_3D(this.SimUniverse.Particles);
                }
                else //Otherwise:
                {
                    //Plot the entire list of particles
                    this.Grid.VG_PlotList_2D(this.SimUniverse.Particles);
                }
            }
            catch (Exception) { }
        }
    }
}
