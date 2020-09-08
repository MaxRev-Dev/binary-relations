using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MaxRev.Extensions.Matrix
{
    public static partial class MatrixExtensions
    {
        #region Fill

        public static T[] Fill<T>(this T[] array, T value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var length = array.GetLength(0);

            for (var i = 0; i < length; i++)
            {
                array[i] = value;
            }

            return array;
        }

        public static T[,] Fill<T>(this T[,] array, T value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var length = array.GetLength(0);

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    array[i, j] = value;
                }
            }

            return array;
        }

        #endregion

        #region Coll & Row 

        internal static T[] GetRow<T>(this T[][] matrix, in int row)
        {
            var rowLength = matrix[0].Length;
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row][i];

            return rowVector;
        }

        internal static void SetRow<T>(this T[][] matrix, in int row, in T[] rowVector)
        {
            var rowLength = matrix[0].Length;

            for (var i = 0; i < rowLength; i++)
                matrix[row][i] = rowVector[i];
        }

        internal static T[] GetCol<T>(this T[][] matrix, in int col)
        {
            var colLength = matrix.Length;
            var colVector = new T[colLength];

            for (var i = 0; i < colLength; i++)
                colVector[i] = matrix[i][col];

            return colVector;
        }

        internal static void SetCol<T>(this T[][] matrix, in int col, in T[] colVector)
        {
            var colLength = matrix.Length;

            for (var i = 0; i < colLength; i++)
                matrix[i][col] = colVector[i];
        }

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
            var r = new T[array.GetLength(1), array.GetLength(0)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    r[j, i] = array[i, j];
                }
            }

            return r;
        }

        #endregion

        #region Multiply by value additional

        public static double[,] Multiply(this double[,] array1, in int x)
        {
            return Multiply(array1, (float)x);
        }

        public static float[,] Multiply(this float[,] array1, in int x)
        {
            return Multiply(array1, (float)x);
        }

        #endregion

        #region Multiply


        private static void CheckCollRowRule<T>(T[][] array1, in T[][] array2)
        {
            if (array1.Length == 0 ||
                array2.Length == 0) throw new InvalidOperationException("Empty matrix");
            if (array1[0].Length != array2.Length)
                throw new InvalidOperationException("Does not satisfy matrix rule - A must be m × n matrix and B is n × p");
        }

        private static void CheckCollRowRule<T>(T[,] array1, in T[,] array2)
        {
            if (array1.GetLength(0) == 0 ||
                array2.GetLength(0) == 0) throw new InvalidOperationException("Empty matrix");
            if (array1.GetLength(1) != array2.GetLength(0))
                throw new InvalidOperationException("Does not satisfy matrix rule - A must be m × n matrix and B is n × p");
        }

        #endregion

        #region MultiplyRecursively

        public static float[,] MultiplyRecursively(this float[,] array1, in float[,] array2)
        {
            return MultiplyRecursivelyImpl(array1, array2);
        }

        public static double[,] MultiplyRecursively(this double[,] array1, in double[,] array2)
        {
            return MultiplyRecursivelyImpl(array1, array2);
        }

        public static int[,] MultiplyRecursively(this int[,] array1, in int[,] array2)
        {
            return MultiplyRecursivelyImpl(array1, array2);
        }

        private static T[,] MultiplyRecursivelyImpl<T>(this T[,] array1, in T[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new T[rA, cA];
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
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
            var multOp = MultOp<T>();
            var addOp = AddOp<T>();
            return InnerRecursivelyCore(array1, array2, multOp, addOp, i, j, k);
        }

        private static T InnerRecursivelyCore<T>(T[,] array1, T[,] array2,
            Func<T, T, T> addOp, Func<T, T, T> multOp, in int i, in int j, in int k)
        {
            if (k < 0)
                return default;
            return addOp(multOp(array1[i, k], array2[k, j]),
                InnerRecursivelyCore(array1, array2, addOp, multOp, i, j, k - 1));
        }

        #endregion

        #region Dynamic

        private static readonly IDictionary<Type, Dictionary<string, Delegate>> _typeCache =
            new Dictionary<Type, Dictionary<string, Delegate>>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> AddOp<T>()
        {
            return InlineOperation<T>((x, y) => Expression.Add(x, y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Func<T, T, T> MultOp<T>()
        {
            return InlineOperation<T>((x, y) => Expression.Multiply(x, y));
        }

        private static Func<T, T, T> InlineOperation<T>(Expression<Func<Expression, Expression, BinaryExpression>> rfunc)
        {
            var be = ((MethodCallExpression)rfunc.Body).Method.Name;
            var t = typeof(T);
            Func<T, T, T> mult;
            if (_typeCache.TryGetValue(t, out var tmp) && tmp.ContainsKey(be))
            {
                mult = (Func<T, T, T>)tmp[be];
            }
            else
            {
                var lhs = Expression.Parameter(t);
                var rhs = Expression.Parameter(t);
                mult = (Func<T, T, T>)Expression.Lambda(rfunc.Compile()(lhs, rhs), lhs, rhs).Compile();
                if (!_typeCache.ContainsKey(t))
                    _typeCache[t] = new Dictionary<string, Delegate>();
                _typeCache[t].Add(be, mult);
            }

            return mult;
        }
        #endregion

        #region Allocate

        public static int[,] AllocateI(in int size)
        {
            return new int[size, size];
        }

        public static bool[,] AllocateB(in int size)
        {
            return new bool[size, size];
        }

        public static float[,] AllocateF(in int size)
        {
            return new float[size, size];
        }

        public static double[,] AllocateD(in int size)
        {
            return new double[size, size];
        }
        #endregion

        #region Identity

        public static int[,] Identity(int size)
        {
            return IdentityI(size);
        }

        public static int[,] IdentityI(in int size)
        {
            return IdentityInternal<int>(size);
        }

        public static float[,] IdentityF(in int size)
        {
            return IdentityInternal<float>(size);
        }

        public static double[,] IdentityD(in int size)
        {
            return IdentityInternal<double>(size);
        }

        private static T[,] IdentityInternal<T>(in int size)
        {
            var ret = new T[size, size];
            var val = (T)System.Convert.ChangeType(1, typeof(T));
            for (var i = 0; i < size; i++)
            {
                ret[i, i] = val;
            }
            return ret;
        }

        #endregion

        #region Convert

        public static T[][] Convert<T>(this T[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var ret = new T[m].Select(x => new T[n]).ToArray();
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    ret[i][j] = matrix[i, j];
                }
            }

            return ret;
        }

        public static T[,] Convert<T>(this T[][] matrix)
        {
            var m = matrix.Length;
            if (m == 0) throw new InvalidOperationException("Empty matrix");
            var n = matrix[0].Length;
            var ret = new T[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    ret[i, j] = matrix[i][j];
                }
            }

            return ret;
        }

        #endregion

        #region Print

        public static void Print<T>(this T[,] arr, int floatTolerance = 5)
        {
            var a = arr.GetLength(0);
            var b = arr.GetLength(1);
            for (var i = 0; i < a; i++)
            {
                for (var j = 0; j < b; j++)
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
            for (var i = 0; i < a; i++)
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

        #region Clone 

        public static T[][] Duplicate<T>(this T[][] matrix)
        {
            var result = new T[matrix.Length]
                .Select(x => new T[matrix[0].Length]).ToArray();
            for (var i = 0; i < matrix.Length; ++i)
                for (var j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        public static T[,] Duplicate<T>(this T[,] matrix)
        {
            var result = new T[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(0); ++i)
                for (var j = 0; j < matrix.GetLength(1); ++j)
                    result[i, j] = matrix[i, j];
            return result;
        }

        #endregion
    }
}