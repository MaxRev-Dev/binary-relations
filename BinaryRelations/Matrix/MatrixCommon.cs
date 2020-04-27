 
using System;
using System.Linq; 


namespace MaxRev.Extensions.Matrix
{
    public static partial class MatrixExtensions
    { 
        #region Add array
       
        public static int[,] Add(this int[,] array1, in int value)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new int[rA, cA]; 

            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + value;
                }
            }

            return r;
        }
       
        public static float[,] Add(this float[,] array1, in float value)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new float[rA, cA]; 

            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + value;
                }
            }

            return r;
        }
       
        public static double[,] Add(this double[,] array1, in double value)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new double[rA, cA]; 

            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + value;
                }
            }

            return r;
        }

        public static int[] Add(this int[] array1, in int value)
        {
            var rA = array1.GetLength(0);
            var r = new int[rA];
             
            for (var i = 0; i < rA; i++)
            {
                r[i] = array1[i] + value;
            }

            return r;
        }

        public static float[] Add(this float[] array1, in float value)
        {
            var rA = array1.GetLength(0);
            var r = new float[rA];
             
            for (var i = 0; i < rA; i++)
            {
                r[i] = array1[i] + value;
            }

            return r;
        }

        public static double[] Add(this double[] array1, in double value)
        {
            var rA = array1.GetLength(0);
            var r = new double[rA];
             
            for (var i = 0; i < rA; i++)
            {
                r[i] = array1[i] + value;
            }

            return r;
        }

        public static int[,] Add(this int[,] array1, in int[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new int[rA, cA];
             
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + array2[i, j];
                }
            }

            return r; 
        }
        

        public static float[,] Add(this float[,] array1, in float[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new float[rA, cA];
             
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + array2[i, j];
                }
            }

            return r; 
        }
        

        public static double[,] Add(this double[,] array1, in double[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new double[rA, cA];
             
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] + array2[i, j];
                }
            }

            return r; 
        }
        
        #endregion

        #region Add vector

        public static int[] Add(this int[] a, in int[] b)
        {
            var ret = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] + b[i];
            }
            return ret;
        }

        public static float[] Add(this float[] a, in float[] b)
        {
            var ret = new float[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] + b[i];
            }
            return ret;
        }

        public static double[] Add(this double[] a, in double[] b)
        {
            var ret = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] + b[i];
            }
            return ret;
        }

        public static int[] Add(this int[,] array1, in int[] vector)
        {
            var r = new int[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                int temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] + vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        public static float[] Add(this float[,] array1, in float[] vector)
        {
            var r = new float[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                float temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] + vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        public static double[] Add(this double[,] array1, in double[] vector)
        {
            var r = new double[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                double temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] + vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        #endregion  
        
        #region Subtract vector

        public static int[] Subtract(this int[] a, in int[] b)
        {
            var ret = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] - b[i];
            }
            return ret;
        }

        public static float[] Subtract(this float[] a, in float[] b)
        {
            var ret = new float[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] - b[i];
            }
            return ret;
        }

        public static double[] Subtract(this double[] a, in double[] b)
        {
            var ret = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                ret[i] = a[i] - b[i];
            }
            return ret;
        }

        public static int[] Subtract(this int[,] array1, in int[] vector)
        {
            var r = new int[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                int temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] - vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        public static float[] Subtract(this float[,] array1, in float[] vector)
        {
            var r = new float[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                float temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] - vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        public static double[] Subtract(this double[,] array1, in double[] vector)
        {
            var r = new double[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                double temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp = array1[i, j] - vector[j];
                }

                r[i] = temp;
            }

            return r;
        }

        #endregion

        #region Subtract matrix

        public static int[,] Subtract(this int[,] array1, in int[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new int[rA, cA];
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] - array2[i, j];
                }
            }

            return r;
        }

        public static float[,] Subtract(this float[,] array1, in float[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new float[rA, cA];
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] - array2[i, j];
                }
            }

            return r;
        }

        public static double[,] Subtract(this double[,] array1, in double[,] array2)
        {
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new double[rA, cA];
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] = array1[i, j] - array2[i, j];
                }
            }

            return r;
        }

        #endregion    
        
        #region Opposite vector

        public static int[] Opposite(this int[] array1)
        {  
            return array1.Select(x => -x).ToArray();
        }

        public static float[] Opposite(this float[] array1)
        {  
            return array1.Select(x => -x).ToArray();
        }

        public static double[] Opposite(this double[] array1)
        {  
            return array1.Select(x => -x).ToArray();
        }

        #endregion               

        #region Multiply vector by vector

        public static int Multiply(this int [] array1, in int [] vector)
        { 
            int temp = default;
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                temp +=  array1[i] * vector[i];
            }
            return temp;
        }

        public static float Multiply(this float [] array1, in float [] vector)
        { 
            float temp = default;
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                temp +=  array1[i] * vector[i];
            }
            return temp;
        }

        public static double Multiply(this double [] array1, in double [] vector)
        { 
            double temp = default;
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                temp +=  array1[i] * vector[i];
            }
            return temp;
        }

        #endregion 
        
        #region Multiply vector by vector

        public static float[] Normalize(this float[] a)
        {
            if (a.Any(x => Math.Abs(x) > 1))
            {
                var b = new float[a.Length]; 
                var m = Math.Sqrt(a.Aggregate(default(float), (acc, x) => acc + x * x));
                for (int i = 0; i < a.Length; i++)
                    b[i] = (float)(a[i] / m);
                return b;
            } 
            return a; 
        }

        public static double[] Normalize(this double[] a)
        {
            if (a.Any(x => Math.Abs(x) > 1))
            {
                var b = new double[a.Length]; 
                var m = Math.Sqrt(a.Aggregate(default(double), (acc, x) => acc + x * x));
                for (int i = 0; i < a.Length; i++)
                    b[i] = (double)(a[i] / m);
                return b;
            } 
            return a; 
        }

