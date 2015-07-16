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
    /// Represents a basic particle update script
    /// This script requires that all particles have a numerical property called "mass" and supports "MinimumNetForce", "MinimumVelocity", "MinimumAcceleration", "MinimumPosition", "MaximumNetForce", "MaximumPosition", "MaximumVelocity" and "MaximumAcceleration" as simulation parameters (not required)
    /// </summary>
    public class Script : UpdateScript
    {

        public Script()
        {
            this.Name = "Basic";
            this.Description = "A basic particle update script that uses a O(n^2) algorithm for interaction calculation. This script requires that all particles have a numerical property called \"mass\" and supports \"MinimumNetForce\", \"MinimumVelocity\", \"MinimumAcceleration\", \"MinimumPosition\", \"MaximumNetForce\", \"MaximumPosition\", \"MaximumVelocity\" and \"MaximumAcceleration\" as simulation parameters (not required).";
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
            if (ForceInteractions.Count == 0 && PostForceInteractions.Count == 0) return Input;

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

            //If we have a simulation parameter called "MaximumNetForce":
            if (Sim.Parameters.HasParam("MaximumNetForce"))
            {
                //Limit the net force by this value
                double MaximumNetForce = Sim.Parameters.GetParam("MaximumNetForce");
                if (ReturnParticle.NetForce.Magnitude > MaximumNetForce) ReturnParticle.NetForce.Magnitude = MaximumNetForce;
            }

            //If we have a simulation parameter called "MinimumNetForce":
            if (Sim.Parameters.HasParam("MinimumNetForce"))
            {
                //Limit the net force by this value
                double MinimumNetForce = Sim.Parameters.GetParam("MinimumNetForce");
                if (ReturnParticle.NetForce.Magnitude < MinimumNetForce) ReturnParticle.NetForce.Magnitude = MinimumNetForce;
            }

            //Now lets calculate the acceleration of the particle by dividing the net force by the mass of the particle
            ReturnParticle.Acceleration = ReturnParticle.NetForce / ReturnParticle.GetPropertyVal("Mass");

            //If we have a simulation parameter called "MaximumAcceleration":
            if (Sim.Parameters.HasParam("MaximumAcceleration"))
            {
                //Limit the acceleration by this value
                double MaximumAcceleration = Sim.Parameters.GetParam("MaximumAcceleration");
                if (ReturnParticle.Acceleration.Magnitude > MaximumAcceleration) ReturnParticle.Acceleration.Magnitude = MaximumAcceleration;
            }

            //If we have a simulation parameter called "MinimumAcceleration":
            if (Sim.Parameters.HasParam("MinimumAcceleration"))
            {
                //Limit the acceleration by this value
                double MinimumAcceleration = Sim.Parameters.GetParam("MinimumAcceleration");
                if (ReturnParticle.Acceleration.Magnitude < MinimumAcceleration) ReturnParticle.Acceleration.Magnitude = MinimumAcceleration;
            }

            //Now we need to calculate velocity
            ReturnParticle.Velocity += ReturnParticle.Acceleration;

            //If we have a simulation parameter called "MaximumVelocity":
            if (Sim.Parameters.HasParam("MaximumVelocity"))
            {
                //Limit the velocity by this value
                double MaxVelocity = Sim.Parameters.GetParam("MaximumVelocity");
                if (ReturnParticle.Velocity.Magnitude > MaxVelocity) ReturnParticle.Velocity.Magnitude = MaxVelocity;
            }

            //If we have a simulation parameter called "MinimumVelocity":
            if (Sim.Parameters.HasParam("MinimumVelocity"))
            {
                //Limit the velocity by this value
                double MinimumVelocity = Sim.Parameters.GetParam("MinimumVelocity");
                if (ReturnParticle.Velocity.Magnitude < MinimumVelocity) ReturnParticle.Velocity.Magnitude = MinimumVelocity;
            }

            //Now we calculate position and we're done
            ReturnParticle.Position += ReturnParticle.Velocity;

            //If we have a simulation parameter called "MaximumPosition":
            if (Sim.Parameters.HasParam("MaximumPosition"))
            {
                //Limit the position by this value
                double MaxPosition = Sim.Parameters.GetParam("MaximumPosition");
                if (ReturnParticle.Position.Magnitude > MaxPosition) ReturnParticle.Position.Magnitude = MaxPosition;
            }

            //If we have a simulation parameter called "MinimumPosition":
            if (Sim.Parameters.HasParam("MinimumPosition"))
            {
                //Limit the position by this value
                double MinimumPosition = Sim.Parameters.GetParam("MinimumPosition");
                if (ReturnParticle.Position.Magnitude < MinimumPosition) ReturnParticle.Position.Magnitude = MinimumPosition;
            }

            //Return the updated particle
            return ReturnParticle;
        }

    }
}
