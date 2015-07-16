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
    /// Represents an interaction script for another fake force I created (again)
    /// This script returns the force of gravity of the comparison particle on the input particle
    /// Optional Simulation Parameters: SofteningValue (Numerical), Precision (Numerical)
    /// </summary>
    public class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "Flipper (Fake)";
            this.Description = "An interaction script for another fake force I created (again).";
            this.RequiredParticleProperties = new string[] { "Mass" };
        }

        public override dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulation Sim)
        {
            //First we create a new force vector to store our result to
            Vector Force = Vector.Vector_Copy(Comparison.Position);
            Force.Magnitude = Vector.Vector_Dot(Input.Position, Comparison.Position) * Comparison.Position.Magnitude / 2;

            //Return the new net force
            return Force;
        }
    }
}
