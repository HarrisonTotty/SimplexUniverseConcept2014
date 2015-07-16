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
using SimplexUniverse.Math;

namespace SimplexUniverse
{
    public partial class ParticleData : MetroForm
    {
        public MainForm LinkedForm;

        public ParticleData(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedForm = LinkedForm;
        }

        private void ParticleData_Load(object sender, EventArgs e)
        {
            PopulateGrid();
            this.ParticleGrid.Theme = this.Theme;
            this.ParticleGrid.Style = this.Style;
            this.MainMenu.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.MainMenu.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.MainMenu.Renderer = new ToolStripProfessionalRenderer(new Drawing.MenuColorPallet(this.Theme, this.Style));
            UpdateTimer.Start();
        }

        private void PopulateGrid()
        {
            lock (Simplex.ObjectRegistry)
            {
                try
                {
                    ParticleGrid.Rows.Clear();
                    List<string> IDs = Simplex.ObjectRegistry.Keys.ToList<string>();
                    IDs.Sort();
                    foreach (string ID in IDs)
                    {
                        var S = Simplex.ObjectRegistry[ID];
                        if (S is Particle)
                        {
                            Particle P = (Particle)S;
                            string PNF = P.NetForce.Magnitude.ToString("n8");
                            string PA = P.GetActualAcceleration().Magnitude.ToString("n8");
                            string PV = P.GetActualVelocity().Magnitude.ToString("n8");
                            string PP = P.GetActualPosition().ToString(Math.Enums.Vector_StringFormat.Bracket, "n4");
                            ParticleGrid.Rows.Add(ID, P.Radius, PNF, PA, PV, PP, P.Name, P.Description);
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            try
            {
                if (this.LinkedForm.CurrentSimulation.Running)
                {
                    this.Edit_SelectedParticles.Enabled = false;
                    PopulateGrid();
                }
                else
                {
                    this.Edit_SelectedParticles.Enabled = true;
                }
            }
            catch (Exception) { }
            UpdateTimer.Start();
        }

        private void ParticleGrid_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void Edit_SelectedParticles_Click(object sender, EventArgs e)
        {
            if (ParticleGrid.SelectedRows.Count > 0)
            {
                List<Particle> list = new List<Particle>();

                foreach (DataGridViewRow row in ParticleGrid.SelectedRows)
                {
                    string ID = (string)row.Cells[0].Value;
                    list.Add((Simplex.ObjectRegistry[ID] as Particle));
                }

                ParticleEditor NewEditor = new ParticleEditor();
                NewEditor.Editor.SelectedObjects = list.ToArray();
                NewEditor.ShowDialog();
            }
        }

        private void RFI_1_Click(object sender, EventArgs e)
        {
            RFI_1.Enabled = false;
            RFI_100.Enabled = true;
            RFI_1000.Enabled = true;
            this.UpdateTimer.Interval = 1;
        }

        private void RFI_100_Click(object sender, EventArgs e)
        {
            RFI_1.Enabled = true;
            RFI_100.Enabled = false;
            RFI_1000.Enabled = true;
            this.UpdateTimer.Interval = 100;
        }

        private void RFI_1000_Click(object sender, EventArgs e)
        {
            RFI_1.Enabled = true;
            RFI_100.Enabled = true;
            RFI_1000.Enabled = false;
            this.UpdateTimer.Interval = 1000;
        }
    }
}
