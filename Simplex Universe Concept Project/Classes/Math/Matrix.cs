using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Math
{
    /// <summary>
    /// Represents a mathematical matrix of numerical values.
    /// </summary>
    public class Matrix : List<List<double>>
    {
        /// <summary>
        /// Creates a new 2x2 matrix.
        /// </summary>
        public Matrix()
        {
            this.Capacity = 2;
            this.Add(new List<double>(2));
            this.Add(new List<double>(2));
            this[0].Add(0);
            this[0].Add(0);
            this[1].Add(0);
            this[1].Add(0);
        }

        /// <summary>
        /// Creates a new matrix with a particular number of rows and columns.
        /// </summary>
        /// <param name="NumberRows">The number of rows to be contained in the matrix</param>
        /// <param name="NumberColumns">The number of columns to be contained in the matrix</param>
        public Matrix(int NumberRows, int NumberColumns)
        {
            this.Capacity = NumberRows;
            for (int i = 0; i < NumberRows; i++)
            {
                this.Add(new List<double>(NumberColumns));
                for (int j = 0; j < NumberColumns; j++)
                {
                    this[i].Add(0);
                }
            }
        }

        /// <summary>
        /// Gets the number of rows contained in the matrix.
        /// </summary>
        public int NumberRows
        {
            get
            {
                return this.Capacity;
            }
        }

        /// <summary>
        /// Gets the number of columns contained in the matrix.
        /// </summary>
        public int NumberColumns
        {
            get
            {
                return this[0].Capacity;
            }
        }

        /// <summary>
        /// Returns a full copy of a given matrix. Assumes the matrix is not jagged (equal number of columns for each row).
        /// </summary>
        /// <param name="MatrixToCopy">The matrix to copy</param>
        public static Matrix Matrix_Copy(Matrix MatrixToCopy)
        {
            Matrix CopyMatrix = new Matrix(MatrixToCopy.NumberRows, MatrixToCopy.NumberColumns);

            for (int i = 0; i < MatrixToCopy.NumberRows; i++)
            {
                for (int j = 0; j < MatrixToCopy.NumberColumns; j++)
                {
                    CopyMatrix[i][j] = MatrixToCopy[i][j];
                }
            }

            return CopyMatrix;
        }

        /// <summary>
        /// Computes the addition between two same-size matricies.
        /// </summary>
        /// <param name="Matrix1">The first matrix to add</param>
        /// <param name="Matrix2">The second matrix to add</param>
        public static Matrix Matrix_Add(Matrix Matrix1, Matrix Matrix2)
        {
            if (!Matrix_IsSameSize(Matrix1, Matrix2)) throw new Exception("Matricies do not have the same dimensions!");
            
            Matrix ReturnMatrix = Matrix_Copy(Matrix1);

            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    ReturnMatrix[i][j] += Matrix2[i][j];
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Returns if two matricies have the name number of rows and columns.
        /// </summary>
        /// <param name="Matrix1">The first matrix to compare</param>
        /// <param name="Matrix2">The second matrix to compare</param>
        public static bool Matrix_IsSameSize(Matrix Matrix1, Matrix Matrix2)
        {
            return (Matrix1.NumberRows == Matrix2.NumberRows && Matrix1.NumberColumns == Matrix2.NumberColumns);
        }

        /// <summary>
        /// Computes the subtraction between two same-size matricies (Matrix1 - Matrix2).
        /// </summary>
        /// <param name="Matrix1">The matrix to subtract from</param>
        /// <param name="Matrix2">The matrix to subtract</param>
        public static Matrix Matrix_Subtract(Matrix Matrix1, Matrix Matrix2)
        {
            if (!Matrix_IsSameSize(Matrix1, Matrix2)) throw new Exception("Matricies do not have the same dimensions!");

            Matrix ReturnMatrix = Matrix_Copy(Matrix1);

            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    ReturnMatrix[i][j] -= Matrix2[i][j];
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Computes the scalar multiplication of a matrix.
        /// </summary>
        /// <param name="InputMatrix">The matrix to multiply</param>
        /// <param name="Scalar">The scalar to multiply</param>
        public static Matrix Matrix_Multiply(Matrix InputMatrix, double Scalar)
        {
            Matrix ReturnMatrix = Matrix_Copy(InputMatrix);

            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    ReturnMatrix[i][j] *= Scalar;
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Computes the multiplication of two matricies where the number of columns in Matrix1 is equal to the number of rows in Matrix2.
        /// </summary>
        /// <param name="Matrix1">The first matrix to multiply</param>
        /// <param name="Matrix2">The second matrix to multiply</param>
        public static Matrix Matrix_Multiply(Matrix Matrix1, Matrix Matrix2)
        {
            if (Matrix1.NumberColumns != Matrix2.NumberRows) throw new Exception("Invalid input. Matrix1.NumberColumns != Matrix2.NumberRows");

            //If A is an MxN matrix and B is an NxP matrix, then their matrix product AB is the MxP matrix
            Matrix ReturnMatrix = new Matrix(Matrix1.NumberRows, Matrix2.NumberColumns);

            //For each row in the return matrix:
            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                //For each column in the return matrix:
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    //Sum down the same row/column index
                    ReturnMatrix[i][j] = 0;
                    for (int k = 0; k < Matrix1.NumberColumns; k++)
                    {
                        ReturnMatrix[i][j] += Matrix1[i][k] * Matrix2[k][j];
                    }
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Negates a matrix (multiplies a matrix by -1).
        /// </summary>
        /// <param name="InputMatrix">The matrix to negate</param>
        public static Matrix Matrix_Negate(Matrix InputMatrix)
        {
            Matrix ReturnMatrix = Matrix_Copy(InputMatrix);

            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    ReturnMatrix[i][j] *= -1;
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Takes a NxM matrix and transposes it into a MxN matrix.
        /// </summary>
        /// <param name="InputMatrix">The matrix to transpose</param>
        public static Matrix Matrix_Transpose(Matrix InputMatrix)
        {
            //Flip the number of rows and columns
            Matrix ReturnMatrix = new Matrix(InputMatrix.NumberColumns, InputMatrix.NumberRows);

            for (int i = 0; i < ReturnMatrix.NumberRows; i++)
            {
                for (int j = 0; j < ReturnMatrix.NumberColumns; j++)
                {
                    ReturnMatrix[i][j] = InputMatrix[j][i];
                }
            }

            return ReturnMatrix;
        }

        /// <summary>
        /// Computes the summation of a particular row in this matrix.
        /// </summary>
        /// <param name="Index">The index of the row to calculate</param>
        public double RowSummation(int Index)
        {
            double Sum = 0;

            for (int i = 0; i < this[Index].Capacity; i++)
            {
                Sum += this[Index][i];
            }

            return Sum;
        }

        /// <summary>
        /// Computes the summation of a particular column in this matrix.
        /// </summary>
        /// <param name="Index">The index of the column to calculate</param>
        public double ColumnSummation(int Index)
        {
            double Sum = 0;

            for (int i = 0; i < this.Capacity; i++)
            {
                Sum += this[i][Index];
            }

            return Sum;
        }

        /// <summary>
        /// Overload for the addition operator (Matrix1 + Matrix2).
        /// </summary>
        public static Matrix operator +(Matrix Matrix1, Matrix Matrix2)
        {
            return Matrix_Add(Matrix1, Matrix2);
        }

        /// <summary>
        /// Overload for the subtraction operator (Matrix1 - Matrix2).
        /// </summary>
        public static Matrix operator -(Matrix Matrix1, Matrix Matrix2)
        {
            return Matrix_Subtract(Matrix1, Matrix2);
        }

        /// <summary>
        /// Overload for the negation operator (-Matrix).
        /// </summary>
        public static Matrix operator -(Matrix Matrix1)
        {
            return Matrix_Negate(Matrix1);
        }

        /// <summary>
        /// Overload for the multiplication operator for scalar multiplication (Matrix * Scalar).
        /// </summary>
        public static Matrix operator *(Matrix Matrix1, double Scalar)
        {
            return Matrix_Multiply(Matrix1, Scalar);
        }

        /// <summary>
        /// Overload for the multiplication operator for scalar multiplication (Matrix * Scalar).
        /// </summary>
        public static Matrix operator *(Matrix Matrix1, int Scalar)
        {
            return Matrix_Multiply(Matrix1, Scalar);
        }

        /// <summary>
        /// Overload for the multiplication operator for scalar multiplication (Scalar * Matrix).
        /// </summary>
        public static Matrix operator *(double Scalar, Matrix Matrix1)
        {
            return Matrix_Multiply(Matrix1, Scalar);
        }

        /// <summary>
        /// Overload for the multiplication operator for scalar multiplication (Scalar * Matrix).
        /// </summary>
        public static Matrix operator *(int Scalar, Matrix Matrix1)
        {
            return Matrix_Multiply(Matrix1, Scalar);
        }

        /// <summary>
        /// Overload for the multiplication operator for matrix multiplication (Matrix1 * Matrix2).
        /// </summary>
        public static Matrix operator *(Matrix Matrix1, Matrix Matrix2)
        {
            return Matrix_Multiply(Matrix1, Matrix2);
        }

        /// <summary>
        /// Calculates the determinate of a 2x2 or 3x3 square matrix.
        /// </summary>
        /// <param name="InputMatrix">The matrix to calculate</param>
        public static double Matrix_Determinate(Matrix InputMatrix)
        {
            if (!Matrix_IsSquare(InputMatrix)) throw new Exception("Input matrix must have the same number of rows and columns!");

            if (InputMatrix.NumberRows == 2)
            {
                return ((InputMatrix[0][0] * InputMatrix[1][1]) - (InputMatrix[0][1] * InputMatrix[1][0]));
            }
            else if (InputMatrix.NumberRows == 3)
            {
                double A = (InputMatrix[0][0] * InputMatrix[1][1] * InputMatrix[2][2]);
                double B = (InputMatrix[0][1] * InputMatrix[1][2] * InputMatrix[2][0]);
                double C = (InputMatrix[0][2] * InputMatrix[1][0] * InputMatrix[2][1]);
                double D = (InputMatrix[2][0] * InputMatrix[1][1] * InputMatrix[0][2]);
                double E = (InputMatrix[2][1] * InputMatrix[1][2] * InputMatrix[0][0]);
                double F = (InputMatrix[2][2] * InputMatrix[1][0] * InputMatrix[0][1]);

                return (A + B + C - D - E - F);
            }
            else
            {
                throw new Exception("Input matrix must be a 2x2 or 3x3 matrix!");
            }
        }

        /// <summary>
        /// Determines if a matrix is a square matrix (contains the same number of rows and columns).
        /// </summary>
        /// <param name="InputMatrix">The matrix to check</param>
        public static bool Matrix_IsSquare(Matrix InputMatrix)
        {
            return (InputMatrix.NumberRows == InputMatrix.NumberColumns);
        }

        /// <summary>
        /// Caclulates the trace (sum of the primary diagonal) of a square matrix.
        /// </summary>
        /// <param name="InputMatrix">The matrix to calculate</param>
        public static double Matrix_Trace(Matrix InputMatrix)
        {
            if (!Matrix_IsSquare(InputMatrix)) throw new Exception("Input matrix must have the same number of rows and columns!");

            double Sum = 0;
            for (int i = 0; i < InputMatrix.NumberRows; i++)
            {
                Sum += InputMatrix[i][i];
            }

            return Sum;
        }

        /// <summary>
        /// Creates a new matrix from a given 2d array of doubles.
        /// </summary>
        /// <param name="InputArray">The array to create the matrix from</param>
        public static Matrix Matrix_FromArray(double[][] InputArray)
        {
            throw new System.NotImplementedException();
        }
    }
}
