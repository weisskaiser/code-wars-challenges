using System;
using CodeWars.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeWars.Challenges3Kyu.ScreenLockingPatterns
{
    public class ScreenLockingPatternsTests
    {
        public ScreenLockingPatternsTests(ITestOutputHelper helper)
        {
            Console.SetOut(new TestOutputWriter(helper));
        }
        
        [Theory]   
        [InlineData('A', 0, 0)]
        [InlineData('A', 10, 0)]
        [InlineData('B', 1, 1)]
        [InlineData('C', 2, 5)]
        [InlineData('D', 3, 37)]
        [InlineData('E', 4, 256)]
        [InlineData('E', 8, 23280)]
        public void ExampleTests(char firstDot, int length, int expectedResult)
        {
            Assert.Equal(expectedResult, ScreenLockingPatterns.CountPatternsFrom(firstDot, length));
        }
    
    }
}