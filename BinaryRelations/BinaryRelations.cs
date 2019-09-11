using System;
using System.IO;
using MaxRev.Extensions.Matrix;

namespace MaxRev.Extensions.Binary
{ 
    public static class BinaryRelations
    {
        /// <summary>
        /// Is a full related binary matrix 
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsFullRelation(this bool[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (!a1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is matrix anti-diagonal related
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsAntiDiagonalRelation(this bool[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (i == j && a1[i, j])
                        return false;
                    if (i != j && !a1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is matrix diagonal related
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsDiagonalRelation(this bool[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    if (i == j && !a1[i, j])
                        return false;
                    if (i != j && a1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// A complementation of two binary matrices 
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Complementation(this bool[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[i, j] = !a1[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// An intersection of two binary matrices
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="a2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Intersection(this bool[,] a1, bool[,] a2)
        {
            ThrowIfSizeDiffers(a1, a2);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    // min of two cells
                    ac[i, j] = a1[i, j] & a2[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// Union of two binary matrices
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="a2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Union(this bool[,] a1, bool[,] a2)
        {
            ThrowIfSizeDiffers(a1, a2);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    // max of two cells
                    ac[i, j] = a1[i, j] | a2[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// Finds a difference between two binary matrices
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="a2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Difference(this bool[,] a1, bool[,] a2)
        {
            ThrowIfSizeDiffers(a1, a2);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[i, j] = a1[i, j] && !a2[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// Returns a b-matrix of symmetric difference between two b-matrices
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="a2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] SymmetricDifference(this bool[,] a1, bool[,] a2)
        {
            ThrowIfSizeDiffers(a1, a2);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            // next code is equal to a block below, but more efficient)
            //  var m1 = a1.Difference(a2);
            //  var m2 = a2.Difference(a1);
            //  return m1.Union(m2);
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[i, j] = a2[i, j] ^ a1[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// A product of two b-matrices
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="a2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Product(this bool[,] a1, bool[,] a2)
        {
            ThrowIfSizeDiffers(a1, a2);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    var max = false;

                    for (int k = 0; k < l1; k++)
                    {
                        max |= a1[i, k] & a2[k, j];
                    }

                    ac[i, j] = max;
                }

            }

            return ac;
        }

        /// <summary>
        /// Transposes matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a1"></param>
        /// <returns>transposed matrix</returns>
        public static T[,] Reverse<T>(this T[,] a1)
        {
            ThrowIfNull(a1);
            return MatrixExtensions.Transpose(a1);
        }

        /// <summary>
        /// A dual b-matrix where all elements are inverted. Result equals to composition of <see cref="Complementation"/> and <see cref="Reverse{T}"/>
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Dual(this bool[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];

            // it's the same as
            // a1.Complementation().Reverse();

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[j, i] = !a1[i, j];
                }
            }

            return ac;
        }

        /// <summary>
        /// Narrows matrix to region defined by X1 and X2. Indexes are starting from 1 
        /// </summary>
        /// <param name="a1">binary matrix</param>
        /// <param name="x1">index [1..n]</param>
        /// <param name="x2">index [1..n]</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Narrowing(this bool[,] a1, int x1, int x2)
        {
            if (x1 > x2) throw new InvalidOperationException(nameof(x1) + " must be bigger than " + nameof(x2));
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new bool[l1, l2];
            x1--;
            x2--;
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[i, j] = i >= x1 && i <= x2
                               && j <= x2 && j >= x1
                               && a1[i, j];
                }
            }

            return ac;
        }
        
        /// <summary>
        /// Converts elements of two dimensional array from <see cref="R"/> to <see cref="T"/> 
        /// </summary>
        /// <typeparam name="R">convert from</typeparam>
        /// <typeparam name="T">convert to</typeparam>
        /// <param name="a1"></param>
        /// <returns></returns>
        public static T[,] Cast<R, T>(this R[,] a1)
        {
            ThrowIfNull(a1);
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            var ac = new T[l1, l2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    ac[i, j] = (T)Convert.ChangeType(a1[i, j], typeof(T));
                }
            }

            return ac;
        }

        /// <summary>
        /// Prints matrix to <see cref="Console.Out"/> or specified text writer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a1"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static T[,] PrintThrough<T>(this T[,] a1, TextWriter writer = default)
        {
            ThrowIfNull(a1);
            if (writer == default) writer = Console.Out;
            var l1 = a1.GetLength(0);
            var l2 = a1.GetLength(1);
            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < l2; j++)
                {
                    writer.Write(a1[i, j].ToString() + ' ');
                }
                writer.WriteLine("");
            }

            return a1;
        }

        private static void ThrowIfNull(params object[] a1)
        {
            foreach (object o in a1)
            {
                if (o == null) throw new ArgumentNullException(nameof(o));
            }
        }

        private static void ThrowIfSizeDiffers<T>(T[,] array1, T[,] array2)
        {
            ThrowIfNull(array1, array2);
            if (array1.GetLength(0) != array2.GetLength(0))
            {
                throw new ArgumentException("matrices sizes are not equal");
            }
        }
    }
}