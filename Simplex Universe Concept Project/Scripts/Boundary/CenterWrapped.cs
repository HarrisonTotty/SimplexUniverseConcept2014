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
            this.Name = "Center Wrapped";
            this.Description = "Particles that exit one side of the universe will re-appear at the center of the universe.";
        }

        public override Particle Resolve(Particle Input, UniverseBoundary Boundary)
        {
            //Create a shallow copy of the input particle
            Particle Resolved = Particle.Copy_Shallow(Input, true);

            Resolved.Position = new Vector(Resolved.Position.Capacity);

            //Return the result
            return Resolved;
        }
    }
}

