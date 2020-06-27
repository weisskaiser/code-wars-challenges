using System;
using CodeWars.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeWars.Challenges3Kyu.PathFinderTheAlpinist
{
    public class PathFinderTheAlpinistTests
    {

        public PathFinderTheAlpinistTests(ITestOutputHelper testOutputHelper)
        {
            Console.SetOut(new TestOutputWriter(testOutputHelper));
        }
        
        [Fact]
        public void ExampleA()
        {
            string a = "000\n" +
                       "000\n" +
                       "000";
            
            Assert.Equal(0, PathFinderTheAlpinist.PathFinder(a));
        }
        
        [Fact]
        public void ExampleB()
        {
            string b = "010\n" +
                       "010\n" +
                       "010";

            Assert.Equal(2, PathFinderTheAlpinist.PathFinder(b));
        }
        
        [Fact]
        public void ExampleC()
        {
            string c = "010\n" +
                       "101\n" +
                       "010";

            Assert.Equal(4, PathFinderTheAlpinist.PathFinder(c));
        }
        
        [Fact]
        public void ExampleD()
        {
            string d = "0707\n" +
                       "7070\n" +
                       "0707\n" +
                       "7070";

            Assert.Equal(42, PathFinderTheAlpinist.PathFinder(d));
        }
        
        [Fact]
        public void ExampleE()
        {
            string e = "700000\n" +
                       "077770\n" +
                       "077770\n" +
                       "077770\n" +
                       "077770\n" +
                       "000007";
            
            Assert.Equal(14, PathFinderTheAlpinist.PathFinder(e));
        }
        
        [Fact]
        public void ExampleF()
        {
            string f = "777000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007000\n" +
                       "007777";
            
            Assert.Equal(0, PathFinderTheAlpinist.PathFinder(f));
        }
        
        [Fact]
        public void ExampleG()
        {
            string g = "000000\n" +
                       "000000\n" +
                       "000000\n" +
                       "000010\n" +
                       "000109\n" +
                       "001010";
            
            Assert.Equal(4, PathFinderTheAlpinist.PathFinder(g));
        }
        
        [Fact]
        public void ExampleH()
        {
            string h = "747062171\n" +
                       "904866986\n" +
                       "340268947\n" +
                       "974542098\n" +
                       "574036106\n" +
                       "567149757\n" +
                       "726658263\n" +
                       "848862682\n" +
                       "755104617";
            
            Assert.Equal(34, PathFinderTheAlpinist.PathFinder(h));
        }
        
        [Fact]
        public void ExampleI()
        {
            string i = "777000\n" +
                       "000000\n" +
                       "000000\n" +
                       "000000\n" +
                       "000000\n" +
                       "000007";
            
            Assert.Equal(14, PathFinderTheAlpinist.PathFinder(i));
        }
        
        [Fact]
        public void ExampleL()
        {
            string l = "777777\n" +
                       "000007\n" +
                       "000007\n" +
                       "000007\n" +
                       "007777\n" +
                       "007000";
            
            Assert.Equal(7, PathFinderTheAlpinist.PathFinder(l));
        }
        
        [Fact]
        public void ExampleM()
        {
            string m = "949\n" +
                       "618\n" +
                       "524";     
            
            Assert.Equal(9, PathFinderTheAlpinist.PathFinder(m));
        }
        
    }
}