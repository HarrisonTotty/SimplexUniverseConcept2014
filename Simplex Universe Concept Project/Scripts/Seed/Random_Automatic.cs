﻿using System;
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
            this.Name = "Random Position with Automatic Properties";
            this.Description = "Randomizes the starting positions particles in a universe within the bounds of the universe and automatically initializes particle properties to double values within their minimum and maximum. Supports sub-particles.";
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
            if (Input.ParentParticle == null)
            {
                Input.Position = SimMath.RandomSphericalPosition(Input.Position.Capacity, UniverseRadius);
            }
            else
            {
                Input.Position = SimMath.RandomSphericalPosition(Input.Position.Capacity, Input.ParentParticle.Radius);
            }

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
