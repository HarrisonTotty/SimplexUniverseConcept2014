using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplexUniverse.Scripting;
using SimplexUniverse.Simulations;
using MetroFramework.Forms;

namespace SimplexUniverse
{
    /// <summary>
    /// This form is displayed when the user wants to buffer their simulation over a particular number of generations.
    /// </summary>
    public partial class BufferSimulation : MetroForm
    {
        public Simulation Sim;

        /// <summary>
        /// Creates a new buffer simulation form with a particular simulation to buffer
        /// </summary>
        /// <param name="SimulationToBuffer">The simulation to buffer</param>
        public BufferSimulation(Simulation SimulationToBuffer, MetroFramework.MetroThemeStyle Theme, MetroFramework.MetroColorStyle ColorStyle)
        {
            InitializeComponent();
            this.Sim = SimulationToBuffer;
            SetThemeStyle(Theme, ColorStyle);
        }

        private void SetThemeStyle(MetroFramework.MetroThemeStyle Theme, MetroFramework.MetroColorStyle ColorStyle)
        {
            System.Drawing.Color BC = MetroFramework.Drawing.MetroPaint.BackColor.Form(Theme);
            System.Drawing.Color FC = MetroFramework.Drawing.MetroPaint.ForeColor.Title(Theme);
            this.Theme = Theme;
            this.Style = ColorStyle;
            Tabs.Theme = Theme;
            Tabs.Style = ColorStyle;
            Tab_Basic.Theme = Theme;
            Tab_Basic.Style = ColorStyle;
            Tab_Advanced.Theme = Theme;
            Tab_Advanced.Style = ColorStyle;
            L1.Theme = Theme;
            L2.Theme = Theme;
            Basic_NumberGenerations.ForeColor = FC;
            Basic_NumberGenerations.BackColor = BC;
            Basic_StartFromCurrentGeneration.Theme = Theme;
            Basic_StartFromCurrentGeneration.Style = ColorStyle;
            StartButton.Theme = Theme;
            StartButton.Style = ColorStyle;
            CancelButton.Theme = Theme;
            CancelButton.Style = ColorStyle;
        }

        private void BufferSimulation_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Sim.Grid = null;
            (new BufferingForm(this.Sim, !this.Basic_StartFromCurrentGeneration.Checked, (long)this.Basic_NumberGenerations.Value, this.Theme, this.Style)).ShowDialog();
            this.Close();
        }
    }
}
