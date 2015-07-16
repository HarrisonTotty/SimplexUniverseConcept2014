using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents an Euclidean vector of a certain number of dimensions.
    /// Also contains static methods dealing with vectors.
    /// </summary>
    [Serializable(), Description("Represents an Euclidean vector of a certain number of dimensions"), TypeConverter(typeof(TypeConverters.TypeConverter_Vector))]
    public class Vector : List<double>
    {
        /// <summary>
        /// Creates a new 2D vector.
        /// </summary>
        public Vector()
        {
            this.Capacity = 2;
            this.Add(0);
            this.Add(0);
        }

        /// <summary>
        /// Creates a new vector of a certain number of dimensions.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this vector exists in</param>
        public Vector(int NumberDimensions)
        {
            this.Capacity = NumberDimensions;
            for (int i = 0; i < NumberDimensions; i++)
            {
                this.Add(0);
            }
        }

        /// <summary>
        /// Gets or sets the magnitude (length) of this vector.
        /// </summary>
        [Category("Vector Properties"), Description("The magnitude (or length) of this vector")]
        public double Magnitude
        {
            get
            {
                double Summation = 0;
                for (int i = 0; i < this.Capacity; i++)
                {
                    Summation += this[i] * this[i];
                }
                return System.Math.Sqrt(Summation);
            }
            set
            {
                Vector MyDirection = this.Direction;
                for (int i = 0; i < this.Capacity; i++)
                {
                    this[i] = MyDirection[i] * value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the direction (unit vector) of this vector.
        /// </summary>
        [Category("Vector Properties"), Description("The direction (as a unit vector) of this vector")]
        public Vector Direction
        {
            get
            {
                Vector DirectionVector = new Vector(this.Capacity);

                //Get the magnitude
                double Summation = 0;
                for (int i = 0; i < this.Capacity; i++)
                {
                    Summation += this[i] * this[i];
                }
                double MyMag = System.Math.Sqrt(Summation);

                //Get the direction
                for (int i = 0; i < this.Capacity; i++)
                {
                    DirectionVector[i] = this[i] / MyMag;
                }
                return DirectionVector;
            }
            set
            {
                double MyMag = this.Magnitude;

                for (int i = 0; i < this.Capacity; i++)
                {
                    this[i] = value[i] * MyMag;
                }
            }
        }

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        /// <param name="Vector1">The first vector to add</param>
        /// <param name="Vector2">The second vector to add</param>
        public static Vector Vector_Add(Vector Vector1, Vector Vector2)
        {
            if (Vector1.Capacity != Vector2.Capacity) throw new Exception("Vectors do not have the same number of dimensions");
            Vector ReturnVector = new Vector(Vector1.Capacity);
            for (int i = 0; i < Vector1.Capacity; i++)
            {
                ReturnVector[i] = Vector1[i] + Vector2[i];
            }
            return ReturnVector;
        }


        /// <summary>
        /// Subracts two vectors from each other (Vector1 - Vector2).
        /// </summary>
        /// <param name="Vector1">The first vector to subtract</param>
        /// <param name="Vector2">The second vector to subtract</param>
        public static Vector Vector_Subtract(Vector Vector1, Vector Vector2)
        {
            if (Vector1.Capacity != Vector2.Capacity) throw new Exception("Vectors do not have the same number of dimensions");
            Vector ReturnVector = new Vector(Vector1.Capacity);
            for (int i = 0; i < Vector1.Capacity; i++)
            {
                ReturnVector[i] = Vector1[i] - Vector2[i];
            }
            return ReturnVector;
        }

        /// <summary>
        /// Adds a scalar to a vector.
        /// </summary>
        /// <param name="InputVector">The vector to add</param>
        /// <param name="Scalar">The scalar to add</param>
        public static Vector Vector_Add(Vector InputVector, double Scalar)
        {
            Vector ReturnVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                ReturnVector[i] = InputVector[i] + Scalar;
            }
            return ReturnVector;
        }


        /// <summary>
        /// Subtracts a scalar from a vector.
        /// </summary>
        /// <param name="InputVector">The vector to subtract</param>
        /// <param name="Scalar">The scalar to subtract</param>
        public static Vector Vector_Subtract(Vector InputVector, double Scalar)
        {
            Vector ReturnVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                ReturnVector[i] = InputVector[i] - Scalar;
            }
            return ReturnVector;
        }

        /// <summary>
        /// Computes the dot product of two vectors
        /// </summary>
        /// <param name="Vector1">The first vector</param>
        /// <param name="Vector2">The second vector</param>
        public static double Vector_Dot(Vector Vector1, Vector Vector2)
        {
            if (Vector1.Capacity != Vector2.Capacity) throw new Exception("Vectors do not have the same number of dimensions");
            double Summation = 0;
            for (int i = 0; i < Vector1.Capacity; i++)
            {
                Summation += Vector1[i] * Vector2[i];
            }
            return Summation;
        }

        /// <summary>
        /// Multiplies a scalar to a vector.
        /// </summary>
        /// <param name="InputVector">The vector to multiply</param>
        /// <param name="Scalar">The scalar to multiply</param>
        public static Vector Vector_Multiply(Vector InputVector, double Scalar)
        {
            Vector ReturnVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                ReturnVector[i] = InputVector[i] * Scalar;
            }
            return ReturnVector;
        }


        /// <summary>
        /// Divides a scalar from a vector.
        /// </summary>
        /// <param name="InputVector">The vector to divide</param>
        /// <param name="Scalar">The scalar to divide</param>
        public static Vector Vector_Divide(Vector InputVector, double Scalar)
        {
            if (Scalar == 0) throw new Exception("Divide by zero!");
            Vector ReturnVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                ReturnVector[i] = InputVector[i] / Scalar;
            }
            return ReturnVector;
        }


        /// <summary>
        /// Divides a vector from a scalar. This is the same as (1 / Vector) * Scalar.
        /// </summary>
        /// <param name="Scalar">The scalar to divide</param>
        /// <param name="InputVector">The vector to divide</param>
        public static Vector Vector_Divide(double Scalar, Vector InputVector)
        {
            Vector ReturnVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                if (InputVector[i] == 0) throw new Exception("Divide by zero!");
                ReturnVector[i] = (1 / InputVector[i]) * Scalar;
            }
            return ReturnVector;
        }

        /// <summary>
        /// Copies a given vector.
        /// </summary>
        /// <param name="InputVector">The vector to copy</param>
        public static Vector Vector_Copy(Vector InputVector)
        {
            Vector NewVector = new Vector(InputVector.Capacity);
            for (int i = 0; i < InputVector.Capacity; i++)
            {
                NewVector[i] = InputVector[i];
            }
            return NewVector;
        }

        /// <summary>
        /// Returns the string representation of a vector according to the given format.
        /// </summary>
        /// <param name="Format">The vector format to use</param>
        /// <param name="IndividualStringFormat">The format of each individual number in the sequence</param>
        public string ToString(Enums.Vector_StringFormat Format, string IndividualStringFormat)
        {
            string OutputString = "";
            switch (Format)
            {
                case Enums.Vector_StringFormat.Bracket:
                    OutputString = "<";
                    for (int i = 0; i < this.Capacity; i++)
                    {
                        if (i == this.Capacity - 1)
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + ">";
                        }
                        else
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + ", ";
                        }
                    }
                    break;

                case Enums.Vector_StringFormat.Matrix:
                    OutputString = "[";
                    for (int i = 0; i < this.Capacity; i++)
                    {
                        if (i == this.Capacity - 1)
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + "]";
                        }
                        else
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + ", ";
                        }
                    }
                    break;

                case Enums.Vector_StringFormat.UnitVector:
                    if (this.Capacity > 26) return null;
                    string letters = "ijklmnopqrstuvwxyzabcdefgh";
                    for (int i = 0; i < this.Capacity; i++)
                    {
                        if (i == this.Capacity - 1)
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + letters[i];
                        }
                        else
                        {
                            OutputString += this[i].ToString(IndividualStringFormat) + letters[i] + " + ";
                        }
                    }
                    break;

                default:
                    throw new Exception("Unknown vector string format");
            }

            return OutputString;
        }

        /// <summary>
        /// Returns the cross product of two 3D vectors.
        /// </summary>
        /// <param name="Vector1">The first vector</param>
        /// <param name="Vector2">The second vector</param>
        public static Vector Vector_3DCross(Vector Vector1, Vector Vector2)
        {
            if (Vector1.Capacity != 3 || Vector2.Capacity != 3) throw new Exception("One or more vectors passed are not 3-Dimensional");
            Vector ReturnVector = new Vector(3);
            ReturnVector[0] = (Vector1[1] * Vector2[2]) - (Vector1[2] * Vector2[1]);
            ReturnVector[1] = (Vector1[2] * Vector2[0]) - (Vector1[0] * Vector2[2]);
            ReturnVector[2] = (Vector1[0] * Vector2[1]) - (Vector1[1] * Vector2[0]);
            return ReturnVector;
        }

        /// <summary>
        /// Returns the angle between two vectors (radians).
        /// </summary>
        /// <param name="Vector1">The first vector</param>
        /// <param name="Vector2">The second vector</param>
        public static double Vector_AngleBetweenVectors(Vector Vector1, Vector Vector2)
        {
            if (Vector1.Capacity != Vector2.Capacity) throw new Exception("Vectors do not have the same number of dimensions");
            double DotProduct = Vector_Dot(Vector1, Vector2);
            double Magnitudes = Vector1.Magnitude * Vector1.Magnitude;
            return System.Math.Atan(DotProduct / Magnitudes);
        }

        /// <summary>
        /// Reverses the direction of a vector (same as doing a scalar multiplication by -1).
        /// </summary>
        /// <param name="InputVector">The vector to negate</param>
        public static Vector Vector_Negate(Vector InputVector)
        {
            return Vector_Multiply(InputVector, -1);
        }

        /// <summary>
        /// Overload for addition operator (Vector1 + Vector2).
        /// </summary>
        public static Vector operator +(Vector Vector1, Vector Vector2)
        {
            return Vector_Add(Vector1, Vector2);
        }

        /// <summary>
        /// Overload for addition operator (Vector + Scalar).
        /// </summary>
        public static Vector operator +(Vector InputVector, double Scalar)
        {
            return Vector_Add(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for addition operator (Vector + Scalar).
        /// </summary>
        public static Vector operator +(Vector InputVector, int Scalar)
        {
            return Vector_Add(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for addition operator (Scalar + Vector).
        /// </summary>
        public static Vector operator +(double Scalar, Vector InputVector)
        {
            return Vector_Add(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for addition operator (Scalar + Vector).
        /// </summary>
        public static Vector operator +(int Scalar, Vector InputVector)
        {
            return Vector_Add(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for subtraction operator (Vector1 - Vector2).
        /// </summary>
        public static Vector operator -(Vector Vector1, Vector Vector2)
        {
            return Vector_Subtract(Vector1, Vector2);
        }

        /// <summary>
        /// Overload for subtraction operator (Vector - Scalar).
        /// </summary>
        public static Vector operator -(Vector InputVector, double Scalar)
        {
            return Vector_Subtract(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for subtraction operator (Vector - Scalar).
        /// </summary>
        public static Vector operator -(Vector InputVector, int Scalar)
        {
            return Vector_Subtract(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for subtraction operator (Scalar - Vector).
        /// </summary>
        public static Vector operator -(double Scalar, Vector InputVector)
        {
            return Vector_Add(Vector_Negate(InputVector), Scalar);
        }

        /// <summary>
        /// Overload for subtraction operator (Scalar - Vector).
        /// </summary>
        public static Vector operator -(int Scalar, Vector InputVector)
        {
            return Vector_Add(Vector_Negate(InputVector), Scalar);
        }

        /// <summary>
        /// Overload for negation operator (-Vector).
        /// </summary>
        public static Vector operator -(Vector InputVector)
        {
            return Vector_Negate(InputVector);
        }

        /// <summary>
        /// Overload for multiplication operator (Vector * Vector). We will assume this means dot product.
        /// </summary>
        public static double operator *(Vector Vector1, Vector Vector2)
        {
            return Vector_Dot(Vector1, Vector2);
        }

        /// <summary>
        /// Overload for multiplication operator (Vector * Scalar).
        /// </summary>
        public static Vector operator *(Vector InputVector, double Scalar)
        {
            return Vector_Multiply(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for multiplication operator (Vector * Scalar).
        /// </summary>
        public static Vector operator *(Vector InputVector, int Scalar)
        {
            return Vector_Multiply(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for multiplication operator (Scalar * Vector).
        /// </summary>
        public static Vector operator *(double Scalar, Vector InputVector)
        {
            return Vector_Multiply(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for multiplication operator (Scalar * Vector).
        /// </summary>
        public static Vector operator *(int Scalar, Vector InputVector)
        {
            return Vector_Multiply(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for division operator (Vector / Scalar).
        /// </summary>
        public static Vector operator /(Vector InputVector, double Scalar)
        {
            return Vector_Divide(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for the greater than test operator (Vector > Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator >(Vector InputVector, Vector Comparison)
        {
            return (InputVector.Magnitude > Comparison.Magnitude);
        }


        /// <summary>
        /// Overload for the greater than test operator (Vector >= Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator >=(Vector InputVector, Vector Comparison)
        {
            return (InputVector.Magnitude >= Comparison.Magnitude);
        }

        /// <summary>
        /// Overload for the less than test operator (Vector < Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator <(Vector InputVector, Vector Comparison)
        {
            return (InputVector.Magnitude < Comparison.Magnitude);
        }

        /// <summary>
        /// Overload for the less than test operator (Vector <= Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator <=(Vector InputVector, Vector Comparison)
        {
            return (InputVector.Magnitude <= Comparison.Magnitude);
        }


        /// <summary>
        /// Overload for equality test operator (Vector != Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator !=(Vector InputVector, Vector Comparison)
        {
            if ((object)InputVector == null && (object)Comparison == null) return false;
            if ((object)InputVector == null || (object)Comparison == null) return true;
            return !Vector.Vector_Compare(InputVector, Comparison);
        }


        /// <summary>
        /// Overload for equality test operator (Vector != Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator !=(Vector InputVector, double Scalar)
        {
            return (InputVector.Magnitude != Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector != Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator !=(double Scalar, Vector InputVector)
        {
            return (InputVector.Magnitude != Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector != Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator !=(Vector InputVector, int Scalar)
        {
            return (InputVector.Magnitude != Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector != Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator !=(int Scalar, Vector InputVector)
        {
            return (InputVector.Magnitude != Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector == Vector)
        /// </summary>
        /// <param name="InputVector">The first vector</param>
        /// <param name="Comparison">The second vector</param>
        public static bool operator ==(Vector InputVector, Vector Comparison)
        {
            if ((object)InputVector == null && (object)Comparison == null) return true;
            if ((object)InputVector == null || (object)Comparison == null) return false;
            return Vector.Vector_Compare(InputVector, Comparison);
        }


        /// <summary>
        /// Overload for equality test operator (Vector == Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator ==(Vector InputVector, double Scalar)
        {
            return (InputVector.Magnitude == Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector == Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator ==(double Scalar, Vector InputVector)
        {
            return (InputVector.Magnitude == Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector == Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator ==(Vector InputVector, int Scalar)
        {
            return (InputVector.Magnitude == Scalar);
        }


        /// <summary>
        /// Overload for equality test operator (Vector == Scalar)
        /// Assumes magnitude
        /// </summary>
        /// <param name="InputVector">The vector to compare</param>
        /// <param name="Scalar">The scalar to compare</param>
        public static bool operator ==(int Scalar, Vector InputVector)
        {
            return (InputVector.Magnitude == Scalar);
        }


        /// <summary>
        /// Overload for division operator (Vector / Scalar).
        /// </summary>
        public static Vector operator /(Vector InputVector, int Scalar)
        {
            return Vector_Divide(InputVector, Scalar);
        }

        /// <summary>
        /// Overload for division operator (Scalar / Vector).
        /// </summary>
        public static Vector operator /(double Scalar, Vector InputVector)
        {
            return Vector_Divide(Scalar, InputVector);
        }

        /// <summary>
        /// Overload for division operator (Scalar / Vector).
        /// </summary>
        public static Vector operator /(int Scalar, Vector InputVector)
        {
            return Vector_Divide(Scalar, InputVector);
        }


        /// <summary>
        /// Converts a vector into an array of doubles
        /// </summary>
        /// <param name="InputVector">The vector to convert</param>
        public static double[] Vector_ToArray(Vector InputVector)
        {
            return InputVector.ToArray();
        }


        /// <summary>
        /// Converts a vector into a list of doubles
        /// </summary>
        /// <param name="InputVector">The vector to convert</param>
        public static List<double> Vector_ToList(Vector InputVector)
        {
            List<double> ReturnList = new List<double>(InputVector.Capacity);

            foreach (double x in InputVector)
            {
                ReturnList.Add(x);
            }

            return ReturnList;
        }

        /// <summary>
        /// Creates a new vector from a list of double values
        /// </summary>
        /// <param name="InputList">The list of doubles</param>
        public static Vector Vector_FromList(List<double> InputList)
        {
            Vector ReturnVector = new Vector(InputList.Capacity);

            for (int i = 0; i < InputList.Capacity; i++)
            {
                ReturnVector[i] = InputList[i];
            }

            return ReturnVector;
        }

        /// <summary>
        /// Creates a new vector from an array of double values
        /// </summary>
        /// <param name="InputArray">The list of doubles</param>
        public static Vector Vector_FromArray(double[] InputArray)
        {
            Vector ReturnVector = new Vector(InputArray.Length);

            for (int i = 0; i < InputArray.Length; i++)
            {
                ReturnVector[i] = InputArray[i];
            }

            return ReturnVector;
        }

        /// <summary>
        /// Returns a sub-vector of the current vector from the given dimensional span (inclusive).
        /// Example: Vector_ToSubVector(2, 4) of {6, 8, -3, 2, 0, 9} would return {8, -3, 2}.
        /// </summary>
        /// <param name="StartDimension">The starting dimension (not index) to pull</param>
        /// <param name="EndDimension">The end dimension (not index) to pull</param>
        public Vector Vector_ToSubVector(int StartDimension, int EndDimension)
        {
            //Check for errors
            if (StartDimension > EndDimension || StartDimension < 1 || EndDimension > this.Count) throw new Exception("Invalid sub-vector arguements!");

            Vector ReturnVector = new Vector(EndDimension - StartDimension + 1);

            for (int i = (StartDimension - 1); i < EndDimension; i++)
            {
                ReturnVector.Add(this[i]);
            }

            return ReturnVector;
        }

        /// <summary>
        /// Compares two vectors to see if they have the same values.
        /// </summary>
        /// <param name="Vector1">The first vector to compare</param>
        /// <param name="Vector2">The second vector to compare</param>
        public static bool Vector_Compare(Vector Vector1, Vector Vector2)
        {
            if (Vector1 == null && Vector2 == null) return true;
            if (Vector1 == null || Vector2 == null) return false;
            if (Vector1.Capacity != Vector2.Capacity) return false;

            for (int i = 0; i < Vector1.Capacity; i++)
            {
                if (Vector1[i] != Vector2[i]) return false;
            }

            return true;
        }
    }
}
