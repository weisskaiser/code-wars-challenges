using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars.Challenges3Kyu.PathFinderTheAlpinist
{
    public class PathFinderTheAlpinist
    {
        public static int PathFinder(string maze)
        {
            var neighbours = new[] {(1, 0), (0, 1), (0, -1), (-1, 0)};
            var graph = MountGraph(maze);
            var costBag = new Dictionary<(int, int),int>{[(0,0)]=0};
            
            var toBeVisited = new Queue<(int,int)>();
            toBeVisited.Enqueue((0,0));
            
            void Act((int,int) pos)
            {
                (int i, int j) = pos;
                
                foreach (var (incI,incJ) in neighbours)
                {
                    if (
                        i + incI < graph.Length &&
                        i + incI >= 0 &&
                        j + incJ < graph.Length &&
                        j + incJ >= 0
                    )
                    {
                        var neighbour = (i + incI, j + incJ);
                        var cost = Math.Abs(graph[i][j] - graph[i + incI][j + incJ]);
                        
                        if (!costBag.ContainsKey(neighbour) || costBag[neighbour] > cost + costBag[pos])
                        {
                            toBeVisited.Enqueue(neighbour);
                            costBag[neighbour] = cost + costBag[pos];
                        }
                    }
                }
            }
            
            while (toBeVisited.TryDequeue(out var position))
            {
                Act(position);
            }
            
            return costBag[(graph.Length-1, graph.Length-1)];
        }
        
        

        private static int[][] MountGraph(string maze)
        {
            return maze.Split().Select(l => l.Select(l => int.Parse(l.ToString())).ToArray()).ToArray();
        }

    }
}