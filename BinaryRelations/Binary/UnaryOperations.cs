using System;
using System.Linq;
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
        /// Narrows matrix to the region defined by the set of X..Xi..Xn. Indexes are starting from 1 and will be sorted
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="x">index [1..n]</param> 
        /// <returns>binary matrix</returns>
        public static bool[,] Narrowing(this bool[,] matrix1, params int[] x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            ThrowIfNull_NotQuad(matrix1);
            var length = matrix1.GetLength(0);
            var set = x.Select(p => --p).OrderBy(a => a).ToList();  
            var result = new bool[x.Length, x.Length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (set.Contains(i) && set.Contains(j))
                        result[set.IndexOf(i), set.IndexOf(j)] = matrix1[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Narrows matrix  to the region defined by the set of X..Xi..Xn, but preserves it's original size. Indexes are starting from 1 and will be sorted
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="x">index [1..n]</param> 
        /// <returns>binary matrix</returns>
        public static bool[,] NarrowingPreserveSize(this bool[,] matrix1, params int[] x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            ThrowIfNull_NotQuad(matrix1);
            var length = matrix1.GetLength(0);
            var result = matrix1.Duplicate();
            x = x.Select(p => --p).OrderBy(a => a).ToArray();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!x.Contains(i) || !x.Contains(j))
                        result[i, j] = false;
                }
            }

            return result;
        }

        #endregion
    }
}