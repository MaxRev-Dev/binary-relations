using MaxRev.Extensions.Matrix;
using MaxRev.Extensions.Binary;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class MainTests
    {
        private readonly MockTextWriter mock;
        public MainTests(ITestOutputHelper output)
        {
            mock = new MockTextWriter(output);
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
            Assert.Equal(expected.PrintThrought(mock), MatrixExtensions.Multiply(m1, m2).PrintThrought(mock));
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
            Assert.Equal(expected, MatrixExtensions.Add(m1, m2));
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
            Assert.Equal(expected, MatrixExtensions.Subtract(m1, m2));
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
                {1, 0, 0, 1},
                {1, 1, 1, 0},
                {0, 1, 0, 1},
                {1, 1, 0, 0},
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {0, 0, 0, 0},
                {0, 1, 1, 0},
                {0, 1, 0, 0},
                {0, 0, 0, 0},
            }.Cast<int, bool>();
            Assert.Equal(expected, m1.Narrowing(2, 3));
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
        public void IsDiagonalRelation()
        {
            var m = new[,]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            }.Cast<int, bool>();
            Assert.True(m.IsDiagonalRelation());
        }

        [Fact]
        public void IsAntiDiagonalRelation()
        {
            var m = new[,]
            {
                {0, 1, 1, 1},
                {1, 0, 1, 1},
                {1, 1, 0, 1},
                {1, 1, 1, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsAntiDiagonalRelation());
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
        public void ComplementationReverseEqualsReverseComplementation()
        {
            var m1 = RandomExtensions.AllocateRandomSquareMatrix(10).Cast<double, bool>();
            Assert.Equal(m1.Complementation().Reverse(), m1.Reverse().Complementation());
        }

        [Fact]
        public void IsFullRelation()
        {
            var m1 = new[,]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1},
                {1, 1, 1, 1}
            }.Cast<int, bool>();

            Assert.True(m1.IsFullRelation());
        }
    }
}
