using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day3
    {
        public long SolveA(string input)
        {
            var myList = Parser.TokenizeLines(input);

            // Hash values like this: '123,125' (coordinates).
            var myHashset = new HashSet<string>();
            var overlaps = new HashSet<string>();

            foreach (var line in myList)
            {
                // sample token:
                //   #2 @ 486,680: 13x15
                var tokens = line.Split(' ');
                var minX = int.Parse(tokens[2].Split(',')[0]);
                var minY = int.Parse(tokens[2].Replace(":","").Split(',')[1]);
                var maxX = minX + int.Parse(tokens[3].Split('x')[0]) - 1;
                var maxY = minY + int.Parse(tokens[3].Split('x')[1]) - 1;

                for (var currX = minX; currX <= maxX; currX++)
                {
                    for (var currY = minY; currY <= maxY; currY++)
                    {
                        var coords = $"{currX},{currY}";
                        if (myHashset.Contains(coords))
                        {
                            if (!overlaps.Contains(coords))
                            {
                                overlaps.Add(coords);
                            }
                        }
                        else
                        {
                            myHashset.Add(coords);
                        }
                    }
                }
            }

            return overlaps.Count();
        }

        public int SolveB(string input)
        {
            var myList = Parser.TokenizeLines(input);

            // Hash values like this: '123,125' (coordinates).
            var myHashset = new HashSet<string>();
            var overlaps = new HashSet<string>();

            foreach (var line in myList)
            {
                // sample token:
                //   #2 @ 486,680: 13x15
                var tokens = line.Split(' ');
                var minX = int.Parse(tokens[2].Split(',')[0]);
                var minY = int.Parse(tokens[2].Replace(":", "").Split(',')[1]);
                var maxX = minX + int.Parse(tokens[3].Split('x')[0]) - 1;
                var maxY = minY + int.Parse(tokens[3].Split('x')[1]) - 1;

                for (var currX = minX; currX <= maxX; currX++)
                {
                    for (var currY = minY; currY <= maxY; currY++)
                    {
                        var coords = $"{currX},{currY}";
                        if (myHashset.Contains(coords))
                        {
                            if (!overlaps.Contains(coords))
                            {
                                overlaps.Add(coords);
                            }
                        }
                        else
                        {
                            myHashset.Add(coords);
                        }
                    }
                }
            }

            // Check which one doesn't have any coords in 'overlaps'.
            foreach (var line in myList)
            {
                // sample token:
                //   #2 @ 486,680: 13x15
                var tokens = line.Split(' ');
                var minX = int.Parse(tokens[2].Split(',')[0]);
                var minY = int.Parse(tokens[2].Replace(":", "").Split(',')[1]);
                var maxX = minX + int.Parse(tokens[3].Split('x')[0]) - 1;
                var maxY = minY + int.Parse(tokens[3].Split('x')[1]) - 1;

                bool foundOverlap = false;
                for (var currX = minX; currX <= maxX; currX++)
                {
                    for (var currY = minY; currY <= maxY; currY++)
                    {
                        var coords = $"{currX},{currY}";
                        if (overlaps.Contains(coords))
                        {
                            foundOverlap = true;
                            //goto jumpOut;
                        }
                    }
                }
                //jumpOut:
                if (!foundOverlap)
                {
                    return int.Parse(tokens[0].Replace("#", ""));
                }
            }

            return -1;
        }
    }
}
