using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// A specialized object for holding plotting information for a particular particle.
    /// </summary>
    public class PlotVector
    {

        /// <summary>
        /// Creates a new plot vector from a particular particle.
        /// </summary>
        /// <param name="SeedParticle">The particle to extract the data from</param>
        public PlotVector(Physics.Particle SeedParticle)
        {
            this.Position = SeedParticle.GetActualPosition();
            this.Radius = SeedParticle.Radius;

            int CurrentLayer = 0;
            Physics.Particle ParentParticle = SeedParticle.ParentParticle;
            while (ParentParticle != null)
            {
                CurrentLayer++;
                ParentParticle = ParentParticle.ParentParticle;
            }
            this.Layer = CurrentLayer;
        }

        /// <summary>
        /// Creates a new blank plot vector in a certain number of dimensions.
        /// </summary>
        public PlotVector(int NumberDimensions)
        {
            this.Position = new Vector(NumberDimensions);
            this.Radius = 0;
            this.Layer = 0;
        }

        /// <summary>
        /// The actual (global) position of this point.
        /// </summary>
        public Vector Position
        {
            get;
            set;
        }

        /// <summary>
        /// The radius of this point. 
        /// </summary>
        public double Radius
        {
            get;
            set;
        }

        /// <summary>
        /// The layer index (in terms of parent/sub particles) this plotting point exists in.
        /// </summary>
        public int Layer
        {
            get;
            set;
        }

        /// <summary>
        /// Extracts a pre-sorted plot vector list (by size from largest particle to smallest) from a list of 2D particles.
        /// NOTE: Only extracts the CURRENT LAYER and does not recurse to lower/higher (child/parent) layers of particles.
        /// </summary>
        /// <param name="ParticleList">The list of particles to pull the list from</param>
        public static List<PlotVector> ExtractSortedListFromParticleList_2D(List<Physics.Particle> ParticleList)
        {
            //Create a generic list to hold the results
            List<PlotVector> PlotList = new List<PlotVector>(ParticleList.Capacity);

            //Dump the current layer of particles into the list
            foreach (Physics.Particle P in ParticleList)
            {
                PlotList.Add(new PlotVector(P));
            }

            //Sort the list by size
            PlotList = PlotList.OrderByDescending(x => x.Radius).ToList();
            PlotList.Capacity = PlotList.Count;

            //Return the results
            return PlotList;
        }
    }
}
