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

        public bool[,] Grid;

        public AsteroidDetectorResult Solve(string input)
        {
            var myList = Parser.TokenizeLines(input);
            var rows = myList.Count();
            var cols = myList[0].Length;
            Grid = new bool[rows, cols];
            for(int r = 0; r < rows; r++)
            {
                var currRow = myList[r];
                for(int c = 0; c < cols; c++)
                {
                    Grid[r, c] = (currRow[c] == '#');
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
                    if (!Grid[r, c]) continue;
                    var cellDetected = GetDetected(Grid, r, c);
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
            var result = Solve(input);
            var Asteroids = new List<AsteroidInfo>();

            for (int c = 0; c < Grid.GetLength(0); c++)
            { 
                for (int r = 0; r < Grid.GetLength(1); r++)
                {
                    if (Grid[c,r])
                    {
                        Asteroids.Add(new AsteroidInfo { Row = r, Col = c, DeltaCol = c - result.BestY, DeltaRow = r - result.BestX });
                    }
                }
            }

            // Let's put them in a big master list.  We'll skip asteroids that are blocked.

            // Now let's shoot some asteroids.


            //var AsteroidsShot = new List<AsteroidInfo>();
            Asteroids.Sort();
            
            // Print the list
            foreach(var ast in Asteroids)
            {
                Console.WriteLine(ast);
            }

            // Start shootin'!

            int destroyedSoFar = -1;
            int i = 0;
            while(Asteroids.Any(x => !x.Destroyed))
            {
                i = 0;
                while(i < Asteroids.Count)
                {
                    var currAsteroid = Asteroids[i];
                    if (currAsteroid.Destroyed)
                    {
                        i++;
                        continue;
                    }
                    currAsteroid.Destroyed = true;
                    currAsteroid.DestroyedOrder = ++destroyedSoFar;
                    do
                    {
                        i++;
                    }
                    while (i < Asteroids.Count && currAsteroid.Quadrant == Asteroids[i].Quadrant && currAsteroid.Slope == Asteroids[i].Slope);
                }
            }

            Console.WriteLine("After shootin...");
            foreach (var ast in Asteroids)
            {
                Console.WriteLine(ast);
            }

            return -123;
        }

        private void Log(string log)
        {
//            Console.WriteLine(log);
        }

        private void LogShot(string log)
        {
            Console.WriteLine(log);
        }
    }

    public class AsteroidInfo : IComparable<AsteroidInfo>
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int DeltaRow { get; set; }
        public int DeltaCol { get; set; }
        public bool Destroyed { get; set; }
        public int DestroyedOrder { get; set; } = 0;
        public decimal Slope
        {
            get
            {
                if (DeltaCol == 0) return 999;
                return -DeltaRow / (DeltaCol * 1m);
            }
        }

        public override string ToString()
        {
            return $"{(Destroyed ? $"DESTROYED ({DestroyedOrder})" : "")} ({Row},{Col}) delta=({DeltaRow},{DeltaCol}) q={Quadrant} s={Slope:#0.###} d={Distance:##.###}";
        }

        // Quadrants:
        //  8 1 2
        //  7 * 3
        //  6 5 4
        private int _quadrant = 0;
        public int Quadrant
        {
            get
            {
                if (_quadrant == 0)
                {

                    // im REALLY messing up rows and columns.
                    if (DeltaCol == 0 && DeltaRow > 0) _quadrant = 1;
                    if (DeltaCol > 0 && DeltaRow > 0) _quadrant = 2;
                    if (DeltaCol > 0 && DeltaRow == 0) _quadrant = 3;
                    if (DeltaCol > 0 && DeltaRow < 0) _quadrant = 4;
                    if (DeltaCol == 0 && DeltaRow < 0) _quadrant = 5;
                    if (DeltaCol < 0 && DeltaRow < 0) _quadrant = 6;
                    if (DeltaCol < 0 && DeltaRow == 0) _quadrant = 7;
                    if (DeltaCol < 0 && DeltaRow > 0) _quadrant = 8;

                    _quadrant += 2;
                    if (_quadrant > 8) _quadrant -= 8;
                }
                return _quadrant;
            }
        }

        public double Distance => Math.Sqrt((DeltaRow * DeltaRow) + (DeltaCol * DeltaCol));

        public int CompareTo(AsteroidInfo other)
        {
            int cmpVal;
            
            cmpVal = this.Quadrant.CompareTo(other.Quadrant);
            if (cmpVal != 0) return cmpVal;

            if (this.Quadrant % 2 == 0)
            {
                cmpVal = this.Slope.CompareTo(other.Slope);
                if (cmpVal != 0) return cmpVal;
            }

            cmpVal = this.Distance.CompareTo(other.Distance);
            if (cmpVal != 0) return cmpVal;

            // default
            return cmpVal;
        }


    }

    public class AsteroidDetectorResult
    {
        public int BestX { get; set; }
        public int BestY { get; set; }
        public int Detected { get; set; }
    }

}
