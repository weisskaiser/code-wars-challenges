using System;
using CodeWars.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeWars.Challenges3Kyu.Calculator
{
    public class CalculatorTests
    {
        public CalculatorTests(ITestOutputHelper outputHelper)
        {
            Console.SetOut(new TestOutputWriter(outputHelper));
        }
        
        [Theory]
        [InlineData("1-1", 0)]
        [InlineData("1+1", 2)]
        [InlineData("1 - 1", 0)]
        [InlineData("1* 1", 1)]
        [InlineData("1 /1", 1)]
        [InlineData("12* 123/-(-5 + 2)",492)]
        [InlineData("1 - -(-(-(-4)))",-3)]
        [InlineData("12*-1", -12)]
        [InlineData("-12", -12)]
        [InlineData("((2.33 / (2.9+3.5)*4) - -6)",7.4562499999999998d)]
        public void TestEvaluation(string expression, double result)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(result, calculator.Evaluate(expression));
        }
    }
}