using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.ComponentModel;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents a physical VG_Theme_Field such as the electric or magnetic VG_Theme_Field.
    /// </summary>
    /// <typeparam name="ValueType">The type of value stored at each position in space</typeparam>
    [Serializable()]
    public class Field<ValueType> : Simplex
    {
        /// <summary>
        /// The values of this VG_Theme_Field at each point in space stored as a dictionary with position vectors as keys and dynamic values at each position
        /// </summary>
        private Dictionary<Vector, ValueType> Values_Protected = new Dictionary<Vector, ValueType>();


        /// <summary>
        /// Gets the value of a VG_Theme_Field at the specified position
        /// If a position's value hasn't been directly specified, then the probable value will be calculated by averaging the two nearest points' values.
        /// </summary>
        /// <param name="Position">The position vector to lookup</param>
        public ValueType this[Vector Position]
        {
            get
            {
                if (this.Values_Protected.Keys.Count == 0) return default(ValueType);
                if (this.Values_Protected.ContainsKey(Position))
                {
                    return this.Values_Protected[Position];
                }
                else
                {
                    return this.DetermineApproximateValue(Position);
                }
            }
            set
            {
                if (this.Values_Protected.ContainsKey(Position))
                {
                    this.Values_Protected[Position] = value;
                }
                else
                {
                    this.Values_Protected.Add(Position, value);
                }
            }
        }

        public int NumberDimensions
        {
            get;
            set;
        }

        /// <summary>
        /// Determines the approximate value of the VG_Theme_Field at a position
        /// </summary>
        /// <param name="Position">The position to obtain the value for</param>
        private ValueType DetermineApproximateValue_OLD(Vector Position)
        {
            //The first thing we need to do is determine the closest relatively positive position vectors in each dimension to this position

            //Create a new list of doubles to store all of the distances
            List<Vector> DimensionalDistances = new List<Vector>(this.NumberDimensions * 2);

            //For each dimension:
            for (int i = 0; i < this.NumberDimensions; i++)
            {
                //For each position key:
                foreach (Vector PKey in this.Values_Protected.Keys)
                {
                    //If there isn't a value in this dimension:
                    if (DimensionalDistances[i * 2] == null)
                    {
                        if (PKey[i] >= Position[i])
                        {
                            DimensionalDistances[i * 2] = PKey;
                            continue;
                        }
                    }
                    if (DimensionalDistances[(i * 2) + 1] == null)
                    {
                        if (PKey[i] <= Position[i])
                        {
                            DimensionalDistances[(i * 2) + 1] = PKey;
                            continue;
                        }
                    }

                    //If the value of the position in that dimension is closer to the position vector than the previous attempt:
                    if (PKey[i] < DimensionalDistances[i * 2][i] && PKey[i] >= Position[i])
                    {
                        DimensionalDistances[i * 2] = PKey;
                    }
                    else if (PKey[i] > DimensionalDistances[(i * 2) + 1][i] && PKey[i] <= Position[i])
                    {
                        DimensionalDistances[(i * 2) + 1] = PKey;
                    }
                }
            }

            if (DimensionalDistances.Count == 0) return default(ValueType);

            //Now that we have the dimensional distances, lets take the average of their values
            dynamic Sum = default(ValueType);

            foreach (Vector Pos in DimensionalDistances)
            {
                Sum += this.Values_Protected[Pos];
            }

            return (Sum / DimensionalDistances.Count);
        }


        /// <summary>
        /// Determines the approximate value of the VG_Theme_Field at a position
        /// </summary>
        /// <param name="Position">The position to obtain the value for</param>
        private dynamic DetermineApproximateValue(Vector Position)
        {
            //Get the list of vectors in the dictionary
            List<Vector> CompareList = this.Values_Protected.Keys.ToList();

            //Translate the list of vectors so that the input position is the new origin
            for (int i = 0; i < CompareList.Count; i++)
            {
                CompareList[i] = CompareList[i] - Position;
            }

            //Get the closest position to our position
            Vector FirstClosest = SimMath.DetermineNearestVector(Position, CompareList);

            //Get the closest position to the negative of the first closest position
            Vector SecondClosest = SimMath.DetermineNearestVector(Vector.Vector_Negate(FirstClosest), CompareList);

            //Return our answer
            return ((dynamic)this.Values_Protected[FirstClosest] + (dynamic)this.Values_Protected[SecondClosest]) / 2;
        }
    }
}
