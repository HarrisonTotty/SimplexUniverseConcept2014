using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// A class containing known physics constants and values.
    /// </summary>
    public static class PhysicsConstants
    {
        /// <summary>
        /// The classical mechanical value of the smallest unit of charge in Coulombs (magnitude of charge of protons/electrons).
        /// </summary>
        public const double ElementaryCharge = 1.60217657E-19;

        /// <summary>
        /// The classical mechanical value of Newton's constant of gravitation in N*(m/kg)^2.
        /// </summary>
        public const double GravitationalConstant = 6.67384E-11;

        /// <summary>
        /// The exact value of Coulomb's constant / electric force constant / electrostatic constant in (N*m^2)/C^2 or meters per Farad.
        /// </summary>
        public const double ElectrostaticConstant = 8.9875517873681764E9;

        /// <summary>
        /// The value of the speed of light in a vacuum in m/s.
        /// </summary>
        public const double SpeedOfLight = 299792458;

        /// <summary>
        /// The value of magnetic permeability of free space in H/m.
        /// </summary>
        public const double MagneticPermeability = System.Math.PI * 4E-7;

        /// <summary>
        /// The value of electric permitivity of free space in F/m.
        /// </summary>
        public const double ElectricPermitivity = 8.8541878176E-12;

        /// <summary>
        /// The value of Planck's constant in J*s.
        /// </summary>
        public const double PlanckConstant_Js = 6.62606957E-34;

        /// <summary>
        /// The value of Planck's constant in eV*s.
        /// </summary>
        public const double PlanckConstant_eVs = 4.135667516E-15;

        /// <summary>
        /// The value of the Dirac constant (or reduced Planck constant) in J*s.
        /// </summary>
        public const double DiracConstant_Js = 1.054571726E-34;

        /// <summary>
        /// The value of the Dirac constant (or reduced Planck constant) in eV*s.
        /// </summary>
        public const double DiracConstant_eVs = 6.58211928E-16;

        /// <summary>
        /// The mass of a proton in kg.
        /// </summary>
        public const double ProtonMass = 1.672621777E-27;

        /// <summary>
        /// The mass of a neutron in kg.
        /// </summary>
        public const double NeutronMass = 1.674927351E-27;

        /// <summary>
        /// The mass of an electron in kg.
        /// </summary>
        public const double ElectronMass = 9.10938291E-31;
    }
}
