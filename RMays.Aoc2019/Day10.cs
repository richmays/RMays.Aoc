using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    // start: 12:28 AM
    public class Day10 : IDay<long>
    {
        public long SolveA(string input)
        {
            var result = Solve(input);
            return result.Detected;
        }

        public AsteroidDetectorResult Solve(string input)
        {
            var myList = Parser.TokenizeLines(input);
            var rows = myList.Count();
            var cols = myList[0].Length;
            var grid = new bool[rows, cols];
            for(int r = 0; r < rows; r++)
            {
                var currRow = myList[r];
                for(int c = 0; c < cols; c++)
                {
                    grid[r, c] = (currRow[c] == '#');
                }
            }

            var gridDetected = new int[rows, cols];
            int bestDetected = 0;
            int bestX = -1;
            int bestY = -1;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!grid[r, c]) continue;
                    var cellDetected = GetDetected(grid, r, c);
                    Log($"({r},{c}) detected: {cellDetected}");
                    gridDetected[r, c] = cellDetected;
                    if (cellDetected > bestDetected)
                    {
                        bestDetected = cellDetected;
                        bestX = c;
                        bestY = r;
                    }
                }
            }


            return new AsteroidDetectorResult { BestX = bestX, BestY = bestY, Detected = bestDetected };
        }

        private int GetDetected(bool[,] grid, int row, int col)
        {
            int count = 0;
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (row == r && col == c) continue;
                    if (grid[r,c])
                    {
                        if (CanSee(grid, row, col, r, c))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /*
        private bool CanSee(bool[,] grid, int startRow, int startCol, int endRow, int endCol)
        {
            int rowDiff = endRow - startRow;
            int colDiff = endCol - startCol;
            for(int div = 1; div < 10; div++) // 10 is too high.  Get the max somehow.
            {
                if (rowDiff % div != 0 || colDiff % div != 0) continue;

                int fact = 1;
                while(div * fact < )
                // Check the cell that intercepts.
                if (grid[startRow + (rowDiff / div), startCol + (colDiff / div)])
                {
                    return false;
                }
            }

            return true;
        }
        */

        private bool CanSee(bool[,] grid, int startRow, int startCol, int endRow, int endCol)
        {
            // (0,0) to (3,3).  slope: 3/3. check (1,1) and (2,2) for asteroids. (factor: 3)
            // (0,0) to (3,6).  slope: 6/3. check (1,2) and (2,4) for asteroids. (factor: 3)
            // (0,0) to (4,6).  slope: 6/4. check (2,3) for asteroids. (factor: 2)
            int slopeY = endCol - startCol;
            int slopeX = endRow - startRow;

            //List<int> divsToCheck = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            //foreach( int div in divsToCheck) // 11 is probably too high.  Get the max somehow.
            for(int div = 2; div < 30; div++)
            {
                if (slopeY % div != 0 || slopeX % div != 0) continue;

                // 'div' is a divisor of slopeY and slopeX.
                // so, divide the slopeY and slopeX by this divisor,
                //   then add it to each of startCol and startRow repeatedly.

                for (int fact = 1; fact < div; fact++)
                {
                    var candidateRow = startRow + (slopeX / div) * fact;
                    var candidateCol = startCol + (slopeY / div) * fact;
                    // Check the cell that intercepts.
                    if (grid[candidateRow, candidateCol])
                    {
                        Log($"Start: ({startRow},{startCol}), end: ({endRow},{endCol}).  Blocked by: ({candidateRow}, {candidateCol}).");
                        return false;
                    }
                }
            }

            Log($"Start: ({startRow},{startCol}), end: ({endRow},{endCol}).  Not blocked by anything.");
            return true;

        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);
      

            return 456;
        }

        private void Log(string log)
        {
//            Console.WriteLine(log);
        }
    }

    public class AsteroidDetectorResult
    {
        public int BestX { get; set; }
        public int BestY { get; set; }
        public int Detected { get; set; }
    }

}
