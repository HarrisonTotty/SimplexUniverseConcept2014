using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a 3D orientation amoung axes in Tait–Bryan angles (pitch, roll, yaw).
    /// </summary>
    public class Orientation3D : List<double>
    {
        /// <summary>
        /// Creates a new blank 3D orientation (with all angles initialized to zero).
        /// </summary>
        public Orientation3D()
        {
            this.Capacity = 3;
            this.Add(0);
            this.Add(0);
            this.Add(0);
        }

        /// <summary>
        /// Obtains an orientation from a particular unit vector direction (disreguards roll).
        /// </summary>
        /// <param name="DirectionUnitVector">The 3D unit vector corresponding to a direction</param>
        public static Orientation3D FromDirection(Vector DirectionUnitVector)
        {
            if (DirectionUnitVector.Capacity != 3) throw new Exception("Unit vector must be 3-dimensional!");

            Orientation3D ReturnOrientation = new Orientation3D();

            //ACCORDING TO https://stackoverflow.com/questions/1568568/how-to-convert-euler-angles-to-directional-vector
            // x = cos(yaw)*cos(pitch)
            // y = sin(yaw)*cos(pitch)
            // z = sin(pitch)
            //NOTE THAT System.Math USES RADIANS INSTEAD OF DEGREES!!

            //pitch = sin^-1(z)
            double pitch = System.Math.Asin(DirectionUnitVector[1]);
            ReturnOrientation[0] = SimMath.RadiansToDegrees(pitch);

            //yaw = cos^-1(x / cos(pitch)) and yaw = sin^-1(y / cos(pitch))
            double yaw = System.Math.Asin(DirectionUnitVector[0] / System.Math.Cos(pitch));
            if (DirectionUnitVector[0] > 0 && DirectionUnitVector[2] > 0)
            {
                ReturnOrientation[1] = SimMath.RadiansToDegrees(-yaw); //I have no idea why I used a negative yaw...just worked?
            }
            else if (DirectionUnitVector[0] < 0 && DirectionUnitVector[2] < 0)
            {
                ReturnOrientation[1] = 180 - SimMath.RadiansToDegrees(-yaw);
            }
            else if (DirectionUnitVector[0] >= 0 && DirectionUnitVector[2] <= 0)
            {
                ReturnOrientation[1] = 180 - SimMath.RadiansToDegrees(-yaw);
            }
            else if (DirectionUnitVector[0] <= 0 && DirectionUnitVector[2] >= 0)
            {
                ReturnOrientation[1] = SimMath.RadiansToDegrees(-yaw);
            }

            return ReturnOrientation;
        }

        /// <summary>
        /// Creates a copy of a 3D orientation.
        /// </summary>
        /// <param name="Input">The orientation to copy</param>
        public static Orientation3D Copy(Orientation3D Input)
        {
            Orientation3D Output = new Orientation3D();

            Output[0] = Input[0];
            Output[1] = Input[1];
            Output[2] = Input[2];

            return Output;
        }

        /// <summary>
        /// Obtains a unit vector from a particular orientation (disreguards roll).
        /// </summary>
        /// <param name="InputOrientation">A 3D orientation</param>
        public static Vector ToDirection(Orientation3D InputOrientation)
        {
            Vector ReturnVector = new Vector(3);

            double Yaw = InputOrientation[1];
            double Pitch = InputOrientation[0];

            ReturnVector[0] = System.Math.Cos(Yaw) * System.Math.Cos(Pitch);
            ReturnVector[1] = System.Math.Sin(Yaw) * System.Math.Cos(Pitch);
            ReturnVector[2] = System.Math.Sin(Pitch);

            return ReturnVector;
        }


    }
}
