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
using SimplexUniverse.VisualizationComponents;

namespace SimplexUniverse
{
    public partial class GridController : MetroForm
    {
        private VisualizationGrid GridLink;

        public GridController(VisualizationGrid GridLink)
        {
            InitializeComponent();
            this.GridLink = GridLink;
        }

        private void GridController_Load(object sender, EventArgs e)
        {
            UpdateControls();
            UpdateTimer.Start();
        }

        public void UpdateControls()
        {
            LabelGenerationCounter.Style = this.Style;
            LabelGenerationCounter.Theme = this.Theme;
            LabelHD.Style = this.Style;
            LabelHD.Theme = this.Theme;
            LabelPointMode.Style = this.Style;
            LabelPointMode.Theme = this.Theme;
            LabelPPT.Style = this.Style;
            LabelPPT.Theme = this.Theme;
            LabelPTF.Style = this.Style;
            LabelPTF.Theme = this.Theme;
            LabelPTL.Style = this.Style;
            LabelPTL.Theme = this.Theme;
            LabelX.Style = this.Style;
            LabelX.Theme = this.Theme;
            LabelY.Style = this.Style;
            LabelY.Theme = this.Theme;
            LabelZ.Style = this.Style;
            LabelZ.Theme = this.Theme;
            Label3DMode.Style = this.Style;
            Label3DMode.Theme = this.Theme;
            LCameraOr.Style = this.Style;
            LCameraOr.Theme = this.Theme;
            LCameraPos.Style = this.Style;
            LCameraPos.Theme = this.Theme;
            LCamOptions.Style = this.Style;
            LCamOptions.Theme = this.Theme;
            LFOV.Style = this.Style;
            LFOV.Theme = this.Theme;

            this.Toggle3D.Checked = this.GridLink.VG_3DMode;
            this.Toggle3D.Theme = this.Theme;
            this.Toggle3D.Style = this.Style;
            this.ToggleParticleTrails.Checked = this.GridLink.VG_PlotPointWatcherTrails;
            this.ToggleParticleTrails.Theme = this.Theme;
            this.ToggleParticleTrails.Style = this.Style;
            this.ToggleHighDefinition.Theme = this.Theme;
            this.ToggleHighDefinition.Style = this.Style;
            if (this.GridLink.Titles[0].Visible == true)
            {
                this.ToggleGenerationCounter.Checked = true;
            }
            else
            {
                this.ToggleGenerationCounter.Checked = false;
            }
            this.ToggleGenerationCounter.Theme = this.Theme;
            this.ToggleGenerationCounter.Style = this.Style;
            this.TogglePointMode.Checked = this.GridLink.VG_PrimarySeries.VG_PointMode;
            this.TogglePointMode.Theme = this.Theme;
            this.TogglePointMode.Style = this.Style;
            this.XAxisIndex.Value = this.GridLink.VG_XIndex;
            this.XAxisIndex.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.XAxisIndex.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.YAxisIndex.Value = this.GridLink.VG_YIndex;
            this.YAxisIndex.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.YAxisIndex.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.ZAxisIndex.Value = this.GridLink.VG_ZIndex;
            this.ZAxisIndex.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.ZAxisIndex.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.FOV.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.FOV.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.FOV.Value = (decimal)this.GridLink.VG_3DFOV;
            this.PosTB.Theme = this.Theme;
            this.PosTB.Style = this.Style;
            this.PosTB.Text = this.GridLink.VG_3DCameraPosition.ToString(Math.Enums.Vector_StringFormat.Bracket, "n");
            this.OrTB.Theme = this.Theme;
            this.OrTB.Style = this.Style;
            this.OrTB.Text = Vector.Vector_FromList(this.GridLink.VG_3DCameraOrientation.ToList<double>()).ToString(Math.Enums.Vector_StringFormat.Bracket, "n");
            this.PTF.Value = this.GridLink.VG_PointWatcherTrailFrequency;
            this.PTF.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.PTF.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            this.PTL.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.Theme);
            this.PTL.ForeColor = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.Theme);
            foreach (var S in this.GridLink.Series)
            {
                if (S is VG_PointWatchSeries)
                {
                    PTL.Value = (S as VG_PointWatchSeries).VG_PWPositions.Capacity;
                    break;
                }
            }
            this.Refresh();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimer.Stop();
            try { UpdateControls(); }
            catch (Exception) { }
            UpdateTimer.Start();
        }

        private void Toggle3D_CheckedChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_3DMode = this.Toggle3D.Checked;
        }

        private void TogglePointMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TogglePointMode.Checked)
            {
                this.GridLink.VG_PrimarySeries.VG_PointMode_ON();
            }
            else
            {
                this.GridLink.VG_PrimarySeries.VG_PointMode_OFF();
            }
        }

        private void ToggleParticleTrails_CheckedChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_PlotPointWatcherTrails = this.ToggleParticleTrails.Checked;
        }

        private void ToggleHighDefinition_CheckedChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_HighDefinition = this.ToggleHighDefinition.Checked;
        }

        private void ToggleGenerationCounter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.GridLink.Titles[0].Visible = this.ToggleGenerationCounter.Checked;
            }
            catch (Exception) { }
        }

        private void PTF_ValueChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_PointWatcherTrailFrequency = (int)PTF.Value;
        }

        private void PTL_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var S in this.GridLink.Series)
                {
                    if (S is VG_PointWatchSeries)
                    {
                        (S as VG_PointWatchSeries).VG_PWPositions = new List<Vector>((int)PTL.Value);
                    }
                }
            }
            catch (Exception) { }
        }

        private void XAxisIndex_ValueChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_XIndex = (int)XAxisIndex.Value;
        }

        private void YAxisIndex_ValueChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_YIndex = (int)YAxisIndex.Value;
        }

        private void ZAxisIndex_ValueChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_ZIndex = (int)ZAxisIndex.Value;
        }

        private void LabelPPT_Click(object sender, EventArgs e)
        {

        }

        private void FOV_ValueChanged(object sender, EventArgs e)
        {
            this.GridLink.VG_3DFOV = (double)this.FOV.Value;
        }
    }
}
