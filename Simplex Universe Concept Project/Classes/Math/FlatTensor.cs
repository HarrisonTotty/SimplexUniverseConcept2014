using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a tensor that has been flattened into a 1D array.
    /// This class is used by the primary tensor class to make tensor calculation easier to implement.
    /// </summary>
    /// <remarks>
    /// Assuming the origional rank 2 tensor with uniform underlying dimensionality:
    /// [6] [4] [8] [5] 
    /// [2] [1] [9] [7]
    /// [1] [3] [5] [8]
    /// [5] [9] [0] [2]
    /// 
    /// The below would the the flattened varient of the above:
    ///     Section 1         Section 2         Section 3         Section 4
    /// [6] [4] [8] [5] | [2] [1] [9] [7] | [1] [3] [5] [8] | [5] [9] [0] [2]
    /// 
    /// </remarks>
    public class FlatTensor : List<double>
    {
        /// <summary>
        /// Creates a new blank flat tensor of a particular length.
        /// </summary>
        public FlatTensor(int Length)
        {
            this.Capacity = Length;
        }

        /// <summary>
        /// The rank/order/degree of the origional tensor.
        /// </summary>
        public int Rank
        {
            get;
            set;
        }

        /// <summary>
        /// The underlying dimensionalities of each sub-rank of the origional tensor.
        /// </summary>
        public int[] Dimensionalities
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new flat tensor from a regular tensor.
        /// </summary>
        /// <param name="Input">The tensor to flatten</param>
        public static FlatTensor FromTensor(Tensor Input)
        {
            //Make sure the tensor is at least rank 2
            if (Input.Rank < 2) throw new Exception("Tensor does not have a high enough rank to compress.");

            //Obtain the dimensionalities of the tensor
            int[] Dim = Input.ObtainDimensionalities();

            //Compress the input to a 1D array
            List<double> Compressed = (List<double>)DataCompactor(Input.Data, Input.Rank);

            //Create a new flat tensor
            FlatTensor NewFlat = new FlatTensor(Compressed.Capacity);

            //Copy the values from the compressed array to the flat tensor
            for (int i = 0; i < Compressed.Capacity; i++)
            {
                NewFlat.Add(Compressed[i]);
            }

            //Copy all other relevant information
            NewFlat.Dimensionalities = Dim;
            NewFlat.Rank = Input.Rank;

            //Return the new flat tensor
            return NewFlat;
        }

        /// <summary>
        /// Creates a new tensor from this flattened tensor.
        /// </summary>
        public Tensor ToTensor()
        {
            throw new System.NotImplementedException();
        }


        /// <summary>
        /// Recursive function for compacting tensors into one-dimensional lists of doubles.
        /// </summary>
        /// <param name="RelativeData">The relative tensor data to work with</param>
        /// <param name="CurrentRank">The current sub-rank to work with</param>
        private static dynamic DataCompactor(dynamic RelativeData, int CurrentRank)
        {
            //If the current rank is two:
            if (CurrentRank == 2)
            {
                //Create a new list of doubles to store the data:
                List<double> ReturnList = new List<double>();

                //For each "row" of data:
                for (int i = 0; i < ((List<dynamic>)(RelativeData)).Count; i++)
                {
                    //Merge the row with the return list
                    ReturnList.AddRange((List<double>)(RelativeData[i]));
                }

                //Return the list of numbers
                ReturnList.Capacity = ReturnList.Count;
                return ReturnList;
            }
            else if (CurrentRank > 2) //If the current rank is greater than two:
            {
                //Create a new list of doubles to store the data:
                List<double> ReturnList = new List<double>();

                //For each relative dimensionality:
                for (int i = 0; i < ((List<dynamic>)(RelativeData)).Count; i++)
                {
                    //Obtain the next layer
                    dynamic NextLayer = DataCompactor(RelativeData[i], CurrentRank - 1);

                    //Add the range of data
                    ReturnList.AddRange((List<double>)(NextLayer));
                }

                //Return the list of numbers
                ReturnList.Capacity = ReturnList.Count;
                return ReturnList;
            }
            else //If the current rank is less than two:
            {
                //The data is already compacted
                return RelativeData;
            }
        }

        /// <summary>
        /// Squashes a list of underlying dimensionalities by one dimension.
        /// </summary>
        /// <param name="Dimensionalities">The list of underlying dimensionalities to squash</param>
        private static int[] SquashDimensionalities(int[] Dimensionalities)
        {
            //Create a new array of dimensionalities with a size one less than the starting array
            int[] NewDimensionalities = new int[Dimensionalities.Length - 1];

            //For each dimensionality in the new array:
            for (int i = 0; i < NewDimensionalities.Length; i++)
            {
                //Copy over the old dimensionality to the new array
                NewDimensionalities[i] = Dimensionalities[i];
            }

            //Multiply the last dimensionality in the new array by the last dimensionality in the old array
            NewDimensionalities[NewDimensionalities.Length - 1] *= Dimensionalities[NewDimensionalities.Length];

            //Return the new array of dimensionalities
            return NewDimensionalities;
        }



        private static dynamic DataExpander(dynamic RelativeData, int CurrentRank, int[] Dimensionalities)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Expands a list of underlying dimensionalities by one dimension. 
        /// </summary>
        /// <param name="SquashedDimensionalities">The list of dimensionalities to expand</param>
        /// <param name="OrigionalDimensionalities">The origional (fully expanded) list of dimensionalities</param>
        private static int[] ExpandDimensionalities(int[] SquashedDimensionalities, int[] OrigionalDimensionalities)
        {
            //Make sure we can expand
            if (SquashedDimensionalities.Length >= OrigionalDimensionalities.Length) throw new Exception("Cannot expand array of dimensionalities!");

            //Create a new array of dimensionalities with a size one greater than the squashed array
            int[] Expanded = new int[SquashedDimensionalities.Length + 1];

            //Copy over all of the indicies except for the last
            for (int i = 0; i < Expanded.Length - 1; i++)
            {
                Expanded[i] = OrigionalDimensionalities[i];
            }

            //The last index is equal to the previous last index divided by the index before the new last index
            Expanded[Expanded.Length - 1] = SquashedDimensionalities[SquashedDimensionalities.Length - 1] / Expanded[Expanded.Length - 2];

            //Return the expanded array
            return Expanded;
        }
    }
}
