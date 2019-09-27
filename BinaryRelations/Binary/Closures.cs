namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
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
    }
}