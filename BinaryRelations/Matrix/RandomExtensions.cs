using System;

namespace MaxRev.Extensions.Matrix
{
    public static class RandomExtensions
    {
        /// <summary>
        /// <see cref="MatrixRandomizer"/> alias
        /// </summary>
        public static MatrixRandomizer Default => MatrixRandomizer.Default;

        [Obsolete("Use Randomizer type")]
        public static int LowRandBounds
        {
            get => MatrixRandomizer.Default.LowRandBounds;
            set => MatrixRandomizer.Default.LowRandBounds = value;
        }

        [Obsolete("Use Randomizer type")]
        public static int MaxRandBounds
        {
            get => MatrixRandomizer.Default.MaxRandBounds;
            set => MatrixRandomizer.Default.MaxRandBounds = value;
        }

        /// <summary>
        /// Normalizes float point output of matrix randomizer. Default is 1.0 / 100
        /// </summary>
        [Obsolete("Use Randomizer type")]
        public static float Normalizer
        {
            get => MatrixRandomizer.Default.Normalizer;
            set => MatrixRandomizer.Default.Normalizer = value;
        }

        [Obsolete("Use Randomizer type")]
        public static void Randomize(double[,] array)
        {
            MatrixRandomizer.Default.Randomize(array);
        }

        [Obsolete("Use Randomizer type")]
        public static void Randomize(double[] array)
        {
            MatrixRandomizer.Default.Randomize(array);
        }

        [Obsolete("Use Randomizer type")]
        public static double[,] AllocateRandomSquareMatrix(int size)
        {
            var array = new double[size, size];
            MatrixRandomizer.Default.Randomize(array);
            return array;
        }

        [Obsolete("Use Randomizer type")]
        public static double[] AllocateRandomVector(int size)
        {
            var array = new double[size];
            MatrixRandomizer.Default.Randomize(array);
            return array;
        }

        [Obsolete("Use Randomizer type")]
        public static double[,] MatrixRandom(int size,
            double minVal, double maxVal)
        {
            return MatrixRandomizer.Default.MatrixRandomD(size, minVal, maxVal);
        }
    }
}
