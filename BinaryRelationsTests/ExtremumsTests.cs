using System.Linq;
using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class ExtremumsTests : HasMockOutput
    {
        public ExtremumsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ExtremumTest0()
        {
            Assert.True(new[,] { { true } }.GetMaximums().Any());
        }

        [Fact]
        public void ExtremumTest1()
        {
            var m = new[,]
            {
                {1, 1, 0, 1},
                {0, 0, 1, 0},
                {0, 0, 0, 1},
                {0, 1, 0, 0}
            }.Cast<int, bool>();

            Assert.False(m.HasMaximum());
            Assert.False(m.HasMajorant());
            Assert.False(m.HasMinimum());
            Assert.False(m.HasMinorant());
        }

        [Fact]
        public void ExtremumTest2()
        {
            var m = new[,]
            {
                {1, 1, 1, 1},
                {1, 0, 1, 1},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            }.Cast<int, bool>();

            Assert.True(m.HasMaximum());
            Assert.True(m.HasMinorant());
            Assert.False(m.HasMajorant());
            Assert.False(m.HasMinimum());
            Assert.Equal(m.GetMaximums(), new[] { 0 });
            Assert.Equal(m.GetMinorants(), new[] { 2, 3 });
        }

        [Fact]
        public void ExtremumTest3()
        {
            var m = new[,]
            {
                {0, 0, 1, 1},
                {0, 0, 1, 1},
                {0, 0, 1, 1},
                {0, 0, 1, 1}
            }.Cast<int, bool>();

            Assert.False(m.HasMaximum());
            Assert.False(m.HasMinorant());
            Assert.True(m.HasMajorant());
            Assert.True(m.HasMinimum());
            Assert.Equal(m.GetMinimums(), new[] { 2, 3 });
            Assert.Equal(m.GetMajorants(), new[] { 0, 1 });
        }
    }
}