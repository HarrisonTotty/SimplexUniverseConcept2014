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
    /// Represents an interaction script for classical mechanical electrostatics
    /// This script returns the electrostatic force of the comparison particle on the input particle
    /// Optional Simulation Parameters: ElectrostaticConstant (Numerical), SofteningValue (Numerical), Precision (Numerical)
    /// </summary>
    public class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "Classical Electrostatics";
            this.Description = "An interaction script for classical mechanical electrostatics. This script returns the electrostatic force of the comparison particle on the input particle.";
            this.RequiredParticleProperties = new string[] { "Charge" };
        }

        public override dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulations.Simulation Sim)
        {
            //First we create a new force vector to store our result to
            Vector Force = new Vector(Input.NetForce.Capacity);

            //Make sure both our input and comparison particles have "charge"
            if (!Input.HasProperty("Charge") || !Comparison.HasProperty("Charge")) return Force;
            double InputCharge = Input.GetPropertyVal("Charge");
            double ComparisonCharge = Comparison.GetPropertyVal("Charge");
            if (InputCharge == 0 || ComparisonCharge == 0) return Force;

            //Now we calculate the actual distance between the particles (we will need this later)
            double ActualDistance = (Comparison.Position - Input.Position).Magnitude;
            if (ActualDistance == 0) return new Vector(Input.Acceleration.Count);

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

            //If the "SofteningValue" simulation parameter is available to us:
            double Denominator;
            if (Sim.Parameters.HasParam("SofteningValue"))
            {
                //Calculate the denominator of the equation
                double SofteningValue = Sim.Parameters.GetParam("SofteningValue");
                Denominator = System.Math.Pow(((ActualDistance * ActualDistance) + (SofteningValue * SofteningValue)), (3.0 / 2.0));
            }
            else //Otherwise:
            {
                //Calculate the denominator of the equation
                Denominator = System.Math.Pow((ActualDistance * ActualDistance), (3.0 / 2.0));
            }

            //Get all of our needed parts
            double ElectrostaticConstant;
            if (Sim.Parameters.HasParam("ElectrostaticConstant"))
            {
                ElectrostaticConstant = Sim.Parameters.GetParam("ElectrostaticConstant");
            }
            else
            {
                ElectrostaticConstant = PhysicsConstants.ElectrostaticConstant;
            }

            //For each dimension of movement/location:
            for (int i = 0; i < Force.Capacity; i++)
            {
                //Calculate the component distance of this dimension
                double ComponentDistance = Input.Position[i] - Comparison.Position[i];
                                                             
                //Calculate the new force
                Force[i] = ElectrostaticConstant * (InputCharge * ComparisonCharge * ComponentDistance) / Denominator;
            }

            //Return the new net force
            return Force;
        }
    }
}

