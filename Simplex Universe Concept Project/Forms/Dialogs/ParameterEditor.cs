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
using SimplexUniverse.Physics;
using SimplexUniverse.Simulations;
using SimplexUniverse.Math;

namespace SimplexUniverse
{
    public partial class ParameterEditor : MetroForm
    {
        public MainForm LinkedForm;

        public ParameterEditor(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedForm = LinkedForm;
        }

        private void ParameterEditor_Load(object sender, EventArgs e)
        {
            UpdateList();
            UpdateTimer.Start();
        }

        private void UpdateList()
        {
            try
            {
                ParamList.Rows.Clear();

                foreach (SimulationParameter P in this.LinkedForm.CurrentSimulation.Parameters)
                {
                    ParamList.Rows.Add(P.Name, P.Value);
                }
            }
            catch (Exception) { }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            try
            {
                if (this.LinkedForm.CurrentSimulation.Running) UpdateList();
            }
            catch (Exception) { }
            UpdateTimer.Start();
        }

        private void ParamList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
