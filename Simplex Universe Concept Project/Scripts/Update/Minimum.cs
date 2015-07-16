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
    /// Represents the minimum construction of a update script.
    /// This script requires that all particles have a numerical property called "mass" but does not implement any simulation parameters
    /// </summary>
    public class Script : UpdateScript
    {

        public Script()
        {
            this.Name = "Minimum";
            this.Description = "The minimum construction of an update script that uses a O(n^2) algorithm for interaction calculation. This script requires that all particles have a numerical property called \"mass\" but does not implement any simulation parameters.";
            this.RequiredSimulationParameters = new string[] { "mass" };
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

                //Update the new particle
                NewParticle = UpdateParticle(NewParticle, Sim);

                //Add the updated particle to the new list
                lock (NewList)
                {
                    NewList.Add(NewParticle);
                }
            });

            //Save the temporary list to the new one
            Sim.SimUniverse.Particles = NewList;
        }


        /// <summary>
        /// Returns a copy of an input particle updated against all particles under the same parent
        /// </summary>
        /// <param name="Input">The particle to update</param>
        /// <param name="Sim">The simulation object</param>
        public static Particle UpdateParticle(Particle Input, Simulations.Simulation Sim)
        {
            //Extract all scripts that have the "Force" tag
            InteractionScripts ForceInteractions = Sim.Interactions.ExtractByTag("Force");

            //Extract all scripts that have the "PostForceInteraction" tag
            InteractionScripts PostForceInteractions = Sim.Interactions.ExtractByTag("PostForceInteraction");

            //Complain if we dont have any interaction types
            if (ForceInteractions == null && PostForceInteractions == null) return Input;

            //Create a copy of the input particle that we can return without modifying the origional
            Particle ReturnParticle = Particle.Copy_Shallow(Input, true);

            //Zero-out the net force and acceleration of the particle we are returning
            ReturnParticle.Acceleration = new Vector(Input.Acceleration.Capacity);
            ReturnParticle.NetForce = new Vector(Input.NetForce.Capacity);

            //Calculate force interactions
            if (ForceInteractions != null)
            {
                //For each possible comparison particle:
                foreach (Particle Comparison in Sim.SimUniverse.Particles)
                {
                    //Make sure they aren't the same particle
                    if (ReturnParticle.ID == Comparison.ID) continue;

                    //Calculate the net force of that particle on our return particle
                    foreach (ParticleInteractionScript ForceInteraction in ForceInteractions)
                    {
                        ReturnParticle.NetForce += ForceInteraction.CalculateInteraction(ReturnParticle, Comparison, Sim);
                    }
                }
            }

            //Calculate post force interactions
            if (PostForceInteractions != null)
            {
                foreach (ParticleInteractionScript PostForceInteraction in PostForceInteractions)
                {
                    ReturnParticle.NetForce += PostForceInteraction.CalculateInteraction(ReturnParticle, null, Sim);
                }
            }

            //Here we multiply by 0.0001 to account for the max timer speed
            ReturnParticle.NetForce *= 0.0001;

            //Now lets calculate the acceleration of the particle by dividing the net force by the mass of the particle
            ReturnParticle.Acceleration = ReturnParticle.NetForce / ReturnParticle.GetPropertyVal("Mass");

            //Now we need to calculate velocity
            ReturnParticle.Velocity += ReturnParticle.Acceleration;

            //Now we calculate position and we're done
            ReturnParticle.Position += ReturnParticle.Velocity;

            //Return the updated particle
            return ReturnParticle;
        }
    }
}
