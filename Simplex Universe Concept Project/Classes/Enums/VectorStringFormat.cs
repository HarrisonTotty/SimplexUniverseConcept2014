using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Math.Enums
{
    /// <summary>
    /// Represents a possible string format for displaying a vector.
    /// </summary>
    public enum Vector_StringFormat
    {
        /// <summary>
        /// Display the vector in unit vector notation
        /// Ai + Bj + Ck
        /// </summary>
        UnitVector,

        /// <summary>
        /// Display the vector in bracket notation with "wakas"
        /// (A, B, C)
        /// </summary>
        Bracket,

        /// <summary>
        /// Display the vector in square bracket (matrix) notation
        /// [A, B, C]
        /// </summary>
        Matrix,
    }
}
