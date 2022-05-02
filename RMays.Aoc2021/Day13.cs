using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 13
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day13 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            // Structure: List of coords.
            var coords = new List<(int, int)>();
            var lines = Parser.TokenizeLines(input);
            foreach(var line in lines)
            {
                if (line.StartsWith("fold")) break;
                var lineItems = line.Split(',');
                coords.Add((int.Parse(lineItems[0]), int.Parse(lineItems[1])));
            }

            // Make folds.
            lines = lines.Where(x => x.StartsWith("fold")).ToList();
            foreach(var line in lines)
            {
                var axis = line.Split(' ')[2].Split('=')[0];
                var foldIndex = int.Parse(line.Split(' ')[2].Split('=')[1]);
                var newCoords = new List<(int, int)>();

                // Fold!
                foreach (var coord in coords)
                {
                    (int, int) newCoord = (0, 0);
                    if (axis == "y")
                    {
                        newCoord = (coord.Item1, coord.Item2 <= foldIndex ? coord.Item2 : 2 * foldIndex - coord.Item2);
                    }
                    else if (axis == "x")
                    {
                        newCoord = (coord.Item1 <= foldIndex ? coord.Item1 : 2 * foldIndex - coord.Item1, coord.Item2);
                    }
                    else
                    {
                        throw new ApplicationException("Invalid axis: " + axis);
                    }

                    if (!newCoords.Contains(newCoord))
                    {
                        newCoords.Add(newCoord);
                    }
                }

                coords = newCoords;

                if (!IsPartB)
                {
                    // We're just folding once, so jump out.
                    return coords.Count;
                }
            }

            PrintBoard(coords);
            return coords.Count;
        }

        private void PrintBoard(List<(int, int)> coords)
        {
            int maxX = coords.Max(x => x.Item1);
            int maxY = coords.Max(x => x.Item2);

            for(int y = 0; y <= maxY; y++)
            {
                for(int x = 0; x <= maxX; x++)
                {
                    Console.Write(coords.Contains((x, y)) ? 'X' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}
