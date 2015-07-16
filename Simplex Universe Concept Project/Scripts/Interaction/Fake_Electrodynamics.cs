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
    /// Represents an interaction script for a fake modified version of classical mechanical electrodynamics
    /// This script returns the Lorentz force of the electromagnetic field on the input particle
    /// THIS SCRIPT IS A CRUDE FIX UNTIL FIELDS ARE APPROPRATELY IMPLIMENTED
    /// Optional Simulation Parameters: ElectrostaticConstant (Numerical), MagneticPermeability (Numerical)
    /// </summary>
    public class Script : ParticleInteractionScript
    {
        public Script()
        {
            this.Tags = new string[] { "Force" };
            this.Name = "Fake Electrodynamics";
            this.Description = "An interaction script for a fake modified version of classical mechanical electrodynamics";
            this.RequiredParticleProperties = new string[] { "Mass", "Charge" };
        }

        public override dynamic CalculateInteraction(Particle Input, Particle Comparison, Simulations.Simulation Sim)
        {
            //First we create a new force vector to store our result to
            Vector Force = new Vector(Input.NetForce.Capacity);

            //Make sure our input particle has "charge" and obtain it
            if (!Input.HasProperty("Charge")) return Force;
            double Charge = Input.GetPropertyVal("Charge");
            if (Charge == 0) return Force;

            //Make sure our input particle has "mass" and obtain it
            if (!Input.HasProperty("Mass")) return Force;
            double Mass = Input.GetPropertyVal("Mass");

            //Determine the input's siblings
            List<Particle> Siblings;
            if (Input.ParentParticle != null)
            {
                Siblings = Input.ParentParticle.SubParticles;
            }
            else
            {
                //Assume top layer
                Siblings = Sim.SimUniverse.Particles;
            }

            //Get the electric and magnetic fields on the charge
            Vector ElectricField = CalculateElectricFieldAtPosition(Input.Position, Siblings, Sim.Parameters);
            Vector MagneticField = CalculateMagneticFieldAtPosition(Input.Position, Siblings, Sim.Parameters);

            //Calculate the Lorentz force
            Force = (Charge * MagneticField) + Vector.Vector_3DCross((Charge * Input.Velocity), ElectricField);

            //Return the new net force
            return Force;
        }

        private Vector CalculateMagneticFieldAtPosition(Vector Position, List<Particle> CompareParticles, SimulationParameters SimParams)
        {
            //Create a new vector for the magnetic dsffd
            Vector MagneticField = new Vector(Position.Capacity);

            //Extract the Magnetic Permeability constant
            double MagneticPermeability;
            if (SimParams.HasParam("MagneticPermeability"))
            {
                MagneticPermeability = SimParams.GetParam("MagneticPermeability");
            }
            else
            {
                MagneticPermeability = PhysicsConstants.MagneticPermeability;
            }

            //Calculate the first part of the equation
            double FirstPart = MagneticPermeability / (4 * System.Math.PI);

            //For each comparison particle:
            foreach (Particle Comparison in CompareParticles)
            {
                //Make sure we don't have the same position
                if (Vector.Vector_Compare(Position, Comparison.Position)) continue;

                //Make sure the comparison particle has a velocity and a charge
                if (Comparison.Velocity.Magnitude == 0) continue;
                if (!Comparison.HasProperty("Charge")) continue;
                double Charge = Comparison.GetPropertyVal("Charge");
                if (Charge == 0) continue;

                //Calculate the distance and direction between the two particles
                Vector Direction = (Comparison.Position - Position).Direction;
                double Distance = (Comparison.Position - Position).Magnitude;

                //Calculate the magnetic dsffd from that particle and add it
                MagneticField += FirstPart * Charge * (Vector.Vector_3DCross(Comparison.Velocity, Direction) / (Distance * Distance));
            }

            //Return the magnetic dsffd vector
            return MagneticField;
        }

        private Vector CalculateElectricFieldAtPosition(Vector Position, List<Particle> CompareParticles, SimulationParameters SimParams)
        {
            //Create a new vector for the electric dsffd
            Vector ElectricField = new Vector(Position.Capacity);

            //Extract the Electrostatic constant
            double ElectrostaticConstant;
            if (SimParams.HasParam("ElectrostaticConstant"))
            {
                ElectrostaticConstant = SimParams.GetParam("ElectrostaticConstant");
            }
            else
            {
                ElectrostaticConstant = PhysicsConstants.ElectrostaticConstant;
            }

            //For each comparison particle:
            foreach (Particle Comparison in CompareParticles)
            {
                //Make sure we don't have the same position
                if (Vector.Vector_Compare(Position, Comparison.Position)) continue;

                //Make sure the comparison particle has a charge
                if (!Comparison.HasProperty("Charge")) continue;
                double Charge = Comparison.GetPropertyVal("Charge");
                if (Charge == 0) continue;

                //Calculate the distance and direction between the two particles
                Vector Direction = (Position - Comparison.Position).Direction;
                double Distance = (Position - Comparison.Position).Magnitude;

                //Calculate the magnetic dsffd from that particle and add it
                ElectricField += ElectrostaticConstant * (Charge * Direction) / (Distance * Distance);
            }

            //Return the electric dsffd vector
            return ElectricField;
        }
    }
}
