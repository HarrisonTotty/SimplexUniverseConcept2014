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
            this.Name = "Wrapped";
            this.Description = "Particles that exit one side of the universe will re-appear on the exact opposite side.";
        }

        public override Particle Resolve(Particle Input, UniverseBoundary Boundary)
        {
            //Create a shallow copy of the input particle
            Particle Resolved = Particle.Copy_Shallow(Input, true);

            //All we need to do is reverse the direction of the position vector
            Resolved.Position = Vector.Vector_Negate(Resolved.Position);

            //Return the result
            return Resolved;
        }
    }
}

