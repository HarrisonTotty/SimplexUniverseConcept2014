using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a mathematical complex number.
    /// </summary>
    [Serializable()]
    public class ComplexNumber
    {
        /// <summary>
        /// The "real" portion of the complex number.
        /// </summary>
        public double RealPortion
        {
            get;
            set;
        }

        /// <summary>
        /// The "complex" portion of the complex number.
        /// </summary>
        public double ComplexPortion
        {
            get;
            set;
        }

        /// <summary>
        /// Adds two complex numbers together.
        /// </summary>
        /// <param name="Num1">The first complex number</param>
        /// <param name="Num2">The second complex number</param>
        public static ComplexNumber ComplexNumber_Add(ComplexNumber Num1, ComplexNumber Num2)
        {
            ComplexNumber New = new ComplexNumber();

            New.ComplexPortion = Num1.ComplexPortion + Num2.ComplexPortion;
            New.RealPortion = Num1.RealPortion + Num2.RealPortion;

            return New;
        }

        /// <summary>
        /// Returns a copy of a complex number.
        /// </summary>
        /// <param name="Number">The complex number to copy</param>
        public static ComplexNumber ComplexNumber_Copy(ComplexNumber Number)
        {
            ComplexNumber New = new ComplexNumber();

            New.ComplexPortion = Number.ComplexPortion;
            New.RealPortion = Number.RealPortion;

            return New;
        }
    }
}
