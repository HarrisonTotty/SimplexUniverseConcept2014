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
using SimplexUniverse.Simulations;

namespace SimplexUniverse
{
    public partial class BufferViewer : MetroForm
    {
        /// <summary>
        /// The (TEMPORARY) buffered simulation object
        /// </summary>
        public SimpleBufferedSimulation BSim;

        public BufferViewer(SimpleBufferedSimulation BSim)
        {
            InitializeComponent();
            this.BSim = BSim;
        }

        private void BufferViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
