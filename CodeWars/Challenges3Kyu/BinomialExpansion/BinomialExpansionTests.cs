using System;
using CodeWars.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeWars.Challenges3Kyu.BinomialExpansion
{
    public class BinomialExpansionTests
    {
        public BinomialExpansionTests(ITestOutputHelper outputHelper)
        {
            Console.SetOut(new TestOutputWriter(outputHelper));
        }
        
        [Fact]
        public void testBPositive()
        {
            Assert.Equal("1", BinomialExpansion.Expand("(x+1)^0"));
            Assert.Equal("x+1", BinomialExpansion.Expand("(x+1)^1"));
            Assert.Equal("x^2+2x+1", BinomialExpansion.Expand("(x+1)^2"));
        }

        [Fact]
        public void testBNegative()
        {
            Assert.Equal("1", BinomialExpansion.Expand("(x-1)^0"));
            Assert.Equal("x-1", BinomialExpansion.Expand("(x-1)^1"));
            Assert.Equal("x^2-2x+1", BinomialExpansion.Expand("(x-1)^2"));
        }

        [Fact]
        public void testAPositive()
        {
            Assert.Equal("625m^4+1500m^3+1350m^2+540m+81", BinomialExpansion.Expand("(5m+3)^4"));
            Assert.Equal("8x^3-36x^2+54x-27", BinomialExpansion.Expand("(2x-3)^3"));
            Assert.Equal("1", BinomialExpansion.Expand("(7x-7)^0"));
        }

        [Fact]
        public void testANegative()
        {
            Assert.Equal("625m^4-1500m^3+1350m^2-540m+81", BinomialExpansion.Expand("(-5m+3)^4"));
            Assert.Equal("-8k^3-36k^2-54k-27", BinomialExpansion.Expand("(-2k-3)^3"));
            Assert.Equal("1", BinomialExpansion.Expand("(-7x-7)^0"));
        }
        
        [Fact]
        public void testNegPlus()
        {
            Assert.Equal("y^15-75y^14+2625y^13-56875y^12+853125y^11-9384375y^10+78203125y^9-502734375y^8+2513671875y^7-9775390625y^6+29326171875y^5-66650390625y^4+111083984375y^3-128173828125y^2+91552734375y-30517578125", BinomialExpansion.Expand("(y-5)^15"));
        }
    }
}