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
    /// Represents an interaction script for a weird custom take on gravity (ish?)
    /// This script returns the force of gravity of the comparison particle on the input particle
    /// Optional Simulation Parameters: GravitationalConstant (Numerical), SofteningValue (Numerical), Precision (Numerical)
    /// </summary>
    public class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "Fake Gravity";
            this.Description = "An interaction script for a weird custom take on gravity (ish?)";
            this.RequiredParticleProperties = new string[] { "Mass", "Charge" };
        }

        public override dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulations.Simulation Sim)
        {
            //First we create a new force vector to store our result to
            Vector Force = new Vector(Input.NetForce.Capacity);

            //Make sure both our input and comparison particles have "mass"
            if (!Input.HasProperty("Mass") || !Comparison.HasProperty("Mass")) return Force;

            //Now we calculate the actual distance between the particles (we will need this later)
            double ActualDistance = (Comparison.Position - Input.Position).Magnitude;
            Vector Dir = (Input.Position - Comparison.Position).Direction;

            //If the "Precision" simulation parameter is available to us:
            if (Sim.Parameters.HasParam("Precision"))
            {
                //Check to see if the actual distance is under the precision value
                if ((System.Math.Abs(ActualDistance) - Input.Radius - Comparison.Radius) <= Sim.Parameters.GetParam("Precision"))
                {
                    //Return no change in acceleration
                    return new Vector(Input.Acceleration.Count);
                }
            }
            else //Otherwise:
            {
                //Assume a precision of zero
                if ((System.Math.Abs(ActualDistance) - Input.Radius - Comparison.Radius) <= 0)
                {
                    //Return no change in acceleration
                    return new Vector(Input.Acceleration.Count);
                }
            }

            //Get all of our needed parts
            double InputMass = Input.GetPropertyVal("Mass");
            double ComparisonMass = Comparison.GetPropertyVal("Mass");
            double GravitationalConstant;
            if (Sim.Parameters.HasParam("GravitationalConstant"))
            {
                GravitationalConstant = Sim.Parameters.GetParam("GravitationalConstant");
            }
            else
            {
                GravitationalConstant = PhysicsConstants.GravitationalConstant;
            }

            Force = GravitationalConstant * InputMass * ComparisonMass / ActualDistance * Dir;

            //Return the new net force
            return Force;
        }
    }
}
