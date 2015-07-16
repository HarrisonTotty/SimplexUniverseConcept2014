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
using SimplexUniverse.Simulations;
using SimplexUniverse.Scripting;
using SimplexUniverse.Physics;

namespace SimplexUniverse
{
    /// <summary>
    /// The form that does the actual buffering when the user presses "Start" on the buffer simulation form
    /// </summary>
    public partial class BufferingForm : MetroForm
    {
        /// <summary>
        /// The simulation to buffer
        /// </summary>
        public Simulation Sim;

        /// <summary>
        /// The number of generations to buffer from the current generation or generation 0 (depending on settings)
        /// </summary>
        public long NumberGenerations = 0;

        /// <summary>
        /// The number of generations currently buffered
        /// </summary>
        public long NumberBuffered = 0;

        /// <summary>
        /// The generation we started buffering on
        /// </summary>
        public long StartGeneration = 0;

        /// <summary>
        /// Whether to buffer this simulation from generation 0 or from the current generation
        /// </summary>
        public bool StartFromBeginning = false;

        /// <summary>
        /// The buffered simulation (TEMPORARY VERSION)
        /// </summary>
        public SimpleBufferedSimulation BSim;

        public BufferingForm(Simulation Sim, bool StartFromBeginning, long NumberGenerations, MetroFramework.MetroThemeStyle Theme, MetroFramework.MetroColorStyle ColorStyle)
        {
            InitializeComponent();
            this.Sim = Sim;
            this.StartFromBeginning = StartFromBeginning;
            this.NumberGenerations = NumberGenerations;
            this.BSim = new SimpleBufferedSimulation((int)NumberGenerations);
            this.SetThemeStyle(Theme, ColorStyle);
        }

        private void SetThemeStyle(MetroFramework.MetroThemeStyle Theme, MetroFramework.MetroColorStyle ColorStyle)
        {
            System.Drawing.Color BC = MetroFramework.Drawing.MetroPaint.BackColor.Form(Theme);
            System.Drawing.Color FC = MetroFramework.Drawing.MetroPaint.ForeColor.Title(Theme);
            this.Theme = Theme;
            this.Style = ColorStyle;
            this.StatusLabel.Theme = Theme;
            this.StatusLabel.Style = ColorStyle;
            this.PB.Theme = Theme;
            this.PB.Style = ColorStyle;
        }

        private void BufferForm_Load(object sender, EventArgs e)
        {
            this.PB.Value = 0;
            
            if (!this.StartFromBeginning)
            {
                this.StartGeneration = Sim.CurrentGeneration;
            }
            else 
            {
                this.StartGeneration = 0;
            }
            this.PB.Maximum = (int)NumberGenerations;
            this.StatusLabel.Text = "Calculating generation 1 of " + this.NumberGenerations.ToString("n") + "...";
            StartTimer.Start();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();
            this.NumberBuffered = this.Sim.CurrentGeneration;

            if (this.NumberBuffered < this.NumberGenerations)
            {
                this.Sim.Update();
                List<Math.Vector> Positions = new List<Math.Vector>(this.Sim.SimUniverse.Particles.Count);
                foreach (Particle P in this.Sim.SimUniverse.Particles) Positions.Add(P.GetActualPosition());
                this.BSim.Positions.Add(Positions);
                this.NumberBuffered++;
                this.PB.Value++;
                this.StatusLabel.Text = "Calculating generation " + (this.NumberBuffered + 1).ToString("n0") + " of " + this.NumberGenerations.ToString("n0") + "...";
                StartTimer.Start();
            }
            else
            {
                this.StatusLabel.Text = "Complete...";
                this.PB.Value = this.PB.Maximum;
                (new BufferViewer(this.BSim)).Show();
                this.Close();
            }
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
