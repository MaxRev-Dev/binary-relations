using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace BinaryRelationsTests.Helpers
{
    public class MockTextWriter : TextWriter
    {
        private readonly ITestOutputHelper _output;

        public MockTextWriter(ITestOutputHelper output)
        {
            _output = output;
            _buffer = new StringBuilder();
        }
        public override Encoding Encoding => Encoding.UTF8;
        private readonly StringBuilder _buffer;
        public override void WriteLine(string value)
        {
            string t = default;
            if (_buffer.Length > 0)
            {
                t = _buffer.ToString();
                _buffer.Clear();
            }

            _output.WriteLine(t + value);
        }

        public override void Write(string value)
        {
            _buffer.Append(value);
        }
    }
}