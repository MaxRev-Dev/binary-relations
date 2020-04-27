using System;
using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using MaxRev.Extensions.Matrix;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class MatrixOperationsTests : HasMockOutput
    {
        public MatrixOperationsTests(ITestOutputHelper output) : base(output)
        {
        }

        private readonly Random _rnd = new Random();

        [Fact]
        public void MatrixInverse()
        {
            for (int j = 0; j < 10; j++)
            {
                var n = _rnd.Next(10, 100);
                var m = RandomExtensions.MatrixRandom(n, -100, 100);
                var i = m.Inverse();
                var I = MatrixExtensions.IdentityD(n);
                var p = m.Multiply(i);
                Assert.True(p.AreEqual(I, 1.0E-8));
            }
        }
        [Fact]
        public void MultiplyMatrices()
        {
            var m1 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var m2 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var expected = new double[,]
            {
                {30, 36, 42},
                {66, 81, 96},
                {102, 126, 150}
            };
            Assert.Equal(expected.PrintThrough(mock), m1.Multiply(m2).PrintThrough(mock));
        }

        [Fact]
        public void MultiplyMatricesMNP()
        {
            var m1 = new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
            };
            var m2 = new[]
            {
                new[] {1},
                new[] {3},
                new[] {5}
            };
            var expected = new[]
            {
                new[] {22},
                new[] {49}
            };
            Assert.Equal(expected.PrintThrough(mock), m1.Multiply(m2).PrintThrough(mock));
        }
        [Fact]
        public void MultiplyMatricesMNP_Convert()
        {
            var m1 = new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
            }.Convert();
            var m2 = new[]
            {
                new[] {1},
                new[] {3},
                new[] {5}
            }.Convert();
            var expected = new[]
            {
                new[] {22},
                new[] {49}
            }.Convert();
            Assert.Equal(expected.PrintThrough(mock), m1.Multiply(m2).PrintThrough(mock));
        }

        [Fact]
        public void SquareUnify()
        {
            var m1 = new[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
                {2, 3, 4}
            };
            var m2 = new[,]
            {
                {1, 2, 3},
                {4, 5, 6},
            };
            var expected = (new[,]
            {
                {1, 2, 3, 0},
                {4, 5, 6, 0},
                {7, 8, 9, 0},
                {2, 3, 4, 1}
            }, new[,]
            {
                {1, 2, 3, 0},
                {4, 5, 6, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1},
            });
            var actual = m1.SquareUnify(m2);
            Assert.Equal(expected.Item1, actual.m1);
            Assert.Equal(expected.Item2, actual.m2);
        }
        [Fact]
        public void AddMatrices()
        {
            var m1 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var m2 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var expected = new double[,]
            {
                {2, 4, 6},
                {8, 10, 12},
                {14, 16, 18}
            };
            Assert.Equal(expected, m1.Add(m2));
        }

        [Fact]
        public void SubtractMatrices()
        {
            var m1 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var m2 = new double[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var expected = new double[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            Assert.Equal(expected, m1.Subtract(m2));
        }

        [Fact]
        public void Permutations()
        {
            var expected = new[]
            {
                new[] {1, 2, 3},
                new[] {1, 2, 4},
                new[] {1, 2, 5},
                new[] {1, 3, 4},
                new[] {1, 3, 5},
                new[] {1, 4, 5},
                new[] {2, 3, 4},
                new[] {2, 3, 5},
                new[] {2, 4, 5},
                new[] {3, 4, 5},
            };
            Assert.Equal(expected, MatrixExtensions.Permutations(Enumerable.Range(1, 5), 3));
        }

        [Fact]
        public void CartesianProductDistinctPairs()
        {
            var expected = new[] {
                new []
                {
                    new[] {1},
                    new[] {2},
                    new[] {3},
                    new[] {4},
                    new[] {5},
                },
                new []
                {
                    new[] {1, 2},
                    new[] {1, 3},
                    new[] {1, 4},
                    new[] {1, 5},
                    new[] {2, 3},
                    new[] {2, 4},
                    new[] {2, 5},
                    new[] {3, 4},
                    new[] {3, 5},
                    new[] {4, 5},
                },
                new []
                {
                    new[] {1, 2, 3},
                    new[] {1, 2, 4},
                    new[] {1, 2, 5},
                    new[] {1, 3, 4},
                    new[] {1, 3, 5},
                    new[] {1, 4, 5},
                    new[] {2, 3, 4},
                    new[] {2, 3, 5},
                    new[] {2, 4, 5},
                    new[] {3, 4, 5},
                },
                new []
                {
                    new[] {1, 2, 3, 4},
                    new[] {1, 2, 3, 5},
                    new[] {1, 2, 4, 5},
                    new[] {1, 3, 4, 5},
                    new[] {2, 3, 4, 5},
                },
                new []
                {
                   new[] {1, 2, 3, 4, 5}
                }
            };

            Assert.Equal(expected, MatrixExtensions.CartesianProductDistinctPairs(5));
        }
    }
}