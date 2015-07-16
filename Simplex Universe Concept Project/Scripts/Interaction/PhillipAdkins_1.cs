using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.Simulations;

namespace SimplexUniverse.Scripting
{
    public class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "G+ Phillip Adkins 1";
            this.Description = "-m1 * m2 / (r^2 + r^-2)";
            this.RequiredParticleProperties = new string[] { "Mass" };
        }

        public override dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulation Sim)
        {
            //First we create a new force vector to store our result to
            Vector Force = new Vector(Input.NetForce.Capacity);

            //Make sure both our input and comparison particles have "mass"
            if (!Input.HasProperty("Mass") || !Comparison.HasProperty("Mass")) return Force;

            //Now we calculate the actual distance between the particles (we will need this later)
            double ActualDistance = (Comparison.Position - Input.Position).Magnitude;
            if (ActualDistance == 0) return new Vector(Input.Acceleration.Count);

            //If the "Precision" simulation parameter is available to us:
            if (Sim.Parameters.HasParam("Precision"))
            {
                //Check to see if the actual distance is under the precision value
                if ((ActualDistance - Input.Radius - Comparison.Radius) <= Sim.Parameters.GetParam("Precision"))
                {
                    //Return no change in acceleration
                    return new Vector(Input.Acceleration.Count);
                }
            }
            else //Otherwise:
            {
                //Assume a precision of zero
                if ((ActualDistance - Input.Radius - Comparison.Radius) <= 0)
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
                double rneg = System.Math.Pow(ActualDistance, -2.0);
                Denominator = System.Math.Pow(((ActualDistance * ActualDistance) + (SofteningValue * SofteningValue) + rneg), (3.0 / 2.0));
            }
            else //Otherwise:
            {
                //Calculate the denominator of the equation
                double rneg = System.Math.Pow(ActualDistance, -2.0);
                Denominator = System.Math.Pow(((ActualDistance * ActualDistance) + rneg), (3.0 / 2.0));
            }

            //Get all of our needed parts
            double InputMass = Input.GetPropertyVal("Mass");
            double ComparisonMass = Comparison.GetPropertyVal("Mass");
            double k;
            if (Sim.Parameters.HasParam("k"))
            {
                k = Sim.Parameters.GetParam("k");
            }
            else
            {
                k = 1;
            }

            //For each dimension of movement/location:
            for (int i = 0; i < Force.Capacity; i++)
            {
                //Calculate the component distance of this dimension
                double ComponentDistance = Comparison.Position[i] - Input.Position[i];

                //Calculate the new force
                Force[i] = k * (-InputMass * ComparisonMass * ComponentDistance) / Denominator;
            }

            //Return the new net force
            return Force;
        }
    }
}
