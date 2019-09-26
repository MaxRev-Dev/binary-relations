using Xunit.Abstractions;

namespace BinaryRelationsTests.Helpers
{
    public class HasMockOutput
    {
        protected readonly MockTextWriter mock;
        public HasMockOutput(ITestOutputHelper output)
        {
            mock = new MockTextWriter(output);
        }
    }
}