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

namespace SimplexUniverse
{
    public partial class NewSimulationWizard : MetroForm
    {
        /// <summary>
        /// The main form that this new simulation wizard will draw data from
        /// </summary>
        public MainForm LinkedMainForm;

        /// <summary>
        /// Creates a new simulation wizard with a linked main form
        /// </summary>
        /// <param name="LinkedForm">The main form that this wizard is linked to</param>
        public NewSimulationWizard(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedMainForm = LinkedForm;
        }

        private void NewSimulationWizard_Load(object sender, EventArgs e)
        {
            SetUpTabs();
            PopulateScriptSelectors();
        }

        private void Tab_Start_NextButton_Click(object sender, EventArgs e)
        {
            Tabs.SelectedTab = Tab_Dimensions;
        }

        /// <summary>
        /// Places the tab pages in the right order because sometimes VS is retarded.
        /// </summary>
        private void SetUpTabs()
        {
            Tabs.TabPages.Clear();
            Tabs.TabPages.Add(Tab_Start);
            Tabs.TabPages.Add(Tab_Dimensions);
            Tabs.TabPages.Add(Tab_UniverseProperties);
            Tabs.TabPages.Add(Tab_Interactions);
            Tabs.TabPages.Add(Tab_Parameters);
            Tabs.TabPages.Add(Tab_Properties);
            Tabs.TabPages.Add(Tab_ParticleSeed);
            Tabs.TabPages.Add(Tab_Advanced);
            Tabs.TabPages.Add(Tab_Review);

            Tabs.SelectedTab = Tab_Start;
            Tab_UniverseProperties_Tabs.SelectedTab = Tab_UniverseProperties_Tabs_Size;
            Tab_Interactions_Tabs.SelectedTab = Tab_Interactions_Tabs_Update;
            Tab_Properties_PropGrid.Rows.Add("mass", "[0, Infinity)");
        }

        /// <summary>
        /// Populates the various combo boxes and grid views
        /// </summary>
        private void PopulateScriptSelectors()
        {
            //Load boundary scripts
            List<Scripting.BoundaryScript> BS = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScripts<Scripting.BoundaryScript>();
            foreach (Scripting.BoundaryScript B in BS)
            {
                if (B.Name == null) continue;
                Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.Items.Add(B.Name);
            }

            //Load update scripts
            List<Scripting.UpdateScript> US = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScripts<Scripting.UpdateScript>();
            foreach (Scripting.UpdateScript U in US)
            {
                if (U.Name == null) continue;
                Tab_Interactions_Tabs_Update_Selector.Items.Add(U.Name);
            }

            //Load interaction scripts
            List<Scripting.InteractionScript> IS = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScripts<Scripting.InteractionScript>();
            foreach (Scripting.InteractionScript I in IS)
            {
                Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows.Add(false, I.Name, I.Description);
            }

            //Load particle seed scripts
            List<Scripting.SeedScript> SS = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScripts<Scripting.SeedScript>();
            foreach (Scripting.SeedScript S in SS)
            {
                //Tab_ParticleSeed_SeedScript.Items.Add(S.Name);
            }
        }

        private void Tab_Dimensions_1DButton_Click(object sender, EventArgs e)
        {
            Tab_Dimensions_1DButton.Highlight = true;
            Tab_Dimensions_2DButton.Highlight = false;
            Tab_Dimensions_3DButton.Highlight = false;
            Tab_Dimensions_NumberDimensions.Value = 1;
            Tab_Dimensions_1DButton.Focus();
            Tab_Dimensions_2DButton.Focus();
            Tab_Dimensions_3DButton.Focus();
            Tab_Dimensions_NumberDimensions.Focus();
        }

        private void Tab_Dimensions_2DButton_Click(object sender, EventArgs e)
        {
            Tab_Dimensions_1DButton.Highlight = false;
            Tab_Dimensions_2DButton.Highlight = true;
            Tab_Dimensions_3DButton.Highlight = false;
            Tab_Dimensions_NumberDimensions.Value = 2;
            Tab_Dimensions_1DButton.Focus();
            Tab_Dimensions_2DButton.Focus();
            Tab_Dimensions_3DButton.Focus();
            Tab_Dimensions_NumberDimensions.Focus();
        }

