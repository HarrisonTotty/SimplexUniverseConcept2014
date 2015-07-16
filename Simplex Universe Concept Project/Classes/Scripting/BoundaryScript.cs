using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Physics;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a universe boundary script for resolving the positions/properties of particles that have passed the edge of the universe.
    /// </summary>
    public abstract class BoundaryScript : SimplexScript
    {
        
        /// <summary>
        /// Resolves the properties of a particle that has passed the edge of the universe.
        /// </summary>
        /// <param name="Input">The particle to resolve</param>
        /// <param name="Boundary">The boundary of the universe that the particle has escaped.</param>
        public abstract Particle Resolve(Particle Input, UniverseBoundary Boundary);
    }
}
