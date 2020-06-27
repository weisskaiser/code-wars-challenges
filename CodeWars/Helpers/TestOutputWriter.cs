#nullable enable
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace CodeWars.Helpers
{
    public class TestOutputWriter : TextWriter
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestOutputWriter(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string? value)
        {
            _testOutputHelper.WriteLine(value);
        }

        public override void WriteLine(string format, object? arg0)
        {
            _testOutputHelper.WriteLine(format, arg0);
        }

        public override void WriteLine(string format, object? arg0, object? arg1)
        {
            _testOutputHelper.WriteLine(format, arg0, arg1);
        }
    }
}