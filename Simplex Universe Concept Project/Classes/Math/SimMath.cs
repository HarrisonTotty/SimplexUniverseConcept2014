using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Contains static mathematical functions.
    /// </summary>
    public class SimMath
    {
        /// <summary>
        /// General purpose random generator.
        /// </summary>
        public static readonly Random RandomGen = new Random();

        /// <summary>
        /// Used to prevent parallel threads from accidentally generating the same random number.
        /// SEE https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
        /// </summary>
        public static readonly object GenSyncLock = new object();

        /// <summary>
        /// Returns a random double value between two double values
        /// </summary>
        /// <param name="Lowerbound">The lowerbound value</param>
        /// <param name="Upperbound">The upperbound value</param>
        public static double GenerateRandomDouble(double Lowerbound, double Upperbound)
        {
            lock (GenSyncLock)
            {
                return RandomGen.NextDouble() * (Upperbound - Lowerbound) + Lowerbound;
            }
        }

        /// <summary>
        /// Converts an angle in degrees to an angle in radians.
        /// </summary>
        /// <param name="Degrees">The angle in degrees</param>
        public static double DegreesToRadians(double Degrees)
        {
            return (Degrees * (System.Math.PI / 180.0));
        }

        /// <summary>
        /// Converts an angle in radians to an angle in degrees.
        /// </summary>
        /// <param name="Radians">The angle in radians</param>
        public static double RadiansToDegrees(double Radians)
        {
            return (Radians * (180.0 / System.Math.PI));
        }

        /// <summary>
        /// Returns a random direction vector in the specified number of dimensions.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions the direction vector exists</param>
        public static Vector RandomDirection(int NumberDimensions)
        {
            Vector RandomVector = new Vector(NumberDimensions);

            lock (GenSyncLock)
            {
                for (int i = 0; i < RandomVector.Capacity; i++)
                {
                    RandomVector[i] = GenerateRandomDouble(-10, 10);
                }
            }

            return RandomVector.Direction;
        }

        /// <summary>
        /// Returns an advanced vector in a random direction by a particular value.
        /// </summary>
        /// <param name="InputVector">The vector to advance</param>
        /// <param name="MinDistance">The minimum distance to advance the vector by</param>
        /// <param name="MaxDistance">The maximum distance to advance the vector by</param>
        public static Vector RandomWalk(Vector InputVector, double MinDistance, double MaxDistance)
        {
            Vector AddVector = RandomVector(InputVector.Capacity, MinDistance, MaxDistance);

            return (InputVector + AddVector);
        }

        /// <summary>
        /// Generates a random vector from a specified minimum and maximum magnitude.
        /// Can be used to determine a random polar position vector.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions the vector exists in</param>
        /// <param name="MinMagnitude">The minimum possible magnitude</param>
        /// <param name="MaxMagnitude">The maximum possible magnitude</param>
        public static Vector RandomVector(int NumberDimensions, double MinMagnitude, double MaxMagnitude)
        {
            Vector RandomVector = RandomDirection(NumberDimensions);
            RandomVector.Magnitude = System.Math.Abs(GenerateRandomDouble(MinMagnitude, MaxMagnitude));

            return RandomVector;
        }

        /// <summary>
        /// Generates a random Euclidean position vector within a specified radius from origin.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions to work with</param>
        /// <param name="GridRadius">The maximum distance from origin (in a single direction) allowed</param>
        public static Vector RandomEuclideanPosition(int NumberDimensions, double GridRadius)
        {
            Vector RandomVector = new Vector(NumberDimensions);

            lock (GenSyncLock)
            {
                for (int i = 0; i < RandomVector.Capacity; i++)
                {
                    RandomVector[i] = GenerateRandomDouble(-System.Math.Abs(GridRadius), System.Math.Abs(GridRadius));
                }
            }

            return RandomVector;
        }

        /// <summary>
        /// Does very basic collision handling with plot vectors (mainly as a test)
        /// </summary>
        /// <param name="InputList">The list to check</param>
        public static List<VisualizationComponents.PlotVector> BasicCollisionHandler(List<VisualizationComponents.PlotVector> InputList)
        {
            List<VisualizationComponents.PlotVector> ReturnList = new List<VisualizationComponents.PlotVector>(InputList.Capacity);

            InputList = InputList.OrderBy(x => x.Radius).ToList();
            InputList.Capacity = InputList.Count;

            //For every particle:
            for (int i = 0; i < InputList.Capacity; i++)
            {
                VisualizationComponents.PlotVector NewVec = new VisualizationComponents.PlotVector(InputList[i].Position.Capacity);
                NewVec.Radius = InputList[i].Radius;
                NewVec.Layer = InputList[i].Layer;
                NewVec.Position = Vector.Vector_Copy(InputList[i].Position);

                //For every other particle:
                for (int j = 0; j < InputList.Capacity; j++)
                {
                    if (i == j) continue;

                    //If these particles have collided:
                    Vector DistanceVec = InputList[j].Position - InputList[i].Position;
                    double DistanceMag = DistanceVec.Magnitude - InputList[i].Radius - InputList[j].Radius;

                    if (DistanceMag < 0)
                    {
                        DistanceVec.Magnitude += -(DistanceMag);
                        NewVec.Position = (InputList[j].Position - DistanceVec);
                        InputList[i].Position = NewVec.Position;
                    }
                }

                //Add the modified particle to the return list:
                ReturnList.Add(NewVec);
            }

            return ReturnList;
        }

        /// <summary>
        /// Generates a random boolean value.
        /// </summary>
        public static bool GenerateRandomBool()
        {
            bool ReturnBool;
            lock (GenSyncLock)
            {
                ReturnBool = (RandomGen.Next(0, 2) == 1);
            }
            return ReturnBool;
        }


        /// <summary>
        /// Generates a random integer value.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the generated number (inclusive)</param>
        /// <param name="Upperbound">The upperbound of the generated number (inclusive)</param>
        public static int GenerateRandomInteger(int Lowerbound, int Upperbound)
        {
            int ReturnInt = 0;
            lock (GenSyncLock)
            {
                ReturnInt = RandomGen.Next(Lowerbound, Upperbound + 1);
            }
            return ReturnInt;
        }


        /// <summary>
        /// Generates a new random simplex object ID
        /// The current method is capable of generating 62^100 possible combinations
        /// </summary>
        public static string GenerateSimplexObjectID()
        {
            string PickString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

            string ReturnString = "";

            lock (GenSyncLock)
            {
                for (int i = 0; i < 100; i++)
                {
                    ReturnString += PickString[RandomGen.Next(0, PickString.Length)];
                }
            }

            return ReturnString;
        }

        public static Vector RandomSphericalPosition(int NumberDimensions, double GridRadius)
        {
            Vector RandomVector = RandomDirection(NumberDimensions);

            lock (GenSyncLock)
            {
                RandomVector.Magnitude = GenerateRandomDouble(-System.Math.Abs(GridRadius), System.Math.Abs(GridRadius));
            }

            return RandomVector;
        }
        

        /// <summary>
        /// Determines the nearest vector in a list of vectors to a given vector
        /// Returns null if unable to find a nearest vector
        /// </summary>
        /// <param name="Input">The vector of interest</param>
        /// <param name="Comparison">The list of vectors to compare</param>
        public static Vector DetermineNearestVector(Vector Input, List<Vector> Comparison)
        {
            if (Comparison == null || Input == null) return null;
            if (Input == null) return null;
            if (Comparison.Count == 1) return Comparison[0];

            Vector Closest = Comparison[0];
            double CurrentD = (Comparison[0] - Input).Magnitude;

            for (int i = 1; i < Comparison.Count; i++)
            {
                double Distance = (Comparison[i] - Input).Magnitude;
                if (Distance < CurrentD)
                {
                    CurrentD = Distance;
                    Closest = Comparison[i];
                }
            }

            return Closest;
        }

        /// <summary>
        /// Determines the farthest vector in a list of vectors to a given vector
        /// Returns null if unable to find a furthest vector
        /// </summary>
        /// <param name="Input">The vector of interest</param>
        /// <param name="Comparison">The list of vectors to compare</param>
        public Vector DetermineFarthestVector(Vector Input, List<Vector> Comparison)
        {
            if (Comparison == null || Input == null) return null;
            if (Input == null) return null;
            if (Comparison.Count == 1) return Comparison[0];

            Vector Furthest = Comparison[0];
            double CurrentD = (Comparison[0] - Input).Magnitude;

            for (int i = 1; i < Comparison.Count; i++)
            {
                double Distance = (Comparison[i] - Input).Magnitude;
                if (Distance > CurrentD)
                {
                    CurrentD = Distance;
                    Furthest = Comparison[i];
                }
            }

            return Furthest;
        }

    }
}
