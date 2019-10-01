using BinaryRelationsTests.Helpers;
using MaxRev.Extensions.Binary;
using MaxRev.Extensions.Matrix;
using Xunit;
using Xunit.Abstractions;

namespace BinaryRelationsTests
{
    public class PropertiesTests : HasMockOutput
    {
        public PropertiesTests(ITestOutputHelper output) : base(output)
        {
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

            Assert.True(m1.IsTotalRelation());
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
        public void IsReflexive()
        {
            var m = new[,]
            {
                {1, 0, 0, 1},
                {0, 1, 0, 1},
                {0, 0, 1, 0},
                {1, 1, 0, 1}
            }.Cast<int, bool>();
            Assert.True(m.IsReflexive());
        }

        [Fact]
        public void IsAntiReflexive()
        {
            var m = new[,]
            {
                {0, 0, 0, 1},
                {0, 0, 0, 1},
                {0, 0, 0, 0},
                {1, 1, 0, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsAntiReflexive());
        }

        [Fact]
        public void IsSymmetric()
        {
            var m = new[,]
            {
                {1, 1, 0, 1},
                {1, 0, 0, 1},
                {0, 0, 1, 0},
                {1, 1, 0, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsSymmetric());
        }

        [Fact]
        public void IsAsymmetric()
        {
            var m = new[,]
            {
                {0, 0, 0},
                {1, 0, 0},
                {1, 0, 0},
            }.Cast<int, bool>();
            Assert.True(m.IsAsymmetric());
            // it also must be anti-reflective
            Assert.True(m.IsAntiReflexive());
        }

        [Fact]
        public void IsAntiSymmetric()
        {
            var m = new[,]
            {
                {1, 0, 0},
                {0, 0, 1},
                {1, 0, 1}
            }.Cast<int, bool>();
            Assert.False(m.IsAntiSymmetric());
            m = new[,]
            {
                {1, 0, 0},
                {1, 1, 0},
                {1, 1, 1}
            }.Cast<int, bool>();
            Assert.True(m.IsAntiSymmetric());
            Assert.True(m.Reverse().IsAntiSymmetric());
        }

        [Fact]
        public void IsAcyclic()
        {
            var m = new[,]
            {
                {0, 1, 0},
                {0, 0, 1},
                {0, 0, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsAcyclic());

            m = new[,]
            {
                {0, 1, 0, 0},
                {0, 0, 0, 1},
                {0, 0, 0, 0},
                {0, 0, 1, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsAcyclic());
            // and then this must pass
            Assert.True(m.IsAsymmetric());

            var transitiveClosure = m.TransitiveClosure();

            if (transitiveClosure.IsAntiReflexive())
                Assert.True(transitiveClosure.IsAsymmetric());
            // anti-reflexive transitive is acyclic
            if (transitiveClosure.IsAntiReflexive() && transitiveClosure.IsTransitive())
                Assert.True(transitiveClosure.IsAcyclic());

            m = new[,]
            {
                {0, 0, 0, 0},
                {0, 0, 0, 1},
                {0, 1, 0, 0},
                {0, 0, 1, 0}
            }.Cast<int, bool>();
            Assert.False(m.IsAcyclic());
        }

        [Fact]
        public void IsConnex()
        {
            var m = new[,]
            {
                {0, 1, 1, 1},
                {0, 0, 1, 1},
                {0, 0, 0, 1},
                {0, 0, 0, 0}
            }.Cast<int, bool>();
            Assert.True(m.IsConnex());
        }

        [Fact]
        public void IsTransitive()
        {
            var m = new[,]
            {
                {1, 0, 0, 1},
                {1, 0, 1, 0},
                {0, 1, 1, 0},
                {1, 0, 0, 1}
            }.Cast<int, bool>();
            Assert.False(m.Product(m).IsReferenceSequenceEqualTo(m));
            Assert.False(m.IsTransitive());
            Assert.True(m.TransitiveClosure().IsTransitive());
        }
    }
}