        private void Tab_Dimensions_3DButton_Click(object sender, EventArgs e)
        {
            Tab_Dimensions_1DButton.Highlight = false;
            Tab_Dimensions_2DButton.Highlight = false;
            Tab_Dimensions_3DButton.Highlight = true;
            Tab_Dimensions_NumberDimensions.Value = 3;
            Tab_Dimensions_1DButton.Focus();
            Tab_Dimensions_2DButton.Focus();
            Tab_Dimensions_3DButton.Focus();
            Tab_Dimensions_NumberDimensions.Focus();
        }

        private void Tab_Dimensions_NumberDimensions_ValueChanged(object sender, EventArgs e)
        {
            int X = (int)Tab_Dimensions_NumberDimensions.Value;
            switch (X)
            {
                case 1:
                    Tab_Dimensions_1DButton.Highlight = true;
                    Tab_Dimensions_2DButton.Highlight = false;
                    Tab_Dimensions_3DButton.Highlight = false;
                    Tab_Dimensions_1DButton.Focus();
                    Tab_Dimensions_2DButton.Focus();
                    Tab_Dimensions_3DButton.Focus();
                    Tab_Dimensions_NumberDimensions.Focus();
                    break;
                case 2:
                    Tab_Dimensions_1DButton.Highlight = false;
                    Tab_Dimensions_2DButton.Highlight = true;
                    Tab_Dimensions_3DButton.Highlight = false;
                    Tab_Dimensions_1DButton.Focus();
                    Tab_Dimensions_2DButton.Focus();
                    Tab_Dimensions_3DButton.Focus();
                    Tab_Dimensions_NumberDimensions.Focus();
                    break;
                case 3:
                    Tab_Dimensions_1DButton.Highlight = false;
                    Tab_Dimensions_2DButton.Highlight = false;
                    Tab_Dimensions_3DButton.Highlight = true;
                    Tab_Dimensions_1DButton.Focus();
                    Tab_Dimensions_2DButton.Focus();
                    Tab_Dimensions_3DButton.Focus();
                    Tab_Dimensions_NumberDimensions.Focus();
                    break;
                default:
                    Tab_Dimensions_1DButton.Highlight = false;
                    Tab_Dimensions_2DButton.Highlight = false;
                    Tab_Dimensions_3DButton.Highlight = false;
                    Tab_Dimensions_1DButton.Focus();
                    Tab_Dimensions_2DButton.Focus();
                    Tab_Dimensions_3DButton.Focus();
                    Tab_Dimensions_NumberDimensions.Focus();
                    break;
            }
        }

        private void Tab_UniverseProperties_Tabs_Size_SizeBar_ValueChanged(object sender, EventArgs e)
        {
            if (Tab_UniverseProperties_Tabs_Size_SizeBar.Value == 1001)
            {
                Tab_UniverseProperties_Tabs_Size_SizeLabel.Text = "Infinite";
                Tab_UniverseProperties_Tabs.TabPages.Remove(Tab_UniverseProperties_Tabs_Boundary);
            }
            else
            {
                Tab_UniverseProperties_Tabs_Size_SizeLabel.Text = Tab_UniverseProperties_Tabs_Size_SizeBar.Value + " Units";
                if (!Tab_UniverseProperties_Tabs.TabPages.Contains(Tab_UniverseProperties_Tabs_Boundary)) Tab_UniverseProperties_Tabs.TabPages.Add(Tab_UniverseProperties_Tabs_Boundary);
            }
        }

        private void Tab_Dimensions_NextButton_Click(object sender, EventArgs e)
        {
            Tabs.SelectedTab = Tab_UniverseProperties;
        }

        private void Tab_UniverseProperties_Tabs_Boundary_BoundarySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string NameString = Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.SelectedItem.ToString();
            Tab_UniverseProperties_Tabs_Boundary_BoundaryDesc.Text = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScript<Scripting.BoundaryScript>(NameString).Description;
        }

        private void Tab_Review_CreateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Tab_UniverseProperties_Tabs_Size_SizeBar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Tab_UniverseProperties_NextButton_Click(object sender, EventArgs e)
        {
            if (Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.SelectedItem == null)
            {
                if (Tab_UniverseProperties_Tabs.SelectedTab == Tab_UniverseProperties_Tabs_Size)
                {
                    Tab_UniverseProperties_Tabs.SelectedTab = Tab_UniverseProperties_Tabs_Boundary;
                }
                else
                {
                    if (Tab_UniverseProperties_Tabs_Size_SizeBar.Value != 1001)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Please select a universe boundary before continuing.", "Woh there partner!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Tabs.SelectedTab = Tab_Interactions;
            }
        }

        private void Tab_Interactions_Tabs_Update_Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string NameString = Tab_Interactions_Tabs_Update_Selector.SelectedItem.ToString();
            Tab_Interactions_Tabs_Update_ScriptDescription.Text = this.LinkedMainForm.LoadedAssets.AvailableScripts.ExtractScript<Scripting.UpdateScript>(NameString).Description;
        }

