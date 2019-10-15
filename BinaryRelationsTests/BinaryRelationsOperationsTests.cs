using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using MaxRev.Extensions.Matrix;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class BinaryRelationsOperationsTests : HasMockOutput
    {
        public BinaryRelationsOperationsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Complementation()
        {
            var m1 = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 1},
                {0, 1, 0, 0},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {0, 0, 1, 0},
                {1, 0, 0, 0},
                {1, 0, 1, 1},
                {0, 1, 0, 1},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Complementation());
        }

        [Fact]
        public void Intersection()
        {
            var m1 = new[,]
            {
                {1, 0, 1, 0},
                {0, 1, 1, 1},
                {1, 0, 1, 1},
                {1, 0, 1, 1}
            }.Cast<int, bool>();
            var m2 = new[,]
            {
                {0, 0, 1, 1},
                {1, 1, 1, 0},
                {0, 1, 1, 1},
                {0, 1, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {0, 0, 1, 0},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 1, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Intersection(m2));
        }

        [Fact]
        public void Union()
        {
            var m1 = new[,]
            {
                {1, 0, 0, 0},
                {0, 1, 1, 0},
                {1, 0, 1, 1},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            var m2 = new[,]
            {
                {0, 0, 1, 1},
                {1, 1, 1, 0},
                {0, 1, 1, 1},
                {0, 1, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 0, 1, 1},
                {1, 1, 1, 0},
                {1, 1, 1, 1},
                {1, 1, 1, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Union(m2));
        }

        [Fact]
        public void Difference()
        {
            var m1 = new[,]
            {
                {1, 0, 0, 0},
                {0, 1, 1, 0},
                {1, 0, 1, 1},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            var m2 = new[,]
            {
                {0, 1, 1, 1},
                {1, 1, 1, 0},
                {0, 1, 1, 1},
                {0, 1, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 0, 0, 0},
                {0, 0, 0, 0},
                {1, 0, 0, 0},
                {1, 0, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Difference(m2));
        }

        [Fact]
        public void SymmericDifference()
        {
            var m1 = new[,]
            {
                {1, 1, 0, 0},
                {0, 1, 1, 0},
                {1, 0, 1, 1},
                {1, 1, 1, 0}
            }.Cast<int, bool>();
            var m2 = new[,]
            {
                {0, 1, 1, 1},
                {1, 1, 1, 0},
                {0, 1, 1, 1},
                {0, 1, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 0, 1, 1},
                {1, 0, 0, 0},
                {1, 1, 0, 0},
                {1, 0, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.SymmetricDifference(m2));
        }

        [Fact]
        public void Narrowing()
        {
            var m1 = new[,]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 0, 0, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {1, 0, 0, 1},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Narrowing(1, 4));

            expected = new[,]
            {
                {1, 1, 0, 0},
                {1, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Narrowing(1, 2));

            expected = new[,]
            {
                {1, 0, 1, 1},
                {0, 0, 0, 0},
                {1, 0, 1, 1},
                {1, 0, 1, 1},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Narrowing(1, 3, 4));

            expected = new[,]
            {
                {1, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Narrowing(1));
        }

        [Fact]
        public void Reverse()
        {
            var m1 = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 1},
                {0, 1, 0, 0},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 0, 0, 1},
                {1, 1, 1, 0},
                {0, 1, 0, 1},
                {1, 1, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Reverse());
        }

        [Fact]
        public void Product()
        {
            var m1 = new[,]
            {
                {1, 1, 1, 1},
                {0, 1, 1, 1},
                {0, 1, 0, 0},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            var m2 = new[,]
            {
                {0, 1, 0, 1},
                {0, 0, 0, 1},
                {0, 1, 0, 0},
                {0, 0, 1, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {0, 1, 1, 1},
                {0, 1, 1, 1},
                {0, 0, 0, 1},
                {0, 1, 0, 1},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Product(m2));
        }

        [Fact]
        public void Dual()
        {
            var m = RandomExtensions.AllocateRandomSquareMatrix(5).Cast<double, bool>();
            Assert.Equal(m.Dual(), m.Complementation().Reverse());
        }
    }
}
