using System;

namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
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
    }
}