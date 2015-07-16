using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a chart area specifically modified for use with a VisualizationGrid.
    /// </summary>
    public class VG_ChartArea : System.Windows.Forms.DataVisualization.Charting.ChartArea
    {
        /// <summary>
        /// Creates a new chart area pre-formatted to support 2D rendering.
        /// </summary>
        public VG_ChartArea()
        {
            this.Name = "PrimaryChartArea";
            this.AxisX.IsLogarithmic = false;
            this.AxisY.IsLogarithmic = false;
            this.AxisX.IsStartedFromZero = false;
            this.AxisY.IsStartedFromZero = false;
            this.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisX.LabelStyle.Format = "n4";
            this.AxisY.LabelStyle.Format = "n4";
            this.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            this.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            VG_SetStyle_2D();
        }

        /// <summary>
        /// Sets the current appearence of the grid to suit 2D rendering.
        /// </summary>
        public void VG_SetStyle_2D()
        {
            this.AxisX.Title = "X Component";
            this.AxisY.Title = "Y Component";
            this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisX.LabelStyle.Enabled = false;
            this.AxisY.LabelStyle.Enabled = false;
            this.AxisX.IsMarginVisible = false;
            this.AxisY.IsMarginVisible = false;
            this.AxisX.MajorGrid.Enabled = false;
            this.AxisX.MinorGrid.Enabled = false;
            this.AxisX.MajorTickMark.Enabled = false;
            this.AxisX.MinorTickMark.Enabled = false;
            this.AxisY.MajorGrid.Enabled = false;
            this.AxisY.MinorGrid.Enabled = false;
            this.AxisX.MajorGrid.Interval = 10;
            this.AxisY.MajorGrid.Interval = 10;
            this.AxisY.MajorTickMark.Enabled = false;
            this.AxisY.MinorTickMark.Enabled = false;
            this.AxisX.Maximum = 100;
            this.AxisX.Minimum = -100;
            this.AxisY.Maximum = 100;
            this.AxisY.Minimum = -100;
        }

        /// <summary>
        /// Sets the current appearence of the grid to suit 3D rendering by removing all axis labels and gridlines.
        /// The grid's axis values will also be set to (-100 -> 100).
        /// </summary>
        public void VG_SetStyle_3D()
        {
            this.AxisX.Title = "";
            this.AxisY.Title = "";
            this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            this.AxisX.LabelStyle.Enabled = false;
            this.AxisY.LabelStyle.Enabled = false;
            this.AxisX.IsMarginVisible = false;
            this.AxisY.IsMarginVisible = false;
            this.AxisX.MajorGrid.Enabled = false;
            this.AxisX.MinorGrid.Enabled = false;
            this.AxisX.MajorTickMark.Enabled = false;
            this.AxisX.MinorTickMark.Enabled = false;
            this.AxisY.MajorGrid.Enabled = false;
            this.AxisY.MinorGrid.Enabled = false;
            this.AxisY.MajorTickMark.Enabled = false;
            this.AxisY.MinorTickMark.Enabled = false;
            this.AxisX.Maximum = 1;
            this.AxisX.Minimum = -1;
            this.AxisY.Maximum = 1;
            this.AxisY.Minimum = -1;
            this.AxisX2.Minimum = -1;
            this.AxisY2.Minimum = -1;
            this.AxisX2.Maximum = 1;
            this.AxisY2.Maximum = 1;
            this.AxisX.MajorGrid.Interval = 0;
            this.AxisY.MajorGrid.Interval = 0;
        }

        /// <summary>
        /// Toggles the grid lines on and off.
        /// </summary>
        public void VG_ToggleGrid()
        {
            this.AxisX.MajorGrid.Enabled = !this.AxisX.MajorGrid.Enabled;
            this.AxisY.MajorGrid.Enabled = !this.AxisY.MajorGrid.Enabled;
            this.AxisX.MajorTickMark.Enabled = !this.AxisX.MajorTickMark.Enabled;
            this.AxisY.MajorTickMark.Enabled = !this.AxisY.MajorTickMark.Enabled;
        }

        /// <summary>
        /// Toggles the axes on and off
        /// </summary>
        public void VG_ToggleAxis()
        {
            this.AxisX.LabelStyle.Enabled = !this.AxisX.LabelStyle.Enabled;
            this.AxisY.LabelStyle.Enabled = !this.AxisY.LabelStyle.Enabled;


            if (this.AxisX.Enabled == System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False)
            {
                this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            }
            else
            {
                this.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            }

            if (this.AxisY.Enabled == System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False)
            {
                this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            }
            else
            {
                this.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            }
        }
    }
}
