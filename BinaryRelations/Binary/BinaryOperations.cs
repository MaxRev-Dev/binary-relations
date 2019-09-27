namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
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
    }
}