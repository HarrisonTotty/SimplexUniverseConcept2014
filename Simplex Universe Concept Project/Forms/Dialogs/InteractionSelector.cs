using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplexUniverse.Physics;
using SimplexUniverse.Math;

namespace SimplexUniverse
{
    public partial class InteractionSelector : MetroFramework.Forms.MetroForm
    {
        public MainForm LinkedForm;

        public InteractionSelector(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedForm = LinkedForm;
        }

        private void InteractionSelector_Load(object sender, EventArgs e)
        {
            //Load available interaction scripts
            this.ScriptSelector.Theme = this.Theme;
            this.ScriptSelector.Style = this.Style;
            this.MainMenu.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.MainMenu.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.MainMenu.Renderer = new ToolStripProfessionalRenderer(new Drawing.MenuColorPallet(this.Theme, this.Style));

            List<Scripting.InteractionScript> IS = this.LinkedForm.LoadedAssets.AvailableScripts.ExtractScripts<Scripting.InteractionScript>();
            foreach (Scripting.InteractionScript I in IS)
            {
                ScriptSelector.Rows.Add(false, I.Name, I.Description);
            }
            UpdateInteractionScripts();
            UpdateTimer.Start();
        }

        /// <summary>
        /// Updates the checked status for whether a particular type of interaction script has been selected
        /// </summary>
        private void UpdateInteractionScripts()
        {
            try
            {
                //For each script that we CAN have:
                for (int i = 0; i < ScriptSelector.Rows.Count; i++)
                {
                    bool found = false;
                    foreach (Scripting.InteractionScript IS in this.LinkedForm.CurrentSimulation.Interactions)
                    {
                        //If that script is in our selector at this count, do nothing
                        if ((string)ScriptSelector.Rows[i].Cells[1].Value == IS.Name)
                        {
                            ScriptSelector.Rows[i].Cells[0].Value = true;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        ScriptSelector.Rows[i].Cells[0].Value = false;
                    }
                }

                
            }
            catch (Exception) { }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            UpdateInteractionScripts();
            UpdateTimer.Start();
        }

        private void ScriptSelector_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ScriptSelector_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void ScriptSelector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ScriptSelector.Rows[e.RowIndex].Cells[0].Value = !(bool)ScriptSelector.Rows[e.RowIndex].Cells[0].Value;
                try
                {
                    bool found = false;
                    bool Enabled = (bool)ScriptSelector.Rows[e.RowIndex].Cells[0].Value;
                    string ScriptName = (string)ScriptSelector.Rows[e.RowIndex].Cells[1].Value;
                    foreach (Scripting.InteractionScript IS in this.LinkedForm.CurrentSimulation.Interactions)
                    {
                        if (ScriptName == IS.Name)
                        {
                            if (!Enabled) this.LinkedForm.CurrentSimulation.Interactions.Remove(this.LinkedForm.LoadedAssets.AvailableScripts.ExtractScript<Scripting.InteractionScript>(ScriptName));
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        if (Enabled) this.LinkedForm.CurrentSimulation.Interactions.Add(this.LinkedForm.LoadedAssets.AvailableScripts.ExtractScript<Scripting.InteractionScript>(ScriptName));
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
