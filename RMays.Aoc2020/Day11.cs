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

    public class Day11 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var totalRows = lines.Count();
            var totalCols = lines[0].Length;
            var grid = new char[totalRows, totalCols];

            var row = 0;
            foreach(var line in lines)
            {
                for(int col = 0; col < totalCols; col++)
                {
                    grid[row,col] = line[col];
                }
                row++;
            }

            //PrintGrid(grid);

            var prevGrids = new HashSet<string>();
            while(!prevGrids.Contains(GridToString(grid)))
            {
                prevGrids.Add(GridToString(grid));
                ProcessGridStep(ref grid, IsPartB);

                //PrintGrid(grid);
            }

            // done!
            return GetOccupiedSeats(grid);
        }

        private void ProcessGridStep(ref char[,] grid, bool IsPartB)
        {
            var newGrid = new char[grid.GetLongLength(0), grid.GetLongLength(1)];
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    switch(grid[row,col])
                    {
                        case '.':
                            newGrid[row, col] = '.';
                            break;
                        case '#':
                            int adj;
                            if (!IsPartB)
                            {
                                adj = GetAdjacentOccupiedSeats(grid, row, col);
                            }
                            else
                            {
                                adj = GetAdjacentOccupiedSeatsB(grid, row, col);
                            }
                            if ((!IsPartB && adj >= 4) || (IsPartB && adj >= 5))
                            { 
                                newGrid[row, col] = 'L';
                            }
                            else
                            {
                                newGrid[row, col] = '#';
                            }
                            break;
                        case 'L':
                            int adj2;
                            if (!IsPartB)
                            {
                                adj2 = GetAdjacentOccupiedSeats(grid, row, col);
                            }
                            else
                            {
                                adj2 = GetAdjacentOccupiedSeatsB(grid, row, col);
                            }
                            if (adj2 == 0)
                            {
                                newGrid[row, col] = '#';
                            }
                            else
                            {
                                newGrid[row, col] = 'L';
                            }
                            break;
                        default:
                            throw new ApplicationException("Invalid char: " + grid[row, col]);
                    }
                }
            }

            grid = newGrid;
        }

        private int GetAdjacentOccupiedSeats(char[,] grid, int row, int col)
        {
            var occupiedSeats = 0;
            for(var iRow = row - 1; iRow <= row + 1; iRow++)
            {
                if (iRow < 0 || iRow >= grid.GetLongLength(0)) continue;
                for(var iCol = col - 1; iCol <= col + 1; iCol++)
                {
                    if (iCol < 0 || iCol >= grid.GetLongLength(1)) continue;
                    if (iCol == col && iRow == row) continue;
                    if (grid[iRow,iCol] == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }
            return occupiedSeats;
        }

        private int GetAdjacentOccupiedSeatsB(char[,] grid, int row, int col)
        {
            var occupiedSeats = 0;
            for (var iDeltaRow = -1; iDeltaRow <= 1; iDeltaRow++)
            {
                for (var iDeltaCol = -1; iDeltaCol <= 1; iDeltaCol++)
                {
                    if (iDeltaRow == 0 && iDeltaCol == 0) continue;
                    int iScale = 0;
                    char currSeat = '.';
                    while(currSeat == '.')
                    {
                        iScale++;
                        currSeat = GetSeat(grid, row + (iScale * iDeltaRow), col + (iScale * iDeltaCol));
                    }
                    if (currSeat == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }
            return occupiedSeats;
        }

        private char GetSeat(char[,] grid, int row, int col)
        {
            if (row < 0 || row >= grid.GetLongLength(0))
            {
                return 'L';
            }
            if (col < 0 || col >= grid.GetLongLength(1))
            {
                return 'L';
            }
            return grid[row, col];
        }



        private void PrintGrid(char[,] grid)
        {
            Console.WriteLine(GridToString(grid));
        }

        private int GetOccupiedSeats(char[,] grid)
        {
            int seatsCount = 0;
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    if (grid[row,col] == '#')
                    {
                        seatsCount++;
                    }
                }
            }

            return seatsCount;
        }

        private string GridToString(char[,] grid)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < grid.GetLongLength(0); row++)
            {
                for (int col = 0; col < grid.GetLongLength(1); col++)
                {
                    sb.Append(grid[row, col]);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
