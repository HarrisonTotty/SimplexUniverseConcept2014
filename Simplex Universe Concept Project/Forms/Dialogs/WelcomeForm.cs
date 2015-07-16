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
    public partial class WelcomeForm : MetroForm
    {
        public MainForm LinkedForm;

        public WelcomeForm(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedForm = LinkedForm;
        }

        private void StartWizard_Load(object sender, EventArgs e)
        {

        }

        private void CreateNewUniverseButton_Click(object sender, EventArgs e)
        {
            LinkedForm.Show_NewSimulationWizard();
            this.Close();
        }

        private void LoadPreviousUniverseButton_Click(object sender, EventArgs e)
        {

        }
    }
}
