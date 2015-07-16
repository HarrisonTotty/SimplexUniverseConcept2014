using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents a universe of unique particles and rules.
    /// </summary>
    [Serializable(), Description("Represents a universe of unique particles and rules")]
    public class Universe
    {
        /// <summary>
        /// Creates a new universe of a particular shape, size, boundary type, and number of dimensions.
        /// </summary>
        /// <param name="NumberDimensions">The maximum number of dimensions that this universe occupies</param>
        /// <param name="ResolveScript">The boundary resolve script attached to this universe</param>
        /// <param name="Radius">The radius (size) of this universe (if the boundary isn't infinate)</param>
        public Universe(int NumberDimensions, Scripting.BoundaryScript ResolveScript, double Radius)
        {
            this.Boundary = new UniverseBoundary(Radius, ResolveScript);
            this.NumberDimensions = NumberDimensions;
        }

        /// <summary>
        /// Creates a new infinate spherical universe of a particular number of dimensions.
        /// </summary>
        public Universe(int NumberDimensions)
        {
            this.Boundary = new UniverseBoundary(double.PositiveInfinity, null);
            this.NumberDimensions = NumberDimensions;
        }

        /// <summary>
        /// Creates a new blank universe with the default boundary and no set number of dimensions.
        /// </summary>
        public Universe()
        {
            this.Boundary = new UniverseBoundary();
            this.NumberDimensions = 0;
        }


        /// <summary>
        /// Represents the topmost "layer" of particles (which in turn would encompass all particles within the universe).
        /// </summary>
        public List<Particle> Particles
        {
            get;
            set;
        }

        /// <summary>
        /// Represents the boundaries (size) of this universe and the rules for particle interactions at the edge.
        /// </summary>
        public UniverseBoundary Boundary
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum number of dimensions that exist in this universe.
        /// </summary>
        public int NumberDimensions
        {
            get;
            set;
        }

        /// <summary>
        /// A list of all the available particle property types.
        /// </summary>
        public List<PropertyType> ParticlePropertyTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Resolves boundary issues for a particular particle (assumes the particle already violates the boundary).
        /// </summary>
        public Particle Boundary_Resolve(Particle InputParticle)
        {
            if (this.Boundary.ResolveScript == null) return InputParticle;
            return this.Boundary.ResolveScript.Resolve(InputParticle, this.Boundary);
        }

        /// <summary>
        /// Checks for boundary violations and automatically resolves them.
        /// NOTE: That this will only apply to the top level of particles.
        /// </summary>
        public void Boundary_CheckViolations()
        {
            List<Particle> PList = new List<Particle>(this.Particles.Count);
            foreach (Particle P in this.Particles)
            {
                if (!this.Boundary.CheckInBounds(P))
                {
                    PList.Add(this.Boundary_Resolve(P));
                }
                else
                {
                    PList.Add(P);
                }
            }
            this.Particles = PList;
        }
    }
}
