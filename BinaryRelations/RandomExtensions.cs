using System;

namespace MaxRev.Extensions.Matrix
{
    public static class RandomExtensions
    {
        public static int LowRandBounds = 0;
        public static int MaxRandBounds = 1;
        /// <summary>
        /// Normalizes output of matrix randomizer
        /// </summary>
        public static double normalizer = 1.0 / 100.0;
        private static readonly Random _rand = new Random();
        public static void Randomize(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = _rand.Next(LowRandBounds, MaxRandBounds) * normalizer;
                }
            }
        }

        public static void Randomize(double[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = _rand.Next(LowRandBounds, MaxRandBounds);
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

    }
}