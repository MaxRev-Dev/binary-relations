using System;
using MaxRev.Extensions.Matrix;

namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
        #region Unary Operations

        /// <summary>
        /// A complementation to this matrix
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Complementation(this bool[,] matrix1)
        {
            ThrowIfNull(matrix1);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = !matrix1[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix1"></param>
        /// <returns>transposed matrix</returns>
        public static T[,] Reverse<T>(this T[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.Transpose();
        }

        /// <summary>
        /// A dual b-matrix where all elements are inverted. Result equals to composition of <see cref="Complementation"/> and <see cref="Reverse{T}"/>
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Dual(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            // it's the same as
            // matrix1.Complementation().Reverse();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[j, i] = !matrix1[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Narrows matrix to region defined by X1 and X2. Indexes are starting from 1 
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="x1">index [1..n]</param>
        /// <param name="x2">index [1..n]</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Narrowing(this bool[,] matrix1, int x1, int x2)
        {
            if (x1 > x2) throw new InvalidOperationException(nameof(x1) + " must be bigger than " + nameof(x2));
            ThrowIfNull_NotQuad(matrix1);
            var length = matrix1.GetLength(0);
            var result = new bool[length, length];
            x1--;
            x2--;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = i >= x1 && i <= x2
                               && j <= x2 && j >= x1
                               && matrix1[i, j];
                }
            }

            return result;
        }

        #endregion
    }
}