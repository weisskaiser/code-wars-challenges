using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeWars.Challenges4Kyu.Permutations
{
    public class PermutationsTests
    {
        [Fact]
        public void Example1()
        {
            Assert.Equal(new List<string> { "a" }, Permutations.SinglePermutations("a").OrderBy(x => x).ToList());
        }

        [Fact]
        public void Example2()
        {
            Assert.Equal(new List<string> { "ab", "ba" }, Permutations.SinglePermutations("ab").OrderBy(x => x).ToList());
        }

        [Fact]
        public void Example3()
        {
            Assert.Equal(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, Permutations.SinglePermutations("aabb").OrderBy(x => x).ToList());
        }
    }
}