using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Contains a bunch of pre-initialized static particle properties types commonly found in particles.
    /// </summary>
    public static class PhysicsParticleProperties
    {
        /// <summary>
        /// Represents "Mass" with acceptable values [0, Infinity)
        /// </summary>
        public static PropertyType Mass = new PropertyType("Mass", 0, double.PositiveInfinity, true, false);


        /// <summary>
        /// Represents "Charge" with acceptable values (-Infinity, Infinity)
        /// </summary>
        public static PropertyType Charge = new PropertyType("Charge", double.NegativeInfinity, double.PositiveInfinity, false, false);


        /// <summary>
        /// Represents "Spin" with acceptable values (-Infinity, Infinity)
        /// </summary>
        public static PropertyType Spin = new PropertyType("Spin", double.NegativeInfinity, double.PositiveInfinity, false, false);

        /// <summary>
        /// Represents "Magnetic Moment" with acceptable values (-Infinity, Infinity)
        /// </summary>
        public static PropertyType MagneticMoment = new PropertyType("Magnetic Moment", double.NegativeInfinity, double.PositiveInfinity, false, false);


        /// <summary>
        /// Represents "Parity" with acceptable values [-1, 1]
        /// </summary>
        public static PropertyType Parity = new PropertyType("Parity", -1, 1, true, true);
    }
}
