using System;
using System.Collections.Immutable;
using System.Linq;

namespace CodeWars.Challenges3Kyu.ScreenLockingPatterns
{
    public static class ScreenLockingPatterns
    {
        public static int CountPatternsFrom(char firstDot, int length)
        {
            if(length <= 0 || length > 9) return 0;

            var indexByDotBuilder = ImmutableDictionary.CreateBuilder<char, (int, int)>();
            indexByDotBuilder.Add('A',(0,0));
            indexByDotBuilder.Add('B',(0,1));
            indexByDotBuilder.Add('C',(0,2));
            indexByDotBuilder.Add('D',(1,0));
            indexByDotBuilder.Add('E',(1,1));
            indexByDotBuilder.Add('F',(1,2));
            indexByDotBuilder.Add('G',(2,0));
            indexByDotBuilder.Add('H',(2,1));
            indexByDotBuilder.Add('I',(2,2));
            var indexByDot = indexByDotBuilder.ToImmutable();

            int GoNext((int,int) current, ImmutableHashSet<(int,int)> visited)
            {
                var newVisited = visited.Add(current);
                var newToBeVisited = GenerateNextVisits(current, newVisited);
                
                return newVisited.Count() < length ?
                    newToBeVisited.Sum(e => GoNext(e,newVisited))
                    : 1;
            }

            ImmutableList<(int, int)> GenerateNextVisits((int,int) current, ImmutableHashSet<(int,int)> visited)
            {
                
                return indexByDotBuilder.Values
                    .Except(visited)
                    .Where(e => 
                        ( Distance(current, e) & 1) == 1 
                        || GetMiddleMen(current, e) is null
                        || GetMiddleMen(current, e) is (int _,int _) middleMen 
                            && visited.Contains(middleMen))
                    .ToImmutableList();
            }


            return GoNext(indexByDot[firstDot], ImmutableHashSet<(int, int)>.Empty);
        }

        static int Distance((int i, int j) p1, (int i, int j) p2)
            => Math.Abs(p1.i - p2.i) + Math.Abs(p1.j - p2.j);

        static (int, int)? GetMiddleMen((int i, int j) p1, (int i, int j) p2)
        {
            return Distance(p1, p2) switch
            {
                0 => null,
                1 => null,
                3 => null,
                2 => Math.Abs(p1.i - p2.i) switch
                {
                    0 => (p1.i, p1.j + (p2.j - p1.j)/2),
                    1 => null,
                    2 => (p1.i + (p2.i - p1.i)/2, p1.j),
                },
                4 => (p1.i + (p2.i - p1.i)/2, p1.j + (p2.j - p1.j)/2)
            };

        }
        
    }
}