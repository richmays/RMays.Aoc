using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022
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
            // Read input into an array.
            //  ab
            //  cd
            // x[0,0] = 'a'
            // x[0,1] = 'b'
            // x[1,0] = 'c'
            // x[1,1] = 'd'
            // x[row,col] = value
            var grid = ReadInput(input);

            var start = (-1, -1);
            var end = (-1, -1);

            // Find the start and end.
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (!IsPartB)
                    {
                        if (grid[r, c] == 'S')
                        {
                            start = (r, c);
                            grid[r, c] = 'a';
                        }
                    }
                    if (grid[r, c] == 'E')
                    {
                        end = (r, c);
                        grid[r, c] = 'z';
                    }
                }
            }

            if (!IsPartB)
            {
                return SolveA(grid, start, end);
            }

            long bestScore = 999999;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] != 'a') continue;
                    var currScore = SolveA(grid, (r, c), end);
                    if (currScore < bestScore)
                    {
                        bestScore = currScore;
                    }
                }
            }

            return bestScore;
        }

        private long SolveA(char[,] grid, (int, int) start, (int, int) end)
        {
            var dist = new int[grid.GetLength(0), grid.GetLength(1)];
            var maxSteps = 99999;

            // Initialize dist.
            // Also, find the start and end.
            for (int r = 0; r < dist.GetLength(0); r++)
            {
                for (int c = 0; c < dist.GetLength(1); c++)
                {
                    dist[r, c] = maxSteps;
                }
            }

            grid[start.Item1, start.Item2] = 'a';
            grid[end.Item1, end.Item2] = 'z';
            dist[start.Item1, start.Item2] = 0;

            var moveQueue = new Queue<(int, int)>();
            moveQueue.Enqueue(start);

            while (moveQueue.Any())
            {
                var cell = moveQueue.Dequeue();
                var currDist = dist[cell.Item1, cell.Item2];

                // Enqueue each of the 4 directions if we can move there.
                if (cell.Item1 > 0 && dist[cell.Item1 - 1, cell.Item2] == maxSteps)
                {
                    if (grid[cell.Item1 - 1, cell.Item2] <= grid[cell.Item1, cell.Item2] + 1)
                    {
                        dist[cell.Item1 - 1, cell.Item2] = Math.Min(dist[cell.Item1 - 1, cell.Item2], currDist + 1);
                        moveQueue.Enqueue((cell.Item1 - 1, cell.Item2));
                    }
                }
                if (cell.Item1 < dist.GetLength(0) - 1 && dist[cell.Item1 + 1, cell.Item2] == maxSteps)
                {
                    if (grid[cell.Item1 + 1, cell.Item2] <= grid[cell.Item1, cell.Item2] + 1)
                    {
                        dist[cell.Item1 + 1, cell.Item2] = Math.Min(dist[cell.Item1 + 1, cell.Item2], currDist + 1);
                        moveQueue.Enqueue((cell.Item1 + 1, cell.Item2));
                    }
                }
                if (cell.Item2 > 0 && dist[cell.Item1, cell.Item2 - 1] == maxSteps)
                {
                    if (grid[cell.Item1, cell.Item2 - 1] <= grid[cell.Item1, cell.Item2] + 1)
                    {
                        dist[cell.Item1, cell.Item2 - 1] = Math.Min(dist[cell.Item1, cell.Item2 - 1], currDist + 1);
                        moveQueue.Enqueue((cell.Item1, cell.Item2 - 1));
                    }
                }
                if (cell.Item2 < dist.GetLength(1) - 1 && dist[cell.Item1, cell.Item2 + 1] == maxSteps)
                {
                    if (grid[cell.Item1, cell.Item2 + 1] <= grid[cell.Item1, cell.Item2] + 1)
                    {
                        dist[cell.Item1, cell.Item2 + 1] = Math.Min(dist[cell.Item1, cell.Item2 + 1], currDist + 1);
                        moveQueue.Enqueue((cell.Item1, cell.Item2 + 1));
                    }
                }
            }

            // Reset the grid
            //grid[start.Item1, start.Item2] = 'S';
            //grid[end.Item1, end.Item2] = 'E';

            return dist[end.Item1, end.Item2];
        }

        private char[,] ReadInput(string input)
        {
            var lines = Parser.TokenizeLines(input);
            var rows = lines.Count();
            var cols = lines[0].Length;
            var result = new char[rows, cols];

            int row = 0;
            foreach (var line in lines)
            {
                int col = 0;
                foreach(var ch in line.ToCharArray())
                {
                    result[row, col] = ch;
                    col++;
                }
                row++;
            }

            return result;
        }
    }
}
