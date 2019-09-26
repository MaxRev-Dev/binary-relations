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
    }
}