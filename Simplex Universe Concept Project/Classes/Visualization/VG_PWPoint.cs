using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a plotted point watcher point
    /// </summary>
    public class VG_PWPoint : System.Windows.Forms.DataVisualization.Charting.DataPoint
    {
        /// <summary>
        /// Creates a new point watcher point at a specified position.
        /// </summary>
        /// <param name="EffectiveX">The x-coordinate of the point cast in 2D coordinates</param>
        /// <param name="EffectiveY">The y-coordinate of the point cast in 2D coordinates</param>
        public VG_PWPoint(double EffectiveX, double EffectiveY)
        {
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.None;
            this.MarkerColor = System.Drawing.SystemColors.MenuHighlight;
            this.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.MarkerSize = 0;
            this.XValue = EffectiveX;
            this.YValues = new double[] { EffectiveY };
        }
    }
}
