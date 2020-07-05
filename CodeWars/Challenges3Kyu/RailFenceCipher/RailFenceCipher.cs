using System;
using System.Linq;

namespace CodeWars.Challenges3Kyu.RailFenceCipher
{
    public class RailFenceCipher
    {
        static int[] GenerateSeq(string s, int n)
        {
            var d = n * 2 - 2;
            var buffer = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                var iv = i % d;
                var v = iv < n ? iv : n - 2 - (iv % n);
                
                buffer[i] = v;
            }

            return buffer;
        }
        
        public static string Encode(string s, int n)
        {
            var seq = GenerateSeq(s,n);

            return new string(s.Select((s,i) => (s,i)).OrderBy(c => seq[c.i]).Select(c => c.s).ToArray());
        }

        public static string Decode(string s, int n)
        {
            var seq = GenerateSeq(s, n); 

            var decSeq = seq.Select((v, i) => (v, i)).OrderBy(e => e.v).Select(e => e.i).ToArray();

            Span<char> decS = stackalloc char[s.Length];
            
            for (int i = 0; i < s.Length; i++)
            {
                decS[decSeq[i]] = s[i];
            }
            
            return new string(decS);
        }
    }
}