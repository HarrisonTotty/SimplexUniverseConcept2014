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
    class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "Semi-Random Force";
            this.Description = "This is a force script that I wrote that kindof acts like gravity but with a random base force between objects divided by the distance.";
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

            //Assume a precision of zero
            if ((ActualDistance - Input.Radius - Comparison.Radius) <= 0)
            {
                //Return no change in acceleration
                return new Vector(Input.Acceleration.Count);
            }

            //If the "SofteningValue" simulation parameter is available to us:
            double Denominator = System.Math.Pow((ActualDistance * ActualDistance), (3.0 / 2.0));

            //Get all of our needed parts
            double InputMass = Input.GetPropertyVal("Mass");
            double ComparisonMass = Comparison.GetPropertyVal("Mass");

            //For each dimension of movement/location:
            for (int i = 0; i < Force.Capacity; i++)
            {
                //Calculate the component distance of this dimension
                double ComponentDistance = Comparison.Position[i] - Input.Position[i];

                //Calculate the new force
                Force[i] = (SimMath.GenerateRandomDouble(-ComparisonMass, ComparisonMass) * ComponentDistance) / Denominator;
            }

            //Return the new net force
            return Force;
        }
    }
}
