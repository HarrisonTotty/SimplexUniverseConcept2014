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
            this.Name = "Perfectly Inelastic";
            this.Description = "The boundary acts like a \"maximum\" position through which no particles may pass.";
        }

        public override Particle Resolve(Particle Input, UniverseBoundary Boundary)
        {
            //Create a shallow copy of the input particle
            Particle Resolved = Particle.Copy_Shallow(Input, true);

            //All we need to do is change the magnitude of the position vector
            Resolved.Position.Magnitude = System.Math.Abs(Boundary.Radius);

            //Return the result
            return Resolved;
        }
    }
}
