using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;


namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a series that acts as a point watcher.
    /// Stores the last few positions of a particle and draws a curved line connecting those positions to show the path a particle has taken.
    /// </summary>
    public class VG_PointWatchSeries : System.Windows.Forms.DataVisualization.Charting.Series
    {
        /// <summary>
        /// Private ID form of VG_HighDefinition (used to prevent us from dorking stuff up).
        /// </summary>
        private bool VG_HighDefinition_Field;


        /// <summary>
        /// Creates a new point watcher with a particular particle to watch and the number of previous positions to plot
        /// </summary>
        /// <param name="ParticleToWatch">The ID of the particle we want to watch</param>
        /// <param name="PositionHistoryCount">The number of previous positions to keep track of</param>
        public VG_PointWatchSeries(string ParticleToWatch, int PositionHistoryCount, string ChartAreaName)
        {
            //Setup generic System.Windows.Forms.DataVisualization.Charting.Series stuff
            this.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.None;
            this.MarkerBorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.MarkerColor = System.Drawing.SystemColors.MenuHighlight;
            this.Enabled = true;
            this.ChartArea = ChartAreaName;
            this.MarkerSize = 0;
            this.MarkerBorderWidth = 0;
            this.XAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Primary;
            this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            //Setup specific VG_PointWatchSeries stuff
            this.VG_HighDefinition_Field = false;
            this.VG_PWPositions = new List<Vector>(PositionHistoryCount);
            this.VG_WatchParticle = ParticleToWatch;
        }
    
        /// <summary>
        /// Represents a previous list of actual positions used to plot the curve.
        /// </summary>
        public List<Vector> VG_PWPositions
        {
            get;
            set;
        }


        /// <summary>
        /// Whether to render the path in high definition (by using a curved line instead of a straight line).
        /// </summary>
        public bool VG_HighDefinition
        {
            get
            {
                return this.VG_HighDefinition_Field;
            }
            set
            {
                if (value == false)
                {
                    this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                }
                else
                {
                    this.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                }
                this.VG_HighDefinition_Field = value;
            }
        }

        /// <summary>
        /// The ID of the particle we are watching
        /// </summary>
        public string VG_WatchParticle
        {
            get;
            set;
        }

        /// <summary>
        /// Checks the reference particle for any changes in position.
        /// Adds new positions to the list of positions if needed and deleting old ones when the list gets full.
        /// </summary>
        /// <param name="NewParticle">The particle to use for the update</param>
        public void VG_UpdatePointWatcher(Physics.Particle NewParticle)
        {
            //If the input particle is null, do nothing
            if (NewParticle == null) return;

            //If this is the first time we are checking a position, just add it
            if (this.VG_PWPositions.Count == 0)
            {
                this.VG_PWPositions.Add(NewParticle.GetActualPosition());
                return;
            }

            //Check the length of the position list and delete old positions
            if (this.VG_PWPositions.Count >= this.VG_PWPositions.Capacity)
            {
                //If the number of elements in the position list is greater than or equal to the maximum number, delete the first entry
                this.VG_PWPositions.RemoveAt(0);
            }

            //Check to see if the current position is different from the last recorded one
            Vector LastPosition = this.VG_PWPositions[this.VG_PWPositions.Count - 1];
            Vector NewPosition = NewParticle.GetActualPosition();
            if (Vector.Vector_Compare(LastPosition, NewPosition) == false)
            {
                //If the positions are different, add the new position
                this.VG_PWPositions.Add(NewPosition);
            }
        }
    }
}
