using System.Collections.Generic;
using System.Linq;
using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using MaxRev.Extensions.Matrix;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class MatrixOperationsTests : HasMockOutput
    {
        public MatrixOperationsTests(ITestOutputHelper output) : base(output)
        {
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
                new[]
                {
                    new[] {1},
                    new[] {2},
                    new[] {3},
                    new[] {4},
                    new[] {5},
                },
                new[]
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
                new[]
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
                new[]
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