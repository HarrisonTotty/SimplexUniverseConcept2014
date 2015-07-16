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
            this.Name = "Perfectly Elastic";
            this.Description = "Particles that come in contact with the edge of the universe bounce off in a perfectly elastic collision.";
        }

        public override Particle Resolve(Particle Input, UniverseBoundary Boundary)
        {
            //Create a shallow copy of the input particle
            Particle Resolved = Particle.Copy_Shallow(Input, true);

            Resolved.Position.Magnitude = System.Math.Abs(Boundary.Radius);

            //this isn't right, we don't want to reverse the direction of the velocity, we want to reverse the direction of the direction vector between the particle and the edge
            Resolved.Velocity.Direction = Vector.Vector_Negate(Resolved.Position.Direction);

            //Return the result
            return Resolved;
        }
    }
}
