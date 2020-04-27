using System;

namespace MaxRev.Extensions.Matrix
{
    public static partial class MatrixExtensions
    {
        // 
        // Original source https://jamesmccaffrey.wordpress.com/2015/03/06/inverting-a-matrix-using-c/
        //

        #region Inverse

        private static bool IsNotZero(this double num) => !num.IsZero();

        private static bool IsZero(this double num)
        {
            return Math.Abs(num) < 0.0001;
        }

        public static bool AreEqual(this double[,] matrixA,
            in double[,] matrixB, in double epsilon)
        {
            var aRows = matrixA.GetLength(0);
            var aCols = matrixA.GetLength(1);
            var bRows = matrixB.GetLength(0);
            var bCols = matrixB.GetLength(1);
            if (aRows != bRows || aCols != bCols)
                throw new Exception("Non-conformable matrices");

            for (var i = 0; i < aRows; ++i)
                for (var j = 0; j < aCols; ++j)
                    if (Math.Abs(matrixA[i, j] - matrixB[i, j]) > epsilon)
                        return false;
            return true;
        }

        public static bool AreEqual(this float[,] matrixA,
            in float[,] matrixB, in float epsilon)
        {
            var aRows = matrixA.GetLength(0);
            var aCols = matrixA.GetLength(1);
            var bRows = matrixB.GetLength(0);
            var bCols = matrixB.GetLength(1);
            if (aRows != bRows || aCols != bCols)
                throw new Exception("Non-conformable matrices");

            for (var i = 0; i < aRows; ++i)
                for (var j = 0; j < aCols; ++j)
                    if (Math.Abs(matrixA[i, j] - matrixB[i, j]) > epsilon)
                        return false;
            return true;
        }

        private static double[,] MatrixDecompose(double[,] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // returns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1); // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            var n = rows; // convenience

            var result = matrix.Duplicate();

            perm = new int[n]; // set up row permutation result
            for (var i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (var j = 0; j < n - 1; ++j) // each column
            {
                var colMax = Math.Abs(result[j, j]); // find largest val in col
                var pRow = j;
                for (var i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i, j]) > colMax)
                    {
                        colMax = Math.Abs(result[i, j]);
                        pRow = i;
                    }
                }
                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    var rowPtr = result.GetRow(pRow);
                    result.SetRow(pRow, result.GetRow(j));
                    result.SetRow(j, rowPtr);

                    var tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                // --------------------------------------------------
                // This part added later (not in original)
                // and replaces the 'return null' below.
                // if there is a 0 on the diagonal, find a good row
                // from i = j+1 down that doesn't have
                // a 0 in column j, and swap that good row with row j
                // --------------------------------------------------

                if (result[j, j].IsZero())
                {
                    // find a good row to swap
                    var goodRow = -1;
                    for (var row = j + 1; row < n; ++row)
                    {
                        if (result[row, j].IsNotZero())
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal
                    var rowPtr = result.GetRow(goodRow);
                    result.SetRow(goodRow, result.GetRow(j));
                    result.SetRow(j, rowPtr);

                    var tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                } 

                for (var i = j + 1; i < n; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (var k = j + 1; k < n; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }


            }
            return result;
        }

        /// <summary>
        /// Compute inverse matrix via LU decomposition
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] Inverse(this double[,] matrix)
        {
            var n = matrix.GetLength(0);
            var result = matrix.Duplicate();

            var lum = MatrixDecompose(matrix, out var perm,
                out _);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            var b = new double[n];
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    b[j] = i == perm[j] ? 1.0 : 0.0;
                }

                var x = HelperSolve(lum, b);

                for (var j = 0; j < n; ++j)
                    result[j, i] = x[j];
            }
            return result;
        }

        /// <summary>
        /// Compute matrix determinant via LU decomposition
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double Determinant(this double[,] matrix)
        {
            var lum = MatrixDecompose(matrix, out _, out var toggle);
            if (lum == null)
                throw new Exception("Unable to compute MatrixDeterminant");
            double result = toggle;
            for (var i = 0; i < lum.GetLength(0); ++i)
                result *= lum[i, i];
            return result;
        }

        private static double[] HelperSolve(double[,] luMatrix, double[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            var n = luMatrix.GetLength(0);
            var x = new double[n];
            b.CopyTo(x, 0);

            for (var i = 1; i < n; ++i)
            {
                var sum = x[i];
                for (var j = 0; j < i; ++j)
                    sum -= luMatrix[i, j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1, n - 1];
            for (var i = n - 2; i >= 0; --i)
            {
                var sum = x[i];
                for (var j = i + 1; j < n; ++j)
                    sum -= luMatrix[i, j] * x[j];
                x[i] = sum / luMatrix[i, i];
            }

            return x;
        }

        /// <summary>
        /// Solve Ax = b
        /// </summary>
        /// <param name="A"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[] SystemSolve(double[,] A, double[] b)
        {
            // Solve Ax = b
            var n = A.GetLength(0);

            // 1. decompose A
            var luMatrix = MatrixDecompose(A, out var perm,
                out _);
            if (luMatrix == null)
                return null;

            // 2. permute b according to perm[] into bp
            var bp = new double[b.GetLength(0)];
            for (var i = 0; i < n; ++i)
                bp[i] = b[perm[i]];

            // 3. call helper
            return HelperSolve(luMatrix, bp);
        }
        #endregion

    }
}