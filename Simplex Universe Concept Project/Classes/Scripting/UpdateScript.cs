using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.Simulations;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a script used to update a simulation by one generation.
    /// </summary>
    public abstract class UpdateScript : SimplexScript
    {

        /// <summary>
        /// Updates a simulation over a single generation
        /// </summary>
        /// <param name="Sim">The link to the simulation data</param>
        public abstract void Update(Simulations.Simulation Sim);
    }
}
