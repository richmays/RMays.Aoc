using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 15
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day15 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var rows = lines.Count();
            var cols = lines[0].Count();
            var grid = new int[rows * (IsPartB ? 5 : 1), cols * (IsPartB ? 5 : 1)];
            var shortest = new int[rows * (IsPartB ? 5 : 1), cols * (IsPartB ? 5 : 1)];

            //foreach (var line in lines)
            for (var row = 0; row < rows; row++)
            {
                var line = lines[row];
                for (int col = 0; col < cols; col++)
                {
                    grid[row, col] = int.Parse($"{line[col]}");

                    // Initialize the 'shortest' array.
                    shortest[row, col] = 20 * rows * cols;
                }
            }

            if (IsPartB)
            {
                // Stretch 5x in both directions, incrementing each new grid by 1.
                // wrap around 9s to 1.
                for (var superRow = 0; superRow < 5; superRow++)
                {
                    for (var superCol = 0; superCol < 5; superCol++)
                    {
                        // Don't rewrite the top left supercell.
                        if (superRow == 0 && superCol == 0)
                        {
                            continue;
                        }

                        var gridOffset = superRow + superCol;
                        for (var row = 0; row < rows; row++)
                        {
                            for (var col = 0; col < cols; col++)
                            {
                                var newRow = row + (superRow * rows);
                                var newCol = col + (superCol * cols);
                                grid[newRow, newCol] = (grid[row, col] + gridOffset - 1) % 9 + 1;
                            }
                        }
                    }
                }

                rows = rows * 5;
                cols = cols * 5;
            }

            // Clear the top-left (the starting spot).
            shortest[0, 0] = 0;

            var madeFix = true;
            while (madeFix)
            {
                madeFix = false;
                for (var row = 0; row < rows; row++)
                {
                    for (var col = 0; col < cols; col++)
                    {
                        if (row == 0 && col == 0)
                        {
                            continue;
                        }

                        var smallestAdj = shortest[row, col];
                        if (row > 0)
                        {
                            smallestAdj = Math.Min(smallestAdj, shortest[row - 1, col]);
                        }
                        if (col > 0)
                        {
                            smallestAdj = Math.Min(smallestAdj, shortest[row, col - 1]);
                        }
                        if (row < rows - 1)
                        {
                            smallestAdj = Math.Min(smallestAdj, shortest[row + 1, col]);
                        }
                        if (col < cols - 1)
                        {
                            smallestAdj = Math.Min(smallestAdj, shortest[row, col + 1]);
                        }
                        if (smallestAdj + grid[row, col] != shortest[row,col])
                        {
                            madeFix = true;
                            shortest[row, col] = smallestAdj + grid[row, col];
                        }
                    }
                }
            }

            return shortest[rows-1, cols-1];
        }
    }
}
