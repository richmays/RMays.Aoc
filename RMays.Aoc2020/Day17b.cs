using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day17b : IDay<long>
    {
        public long Solve(string input, bool IsPartB = true)
        {
            var lines = Parser.TokenizeLines(input);
            // Assume we have a square.  It makes the logic much easier.
            // Initialize the grid; we will expand 6 in all directions (X, Y, Z).
            // Input is a square in (X, Y, 0).  BUT, let's add an offset so we don't need to worry about
            // negative array indexes.

            int length = lines.Count(); // sample is 3, real data is ... whatever it is.
            // grid size formula (assuming L is the length of each side of the input):
            // 1 -> (6*2) + 1
            // 2 -> (6*2) + 1

            int cycles = 6;

            bool[,,,] grid = new bool[length + (cycles * 2), length + (cycles * 2), length + (cycles * 2), length + (cycles * 2)];
            int offset = cycles;

            for (int x = 0; x < length + (cycles * 2); x++)
            {
                for (int y = 0; y < length + (cycles * 2); y++)
                {
                    for (int z = 0; z < length + (cycles * 2); z++)
                    {
                        for (int w = 0; w < length + (cycles * 2); w++)
                        {
                            grid[x, y, z, w] = false;
                        }
                    }
                }
            }

            int y2 = offset;
            foreach (var line in lines)
            {
                int x2 = offset;
                foreach(var c in line.ToCharArray())
                {
                    grid[x2, y2, offset, offset] = (c == '#');
                    x2++;
                }
                y2++;
            }


            for (int i = 0; i < 6; i++)
            {
                ProcessCycle(grid);
                //PrintGrid(grid);
            }
            var result = GetActiveCellCount(grid);

            return result;
        }

        private void ProcessCycle(bool[,,,] grid)
        {
            // This will be pretty slow.  But it should be fast enough.
            // Create a temp grid, all falses.
            bool[,,,] tmpGrid = new bool[grid.GetLongLength(0), grid.GetLongLength(1), grid.GetLongLength(2), grid.GetLongLength(3)];

            for (int w = 0; w < grid.GetLongLength(3); w++)
            {
                for (int z = 0; z < grid.GetLongLength(2); z++)
                {
                    for (int y = 0; y < grid.GetLongLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLongLength(0); x++)
                        {
                            var neighbors = GetNeighborsCount(grid, x, y, z, w);
                            if (grid[x, y, z, w])
                            {
                                tmpGrid[x, y, z, w] = (neighbors == 2 || neighbors == 3);
                            }
                            else
                            {
                                tmpGrid[x, y, z, w] = (neighbors == 3);
                            }
                        }
                    }
                }
            }

            // Overwrite the original grid.
            for (int w = 0; w < grid.GetLongLength(3); w++)
            {
                for (int z = 0; z < grid.GetLongLength(2); z++)
                {
                    for (int y = 0; y < grid.GetLongLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLongLength(0); x++)
                        {
                            grid[x, y, z, w] = tmpGrid[x, y, z, w];
                        }
                    }
                }
            }

        }

        private int GetNeighborsCount(bool[,,,] grid, int x, int y, int z, int w)
        {
            int neighbors = 0;
            for(int x2 = -1; x2 <= 1; x2++)
            {
                for(int y2 = -1; y2 <= 1; y2++)
                {
                    for(int z2 = -1; z2 <= 1; z2++)
                    {
                        for (int w2 = -1; w2 <= 1; w2++)
                        {
                            if (x2 == 0 && y2 == 0 && z2 == 0 && w2 == 0) continue;
                            neighbors += (GetCell(grid, x + x2, y + y2, z + z2, w + w2) ? 1 : 0);
                        }
                    }
                }
            }
            return neighbors;
        }

        private bool GetCell(bool[,,,] grid, int x, int y, int z, int w)
        {
            if (x < 0) return false;
            if (y < 0) return false;
            if (z < 0) return false;
            if (w < 0) return false;
            if (x >= grid.GetLongLength(0)) return false;
            if (y >= grid.GetLongLength(1)) return false;
            if (z >= grid.GetLongLength(2)) return false;
            if (w >= grid.GetLongLength(3)) return false;
            return grid[x, y, z, w];
        }

        private void PrintGrid(bool[,,] grid)
        {
            for (int w = 0; w < grid.GetLongLength(3); w++)
            {
                for (int z = 0; z < grid.GetLongLength(2); z++)
                {
                    Console.WriteLine($"Level {z}, W={w}");
                    for (int y = 0; y < grid.GetLongLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLongLength(0); x++)
                        {
                            Console.Write(grid[x, y, z] ? '#' : '.');
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private int GetActiveCellCount(bool[,,,] grid)
        {
            int count = 0;
            for (int w = 0; w < grid.GetLongLength(3); w++)
            {
                for (int z = 0; z < grid.GetLongLength(2); z++)
                {
                    for (int y = 0; y < grid.GetLongLength(1); y++)
                    {
                        for (int x = 0; x < grid.GetLongLength(0); x++)
                        {
                            count += (grid[x, y, z, w] ? 1 : 0);
                        }
                    }
                }
            }
        
            return count;
        }
    }
}
