namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
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
    }
}