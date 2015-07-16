using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents the boundary options for a particular universe.
    /// </summary>
    public class UniverseBoundary
    {
        /// <summary>
        /// Creates a new set of universe boundaries with the default parameters.
        /// </summary>
        public UniverseBoundary()
        {
            this.Radius = double.PositiveInfinity;
            this.ResolveScript = null;
        }

        /// <summary>
        /// Creates a new set of universe boundaries with a specific size, and boundary type.
        /// </summary>
        public UniverseBoundary(double Radius, SimplexUniverse.Scripting.BoundaryScript ResolveScript)
        {
            this.Radius = Radius;
            this.ResolveScript = ResolveScript;
        }

        /// <summary>
        /// The script used to resolve boundary violations.
        /// </summary>
        public SimplexUniverse.Scripting.BoundaryScript ResolveScript
        {
            get;
            set;
        }

        /// <summary>
        /// The radius of the universe.
        /// </summary>
        public double Radius
        {
            get;
            set;
        }

        /// <summary>
        /// Checks to see if a particle is within bounds of the entire universe (uses absolute position of the particle and thus can also be used on sub-particles).
        /// If the universe boundary type is set to "Infinate", this will always return true
        /// </summary>
        /// <param name="InputParticle">The particle to check</param>
        public bool CheckInBounds(Particle InputParticle)
        {
            if (this.Radius == double.PositiveInfinity) return true;
            if (this.ResolveScript == null) return true;
            Vector realpos = InputParticle.GetActualPosition();
            return (realpos.Magnitude <= System.Math.Abs(this.Radius));
        }
    }
}
