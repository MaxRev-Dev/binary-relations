using System;
using System.IO;

namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
        #region Helpers

        /// <summary>
        /// Creates diagonal matrix with the same size of given matrix
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool[,] GetDiagonalRelation(this bool[,] matrix1)
        {
            ThrowIfNotQuad(matrix1);
            return GetDiagonalRelation(matrix1.GetLength(0));
        }

        /// <summary>
        /// Creates a diagonal matrix of specified length
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static bool[,] GetDiagonalRelation(int len)
        {
            if (len <= 0) throw new ArgumentOutOfRangeException(nameof(len));
            var matrix1 = new bool[len, len];

            for (int i = 0; i < len; i++)
            {
                matrix1[i, i] = true;
            }

            return matrix1;
        }

        /// <summary>
        /// Converts elements of one dimensional array from <see cref="R"/> to <see cref="T"/> 
        /// </summary>
        /// <typeparam name="R">convert from</typeparam>
        /// <typeparam name="T">convert to</typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Cast<R, T>(this R[] array)
        {
            ThrowIfNull(array);

            var length = array.GetLength(0);
            var result = new T[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = (T)Convert.ChangeType(array[i], typeof(T));
            }

            return result;
        }

        /// <summary>
        /// Converts elements of two dimensional array from <see cref="R"/> to <see cref="T"/> 
        /// </summary>
        /// <typeparam name="R">convert from</typeparam>
        /// <typeparam name="T">convert to</typeparam>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static T[,] Cast<R, T>(this R[,] matrix1)
        {
            ThrowIfNull(matrix1);

            var length = matrix1.GetLength(0);
            var result = new T[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = (T)Convert.ChangeType(matrix1[i, j], typeof(T));
                }
            }

            return result;
        }

        /// <summary>
        /// Prints matrix to <see cref="Console.Out"/> or specified text writer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix1"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static T[,] PrintThrough<T>(this T[,] matrix1, TextWriter writer = default)
        {
            ThrowIfNull(matrix1);
            if (writer == default) writer = Console.Out;
            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    writer.Write(matrix1[i, j].ToString() + ' ');
                }
                writer.WriteLine("");
            }

            return matrix1;
        }

        /// <summary>
        /// Prints matrix to <see cref="Console.Out"/> or specified text writer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix1"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static T[] PrintThrough<T>(this T[] matrix1, TextWriter writer = default)
        {
            ThrowIfNull(matrix1);
            if (writer == default) writer = Console.Out;
            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                writer.Write(matrix1[i].ToString() + ' ');
            }

            return matrix1;
        }

        /// <summary>
        /// Sequentially compares elements of two-dimensional arrays using <see cref="object.ReferenceEquals"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public static bool IsReferenceSequenceEqualTo<T>(this T[,] matrix1, T[,] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
                return false;
            var len1 = matrix1.GetLength(0);
            var len2 = matrix1.GetLength(1);
            if (len1 != matrix2.GetLength(0)
                && len2 != matrix2.GetLength(1))
                return false;
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (!ReferenceEquals(matrix1[i, j], matrix2[i, j]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sequentially compares elements of arrays using <see cref="object.ReferenceEquals"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        public static bool IsReferenceSequenceEqualTo<T>(this T[] matrix1, T[] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
                return false;
            var len1 = matrix1.GetLength(0);
            var len2 = matrix1.GetLength(1);
            if (len1 != matrix2.GetLength(0)
                && len2 != matrix2.GetLength(1))
                return false;
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if (!ReferenceEquals(matrix1[i], matrix2[i]))
                        return false;
                }
            }

            return true;
        }

        #endregion
    }
}