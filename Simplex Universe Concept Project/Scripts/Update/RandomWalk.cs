using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.Simulations;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a random walk
    /// </summary>
    public class Script : UpdateScript
    {

        public Script()
        {
            this.Name = "Random Walk";
            this.Description = "This script simply causes all particles to perfrom a random walk and does not support interaction scripts but does support \"MinimumDistance\" and \"MaximumDistance\" as simulation parameters.";
        }


        /// <summary>
        /// Updates a simulation over a single generation
        /// </summary>
        /// <param name="Sim">The link to the simulation data</param>
        public override void Update(Simulations.Simulation Sim)
        {
            //Create a new temporary list
            List<Particle> NewList = new List<Particle>(Sim.SimUniverse.Particles.Count);

            //For each particle:
            Parallel.For(0, Sim.SimUniverse.Particles.Count, i =>
            {
                //Create a new temporary particle with the same properties of the old one
                Particle NewParticle = Particle.Copy_Shallow(Sim.SimUniverse.Particles[i], true);

                //Get simulation parameters
                double MinDistance;
                if (Sim.Parameters.HasParam("MinimumDistance"))
                {
                    MinDistance = Sim.Parameters.GetParam("MinimumDistance");
                }
                else
                {
                    MinDistance = 0;
                }

                double MaxDistance;
                if (Sim.Parameters.HasParam("MaximumDistance"))
                {
                    MaxDistance = Sim.Parameters.GetParam("MaximumDistance");
                }
                else
                {
                    MaxDistance = 5;
                }

                //Update the new particle
                NewParticle.Position = SimMath.RandomWalk(NewParticle.Position, MinDistance, MaxDistance);

                //Add the updated particle to the new list
                lock (NewList)
                {
                    NewList.Add(NewParticle);
                }
            });

            //Save the temporary list to the new one
            Sim.SimUniverse.Particles = NewList;
        }
    }
}
