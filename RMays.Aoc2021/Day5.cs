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

    public class Day5 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            #region Old Helper
            var lowX = 9999999;
            var highX = -999999;
            var lowY = 99999999;
            var highY = -99999999;

            var lines = Parser.TokenizeLines(input);
            foreach (var line in lines)
            {
                var x1 = int.Parse(line.Split(' ')[0].Split(',')[0]);
                var y1 = int.Parse(line.Split(' ')[0].Split(',')[1]);
                var x2 = int.Parse(line.Split(' ')[2].Split(',')[0]);
                var y2 = int.Parse(line.Split(' ')[2].Split(',')[1]);

                //Console.WriteLine($"{x1},{y1} -> {x2},{y2}");
                if (Math.Min(x1, x2) < lowX) lowX = Math.Min(x1, x2);
                if (Math.Min(y1, y2) < lowY) lowY = Math.Min(y1, y2);
                if (Math.Max(x1, x2) > highX) highX = Math.Max(x1, x2);
                if (Math.Max(y1, y2) > highY) highY = Math.Max(y1, y2);
            }

            Console.WriteLine($"Ranges: X: {lowX}-{highX}, Y: {lowY}-{highY}");
            // Ranges: X: 10-989, Y: 10-990

            #endregion

            int[,] grid = new int[highX + 1, highY + 1];

            foreach (var line in lines)
            {
                var x1 = int.Parse(line.Split(' ')[0].Split(',')[0]);
                var y1 = int.Parse(line.Split(' ')[0].Split(',')[1]);
                var x2 = int.Parse(line.Split(' ')[2].Split(',')[0]);
                var y2 = int.Parse(line.Split(' ')[2].Split(',')[1]);

                var dX = (x1 < x2 ? 1 : x1 > x2 ? -1 : 0);
                var dY = (y1 < y2 ? 1 : y1 > y2 ? -1 : 0);

                if (IsPartB || (dX == 0 || dY == 0))
                {
                    var currX = x1;
                    var currY = y1;
                    while (!(currX == x2 && currY == y2)
                        && currX >= lowX && currY >= lowY
                        && currX <= highX && currY <= highY)
                    {
                        grid[currX, currY]++;
                        currX += dX;
                        currY += dY;
                    }
                    grid[x2, y2]++;
                }

                //Console.WriteLine(line);
                //PrintGrid(grid, highX, highY);
            }

            var freq = 0;
            for (int x = 0; x <= highX; x++)
            {
                for (int y = 0; y <= highY; y++)
                {
                    if (grid[x, y] >= 2)
                    {
                        freq++;
                    }
                }
            }

            return freq;
        }

        private void PrintGrid(int[,] grid, int highX, int highY)
        {
            for (int y = 0; y <= highY; y++)
            {
                for (int x = 0; x <= highX; x++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
