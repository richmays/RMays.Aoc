using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 11
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day11 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var grid = new int[10, 10];
            var lines = Parser.TokenizeLines(input);
            var row = 0;
            foreach (var line in lines)
            {
                var col = 0;
                foreach (var c in line.ToCharArray())
                {
                    grid[row, col] = c - '0';
                    col++;
                }
                row++;
            }

            //PrintGrid(grid);
            if (!IsPartB)
            {
                long totalFlashes = 0;
                for (int i = 0; i < 100; i++)
                {
                    totalFlashes += RunStep(grid);
                }

                return totalFlashes;
            }
            else
            {
                long step = 0;
                long totalFlashes = -1;
                while (totalFlashes != 100)
                {
                    totalFlashes = RunStep(grid);
                    step++;
                }
                return step;
            }
        }

        private long RunStep(int[,] grid)
        {
            // Increment each cell, and
            // build a list of cells that flash.
            var flashQueue = new Stack<(int, int)>();
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    grid[row, col]++;
                    if (grid[row, col] > 9)
                    {
                        flashQueue.Push((row, col));
                    }
                }
            }

            // Keep going until the queue is empty.
            while (flashQueue.Any())
            {
                var coords = flashQueue.Pop();

                var row = coords.Item1;
                var col = coords.Item2;
                for (int dRow = -1; dRow <= 1; dRow++)
                {
                    if (dRow + row >= 10 || dRow + row < 0)
                    {
                        continue;
                    }

                    for (int dCol = -1; dCol <= 1; dCol++)
                    {
                        if (dCol + col >= 10 || dCol + col < 0)
                        {
                            continue;
                        }

                        if (dCol == 0 && dRow == 0)
                        {
                            continue;
                        }

                        grid[row + dRow, col + dCol]++;
                        if (grid[row + dRow, col + dCol] == 10)
                        {
                            flashQueue.Push((row + dRow, col + dCol));
                        }
                    }
                }
            }

            var flashes = 0;
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    if (grid[row, col] > 9)
                    {
                        flashes++;
                        grid[row, col] = 0;
                    }
                }
            }

            return flashes;
        }

        private void PrintGrid(int[,] grid)
        {
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    Console.Write(grid[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
