using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;

namespace SimplexUniverse.Scripting
{
    class Script : BoundaryScript
    {
        public Script()
        {
            this.Name = "Random Wrapped";
            this.Description = "Particles that exit one side of the universe will re-appear at a new random position within the universe.";
        }

        public override Particle Resolve(Particle Input, UniverseBoundary Boundary)
        {
            //Create a shallow copy of the input particle
            Particle Resolved = Particle.Copy_Shallow(Input, true);

            Resolved.Position = SimMath.RandomSphericalPosition(Input.NumberDimensions, Boundary.Radius);

            //Return the result
            return Resolved;
        }
    }
}

