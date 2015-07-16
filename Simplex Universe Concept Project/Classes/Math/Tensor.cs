using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a tensor of a particular order/degree/rank and underlying dimenionality (if consistent).
    /// </summary>
    /// <remarks>
    /// Note that all of these examples have a consistent underlying dimensionality of 4!
    /// 
    /// A rank 1 tensor only has one "dimension" of data, and resembles a Vector:
    /// [6] [4] [8] [5]
    /// 
    /// A rank 2 tensor has two dimensions of data, resembling a Matrix:
    /// [6] [4] [8] [5]
    /// [2] [1] [9] [7]
    /// [1] [3] [5] [8]
    /// [5] [9] [0] [2]
    /// 
    /// A rank 3 tensor has three dimensions of data, resembling a "cube array":
    ///     Layer 1                 Layer 2                 Layer 3                 Layer 4
    /// [6] [4] [8] [5]         [1] [6] [4] [3]         [1] [3] [5] [8]         [1] [8] [9] [4]
    /// [2] [1] [9] [7]         [2] [0] [9] [8]         [1] [5] [7] [9]         [7] [2] [0] [2]
    /// [1] [3] [5] [8]         [5] [7] [5] [9]         [3] [6] [8] [0]         [6] [5] [0] [2]
    /// [5] [9] [0] [2]         [1] [1] [7] [4]         [8] [2] [1] [3]         [5] [9] [0] [3]
    /// 
    /// See https://en.wikipedia.org/wiki/Tensor for more info.
    /// </remarks>
    [Serializable()]
    public class Tensor //: List<dynamic> ?   <-  Tensors shouldn't inherit anything because there is no way to dynamically change inheritance in C#
    {
        /// <summary>
        /// Creates a new rank 3 tensor with a 3D underlying dimensionality.
        /// </summary>
        public Tensor()
        {
            this.Rank = 3;
            this.Dimensionality = 3;
            this.Data = BuildData(3, 3);
        }


        /// <summary>
        /// Creates a new tensor of a particular rank and consistent underlying dimensionality.
        /// </summary>
        /// <param name="Rank">The rank/order/degree of the tensor</param>
        /// <param name="Dimensionality">The underlying dimensionality of the tensor (number of numbers stored in each dimension of rank)</param>
        public Tensor(int Rank, int Dimensionality)
        {
            //If the rank is less than 0, it is invalid
            if (Rank < 0) throw new Exception("Invalid tensor rank! A tensor must have a rank greater than 0!");

            //If the rank is 0, then the data is just a scalar
            if (Rank == 0)
            {
                this.Data = new double();
                this.Rank = 0;
                this.Dimensionality = 0;
                return;
            }

            //If the rank is 1, then this is just a list of doubles
            if (Rank == 1)
            {
                this.Data = new List<double>(Dimensionality);
            }

            //If the rank is greater than 1, then we need to create nested lists
            if (Rank > 1)
            {
                this.Data = BuildData(Rank, Dimensionality);
            }


            //Copy the rank and dimensionality to the tensor
            this.Rank = Rank;
            this.Dimensionality = Dimensionality;
        }


        /// <summary>
        /// Creates a new tensor of a particular rank and underlying dimensionalities.
        /// </summary>
        /// <param name="Rank">The rank/order/degree of the tensor</param>
        /// <param name="Dimensionality">The dimesionality of each rank in the tensor (number of numbers stored in each dimension of rank)</param>
        public Tensor(int Rank, params int[] Dimensionality)
        {
            //If the rank is less than 0, it is invalid
            if (Rank < 0) throw new Exception("Invalid tensor rank! A tensor must have a rank greater than 0!");

            //If the rank is 0, then the data is just a scalar
            if (Rank == 0)
            {
                this.Data = new double();
                this.Rank = 0;
                this.Dimensionality = 0;
                return;
            }

            //If the user doesn't give enough dimensionalities for the number of ranks, complain
            if (Dimensionality.Length != Rank) throw new Exception("Invalid number of dimensionalities!");

            //If the rank is 1, then this is just a list of doubles
            if (Rank == 1)
            {
                this.Data = new List<double>(Dimensionality[0]);
                this.Rank = Rank;
                this.Dimensionality = Dimensionality[0];
                return;
            }

            //If the rank is greater than 1, then we need to create nested lists
            if (Rank > 1)
            {
                this.Data = BuildData(Rank, Dimensionality);
            }


            //Copy the rank and dimensionality to the tensor
            this.Rank = Rank;
            this.Dimensionality = 0;
        }


        /// <summary>
        /// The rank/order/degree of this tensor.
        /// </summary>
        public int Rank
        {
            get;
            set;
        }


        /// <summary>
        /// The underlying dimensionality of the tensor (number of numbers stored in each dimension of rank) (if consistent).
        /// </summary>
        public int Dimensionality
        {
            get;
            set;
        }


        /// <summary>
        /// The actual stored data for the tensor represented as nested lists.
        /// NOTE: Use the tensor[x, y, z, ...] syntax for working with values inside of tensors instead of manipulating tensor.Data!
        /// </summary>
        public dynamic Data
        {
            get;
            set;
        }


        /// <summary>
        /// Whether this tensor has a consistent underlying dimensionality (whether each dimension of rank holds the same number of numbers).
        /// </summary>
        public bool ConsistentDimensionality
        {
            get
            {
                //Obtain the underlying dimensionalities for the tensor
                int[] TrueDimensionalities = ObtainDimensionalities();

                //For each dimensionality at each sub-rank:
                foreach (int Dimensionality in TrueDimensionalities)
                {
                    //If this dimensionality isn't equal to the first one, then they aren't consistent
                    if (Dimensionality != TrueDimensionalities[0]) return false;
                }

                //Otherwise we are consistent
                return true;
            }
        }

        /// <summary>
        /// Returns or sets the stored value at a particular set of indicies.
        /// For example ThisTensor[3, 4, 8] would access the value stored at (3, 4, 8)
        /// UNTESTED
        /// </summary>
        /// <param name="Indicies">The indicies of the value</param>
        public double this[params int[] Indicies]
        {
            get
            {
                //Check for index length problems
                if (Indicies.Length != this.Rank) throw new Exception("Invalid number of indicies!");

                //If the rank is zero, then we are only storing one number
                if (this.Rank == 0) return (double)this.Data;

                //If the rank is one, then treat it like a normal list
                if (this.Rank == 1) return (double)this.Data[Indicies[0]];

                //If the rank is greater than one, then we are dealing with nested lists
                return (double)DataExtractor(this.Data, this.Rank, Indicies);
            }
            set
            {
                //Check for index length problems
                if (Indicies.Length != this.Rank) throw new Exception("Invalid number of indicies!");

                //If the rank is zero, then we are only storing one number
                if (this.Rank == 0)
                {
                    this.Data = value;
                    return;
                }

                //If the rank is one, then treat it like a normal list
                if (this.Rank == 1)
                {
                    this.Data[Indicies[0]] = value;
                    return;
                }

                //If the rank is greater than one, then we are dealing with nested lists
                DataSetter(this.Data, this.Rank, Indicies, value);
            }
        }
        

        public static void Tensor_Product()
        {
            throw new System.NotImplementedException();
        }


        public static void Tensor_Contraction()
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// Recursive function used for building nested dynamic lists for tensor data (for consistent underlying dimensionality).
        /// </summary>
        /// <param name="Rank">The relative step rank</param>
        /// <param name="Dimensionality">The overall underlying dimensionality of the tensor</param>
        private static dynamic BuildData(int Rank, int Dimensionality)
        {
            //If the current step rank is 1:
            if (Rank == 1)
            {
                //Return a list of doubles (because a tensor of rank 1 is the same as a vector)
                List<double> UnderlyingList = new List<double>(Dimensionality);

                for (int i = 0; i < Dimensionality; i++)
                {
                    UnderlyingList.Add(0);
                }

                return UnderlyingList;
            }
            else //Otherwise:
            {
                //Create a new list layer to "cover" the underlying one
                List<dynamic> NewData = new List<dynamic>(Dimensionality);

                //For each dimension in the overall underlying dimensionality of the tensor:
                for (int i = 0; i < Dimensionality; i++)
                {
                    //Add a the list generated by running this function again with Rank - 1
                    NewData.Add(BuildData(Rank - 1, Dimensionality));
                }

                //Return the layer
                return NewData;
            }
        }


        /// <summary>
        /// Recursive function used for building nested dynamic lists for tensor data (for inconsistent underlying dimensionalities).
        /// </summary>
        /// <param name="Rank">The relative step rank</param>
        /// <param name="Dimensionalities">The list of underlying dimensionalities for each rank</param>
        private static dynamic BuildData(int Rank, int[] Dimensionalities)
        {
            //If the current step rank is 1:
            if (Rank == 1)
            {
                //Return a list of doubles (because a tensor of rank 1 is the same as a vector)
                List<double> UnderlyingList = new List<double>(Dimensionalities[0]);

                for (int i = 0; i < Dimensionalities[0]; i++)
                {
                    UnderlyingList.Add(0);
                }

                return UnderlyingList;
            }
            else //Otherwise:
            {
                //Create a new list layer to "cover" the underlying one
                List<dynamic> NewData = new List<dynamic>(Dimensionalities[Rank - 1]);

                //For each dimension in the overall underlying dimensionality of the tensor:
                for (int i = 0; i < Dimensionalities[Rank - 1]; i++)
                {
                    //Add a the list generated by running this function again with Rank - 1
                    NewData.Add(BuildData(Rank - 1, Dimensionalities));
                }

                //Return the layer
                return NewData;
            }
        }


        /// <summary>
        /// Recursive function for extracting a value from the tensor at a particular set of indicies.
        /// </summary>
        /// <param name="RelativeData">The relative set of nested lists to work with</param>
        /// <param name="CurrentRank">The current relative rank</param>
        /// <param name="DimensionalityIndicies">The indicies of the value we are trying to extract</param>
        private static dynamic DataExtractor(dynamic RelativeData, int CurrentRank, int[] DimensionalityIndicies)
        {
            //If the current relative rank is one:
            if (CurrentRank == 1)
            {
                //Then return the value as you would handle a List<double>
                return RelativeData[DimensionalityIndicies[0]];
            }
            else //Otheriwse:
            {
                //Run this function again with the list stored inside of our relative data and with CurrentRank - 1
                return DataExtractor(RelativeData[DimensionalityIndicies[CurrentRank - 1]], CurrentRank - 1, DimensionalityIndicies);
            }
        }


        /// <summary>
        /// Recursive function for setting the value at a particular set of indicies in the tensor.
        /// </summary>
        /// <param name="RelativeData">The relative set of nested lists to work with</param>
        /// <param name="CurrentRank">The current relative rank</param>
        /// <param name="DimensionalityIndicies">The indicies of the value we are trying to extract</param>
        private static void DataSetter(dynamic RelativeData, int CurrentRank, int[] DimensionalityIndicies, double Value)
        {
            //If the current relative rank is one:
            if (CurrentRank == 1)
            {
                //Then return the value as you would handle a List<double>
                RelativeData[DimensionalityIndicies[0]] = Value;
            }
            else //Otheriwse:
            {
                //Run this function again with the list stored inside of our relative data and with CurrentRank - 1
                DataSetter(RelativeData[DimensionalityIndicies[CurrentRank - 1]], CurrentRank - 1, DimensionalityIndicies, Value);
            }
        }


        /// <summary>
        /// Computes the addition of two tensors of the same rank and underlying dimensionalities.
        /// </summary>
        /// <param name="Tensor1">The first tensor to add</param>
        /// <param name="Tensor2">The second tensor to add</param>
        public static Tensor Tensor_Add(Tensor Tensor1, Tensor Tensor2)
        {
            //Only two tensors of the same rank may be added
            if (Tensor1.Rank != Tensor2.Rank) throw new Exception("Tensors must be the same rank!");

            //To add two tensors together, first we want to unfold each into a flat tensor
            FlatTensor Flat1 = FlatTensor.FromTensor(Tensor1);
            FlatTensor Flat2 = FlatTensor.FromTensor(Tensor2);

            //Make sure the resulting flat tensors are the same length
            if (Flat1.Count != Flat2.Count) throw new Exception("Tensors must have the same underlying dimensionality at each sub-rank!");

            //Now add them like we would two vectors
            FlatTensor Result = new FlatTensor(Flat1.Count);
            for (int i = 0; i < Flat1.Count; i++)
            {
                Result[i] = Flat1[i] + Flat2[i];
            }

            //Finally, fold the resulting flat tensor back into a regular tensor
            return Result.ToTensor();
        }


        /// <summary>
        /// Computes the subtraction of two tensors of the same rank and underlying dimensionalities.
        /// </summary>
        /// <param name="Tensor1">The tensor to subtract from</param>
        /// <param name="Tensor2">The tensor to subtract</param>
        public static Tensor Tensor_Subtract(Tensor Tensor1, Tensor Tensor2)
        {
            //Only two tensors of the same rank may be subtracted
            if (Tensor1.Rank != Tensor2.Rank) throw new Exception("Tensors must be the same rank!");

            //To subtract two tensors, first we want to unfold each into a flat tensor
            FlatTensor Flat1 = FlatTensor.FromTensor(Tensor1);
            FlatTensor Flat2 = FlatTensor.FromTensor(Tensor2);

            //Make sure the resulting flat tensors are the same length
            if (Flat1.Count != Flat2.Count) throw new Exception("Tensors must have the same underlying dimensionality at each sub-rank!");

            //Now subtract them like we would two vectors
            FlatTensor Result = new FlatTensor(Flat1.Count);
            for (int i = 0; i < Flat1.Count; i++)
            {
                Result[i] = Flat1[i] - Flat2[i];
            }

            //Finally, fold the resulting flat tensor back into a regular tensor
            return Result.ToTensor();
        }


        /// <summary>
        /// Returns an array of integers representing the underlying dimensionality at each rank of this tensor.
        /// </summary>
        public int[] ObtainDimensionalities()
        {
            //Create a new list to hold the underlying dimensionalities
            List<int> ReturnList = new List<int>(this.Rank);

            //If the rank is zero, complain
            if (this.Rank == 0) throw new Exception("Cannot obtain underlying dimensionalities...tensor is rank 0.");

            //For each rank:
            for (int i = 1; i <= this.Rank; i++)
            {
                //Determine the underlying dimensionality at that rank and add it to the list
                ReturnList.Add(DimensionalityExtractor(this.Data, this.Rank, i));
            }

            //Return the array representation of the list
            return ReturnList.ToArray();
        }


        /// <summary>
        /// Recursive function to obtain the underlying dimensionality at a particular sub-rank.
        /// </summary>
        /// <param name="RelativeData">The relative set of data</param>
        /// <param name="CurrentRank">The relative rank</param>
        /// <param name="TargetRank">The rank to extract at</param>
        private static int DimensionalityExtractor(dynamic RelativeData, int CurrentRank, int TargetRank)
        {
            //If the current rank is equal to the target rank:
            if (CurrentRank == TargetRank)
            {
                //If that current rank is one:
                if (CurrentRank == 1)
                {
                    //Cast the RelativeData as a List<double> and return its capacity
                    return ((List<double>)(RelativeData)).Capacity;
                }
                else //Otherwise:
                {
                    //Cast the RelativeData as a List<dynamic> and return its capacity
                    return ((List<dynamic>)(RelativeData)).Capacity;
                }
            }
            else //Otherwise:
            {
                //Run the function again with the next layer of data
                return DimensionalityExtractor(RelativeData[0], CurrentRank - 1, TargetRank);
            }
        }


        /// <summary>
        /// Obtains the underlying dimensionality of a particular sub-rank (array dimension).
        /// For example: running this function on a 3x4x6x8 tensor for rank 3 would return "6".
        /// </summary>
        /// <param name="Subrank">The sub-rank to obtain the underlying dimensionality from</param>
        public int ObtainDimensionality(int Subrank)
        {
            //If the rank is zero, complain
            if (this.Rank == 0) throw new Exception("Cannot obtain underlying dimensionalities...tensor is rank 0.");

            //Use our recursive function:
            return DimensionalityExtractor(this.Data, this.Rank, Subrank);
        }


        /// <summary>
        /// Creates a sub-tensor from a given tensor between a pair of array dimensions (inclusive).
        /// The resulting tensor will have a rank equal to (EndRank - StartRank) + 1.
        /// </summary>
        /// <param name="Input">The tensor to decompose</param>
        /// <param name="StartRank">The starting sub-rank (array dimension) (inclusive)</param>
        /// <param name="EndRank">The ending sub-rank (array dimension) (inclusive)</param>
        public static Tensor Tensor_ToSubTensor(Tensor Input, int StartRank, int EndRank)
        {
            //If the starting sub-rank is greater than the end sub-rank, complain
            if (StartRank > EndRank) throw new Exception("Invalid start/end sub-ranks.");

            //If the starting and ending subrank are the same:
            if (StartRank == EndRank)
            {
                //Obtain the underlying dimensionality of the origional at the starting (and thus ending) rank
                int UnderlyingDim = Input.ObtainDimensionality(StartRank);

                //Create a new rank one tensor with the same dimensionality as the start (and end) rank
                Tensor ReturnTensor = new Tensor(1, UnderlyingDim);

                //Create an access key
                int[] Key = new int[Input.Rank];

                //For each underlying dimension:
                for (int i = 0; i < UnderlyingDim; i++)
                {
                    //Copy over the value
                    Key[StartRank] = i;
                    ReturnTensor[Key] = Input[Key];
                }

                //Return the newly created tensor
                return ReturnTensor;
            }
            else //Otherwise if they are not the same:
            {

            }
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Copies all of the values in a tensor to a new one.
        /// </summary>
        /// <param name="Input">The tensor to copy</param>
        public static Tensor Tensor_Copy(Tensor Input)
        {
            if (Input.Rank > 0)
            {
                //Create a flat tensor from the input and another one for the result
                FlatTensor Flat = FlatTensor.FromTensor(Input);
                FlatTensor Result = new FlatTensor(Flat.Count);

                //For each value in the flat tensor:
                for (int i = 0; i < Flat.Count; i++)
                {
                    //Copy the value to the result
                    Result[i] = Flat[i];
                }

                //Return the result
                return Result.ToTensor();
            }
            else
            {
                //We are working with a scalar
                Tensor ScalarTensor = new Tensor(0, 0);
                ScalarTensor.Data = (double)Input.Data;
                return ScalarTensor;
            }
        }

        /// <summary>
        /// Negates all of the values of a tensor (flips the sign of each value in the tensor).
        /// </summary>
        /// <param name="Input">The tensor to negate</param>
        public static Tensor Tensor_Negate(Tensor Input)
        {
            //The best way to accomplish this, is to unfold the tensor, multiply each value by -1, and then fold the tensor
            FlatTensor Flat = FlatTensor.FromTensor(Input);
            FlatTensor Result = new FlatTensor(Flat.Count);

            //For each value in the flat tensor:
            for (int i = 0; i < Flat.Count; i++)
            {
                //Multiply the value by -1 and add it to the result
                Result[i] = Flat[i] * -1.0;
            }

            //Return the result
            return Result.ToTensor();
        }

        /// <summary>
        /// Multiplies a tensor by a scalar value.
        /// </summary>
        /// <param name="Input">The tensor to multiply</param>
        /// <param name="Scalar">The scalar to multiply by</param>
        public static Tensor Tensor_Multiply(Tensor Input, double Scalar)
        {
            //Create a flat tensor from the input and another one for the result
            FlatTensor Flat = FlatTensor.FromTensor(Input);
            FlatTensor Result = new FlatTensor(Flat.Count);

            //For each value in the flat tensor:
            for (int i = 0; i < Flat.Count; i++)
            {
                //Multiply the value by the scalar and add it to the result
                Result[i] = Flat[i] * Scalar;
            }

            //Return the result
            return Result.ToTensor();
        }


        /// <summary>
        /// Divides a tensor by a scalar
        /// </summary>
        /// <param name="Input">The tensor to divide from</param>
        /// <param name="Scalar">The scalar to divide by</param>
        public static Tensor Tensor_Divide(Tensor Input, double Scalar)
        {
            //Create a flat tensor from the input and another one for the result
            FlatTensor Flat = FlatTensor.FromTensor(Input);
            FlatTensor Result = new FlatTensor(Flat.Count);

            //For each value in the flat tensor:
            for (int i = 0; i < Flat.Count; i++)
            {
                //Divide the value of the tensor by the scalar and add it to the result
                Result[i] = Flat[i] / Scalar;
            }

            //Return the result
            return Result.ToTensor();
        }
    }
}
