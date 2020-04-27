 
using System; 


namespace MaxRev.Extensions.Matrix 
{
    public class MatrixRandomizer
    { 
        private readonly Random _random = new Random();
        private static MatrixRandomizer _instance;
        public static MatrixRandomizer Default => _instance ?? (_instance = new MatrixRandomizer());

        public int LowRandBounds { get; set; } = 0;
        public int MaxRandBounds { get; set; } = 100;
    
        /// <summary>
        /// Normalizes float point output of matrix randomizer. Default is 1.0 / 100
        /// </summary>
        public float Normalizer = 1.0f / 100.0f;
 
        public void Randomize(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = _random.Next(LowRandBounds, MaxRandBounds);
                }
            }
        }

        public void Randomize(int[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = _random.Next(LowRandBounds, MaxRandBounds);
            }
        }

        public int[,] AllocateRandomSquareMatrixI(int size)
        {
            var array = MatrixExtensions.AllocateI(size);
            Randomize(array);
            return array;
        }

        public int[] AllocateRandomVectorI(int size)
        {
            var array = new int[size];
            Randomize(array);
            return array;
        }

        public int[,] MatrixRandomI(int size, double minVal, double maxVal)
        {
            var result = MatrixExtensions.AllocateI(size);
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    result[i, j] = (int)(_random.NextDouble() * (maxVal - minVal) + minVal);
            return result;
        }
 
        public void Randomize(float[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   
                    array[i, j] = (float)(_random.Next(LowRandBounds, MaxRandBounds) * Normalizer);
                }
            }
        }

        public void Randomize(float[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                   
                array[i] = (float)(_random.Next(LowRandBounds, MaxRandBounds) * Normalizer);
            }
        }

        public float[,] AllocateRandomSquareMatrixF(int size)
        {
            var array = MatrixExtensions.AllocateF(size);
            Randomize(array);
            return array;
        }

        public float[] AllocateRandomVectorF(int size)
        {
            var array = new float[size];
            Randomize(array);
            return array;
        }

        public float[,] MatrixRandomF(int size, double minVal, double maxVal)
        {
            var result = MatrixExtensions.AllocateF(size);
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    result[i, j] = (float)(_random.NextDouble() * (maxVal - minVal) + minVal);
            return result;
        }
 
        public void Randomize(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                   
                    array[i, j] = (double)(_random.Next(LowRandBounds, MaxRandBounds) * Normalizer);
                }
            }
        }

        public void Randomize(double[] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                   
                array[i] = (double)(_random.Next(LowRandBounds, MaxRandBounds) * Normalizer);
            }
        }

        public double[,] AllocateRandomSquareMatrixD(int size)
        {
            var array = MatrixExtensions.AllocateD(size);
            Randomize(array);
            return array;
        }

        public double[] AllocateRandomVectorD(int size)
        {
            var array = new double[size];
            Randomize(array);
            return array;
        }

        public double[,] MatrixRandomD(int size, double minVal, double maxVal)
        {
            var result = MatrixExtensions.AllocateD(size);
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    result[i, j] = (double)(_random.NextDouble() * (maxVal - minVal) + minVal);
            return result;
        }
    }
}