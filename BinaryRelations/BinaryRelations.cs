using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MaxRev.Extensions.Matrix;

namespace MaxRev.Extensions.Binary
{
    public static class BinaryRelations
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

        #region Argument check

        private static void ThrowIfNull(params object[] matrix1)
        {
            foreach (object o in matrix1)
            {
                if (o == null) throw new ArgumentNullException(nameof(o));
            }
        }

        private static void ThrowIfNotQuad<T>(T[,] array1)
        {
            if (array1.GetLength(0) != array1.GetLength(1))
            {
                throw new ArgumentNullException(nameof(array1), "This matrix must be a quad matrix");
            }
        }

        private static void ThrowIfNull_NotQuad<T>(T[,] array1)
        {
            ThrowIfNull(array1);
            ThrowIfNotQuad(array1);
        }

        private static void ThrowIfNull_NotQuad_SizeDiffers<T>(T[,] array1, T[,] array2)
        {
            ThrowIfNull(array1, array2);
            ThrowIfNotQuad(array1);
            if (array1.GetLength(0) != array2.GetLength(0))
            {
                throw new ArgumentException("matrices sizes are not equal");
            }
        }

        #endregion

        #region Binary Operations

        /// <summary>
        /// An intersection of two binary matrices
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="maxrix2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Intersection(this bool[,] matrix1, bool[,] maxrix2)
        {
            ThrowIfNull_NotQuad_SizeDiffers(matrix1, maxrix2);
            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    // min of two cells
                    result[i, j] = matrix1[i, j] & maxrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Union of two binary matrices
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="maxrix2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Union(this bool[,] matrix1, bool[,] maxrix2)
        {
            ThrowIfNull_NotQuad_SizeDiffers(matrix1, maxrix2);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    // max of two cells
                    result[i, j] = matrix1[i, j] | maxrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Finds a difference between two binary matrices
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="maxrix2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Difference(this bool[,] matrix1, bool[,] maxrix2)
        {
            ThrowIfNull_NotQuad_SizeDiffers(matrix1, maxrix2);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = matrix1[i, j] && !maxrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a b-matrix of symmetric difference between two b-matrices
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="maxrix2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] SymmetricDifference(this bool[,] matrix1, bool[,] maxrix2)
        {
            ThrowIfNull_NotQuad_SizeDiffers(matrix1, maxrix2);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            // next code is equal to a block below, but more efficient)
            //  var m1 = matrix1.Difference(maxrix2);
            //  var m2 = maxrix2.Difference(matrix1);
            //  return m1.Union(m2);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result[i, j] = maxrix2[i, j] ^ matrix1[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// A product of two b-matrices
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <param name="maxrix2">binary matrix</param>
        /// <returns>binary matrix</returns>
        public static bool[,] Product(this bool[,] matrix1, bool[,] maxrix2)
        {
            ThrowIfNull_NotQuad_SizeDiffers(matrix1, maxrix2);

            var length = matrix1.GetLength(0);
            var result = new bool[length, length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    var max = false;

                    for (int k = 0; k < length; k++)
                    {
                        max |= matrix1[i, k] & maxrix2[k, j];
                    }

                    result[i, j] = max;
                }

            }

            return result;
        }

        #endregion

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

        #region Closures

        /// <summary>
        /// Returns a transitive closure for a provided one. Floyd–Warshall algorithm
        /// <see href="http://courses.ics.hawaii.edu/ReviewICS241/morea/relations/Relations4-QA.pdf"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool[,] TransitiveClosure(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            var result = (bool[,])matrix1.Clone();
            for (int k = 0; k < length; k++)
                for (int i = 0; i < length; i++)
                    for (int j = 0; j < length; j++)
                        result[i, j] = result[i, j] || result[i, k] && result[k, j];

            return result;
        }

        /// <summary>
        /// Returns a reflexive closure for a provided one.
        /// <see href="http://courses.ics.hawaii.edu/ReviewICS241/morea/relations/Relations4-QA.pdf"/> 
        /// </summary>
        /// <param name="matrix1"></param> 
        /// <returns></returns>
        public static bool[,] ReflexiveClosure(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            var result = (bool[,])matrix1.Clone();
            for (int i = 0; i < length; i++)
            {
                result[i, i] = true;
            }

            return result;
        }

        /// <summary>
        /// Returns a reflexive closure for a provided one.
        /// <see href="http://courses.ics.hawaii.edu/ReviewICS241/morea/relations/Relations4-QA.pdf"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool[,] SymmetricClosure(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            var result = (bool[,])matrix1.Clone();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (result[i, j])
                    {
                        result[j, i] = true;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Extremums

        /// <summary>
        /// Returns true if matrix have any relational maximum
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMaximum(this bool[,] matrix1) => GetMaximums(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational minimum
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMinimum(this bool[,] matrix1) => GetMinimums(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational majorants
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMajorant(this bool[,] matrix1) => GetMajorants(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational minorants
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMinorant(this bool[,] matrix1) => GetMinorants(matrix1).Any();

        /// <summary>
        /// Returns indexes of relations those are maximums
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMaximums(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var notFound = false;

                for (int j = 0; j < length; j++)
                {
                    if (!matrix1[i, j])
                    {
                        notFound = true;
                        break;
                    }
                }

                if (!notFound)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are minimums
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMinimums(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var notFound = false;

                for (int j = 0; j < length; j++)
                {
                    if (!matrix1[j, i])
                    {
                        notFound = true;
                        break;
                    }
                }

                if (!notFound)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are majorants
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMajorants(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var notFound = false;

                for (int j = 0; j < length; j++)
                {
                    if (matrix1[j, i])
                    {
                        notFound = true;
                        break;
                    }
                }

                if (!notFound)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are minorants
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMinorants(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var notFound = false;
                for (int j = 0; j < length; j++)
                {
                    if (matrix1[i, j])
                    {
                        notFound = true;
                        break;
                    }
                }

                if (!notFound)
                    yield return i;
            }
        }

        #endregion

        #region Relation properties check

        /// <summary>
        /// Is a total relation binary matrix 
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsTotalRelation(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (!matrix1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is matrix anti-diagonal related
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsAntiDiagonalRelation(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j && matrix1[i, j])
                        return false;
                    if (i != j && !matrix1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is matrix diagonal related
        /// </summary>
        /// <param name="matrix1">binary matrix</param>
        /// <returns>bool</returns>
        public static bool IsDiagonalRelation(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j && !matrix1[i, j])
                        return false;
                    if (i != j && matrix1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Matrix is reflexive if every element of it is related to itself
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsReflexive(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j && !matrix1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// True if it is a ir-reflexive binary relation 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsAntiReflexive(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j && matrix1[i, j])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is this matrix is a symmetric relation
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsSymmetric(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && matrix1[i, j] != matrix1[j, i])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is this matrix is a asymmetric relation
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsAsymmetric(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && matrix1[i, j])
                        if (matrix1[j, i])
                            return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is this matrix is a antisymmetric relation
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsAntiSymmetric(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && matrix1[i, j] == matrix1[j, i])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Is this matrix is a transitive relation
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsTransitive(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        if (matrix1[i, k] && matrix1[k, j])
                            if (!matrix1[i, j])
                                return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is this matrix is a negative transitive relation.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsNegativeTransitive(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.Complementation().IsTransitive();
        }

        /// <summary>
        /// Is this matrix is an acyclic relation
        /// A binary relation is acyclic if it contains no "cycles": equivalently, its transitive closure is antisymmetric.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsAcyclic(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            var node = 0;
            var children = GetConnectedEdges(matrix1, node).ToArray();
            while (!children.Any() || node != matrix1.GetLength(1) - 1)
            {
                children = GetConnectedEdges(matrix1, ++node).ToArray();
            }
            return !HasCycle(matrix1, node, new HashSet<int>());
        }

        private static bool HasCycle(in bool[,] matrix1, int node, in HashSet<int> path)
        {
            if (path.Contains(node))
                return true;
            var current = new HashSet<int>(path) { node };

            foreach (var child in GetConnectedEdges(matrix1, node))
            {
                if (HasCycle(matrix1, child, current))
                    return true;
            }

            return false;
        }

        public static IEnumerable<int> GetConnectedEdges(this bool[,] matrix, int node)
        {
            if (node < 0 || node >= matrix.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(node));
            var rowLength = matrix.GetLength(1);
            for (var i = 0; i < rowLength; i++)
                if (matrix[node, i])
                    yield return i;
        }

        /// <summary>
        /// Is this matrix is a connex relation
        /// <see href="https://www.wikiwand.com/en/Connex_relation"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsConnex(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && !(matrix1[i, j] || matrix1[j, i] ||
                                    matrix1[i, j] && matrix1[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #region Derived rules

        /// <summary>
        /// Is this matrix is a non transitive relation.
        /// <para>Relation is NOT <see cref="IsTransitive"/> and NOT <see cref="IsNegativeTransitive"/> </para>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsNonTransitive(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return !matrix1.IsTransitive() && !matrix1.IsNegativeTransitive();
        }

        /// <summary>
        /// Relation is NOT <see cref="IsSymmetric"/> and NOT <see cref="IsAntiSymmetric"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsNonSymmetric(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return !matrix1.IsSymmetric() && !matrix1.IsAntiSymmetric();
        }

        /// <summary>
        /// Relation is <see cref="IsReflexive"/> and <see cref="IsSymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsEquivalence(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsSymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsSymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsPartialEquivalence(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsSymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsReflexive"/> and <see cref="IsAntiSymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsNonStrictOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsAntiSymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsAntiReflexive"/> and <see cref="IsAntiSymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsStrictOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsAntiReflexive() && matrix1.IsAntiSymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsReflexive"/> and <see cref="IsAntiSymmetric"/> and <see cref="IsTransitive"/> and <see cref="IsConnex"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsLinearOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsAntiSymmetric() && matrix1.IsTransitive() && matrix1.IsConnex();
        }

        /// <summary>
        /// Relation is <see cref="IsReflexive"/> and <see cref="IsAntiSymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsPartialOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsAntiSymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsAntiReflexive"/> and <see cref="IsAsymmetric"/> and <see cref="IsTransitive"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsStrictPartialOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsAntiReflexive() && matrix1.IsAsymmetric() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsAntiReflexive"/> and <see cref="IsAsymmetric"/> and <see cref="IsTransitive"/> and <see cref="IsConnex"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsStrictLinearOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsAntiReflexive() && matrix1.IsAsymmetric() && matrix1.IsTransitive() && matrix1.IsConnex();
        }

        /// <summary>
        /// Relation is <see cref="IsReflexive"/> and <see cref="IsTransitive"/> and <see cref="IsConnex"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsTotalOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsTransitive() && matrix1.IsConnex();
        }

        /// <summary>
        /// Preorder or quasiorder. Relation is <see cref="IsReflexive"/> and <see cref="IsTransitive"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsPreOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Strict preorder or strict quasiorder. Relation is <see cref="IsAntiReflexive"/> and <see cref="IsTransitive"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsStrictPreOrder(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsAntiReflexive() && matrix1.IsTransitive();
        }

        /// <summary>
        /// Relation is <see cref="IsAntiReflexive"/> and <see cref="IsAsymmetric"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsTournament(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsAntiReflexive() && matrix1.IsAsymmetric();
        }

        /// <summary>
        /// Is a finite tolerance relation. Implies that it <see cref="IsReflexive"/> and <see cref="IsSymmetric"/> 
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool IsDependency(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);
            return matrix1.IsReflexive() && matrix1.IsSymmetric();
        }

        #endregion

        #endregion
    }
}