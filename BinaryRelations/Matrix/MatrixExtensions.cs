using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MaxRev.Extensions.Matrix
{
    public static class MatrixExtensions
    {
        #region Fill

        public static T[] Fill<T>(this T[] array, T value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var length = array.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                array[i] = value;
            }

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

        #endregion

        #region Coll & Row 

        public static T[] GetRow<T>(this T[,] matrix, in int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }

        public static void SetRow<T>(this T[,] matrix, in int row, in T[] rowVector)
        {
            var rowLength = matrix.GetLength(1);

            for (var i = 0; i < rowLength; i++)
                matrix[row, i] = rowVector[i];
        }

        public static T[] GetCol<T>(this T[,] matrix, in int col)
        {
            var colLength = matrix.GetLength(0);
            var colVector = new T[colLength];

            for (var i = 0; i < colLength; i++)
                colVector[i] = matrix[i, col];

            return colVector;
        }

        public static void SetCol<T>(this T[,] matrix, in int col, in T[] colVector)
        {
            var colLength = matrix.GetLength(0);

            for (var i = 0; i < colLength; i++)
                matrix[i, col] = colVector[i];
        }

        #endregion

        #region Transpose

        public static T[,] Transpose<T>(this T[,] array)
        {
            var r = new T[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    r[j, i] = array[i, j];
                }
            }

            return r;
        }

        #endregion

        #region Add array

        public static double[,] Add(this double[,] array1, in double val)
        {
            return Add<double>(array1, val);
        }

        public static float[,] Add(this float[,] array1, in float val)
        {
            return Add<float>(array1, val);
        }

        public static int[,] Add(this int[,] array1, in int val)
        {
            return Add<int>(array1, val);
        }

        private static T[,] Add<T>(this T[,] array1, in T value)
        {
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    r[i, j] = InlineOperation(array1[i, j], value, (x, y) => Expression.Add(x, y));
                }
            }

            return r;
        }

        #endregion

        #region Add array

        public static double[,] Add(this double[,] array1, in double[,] vector)
        {
            return Add<double>(array1, vector);
        }

        public static float[,] Add(this float[,] array1, in float[,] vector)
        {
            return Add<float>(array1, vector);
        }

        public static int[,] Add(this int[,] array1, in int[,] vector)
        {
            return Add<int>(array1, vector);
        }

        private static T[,] Add<T>(this T[,] array1, in T[,] array2)
        {
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    r[i, j] = InlineOperation(array1[i, j], array2[i, j], (x, y) => Expression.Add(x, y));
                }
            }

            return r;
        }

        #endregion

        #region Add vector

        public static double[] Add(this double[,] array1, in double[] vector)
        {
            return Add<double>(array1, vector);
        }

        public static float[] Add(this float[,] array1, in float[] vector)
        {
            return Add<float>(array1, vector);
        }

        public static int[] Add(this int[,] array1, in int[] vector)
        {
            return Add<int>(array1, vector);
        }

        private static T[] Add<T>(this T[,] array1, in T[] vector)
        {
            var r = new T[array1.GetLength(0)];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                T temp = default;
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    temp = InlineOperation(array1[i, j], vector[j], (x, y) => Expression.Add(x, y));
                }

                r[i] = temp;
            }

            return r;
        }

        #endregion

        #region Subtract matrix

        public static double[,] Subtract(this double[,] array1, in double[,] array2)
        {
            return Subtract<double>(array1, array2);
        }

        public static float[,] Subtract(this float[,] array1, in float[,] array2)
        {
            return Subtract<float>(array1, array2);
        }

        public static int[,] Subtract(this int[,] array1, in int[,] array2)
        {
            return Subtract<int>(array1, array2);
        }

        private static T[,] Subtract<T>(this T[,] array1, in T[,] array2)
        {
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    r[i, j] = InlineOperation(array1[i, j], array2[i, j], (x, y) => Expression.Subtract(x, y));
                }
            }

            return r;
        }

        #endregion

        #region Subtract vector

        public static double[] Subtract(this double[,] array1, in double[] vector)
        {
            return Subtract<double>(array1, vector);
        }

        public static float[] Subtract(this float[,] array1, in float[] vector)
        {
            return Subtract<float>(array1, vector);
        }

        public static int[] Subtract(this int[,] array1, in int[] vector)
        {
            return Subtract<int>(array1, vector);
        }

        private static T[] Subtract<T>(this T[,] array1, in T[] vector)
        {
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA];
            for (int i = 0; i < rA; i++)
            {
                T temp = default;
                for (int j = 0; j < cA; j++)
                {
                    temp = InlineOperation(array1[i, j], vector[j], (x, y) => Expression.Subtract(x, y));
                }

                r[i] = temp;
            }

            return r;
        }

        #endregion

        #region Multiply by vector

        public static double[] Multiply(this double[,] array1, in double[] vector)
        {
            return Multiply<double>(array1, vector);
        }

        public static float[] Multiply(this float[,] array1, in float[] vector)
        {
            return Multiply<float>(array1, vector);
        }

        public static int[] Multiply(this int[,] array1, in int[] vector)
        {
            return Multiply<int>(array1, vector);
        }

        private static T[] Multiply<T>(this T[,] array1, in T[] vector)
        {
            var r = new T[array1.GetLength(0)];
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                T temp = default;
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    temp = InlineOperation(temp,
                        InlineOperation(array1[i, j], vector[j], (x, y) => Expression.Multiply(x, y)),
                        (x, y) => Expression.Add(x, y));
                }

                r[i] = temp;
            }

            return r;
        }

        #endregion

        #region Multiply by value

        public static double[,] Multiply(this double[,] array1, in int x)
        {
            return Multiply<double>(array1, x);
        }

        public static float[,] Multiply(this float[,] array1, in int x)
        {
            return Multiply<float>(array1, x);
        }

        public static int[,] Multiply(this int[,] array1, in int x)
        {
            return Multiply<int>(array1, x);
        }

        private static T[,] Multiply<T>(this T[,] array1, in T x)
        {
            if (array1 == null) throw new ArgumentNullException(nameof(array1));
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    r[i, j] = InlineOperation(array1[i, j], x, (v, v1) => Expression.Multiply(v, v1));
                }
            }

            return r;
        }

        #endregion

        #region Power

        public static double[,] MatrixPower(this double[,] array1, in int n)
        {
            return MatrixPower<double>(array1, n);
        }

        public static float[,] MatrixPower(this float[,] array1, in int n)
        {
            return MatrixPower<float>(array1, n);
        }

        public static int[,] MatrixPower(this int[,] array1, in int n)
        {
            return MatrixPower<int>(array1, n);
        }

        private static T[,] MatrixPower<T>(this T[,] array1, in int n)
        {
            if (n == 1) return array1;
            var r = Multiply(array1, array1);
            return MatrixPower(r, n - 1);
        }

        #endregion

        #region Multiply

        public static float[,] Multiply(this float[,] array1, in float[,] array2)
        {
            return Multiply<float>(array1, array2);
        }

        public static double[,] Multiply(this double[,] array1, in double[,] array2)
        {
            return Multiply<double>(array1, array2);
        }

        public static int[,] Multiply(this int[,] array1, int[,] array2)
        {
            return Multiply<int>(array1, array2);
        }

        private static T[,] Multiply<T>(this T[,] array1, in T[,] array2)
        {
            ThrowIfSizeNotEqual(array1, array2);
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    for (int k = 0; k < rA; k++)
                    {
                        var tmp = InlineOperation(array1[i, k], array2[k, j], (x, y) => Expression.Multiply(x, y));
                        r[i, j] = InlineOperation(r[i, j], tmp, (x, y) => Expression.Add(x, y));
                    }
                }
            }

            return r;
        }

        #endregion

        #region MultiplyRecursively

        public static float[,] MultiplyRecursively(this float[,] array1, in float[,] array2)
        {
            return MultiplyRecursively<float>(array1, array2);
        }

        public static double[,] MultiplyRecursively(this double[,] array1, in double[,] array2)
        {
            return MultiplyRecursively<double>(array1, array2);
        }

        public static int[,] MultiplyRecursively(this int[,] array1, in int[,] array2)
        {
            return MultiplyRecursively<int>(array1, array2);
        }

        private static T[,] MultiplyRecursively<T>(this T[,] array1, in T[,] array2)
        {
            int rA = array1.GetLength(0);
            int cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    r[i, j] = InnerRecursively(array1, array2, i, j, array2.GetLength(0) - 1);
                }
            }

            return r;
        }

        private static T InnerRecursively<T>(T[,] array1, T[,] array2, in int i, in int j, in int k)
        {
            if (k < 0)
                return default;
            return InlineOperation(InlineOperation(array1[i, k], array2[k, j], (x, y) => Expression.Multiply(x, y)),
                InnerRecursively(array1, array2, i, j, k - 1), (x, y) => Expression.Add(x, y));
        }

        #endregion

        #region Dynamic

        private static readonly IDictionary<Type, Dictionary<string, Delegate>> _typeCache =
            new Dictionary<Type, Dictionary<string, Delegate>>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T InlineOperation<T>(T a, T b, Expression<Func<Expression, Expression, BinaryExpression>> rfunc)
        {
            var be = ((MethodCallExpression)rfunc.Body).Method.Name;
            var func = rfunc.Compile();
            var t = typeof(T);
            Func<T, T, T> mult;
            if (!_typeCache.TryGetValue(t, out var tmp) || !tmp.ContainsKey(be))
            {
                var lhs = Expression.Parameter(t);
                var rhs = Expression.Parameter(t);
                mult = (Func<T, T, T>)Expression.Lambda(func(lhs, rhs), lhs, rhs).Compile();
                if (!_typeCache.ContainsKey(t))
                    _typeCache[t] = new Dictionary<string, Delegate>();
                _typeCache[t].Add(be, mult);
            }
            else
            {
                mult = (Func<T, T, T>)tmp[be];
            }
            return mult(a, b);
        }
        #endregion

        #region Other

        public static void Print<T>(this T[,] arr, int floatTolerance = 5)
        {
            var a = arr.GetLength(0);
            var b = arr.GetLength(1);
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    string fx = default;
                    if (arr[i, j] is float f)
                        fx = f.ToString("f" + floatTolerance);
                    if (arr[i, j] is double d)
                        fx = d.ToString("f" + floatTolerance);
                    if (arr[i, j] is decimal dc)
                        fx = dc.ToString("f" + floatTolerance);
                    if (fx == default) fx = arr[i, j].ToString();
                    Console.Write(fx);
                    Console.Write(new string(' ', 1));
                }

                Console.WriteLine();
            }
        }
        public static void Print<T>(this T[] arr, int floatTolerance = 5)
        {
            var a = arr.GetLength(0);
            for (int i = 0; i < a; i++)
            {
                string fx = default;
                if (arr[i] is float f)
                    fx = f.ToString("f" + floatTolerance);
                if (arr[i] is double d)
                    fx = d.ToString("f" + floatTolerance);
                if (arr[i] is decimal dc)
                    fx = dc.ToString("f" + floatTolerance);
                if (fx == default) fx = arr[i].ToString();
                Console.Write(fx);
                Console.Write(new string(' ', 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ThrowIfSizeNotEqual<T>(this T[,] array1, in T[,] array2)
        {
            if (array1 == null) throw new ArgumentNullException(nameof(array1));
            if (array2 == null) throw new ArgumentNullException(nameof(array2));
            if (array1.GetLength(0) != array2.GetLength(0))
            {
                throw new ArgumentException("matrices sizes are not equal");
            }
        }

        #endregion

        #region Combinatorics

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from acc in accumulator
                    from item in sequence
                    select acc.Concat(new[] { item }));
        }

        public static IEnumerable<IEnumerable<IEnumerable<int>>> CartesianProductDistinctPairs(int size, int start = 1)
        {
            var range = Enumerable.Range(start, size).ToArray();
            for (var i = 1; i <= size; i++)
                yield return Permutations(range, i);
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> array, int elementsInArray)
        {
            var range = array as T[] ?? array.ToArray();
            var i = 1;
            foreach (var item in range)
            {
                if (elementsInArray == 1)
                {
                    yield return new[] { item };
                }
                else
                {
                    foreach (var result in Permutations(range.Skip(i++), elementsInArray - 1))
                        yield return new[] { item }.Concat(result);
                }
            }
        }

        #endregion
    }
}