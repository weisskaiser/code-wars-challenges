using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Challenges4Kyu.Permutations
{
    public class Permutations
    {
        public static List<string> SinglePermutations(string s)
        {
            static string Swap(int a, int b, string s)
            {

                var sr = s.AsSpan();
                
                Span<char> sw = stackalloc char[s.Length];
                sr.CopyTo(sw);

                (sw[a], sw[b]) = (sr[b], sr[a]);

                return sw.ToString();
            }

            static ISet<string> RecSwap(int a, int b, string s)
            {
                if (a == b)
                {
                    return new HashSet<string>{s};
                }

                var set = new HashSet<string> {s};
                
                for (int i = a; i < b; i++)
                {
                    var sn = Swap(a, i, s);
                    set.Add(sn);
                    set.UnionWith(RecSwap(a+1,b, sn));
                }

                return set;
            }

            return RecSwap(0, s.Length, s).ToList();
        }
    }
}