using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class ClosuresTests : HasMockOutput
    {
        public ClosuresTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TransitiveClosure()
        {
            var m = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 1, 1, 1},
                {0, 1, 1, 1},
                {0, 0, 1, 1},
                {0, 0, 0, 1}
            }.Cast<int, bool>();
            Assert.Equal(expected, m.TransitiveClosure());
        }

        [Fact]
        public void ReflexiveClosure()
        {
            var m = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 0},
                {0, 0, 0, 1},
                {0, 0, 0, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {0, 0, 0, 1}
            }.Cast<int, bool>();
            Assert.Equal(expected, m.ReflexiveClosure());
        }

        [Fact]
        public void SymmetricClosure()
        {
            var m = new[,]
            {
                {1, 1, 0, 1},
                {0, 1, 1, 0},
                {0, 0, 0, 1},
                {0, 0, 0, 0}
            }.Cast<int, bool>();
            var expected = new[,]
            {
                {1, 1, 0, 1},
                {1, 1, 1, 0},
                {0, 1, 0, 1},
                {1, 0, 1, 0}
            }.Cast<int, bool>();
            Assert.Equal(expected, m.SymmetricClosure());
        }
    }
}