using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
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
            var lastNode = matrix1.GetLength(1) - 1;
            var children = GetConnectedEdges(matrix1, node).ToArray();
            while (!children.Any())
            {
                if (node >= lastNode) 
                    break;
                children = GetConnectedEdges(matrix1, node++).ToArray();
            }
            return !HasCycle(matrix1, node, new HashSet<int>());
        }

        private static bool HasCycle(in bool[,] matrix1, int node, in HashSet<int> path)
        {
            if (path.Contains(node))
                return true;
            var current = new HashSet<int>(path) { node };

            var shade = matrix1;
            return GetConnectedEdges(matrix1, node).Any(child => HasCycle(shade, child, current));
        }

        /// <summary>
        /// Returns indexes of outgoing connections for node
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="node"></param>
        /// <returns></returns>
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

        #endregion
    }
}