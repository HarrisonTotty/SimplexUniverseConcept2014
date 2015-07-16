using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a scatter series for a visualization grid
    /// </summary>
    public class VG_Series : System.Windows.Forms.DataVisualization.Charting.Series
    {

        /// <summary>
        /// Creates a new series to hold data points.
        /// </summary>
        public VG_Series()
        {
            this.Name = "PrimarySeries";
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            this.MarkerBorderColor = System.Drawing.Color.Black;
            this.MarkerColor = System.Drawing.SystemColors.MenuHighlight;
            this.Enabled = true;
            this.MarkerBorderWidth = 0;
            this.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        /// <summary>
        /// Represents whether point mode is enabled. Please only set this through one of the corresponding methods.
        /// </summary>
        public bool VG_PointMode
        {
            get;
            set;
        }

        /// <summary>
        /// Stylizes the series to plot points without sizes (faster plotting).
        /// </summary>
        public void VG_PointMode_ON()
        {
            this.MarkerSize = 5;
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            this.VG_PointMode = true;
        }

        /// <summary>
        /// Stylizes the series to plot points with sizes (default).
        /// </summary>
        public void VG_PointMode_OFF()
        {
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            this.VG_PointMode = false;
        }

        /// <summary>
        /// Stylizes the series to handle 2D points.
        /// </summary>
        public void VG_SetStyle_2D()
        {
            this.BorderWidth = 0;
        }

        /// <summary>
        /// Stylizes the series to handle 3D points.
        /// </summary>
        public void VG_SetStyle_3D()
        {
            this.BorderWidth = 1;
        }
    }
}
