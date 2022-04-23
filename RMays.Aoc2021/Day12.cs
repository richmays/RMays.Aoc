using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day12 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            // A naiive solution might be good enough.  Let's brute force it.
            // First let's load it into a data structure.  Dictionary?
            // For each node, save a list of connected nodes.
            var lines = Parser.TokenizeLines(input);
            var dict = new Dictionary<string, List<string>>();
            foreach(var line in lines)
            {
                var start = line.Split('-')[0];
                var end = line.Split('-')[1];

                AddPathToDict(dict, start, end);
                AddPathToDict(dict, end, start);
            }

            //PrintCaves(dict);

            // Cave structure is built.
            // Let's traverse recursively.
            // At each point, we can travel to any cave connected to the current one.

            if (!IsPartB)
            {
                return PathsFromCurrentNode(new List<string>(), "start", dict);
            }
            else
            {
                return PathsFromCurrentNodeB(new List<string>(), false, "start", dict);
            }
        }

        private int PathsFromCurrentNode(List<string> cavesVisited, string startNode, Dictionary<string, List<string>> dict)
        {
            // Get all paths from this one.
            var possiblePaths = dict[startNode];
            possiblePaths = possiblePaths.Where(x => !cavesVisited.Contains(x)).ToList();

            var sum = 0;
            foreach(var path in possiblePaths)
            {
                if (path == "end")
                {
                    sum++;
                }
                else if (path == path.ToLower())
                {
                    cavesVisited.Add(path);
                    sum += PathsFromCurrentNode(cavesVisited, path, dict);
                    cavesVisited.Remove(path);
                }
                else
                {
                    sum += PathsFromCurrentNode(cavesVisited, path, dict);
                }
            }

            return sum;
        }

        private int PathsFromCurrentNodeB(List<string> cavesVisited, bool doubleVisitedSmall, string startNode, Dictionary<string, List<string>> dict)
        {
            // Get all paths from this one.
            var possiblePaths = dict[startNode];
            //possiblePaths = possiblePaths.Where(x => !cavesVisited.Contains(x)).ToList();

            var sum = 0;
            foreach (var path in possiblePaths)
            {
                if (path == "end")
                {
                    sum++;
                }
                else if (path == path.ToLower())
                {
                    if (doubleVisitedSmall)
                    {
                        // We already visited a small cave twice, so we can't match any caves we've already been to.
                        if (cavesVisited.Contains(path)) continue;
                        cavesVisited.Add(path);
                        sum += PathsFromCurrentNodeB(cavesVisited, doubleVisitedSmall, path, dict);
                        cavesVisited.Remove(path);
                    }
                    else
                    {
                        // We haven't visited a small cave twice yet, so no matter what, this is a vaild cave.
                        var newDoubleVisitedSmall = cavesVisited.Contains(path);
                        cavesVisited.Add(path);
                        sum += PathsFromCurrentNodeB(cavesVisited, newDoubleVisitedSmall, path, dict);
                        cavesVisited.Remove(path);
                    }
                }
                else
                {
                    sum += PathsFromCurrentNodeB(cavesVisited, doubleVisitedSmall, path, dict);
                }
            }

            return sum;
        }

        private void PrintCaves(Dictionary<string, List<string>> dict)
        {
            foreach(var key in dict.Keys)
            {
                Console.WriteLine(key);
                foreach(var src in dict[key])
                {
                    Console.WriteLine($"> {src}");
                }
            }
        }

        private void AddPathToDict(Dictionary<string, List<string>> dict, string cave1, string cave2)
        {
            if (cave1 == "end") return;
            if (!dict.ContainsKey(cave1))
            {
                dict.Add(cave1, new List<string>());
            }

            if (cave2 != "start")
            {
                dict[cave1].Add(cave2);
            }
        }
    }
}
