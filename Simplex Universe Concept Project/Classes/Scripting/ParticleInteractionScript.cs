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
    /// Represents a particular type of interaction between particles (For example, the gravitational force between two particles)
    /// </summary>
    public abstract class ParticleInteractionScript : InteractionScript
    {

        /// <summary>
        /// A list of particle property names that a comparison particle must have in order to be considered for this interaction (such as "mass")
        /// </summary>
        public string[] RequiredParticleProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Calculates the interaction between two particles, returning 
        /// </summary>
        /// <param name="Input">The particle to update</param>
        /// <param name="Comparison">The particle to compare this particle to</param>
        /// <param name="SimParams">The list of simulation parameters</param>
        /// <param name="Interactions">The list of available interaction scripts</param>
        /// <param name="Cosmos">The universe of available particles</param>
        public abstract dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulations.Simulation Sim);
    }
}
