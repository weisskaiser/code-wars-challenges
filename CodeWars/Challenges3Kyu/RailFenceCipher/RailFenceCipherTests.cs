using System;
using CodeWars.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeWars.Challenges3Kyu.RailFenceCipher
{
    public class RailFenceCipherTests
    {
        public RailFenceCipherTests(ITestOutputHelper helper)
        {
            Console.SetOut(new TestOutputWriter(helper));
        }
        
        [Fact]
        public void EncodeSampleTests()
        {
            string[][] encodes = 
            {
                new []{ "WEAREDISCOVEREDFLEEATONCE", "WDEEFARLREEEVEEDOACICTNSO"},
                new[] { "WEAREDISCOVEREDFLEEATONCE", "WECRLTEERDSOEEFEAOCAIVDEN" },  // 3 rails
                new[] { "Hello, World!", "Hoo!el,Wrdl l" },    // 3 rails
                new[] { "Hello, World!", "H !e,Wdloollr" },    // 4 rails
                new[] { "", "" }                               // 3 rails (even if...)
            };
            int[] rails = { 8, 3, 3, 4, 3 };
            for (int i = 0; i < encodes.Length; i++)
            {
                Assert.Equal(encodes[i][1], RailFenceCipher.Encode(encodes[i][0], rails[i]));
            }
        }

        [Fact]
        public void DecodeSampleTests()
        {
            string[][] decodes =
            {
                new []{ "WECRLTEERDSOEEFEAOCAIVDEN", "WLSADOOTEEECEAEECRFINVEDR" },
                new[] { "WIREEEDSEEEACAECVDLTNROFO","WEAREDISCOVEREDFLEEATONCE"},
                new[] { "WECRLTEERDSOEEFEAOCAIVDEN", "WEAREDISCOVEREDFLEEATONCE" },    // 3 rails
                new[] { "H !e,Wdloollr", "Hello, World!" },    // 4 rails
                new[] { "", "" }                               // 3 rails (even if...)
            };
            int[] rails =
            {
                5,
                4,
                3, 
                4, 
                3
            };
            for (int i = 0; i < decodes.Length; i++)
            {
                Assert.Equal(decodes[i][1], RailFenceCipher.Decode(decodes[i][0], rails[i]));
            }
        }
    }
}