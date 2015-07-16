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

namespace SimplexUniverse
{
    public partial class ObjectTable : MetroForm
    {
        public MainForm LinkedForm;

        public ObjectTable(MainForm LinkedForm)
        {
            InitializeComponent();
            this.LinkedForm = LinkedForm;
        }

        private void ObjectTable_Load(object sender, EventArgs e)
        {
            UpdateTable();
            ObjectGrid.Theme = this.Theme;
            ObjectGrid.Style = this.Style;
            UpdateTimer.Start();
        }

        private void UpdateTable()
        {
            lock (Simplex.ObjectRegistry)
            {
                try
                {
                    //Clear the table
                    ObjectGrid.Rows.Clear();

                    //For each object in the registry:
                    List<string> IDs = Simplex.ObjectRegistry.Keys.ToList<string>();
                    IDs.Sort();
                    foreach (string ID in IDs)
                    {
                        var Item = Simplex.ObjectRegistry[ID];
                        ObjectGrid.Rows.Add(ID, Item.GetType().Name, Item.Name, Item.Description);
                    }
                }
                catch (Exception) { }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            try { if (this.LinkedForm.CurrentSimulation.Running) UpdateTable(); }
            catch (Exception) { }
            UpdateTimer.Start();
        }
    }
}