        private void Tab_Interactions_Tabs_Update_ScriptDescription_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Interactions_NextButton_Click(object sender, EventArgs e)
        {
            if (Tab_Interactions_Tabs_Update_Selector.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select an update script before continuing.", "Woh there partner!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Tab_Interactions_Tabs.SelectedTab == Tab_Interactions_Tabs_Update)
                {
                    Tab_Interactions_Tabs.SelectedTab = Tab_Interactions_Tabs_Interactions;
                }
                else
                {
                    Tabs.SelectedTab = Tab_Parameters;
                }
            }
        }

        private void Tab_Parameters_NextButton_Click(object sender, EventArgs e)
        {
            Tabs.SelectedTab = Tab_Properties;
        }

        private void Tab_Dimensions_RandomButton_Click(object sender, EventArgs e)
        {
            Tab_Dimensions_NumberDimensions.Value = Math.SimMath.GenerateRandomInteger(1, 100);
            Tab_Dimensions_NextButton.PerformClick();
        }

        private void Tab_UniverseProperties_RandomizeButton_Click(object sender, EventArgs e)
        {
            Tab_UniverseProperties_Tabs_Size_SizeBar.Value = Math.SimMath.GenerateRandomInteger(1, 1001);
            if (Tab_UniverseProperties_Tabs_Size_SizeBar.Value != 1001)
            {
                Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.SelectedIndex = Math.SimMath.GenerateRandomInteger(0, Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.Items.Count - 1);
            }
            Tab_UniverseProperties_NextButton.PerformClick();
        }

        private void Tab_Interactions_RandomizeButton_Click(object sender, EventArgs e)
        {
            Tab_Interactions_Tabs_Update_Selector.SelectedIndex = Math.SimMath.GenerateRandomInteger(0, Tab_Interactions_Tabs_Update_Selector.Items.Count - 1);
            for (int i = 0; i < Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows.Count; i++)
            {
                Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows[i].Cells[0].Value = Math.SimMath.GenerateRandomBool();
            }
            Tab_Interactions_NextButton.PerformClick();
        }

        private void Tab_Parameters_InportCommonButton_Click(object sender, EventArgs e)
        {
            Tab_Parameters_ParamGrid.Rows.Clear();
            Tab_Parameters_ParamGrid.Rows.Add("MinimumNetForce", 0);
            Tab_Parameters_ParamGrid.Rows.Add("MinimumAcceleration", 0);
            Tab_Parameters_ParamGrid.Rows.Add("MinimumVelocity", 0);
            Tab_Parameters_ParamGrid.Rows.Add("MinimumPosition", 0);
            Tab_Parameters_ParamGrid.Rows.Add("MaximumNetForce", "Infinity");
            Tab_Parameters_ParamGrid.Rows.Add("MaximumAcceleration", "Infinity");
            Tab_Parameters_ParamGrid.Rows.Add("MaximumVelocity", "Infinity");
            Tab_Parameters_ParamGrid.Rows.Add("MaximumPosition", "Infinity");
            Tab_Parameters_ParamGrid.Rows.Add("GravitationalConstant", Physics.PhysicsConstants.GravitationalConstant);
            Tab_Parameters_ParamGrid.Rows.Add("MagneticPermeability", Physics.PhysicsConstants.MagneticPermeability);
            Tab_Parameters_ParamGrid.Rows.Add("ElectrostaticConstant", Physics.PhysicsConstants.ElectrostaticConstant);
        }

        private void Tab_Properties_NextButton_Click(object sender, EventArgs e)
        {
            Tabs.SelectedTab = Tab_ParticleSeed;
        }

        private int CountInteractionScripts()
        {
            int Count = 0;

            for (int i = 0; i < Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows.Count; i++)
            {
                if ((bool)Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows[i].Cells[0].Value == true) Count++;
            }

            return Count;
        }

        private string PrintInteractionScripts()
        {
            string PS = "";

            for (int i = 0; i < Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows.Count; i++)
            {
                if ((bool)Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows[i].Cells[0].Value == true) PS += Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows[i].Cells[1].Value.ToString() + Environment.NewLine;
            }

            return PS;
        }

        private void PrepareReview()
        {
            string NL = Environment.NewLine;
            Tab_Review_Review.Text = "";
            Tab_Review_Review.Text += "You are about to create a " + Tab_Dimensions_NumberDimensions.Value + "-dimensional universe ";
            if (Tab_UniverseProperties_Tabs_Size_SizeBar.Value == 1001)
            {
                Tab_Review_Review.Text += "of infinite size. ";
            }
            else
            {
                Tab_Review_Review.Text += "with a radius of " + Tab_UniverseProperties_Tabs_Size_SizeBar.Value + " units and a " + Tab_UniverseProperties_Tabs_Boundary_BoundarySelector.SelectedItem.ToString().ToLower() + " boundary. ";
            }
            Tab_Review_Review.Text += "This universe will utilize the \"" + Tab_Interactions_Tabs_Update_Selector.SelectedItem.ToString().ToLower() + "\" update script, which ";
            int ISCount = CountInteractionScripts();
            if (ISCount == 0)
            {
                Tab_Review_Review.Text += "will not rely on any interaction scripts. ";
            }
            else
            {
                Tab_Review_Review.Text += "in turn will have access to the following interaction scripts:" + NL + PrintInteractionScripts() + NL;
            }

            Tab_Review_Review.Text += "The simulation will also have " + (Tab_Parameters_ParamGrid.Rows.Count - 1) + " different parameters and particles will have a maximum of " + (Tab_Properties_PropGrid.Rows.Count - 1) + " different properties.";
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tabs.SelectedTab == Tab_Review)
            {
                try
                {
                    PrepareReview();
                }
                catch (Exception)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please make sure all required fields are specified before continuing to the review page.", "Unable to generate review!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tab_Review_Review.Text = "";
                    Tabs.SelectedTab = Tab_Start;
                }
            }
        }

        private List<int> GetSelectedInteractionIndicies()
        {
            List<int> Selected = new List<int>();

            for (int i = 0; i < Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows.Count; i++)
            {
                if ((bool)Tab_Interactions_Tabs_Interactions_ScriptSelector.Rows[i].Cells[0].Value == true) Selected.Add(i);
            }

            Selected.Capacity = Selected.Count;
            return Selected;
        }

        //private void Tab_Properties_ImportReqButton_Click(object sender, EventArgs e)
        //{
        //    Tab_Properties_PropGrid.Rows.Clear();
        //    List<string> Imported = new List<string>();
        //    List<int> SelectedIndicies = GetSelectedInteractionIndicies();
        //    for (int i = 0; i < SelectedIndicies.Count; i++)
        //    {
        //        if (this.LinkedMainForm.LoadedAssets.AvailableInteractionScripts[SelectedIndicies[i]].RequiredSimulationParameters == null) continue;
        //        foreach (string Param in this.LinkedMainForm.LoadedAssets.AvailableInteractionScripts[SelectedIndicies[i]].RequiredSimulationParameters)
        //        {
        //            if (Imported.Count == 0)
        //            {
        //                Imported.Add(Param.ToLower());
        //                Tab_Properties_PropGrid.Rows.Add(Param.ToLower(), "(-Infinity, Infinity)");
        //            }
        //            else
        //            {
        //                if (!Imported.Contains(Param.ToLower()))
        //                {
        //                    Imported.Add(Param.ToLower());
        //                    Tab_Properties_PropGrid.Rows.Add(Param.ToLower(), "(-Infinity, Infinity)");
        //                }
        //            }
        //        }
        //    }
        //}

        private void Tab_Start_RandomizeButton_Click(object sender, EventArgs e)
        {
            var Result = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to generate a completely random universe?", "Generate random universe?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                
            }
        }

        private void Tab_ParticleSeed_SeedScript_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Tab_ParticleSeed_ScriptDesc.Text = this.LinkedMainForm.LoadedAssets.AvailableParticleSeedScripts[Tab_ParticleSeed_SeedScript.SelectedIndex].Description;
        }

        private void Tab_ParticleSeed_NextButton_Click(object sender, EventArgs e)
        {
            /*if (Tab_ParticleSeed_SeedScript.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select a particle seed script before continuing.", "Woh there partner!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Tabs.SelectedTab = Tab_Advanced;
            }*/
        }

        private void Tab_ParticleSeed_ScriptDesc_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Interactions_Tabs_Interactions_ScriptSelector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
