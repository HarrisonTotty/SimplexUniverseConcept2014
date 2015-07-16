using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Physics;
using SimplexUniverse.Math;
using SimplexUniverse.Simulations;

namespace SimplexUniverse.Scripting
{
    public class Script : SeedScript
    {
        public Script()
        {
            this.Name = "Big Bang";
            this.Description = @"All particles start at the origin with random velocities between 1 and 2 Units/Generation. Particle properties are automatically intialized to double values between the minimum and maximum values allowed. Supports sub-particles.";
        }

        public override void Seed(Simulation Input)
        {
            //Make sure we have somthing to work with
            if (Input.SimUniverse == null) return;
            if (Input.SimUniverse.Particles == null) return;
            if (Input.SimUniverse.Particles.Count == 0) return;

            foreach (Particle P in Input.SimUniverse.Particles)
            {
                SeedParticle(P, Input.SimUniverse.Boundary.Radius);
            }
        }

        /// <summary>
        /// Recusively seeds an input particle (seeds all children as well)
        /// </summary>
        /// <param name="Input">The particle to seed</param>
        private static void SeedParticle(Particle Input, double UniverseRadius)
        {
            Input.Position = new Vector(Input.Position.Capacity);

            Input.Velocity = SimMath.RandomVector(Input.Velocity.Capacity, 1, 2);

            if (Input.SubParticles != null)
            {
                if (Input.SubParticles.Count != 0)
                {
                    foreach (Particle P in Input.SubParticles)
                    {
                        SeedParticle(P, UniverseRadius);
                    }
                }
            }

            if (Input.Properties != null)
            {
                if (Input.Properties.Count != 0)
                {
                    foreach (ParticleProperty P in Input.Properties)
                    {
                        P.Value = SimMath.GenerateRandomDouble(P.Type.AcceptedValues.MinimumValue, P.Type.AcceptedValues.MaximumValue);
                    }
                }
            }
        }
    }
}
