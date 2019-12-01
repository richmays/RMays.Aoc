using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day17
    {
        public class Grid
        {
            protected Spot[,] spotGrid { get; set; }

            public int Rows { get; set; }
            public int Cols { get; set; }

            public int ColOffset { get; set; }

            /// <summary>
            /// There's no walls above this line.  (Used for calculating the number of water tiles.)
            /// </summary>
            public int MinRow { get; set; }

            public Grid(string input)
            {
                ReadGrid(input);
            }

            public long TotalWaterTiles()
            {
                long count = 0;
                for(var r = this.MinRow; r < Rows; r++)
                {
                    for (var c = 0; c < Cols; c ++)
                    {
                        if (GetSpot(r,c) == Spot.Water || GetSpot(r, c) == Spot.FlowingWater)
                        {
                            count++;
                        }

                    }
                }

                return count;
            }

            public long CapturedWaterTiles()
            {
                long count = 0;
                for (var r = this.MinRow; r < Rows; r++)
                {
                    for (var c = 0; c < Cols; c++)
                    {
                        if (GetSpot(r, c) == Spot.Water)
                        {
                            count++;
                        }

                    }
                }

                return count;
            }

            private void SetSpot(int row, int col, Spot spot)
            {
                if (row >= Rows) return;
                if (GetSpot(row, col) == Spot.Wall)
                {
                    // We have a problem!
                    throw new ApplicationException("Tried to turn a wall into water!  Can't do that.");
                }

                spotGrid[row, col] = spot;
            }

            private void SetSpot(Coords coord, Spot spot)
            {
                SetSpot(coord.Row, coord.Col, spot);
            }

            private Spot GetSpot(int row, int col)
            {
                if (row >= Rows) return Spot.Space;
                return spotGrid[row, col];
            }

            private Spot GetSpot(Coords coord)
            {
                return GetSpot(coord.Row, coord.Col);
            }

            public void Flow()
            {
                var OuterFlowingWaters = new List<Coords> {
                    new Coords(0, 500 - ColOffset)
                };
                SetSpot(0, 500 - ColOffset, Spot.FlowingWater);

                int overflowCounter = 0;
                int maxOverflowCounter = int.MaxValue - 1;
                while (OuterFlowingWaters.Any() && OuterFlowingWaters.Count < 10000 && overflowCounter < maxOverflowCounter)
                {
                    overflowCounter++;
                    var flowWaterSpot = OuterFlowingWaters.ToArray().First();
                    OuterFlowingWaters.Remove(flowWaterSpot);

                    if (flowWaterSpot.Row >= Rows) continue;

                    // Jump out if it already turned into water.
                    if (GetSpot(flowWaterSpot) == Spot.Water) continue;
                    
                    // Just grab any of the outer flowing water spots.
                    // Water spreads; if it spreads to a hole (look left, then look right),
                    // add them to the OuterFlowingWater list.
                    var col = flowWaterSpot.Col;
                    var row = flowWaterSpot.Row;
                    var colDiff = 0;

                    // Look left.
                    var hitLeftWall = false;
                    var spotToCheck = GetSpot(row + 1, col);
                    while (spotToCheck == Spot.Water || spotToCheck == Spot.Wall)
                    {
                        colDiff--;
                        if (GetSpot(row, col + colDiff) == Spot.Wall)
                        {
                            // We're done; we found a wall, so don't look left any more.
                            hitLeftWall = true;
                            break;
                        }
                        SetSpot(row, col + colDiff, Spot.FlowingWater);
                        spotToCheck = GetSpot(row + 1, col + colDiff);
                    }

                    if (!hitLeftWall)
                    {
                        // Flow down.
                        SetSpot(row + 1, col + colDiff, Spot.FlowingWater);
                        OuterFlowingWaters.Add(new Coords(row + 1, col + colDiff));
                    }

                    var hitRightWall = false;
                    // Look right, if we didn't fall straight down.
                    if (colDiff < 0)
                    {
                        // Look right.
                        colDiff = 0;
                        spotToCheck = GetSpot(row + 1, col);
                        while (spotToCheck == Spot.Water || spotToCheck == Spot.Wall)
                        {
                            colDiff++;
                            if (GetSpot(row, col + colDiff) == Spot.Wall)
                            {
                                // We're done; we found a wall, so don't look right any more.
                                hitRightWall = true;
                                break;
                            }
                            SetSpot(row, col + colDiff, Spot.FlowingWater);
                            spotToCheck = GetSpot(row + 1, col + colDiff);
                        }

                        if (!hitRightWall)
                        {
                            // Flow down.
                            SetSpot(row + 1, col + colDiff, Spot.FlowingWater);
                            OuterFlowingWaters.Add(new Coords(row + 1, col + colDiff));
                        }
                    }

                    // Check if we're trapped.
                    if (hitLeftWall && hitRightWall)
                    {
                        colDiff = 0;

                        // Turn this whole row of flowing water into standing water.    
                        while (GetSpot(row, col + colDiff) == Spot.FlowingWater)
                        {
                            SetSpot(row, col + colDiff, Spot.Water);
                            // If the row above is flowing water, add it to the list to check.
                            if (GetSpot(row - 1, col + colDiff) == Spot.FlowingWater)
                            {
                                OuterFlowingWaters.Add(new Coords(row - 1, col + colDiff));
                            }
                            colDiff--;
                        }

                        colDiff = 1;
                        // Turn this whole row of flowing water into standing water.
                        while (GetSpot(row, col + colDiff) == Spot.FlowingWater)
                        {
                            SetSpot(row, col + colDiff, Spot.Water);
                            // If the row above is flowing water, add it to the list to check.
                            if (GetSpot(row - 1, col + colDiff) == Spot.FlowingWater)
                            {
                                OuterFlowingWaters.Add(new Coords(row - 1, col + colDiff));
                            }
                            colDiff++;
                        }
                    }
                }

                if (OuterFlowingWaters.Count >= 10000 || overflowCounter >= maxOverflowCounter)
                {
                    throw new ApplicationException("Infinite loop detected; jumping out.");
                }
            }

            internal class LineData
            {
                public char First { get; set; }
                public int FirstMag { get; set; }
                public char Second { get; set; }
                public int SecondMagLow { get; set; }
                public int SecondMagHi { get; set; }
            }

            private void ReadGrid(string input)
            {
                // x=495, y=2..7
                // y=7, x=495..501

                // y is row
                // x is col
                var lines = Parser.TokenizeLines(input);
                var lineData = new List<LineData>();
                foreach(var line in lines)
                {
                    var chunks = line.Split(',');
                    var newLineData = new LineData
                    {
                        First = chunks[0][0],
                        FirstMag = int.Parse(chunks[0].Substring(2)),
                        Second = chunks[1][1],
                        SecondMagLow = int.Parse(chunks[1].Split('.')[0].Substring(3)),
                        SecondMagHi = int.Parse(chunks[1].Split('.')[2])
                    };

                    lineData.Add(newLineData);
                }

                var minCol = Math.Min(
                    lineData.Where(x => x.First == 'x').Min(x => x.FirstMag),
                    lineData.Where(x => x.Second == 'x').Min(x => x.SecondMagLow));
                var maxCol = Math.Max(
                    lineData.Where(x => x.First == 'x').Max(x => x.FirstMag),
                    lineData.Where(x => x.Second == 'x').Max(x => x.SecondMagHi));
                var minRow = Math.Min(
                    lineData.Where(x => x.First == 'y').Min(x => x.FirstMag),
                    lineData.Where(x => x.Second == 'y').Min(x => x.SecondMagLow));
                var maxRow = Math.Max(
                    lineData.Where(x => x.First == 'y').Max(x => x.FirstMag),
                    lineData.Where(x => x.Second == 'y').Max(x => x.SecondMagHi));

                this.ColOffset = minCol - 1;
                this.Rows = maxRow + 1;
                this.Cols = maxCol - minCol + 3;
                this.MinRow = minRow;

                spotGrid = new Spot[Rows, Cols];

                foreach (var line in lineData)
                {
                    int row;
                    int col;
                    if (line.First == 'x')
                    {
                        col = line.FirstMag;
                        for (row = line.SecondMagLow; row <= line.SecondMagHi; row++)
                        {
                            spotGrid[row, col - ColOffset] = Spot.Wall;
                        }
                    }
                    else
                    {
                        row = line.FirstMag;
                        for (col = line.SecondMagLow; col <= line.SecondMagHi; col++)
                        {
                            spotGrid[row, col - ColOffset] = Spot.Wall;
                        }
                    }
                }
            }

            public enum Spot
            {
                Space = 0,
                Wall = 1,
                Water = 2,
                FlowingWater = 3
            }

            public override string ToString()
            {
                var toReturn = new StringBuilder();

                /*
                // Print row 0
                for (var col = 0; col < Cols; col++)
                {
                    if (col + ColOffset == 500)
                    {
                        toReturn.Append('+');
                    }
                    else
                    {
                        toReturn.Append(GetCharFromSpot(spotGrid[0, col]));
                    }
                }
                toReturn.AppendLine();
                */
                toReturn.AppendLine();

                // Print the rest of the rows.
                for (var row = MinRow; row < Rows; row++)
                {
                    for (var col = 0; col < Cols; col++)
                    {
                        toReturn.Append(GetCharFromSpot(GetSpot(row, col)));
                    }
                    toReturn.AppendLine();
                }
                return toReturn.ToString();
            }

            private char GetCharFromSpot(Spot spot)
            {
                switch(spot)
                {
                    case Spot.Space:
                        return '.';
                    case Spot.Wall:
                        return 'X';
                    case Spot.Water:
                        return '~';
                    case Spot.FlowingWater:
                        return '|';
                }
                return '?';
            }
        }

        public long SolveA(string input)
        {
            var grid = new Grid(input);
            grid.Flow();

            return grid.TotalWaterTiles();
        }

        public long SolveB(string input)
        {
            var grid = new Grid(input);
            grid.Flow();

            return grid.CapturedWaterTiles();
        }
    }
}
