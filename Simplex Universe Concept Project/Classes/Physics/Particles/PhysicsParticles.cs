using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Contains static methods for initializing common physics particles and particle properties
    /// </summary>
    public static class PhysicsParticles
    {
        /// <summary>
        /// Creates an antiproton of a particular number of dimensions
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this antiproton exists in</param>
        public static Particle Antiproton(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 8.775E-16;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.ProtonMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, -PhysicsConstants.ElementaryCharge);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.MagneticMoment, 1.410606743E-26);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates a proton of a particular number of dimensions
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this proton exists in</param>
        public static Particle Proton(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 8.775E-16;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.ProtonMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, PhysicsConstants.ElementaryCharge);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.MagneticMoment, 1.410606743E-26);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates an antineutron of a particular number of dimensions
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this antineutron exists in</param>
        public static Particle Antineutron(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 0.8E-15;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.NeutronMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, 0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.MagneticMoment, 0.96623647E-26);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates a neutron of a particular number of dimensions
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this neutron exists in</param>
        public static Particle Neutron(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 0.8E-15;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.NeutronMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, 0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.MagneticMoment, -0.96623647E-26);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates an electron of a particular number of dimensions
        /// NOTE that this assumes a classical radius of 2.8179E-15 m
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this electron exists in</param>
        public static Particle Electron(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 2.8179E-15;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.ElectronMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, -PhysicsConstants.ElementaryCharge);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.MagneticMoment, 9.284764E-24);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates an positron of a particular number of dimensions
        /// NOTE that this assumes a classical radius of 2.8179E-15 m
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this positron exists in</param>
        public static Particle Positron(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 2.8179E-15;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, PhysicsConstants.ElectronMass);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, PhysicsConstants.ElementaryCharge);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1.0 / 2.0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, 1);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates a photon of a particular number of dimensions
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this photon exists in</param>
        public static Particle Photon(int NumberDimensions)
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(NumberDimensions);

            //Setup the particle
            ReturnParticle.Radius = 0;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, 0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, 0);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Spin, 1);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Parity, -1);

            //Return the newly created particle
            return ReturnParticle;
        }


        /// <summary>
        /// Creates a particle representing the planet Earth in 3 dimensions
        /// </summary>
        public static Particle Earth()
        {
            //Initialize a return particle
            Particle ReturnParticle = new Particle(3);

            //Setup the particle
            ReturnParticle.Radius = 6.371E6;
            ReturnParticle.AddProperty(PhysicsParticleProperties.Mass, 5.97219E24);
            ReturnParticle.AddProperty(PhysicsParticleProperties.Charge, 0);

            //Return the newly created particle
            return ReturnParticle;
        }
    }
}
