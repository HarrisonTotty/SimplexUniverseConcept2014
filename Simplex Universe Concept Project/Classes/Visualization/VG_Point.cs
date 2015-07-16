using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a visual point in a VisualizationGrid series.
    /// </summary>
    public class VG_Point : System.Windows.Forms.DataVisualization.Charting.DataPoint
    {
        /// <summary>
        /// Creates a new drawn point at the specified position with a pre-calculated marker size.
        /// </summary>
        /// <param name="EffectiveX">The x-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveY">The y-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveMarkerSize">The pre-calculated effective marker size in pixels</param>
        /// <param name="Enable3DStyle">Whether or not to enable 3D visual styling for each point</param>
        public VG_Point(double EffectiveX, double EffectiveY, int EffectiveMarkerSize, bool Enable3DStyle)
        {
            this.MarkerBorderColor = System.Drawing.Color.Black;
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            this.MarkerColor = System.Drawing.SystemColors.MenuHighlight;
            this.MarkerSize = EffectiveMarkerSize;

            if (Enable3DStyle)
            {
                //CHANGE ME BACK TO "this.MarkerBorderWidth = 1;"
                this.MarkerBorderWidth = 0;
            }
            else
            {
                this.MarkerBorderWidth = 0;
            }

            this.XValue = EffectiveX;
            this.YValues = new double[] { EffectiveY };
        }
    }
}
