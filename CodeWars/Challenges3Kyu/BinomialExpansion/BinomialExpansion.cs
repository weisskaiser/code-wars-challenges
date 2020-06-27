using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace CodeWars.Challenges3Kyu.BinomialExpansion
{
    public class BinomialExpansion
    {
        public static string Expand(string expr)
        {
            var parsedExpr = ParseExpression(expr);

            if (parsedExpr.n == 0) return "1";

            var builder = new StringBuilder();
            for (int i = 0; i <= parsedExpr.n; i++)
            {
                builder.Insert(0,$"{GenerateTerm(parsedExpr, i)}");
            }

            return builder.ToString();
        }

        private static string GenerateTerm((int a, int b, int n, char x) expr, int k)
        {
            var comb = Combine(expr.n, k);
            var bf = Math.Pow(expr.b, expr.n - k);
            var af = Math.Pow(expr.a, k);
            
            var na =  comb * bf * af;

            if (na == 0) return "";
            
            var sa = na switch
            {
                -1 => "-",
                1 => k == expr.n ? "" : "+",
                {} z => k == expr.n ? $"{z:0;-#}" : $"{z:+0;-#}",
            };
            var sx = k switch
            {
                0 => sa.EndsWith("-") || sa.EndsWith("+") ? $"{sa}1" : $"{sa}",
                1 => $"{sa}{expr.x}",
                {} z => $"{sa}{expr.x}^{k}",
            };
            
            return $"{sx}";
        }
        
        private static int Combine(int n, int k)
        {
            if (k == 0) return 1;
            if (k == n) return 1;

            if (k > n / 2) k = n - k;

            var a = Enumerable.Range(0, k).Aggregate(1, (acc, i) => acc * (n - i));
            var b = Enumerable.Range(0, k).Aggregate(1, (acc, i) => acc * (k - i));

            return a / b;
        }
        
        private static (int a, int b, int n, char x)  ParseExpression(string expr)
        {
            var regex = new Regex(@"\((?<a>-?\d*)(?<x>[a-zA-Z])(?<b>(\+|-)\d+)\)\^(?<n>\d+)");

            var match = regex.Match(expr);

            int a = match.Groups["a"]?.Value switch
            {
                null => 1,
                "" => 1,
                "-" => -1,
                { } number => int.Parse(number),
            };

            int b = int.Parse(match.Groups["b"].Value);
            char x = match.Groups["x"].Value[0];
            int n = int.Parse(match.Groups["n"].Value);
            
            return (a, b, n, x);
        }
    }
}