<<<<<<< HEAD
        #endregion      
        
        #region Dot & Cross

 
        public static float Dot(this float[] v1, float[] v2)
        {
            return v1.Multiply(v2);
        }

        public static float Cross2D(this float[] v1, float[] v2)
        {
            return v1[0] * v2[1] - v1[1] * v2[0];
        }

        public static float[] Cross3D(this float[] v1, float[] v2)
        {
            return new[]
            {
                v1[1] * v2[2] - v1[2] * v2[1],
                -v1[0] * v2[2] + v1[2] * v2[0],
                v1[0] * v2[1] - v1[1] * v2[0],
            };
        }

 
        public static double Dot(this double[] v1, double[] v2)
        {
            return v1.Multiply(v2);
        }

        public static double Cross2D(this double[] v1, double[] v2)
        {
            return v1[0] * v2[1] - v1[1] * v2[0];
        }

        public static double[] Cross3D(this double[] v1, double[] v2)
        {
            return new[]
            {
                v1[1] * v2[2] - v1[2] * v2[1],
                -v1[0] * v2[2] + v1[2] * v2[0],
                v1[0] * v2[1] - v1[1] * v2[0],
            };
        }

=======
>>>>>>> 1d77d5e515cd99551e70aa0b10216284c45669dc
        #endregion

        #region Multiply  
        
        public static int[] Multiply(this int[,] array1, in int[] vector)
        {
            var r = new int[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                int temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp += array1[i, j] * vector[j];
                }

                r[i] = temp;
            }

            return r;
        }
        
        public static float[] Multiply(this float[,] array1, in float[] vector)
        {
            var r = new float[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                float temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp += array1[i, j] * vector[j];
                }

                r[i] = temp;
            }

            return r;
        }
        
        public static double[] Multiply(this double[,] array1, in double[] vector)
        {
            var r = new double[array1.GetLength(0)]; 
            for (var i = 0; i < array1.GetLength(0); i++)
            {
                double temp = default;
                for (var j = 0; j < array1.GetLength(1); j++)
                {
                    temp += array1[i, j] * vector[j];
                }

                r[i] = temp;
            }

            return r;
        }
    
       #region Multiply vector by matrix

        public static int[] Multiply(this int[] a, int[,] matrix)
        {
            var res = new int[a.Length]; 
            for (int u = 0; u < a.Length; u++)
            {
                var i = 0;
                res[u] = a.Aggregate(default(int), (acc, x) => acc + x * matrix[u, i++]);
            }
            return res;
        }


        public static float[] Multiply(this float[] a, float[,] matrix)
        {
            var res = new float[a.Length]; 
            for (int u = 0; u < a.Length; u++)
            {
                var i = 0;
                res[u] = a.Aggregate(default(float), (acc, x) => acc + x * matrix[u, i++]);
            }
            return res;
        }


        public static double[] Multiply(this double[] a, double[,] matrix)
        {
            var res = new double[a.Length]; 
            for (int u = 0; u < a.Length; u++)
            {
                var i = 0;
                res[u] = a.Aggregate(default(double), (acc, x) => acc + x * matrix[u, i++]);
            }
            return res;
        }

    
        #endregion
        
        public static int[,] Multiply(this int[,] array1, in int x)
        {
            if (array1 == null) throw new ArgumentNullException(nameof(array1));
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new int[rA, cA]; 
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] =  array1[i, j] * x;
                }
            }

            return r;
        }
        
        public static float[,] Multiply(this float[,] array1, in float x)
        {
            if (array1 == null) throw new ArgumentNullException(nameof(array1));
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new float[rA, cA]; 
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] =  array1[i, j] * x;
                }
            }

            return r;
        }
        
        public static double[,] Multiply(this double[,] array1, in double x)
        {
            if (array1 == null) throw new ArgumentNullException(nameof(array1));
            var rA = array1.GetLength(0);
            var cA = array1.GetLength(1);
            var r = new double[rA, cA]; 
            for (var i = 0; i < rA; i++)
            {
                for (var j = 0; j < cA; j++)
                {
                    r[i, j] =  array1[i, j] * x;
                }
            }

            return r;
        }
    
        
        public static int[][] Multiply(this int[][] array1, in int[][] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.Length;
            var n = array2.Length;
            var p = array2[0].Length;
            var r = new int[m].Select(x => new int[p]).ToArray(); 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i][j] += array1[i][k] * array2[k][j];
                    }
                }
            }

            return r;
        }
        
        public static float[][] Multiply(this float[][] array1, in float[][] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.Length;
            var n = array2.Length;
            var p = array2[0].Length;
            var r = new float[m].Select(x => new float[p]).ToArray(); 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i][j] += array1[i][k] * array2[k][j];
                    }
                }
            }

            return r;
        }
        
        public static double[][] Multiply(this double[][] array1, in double[][] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.Length;
            var n = array2.Length;
            var p = array2[0].Length;
            var r = new double[m].Select(x => new double[p]).ToArray(); 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i][j] += array1[i][k] * array2[k][j];
                    }
                }
            }

            return r;
        }
    
        
        public static int[,] Multiply(this int[,] array1, in int[,] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.GetLength(0);
            var n = array2.GetLength(0);
            var p = array2.GetLength(1);
            var r = new int[m, p]; 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i,j] = r[i,j] + array1[i,k] * array2[k,j];
                    }
                }
            }

            return r;
        }
        
        public static float[,] Multiply(this float[,] array1, in float[,] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.GetLength(0);
            var n = array2.GetLength(0);
            var p = array2.GetLength(1);
            var r = new float[m, p]; 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i,j] = r[i,j] + array1[i,k] * array2[k,j];
                    }
                }
            }

            return r;
        }
        
        public static double[,] Multiply(this double[,] array1, in double[,] array2)
        {
            CheckCollRowRule(array1, array2);
            var m = array1.GetLength(0);
            var n = array2.GetLength(0);
            var p = array2.GetLength(1);
            var r = new double[m, p]; 
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < p; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        r[i,j] = r[i,j] + array1[i,k] * array2[k,j];
                    }
                }
            }

            return r;
        }
    
        #endregion

        #region Power
  
        public static int[,] MatrixPower(this int[,] array1, int n)
        {
            while (true)
            {
                if (n == 1) return array1;
                var r = Multiply(array1, array1);
                array1 = r;
                n -= 1;
            }
        }
  
        public static float[,] MatrixPower(this float[,] array1, int n)
        {
            while (true)
            {
                if (n == 1) return array1;
                var r = Multiply(array1, array1);
                array1 = r;
                n -= 1;
            }
        }
  
        public static double[,] MatrixPower(this double[,] array1, int n)
        {
            while (true)
            {
                if (n == 1) return array1;
                var r = Multiply(array1, array1);
                array1 = r;
                n -= 1;
            }
        }
        
        #endregion

        #region SquareUnify
  
        public static (int[,] m1, int[,] m2) SquareUnify(this int[,] matrix1, in int[,] matrix2)
        {
            var m = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            var n = Math.Max(matrix1.GetLength(1), matrix2.GetLength(1));
            var x = Math.Max(m, n);

            var r1 = IdentityI(x);
            for (var i = 0; i < matrix1.GetLength(0); i++)
                for (var j = 0; j < matrix1.GetLength(1); j++)
                    r1[i, j] = matrix1[i, j];

            var r2 = IdentityI(x);
            for (var i = 0; i < matrix2.GetLength(0); i++)
                for (var j = 0; j < matrix2.GetLength(1); j++)
                    r2[i, j] = matrix2[i, j];
            return (r1, r2);
        }
  
        public static (float[,] m1, float[,] m2) SquareUnify(this float[,] matrix1, in float[,] matrix2)
        {
            var m = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            var n = Math.Max(matrix1.GetLength(1), matrix2.GetLength(1));
            var x = Math.Max(m, n);

            var r1 = IdentityF(x);
            for (var i = 0; i < matrix1.GetLength(0); i++)
                for (var j = 0; j < matrix1.GetLength(1); j++)
                    r1[i, j] = matrix1[i, j];

            var r2 = IdentityF(x);
            for (var i = 0; i < matrix2.GetLength(0); i++)
                for (var j = 0; j < matrix2.GetLength(1); j++)
                    r2[i, j] = matrix2[i, j];
            return (r1, r2);
        }
  
        public static (double[,] m1, double[,] m2) SquareUnify(this double[,] matrix1, in double[,] matrix2)
        {
            var m = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            var n = Math.Max(matrix1.GetLength(1), matrix2.GetLength(1));
            var x = Math.Max(m, n);

            var r1 = IdentityD(x);
            for (var i = 0; i < matrix1.GetLength(0); i++)
                for (var j = 0; j < matrix1.GetLength(1); j++)
                    r1[i, j] = matrix1[i, j];

            var r2 = IdentityD(x);
            for (var i = 0; i < matrix2.GetLength(0); i++)
                for (var j = 0; j < matrix2.GetLength(1); j++)
                    r2[i, j] = matrix2[i, j];
            return (r1, r2);
        }
        
        #endregion



    }
}