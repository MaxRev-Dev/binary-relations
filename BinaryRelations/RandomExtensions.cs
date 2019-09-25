using System;

namespace MaxRev.Extensions.Matrix
{
    public static class RandomExtensions
    {
        public static int LowRandBounds = 0;
        public static int MaxRandBounds = 100;
        /// <summary>
        /// Normalizes float point output of matrix randomizer. Default is 1.0 / 100
        /// </summary>
        public static double Normalizer = 1.0 / 100.0;
        private static readonly Random _rand = new Random();
        public static void Randomize(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = _rand.Next(LowRandBounds, MaxRandBounds) * Normalizer;
                }
            }
        }

        public static void Randomize(double[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = _rand.Next(LowRandBounds, MaxRandBounds) * Normalizer;
            }
        }

        public static double[,] AllocateRandomSquareMatrix(int size)
        {
            var array = new double[size, size];
            Randomize(array);
            return array;
        }

        public static double[] AllocateRandomVector(int size)
        {
            var array = new double[size];
            Randomize(array);
            return array;
        }

        public static T[,] Fill<T>(this T[,] array, T value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var length = array.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    array[i, j] = value;
                }
            }

            return array;
        }
    }
}
