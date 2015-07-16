using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Simulations;
using SimplexUniverse.Physics;
using SimplexUniverse.Math;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a script that controls the starting positions and properties of particles and other objects in the universe
    /// </summary>
    public abstract class SeedScript : SimplexScript
    {
        /// <summary>
        /// Modifies the positions of particles and other properties of an input universe
        /// </summary>
        /// <param name="Input">The universe to modify</param>
        public abstract void Seed(Simulation Input);
    }
}
