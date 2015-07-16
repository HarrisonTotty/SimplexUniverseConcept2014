using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a range of values for testing conditions (for minimum/maximum/excluded values of sets).
    /// For example, mass typically excepts all values between [0, Infinity).
    /// Note that vectors are compared according to magnitude.
    /// </summary>
    [Serializable(), Description("Represents a range of values for testing conditions"), TypeConverter(typeof(TypeConverters.TypeConverter_ValidRangeCondition))]
    public class ValidRangeCondition
    {

        /// <summary>
        /// Creates a new valid range condition between two values.
        /// If lowerbound/upperbound are set to double.NaN, they will be ignored in testing.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the condition</param>
        /// <param name="Upperbound">The upperbound of the condition</param>
        /// <param name="LowerInclusive">Whether the lowerbound is inclusive</param>
        /// <param name="UpperInclusive">Whether the upperbound is inclusive</param>
        public ValidRangeCondition(double Lowerbound, double Upperbound, bool LowerInclusive, bool UpperInclusive)
        {
            this.MinimumValue = Lowerbound;
            this.MaximumValue = Upperbound;
            this.MinimumInclusive = LowerInclusive;
            this.MaximumInclusive = UpperInclusive;
            this.ExcludedValues = null;
        }


        /// <summary>
        /// Creates a new valid range condition between two vectors (their magnitudes will be extracted for testing).
        /// If lowerbound/upperbound are set to null, they will be ignored in testing.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the condition</param>
        /// <param name="Upperbound">The upperbound of the condition</param>
        /// <param name="LowerInclusive">Whether the lowerbound is inclusive</param>
        /// <param name="UpperInclusive">Whether the upperbound is inclusive</param>
        public ValidRangeCondition(Vector Lowerbound, Vector Upperbound, bool LowerInclusive, bool UpperInclusive)
        {
            if (Lowerbound != null)
            {
                this.MinimumValue = Lowerbound.Magnitude;
            }
            else
            {
                this.MinimumValue = double.NaN;
            }
            if (Upperbound != null)
            {
                this.MaximumValue = Upperbound.Magnitude;
            }
            else
            {
                this.MaximumValue = double.NaN;
            }
            
            this.MinimumInclusive = LowerInclusive;
            this.MaximumInclusive = UpperInclusive;
            this.ExcludedValues = null;
        }

        /// <summary>
        /// Creates a new valid range condition between two values with certain excluded values.
        /// If lowerbound/upperbound are set to double.NaN, they will be ignored in testing.
        /// </summary>
        /// <param name="Lowerbound">The lowerbound of the condition</param>
        /// <param name="Upperbound">The upperbound of the condition</param>
        /// <param name="ExcludedValues">The list of excluded values</param>
        /// <param name="LowerInclusive">Whether the lowerbound is inclusive</param>
        /// <param name="UpperInclusive">Whether the upperbound is inclusive</param>
        public ValidRangeCondition(double Lowerbound, double Upperbound, List<double> ExcludedValues, bool LowerInclusive, bool UpperInclusive)
        {
            this.MinimumValue = Lowerbound;
            this.MaximumValue = Upperbound;
            this.MinimumInclusive = LowerInclusive;
            this.MaximumInclusive = UpperInclusive;
            this.ExcludedValues = ExcludedValues;
        }


        /// <summary>
        /// Creates a new blank valid range condition using Double.NaN (and thus all IsValid requests will pass).
        /// </summary>
        public ValidRangeCondition()
        {
            this.MinimumValue = double.NaN;
            this.MaximumValue = double.NaN;
            this.MinimumInclusive = false;
            this.MaximumInclusive = false;
            this.ExcludedValues = null;
        }

        /// <summary>
        /// The maximum value (boundary) of the condition.
        /// </summary>
        [Category("Upperbound and Lowerbound"), Description("The maximum value (boundary) of the condition"), DefaultValue(double.PositiveInfinity)]
        public double MaximumValue
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum value (boundary) of the condition.
        /// </summary>
        [Category("Upperbound and Lowerbound"), Description("The minimum value (boundary) of the condition"), DefaultValue(double.NegativeInfinity)]
        public double MinimumValue
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the maximum value is inclusive.
        /// </summary>
        [Category("Upperbound and Lowerbound"), Description("Whether the maximum value is inclusive"), DefaultValue(false)]
        public bool MaximumInclusive
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the minimum value is inclusive.
        /// </summary>
        [Category("Upperbound and Lowerbound"), Description("Whether the minimum value is inclusive"), DefaultValue(false)]
        public bool MinimumInclusive
        {
            get;
            set;
        }

        /// <summary>
        /// Values to be excluded from the primary boundary test.
        /// For example if you had the maximum set to "+infinty" and the minimum set to "-infinity" (both non-inclusive) and added "0" to this list,
        /// it would be the same as "x belongs to (-infinity, +infinity) where x does not equal 0"
        /// </summary>
        [Category("Excluded Values"), Description("Values to be excluded from the primary boundary test")]
        public List<double> ExcludedValues
        {
            get;
            set;
        }


        /// <summary>
        /// Tests a value against this valid range condition (returns "true" if all conditions pass).
        /// </summary>
        /// <param name="TestValue">The value to test</param>
        public bool IsValid(dynamic TestValue)
        {
            //First test the lowerbound
            //If the value is inclusive:
            if (this.MinimumInclusive)
            {
                //It fails when the value is less than the minimum
                if (TestValue < this.MinimumValue) return false;
            }
            else //Otherwise if it is not inclusive:
            {
                //It fails when the value is less than or equal to the minimum
                if (TestValue <= this.MinimumValue) return false;
            }

            //Then test the upperbound
            //If the value is inclusive:
            if (this.MaximumInclusive)
            {
                //It fails when the value is greater than the maximum
                if (TestValue > this.MaximumValue) return false;
            }
            else //Otherwise if it is not inclusive:
            {
                //It fails when the value is greater than or equal to the maximum
                if (TestValue >= this.MaximumValue) return false;
            }


            //Now iterate through the exluded values
            if (this.ExcludedValues != null)
            {
                foreach (dynamic Val in this.ExcludedValues)
                {
                    //It fails if the values are the same
                    if (TestValue == Val) return false;
                }
            }

            //If everything passed
            return true;
        }


        /// <summary>
        /// Fits a particular input value into this range condition
        /// </summary>
        /// <param name="Input">The value to fit</param>
        public dynamic Resolve(dynamic Input)
        {
            //If the input is null, return null
            if (Input == null) return null;

            //If the input is already valid, then just return it
            if (this.IsValid(Input)) return Input;



            return Input;
        }
    }
}
