using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day18
    {
        public class Grid
        {
            protected Spot[,] spotGrid { get; set; }

            public int Rows { get; set; }
            public int Cols { get; set; }

            public int Score => GetTotalTrees() * GetTotalLumberYards();

            public Grid(string input)
            {
                ReadGrid(input);
            }

            public int GetTotalOfSpot(Spot spot)
            {
                int freq = 0;
                for (var row = 0; row < Rows; row++)
                {
                    for (var col = 0; col < Cols; col++)
                    {
                        if (GetSpot(row, col) == spot) freq++;
                    }
                }
                return freq;
            }

            public int GetTotalTrees()
            {
                return GetTotalOfSpot(Spot.Trees);
            }
            public int GetTotalLumberYards()
            {
                return GetTotalOfSpot(Spot.LumberYard);
            }

            private void SetSpot(int row, int col, Spot spot)
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    return;
                }

                spotGrid[row, col] = spot;
            }

            private void SetSpot(Coords coord, Spot spot)
            {
                SetSpot(coord.Row, coord.Col, spot);
            }

            private Spot GetSpot(int row, int col)
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                {
                    return Spot.Open;
                }

                return spotGrid[row, col];
            }

            private Spot GetSpot(Coords coord)
            {
                return GetSpot(coord.Row, coord.Col);
            }

            private void ReadGrid(string input)
            {
                // x=495, y=2..7
                // y=7, x=495..501

                // y is row
                // x is col
                var lines = Parser.TokenizeLines(input);
                Rows = lines.Count;
                Cols = lines[0].Length;

                spotGrid = new Spot[Rows, Cols];

                var row = 0;
                foreach (var line in lines)
                {
                    var col = 0;
                    foreach (char c in line.ToCharArray())
                    {
                        spotGrid[row, col] = GetSpotFromChar(c);
                        col++;
                    }
                    row++;
                }
            }

            public void Run(int timesToRun)
            {
                for(var i = 1; i <= timesToRun; i++)
                {
                    RunOnce();
                    Console.WriteLine($"{i} ({i % 28}): {this.Score}");
                }
            }

            public void RunOnce()
            {
                // Create a copy.
                var gridCopy = new Spot[Rows, Cols];
                for(var row = 0; row < Rows; row++)
                {
                    for(var col = 0; col < Cols; col++)
                    {
                        gridCopy[row, col] = spotGrid[row, col];
                    }
                }

                for (var row = 0; row < Rows; row++)
                {
                    for (var col = 0; col < Cols; col++)
                    {
                        var trees = 0;
                        var lumberYards = 0;
                        for (var innerRow = row - 1; innerRow <= row + 1; innerRow++)
                        {
                            for (var innerCol = col - 1; innerCol <= col + 1; innerCol++)
                            {
                                if (innerRow == row && innerCol == col) continue;
                                if (innerRow < 0 || innerRow >= Rows || innerCol < 0 || innerCol >= Cols) continue;

                                switch (gridCopy[innerRow, innerCol])
                                {
                                    case Spot.Trees:
                                        trees++;
                                        break;
                                    case Spot.LumberYard:
                                        lumberYards++;
                                        break;
                                }
                            }
                        }

                        switch (gridCopy[row, col])
                        {
                            case Spot.Open:
                                if (trees >= 3)
                                {
                                    SetSpot(row, col, Spot.Trees);
                                }
                                break;
                            case Spot.Trees:
                                if (lumberYards >= 3)
                                {
                                    SetSpot(row, col, Spot.LumberYard);
                                }
                                break;
                            case Spot.LumberYard:
                                if (lumberYards < 1 || trees < 1)
                                {
                                    SetSpot(row, col, Spot.Open);
                                }
                                break;
                        }
                    }
                }

            }

            public enum Spot
            {
                Open = 0,
                Trees = 1,
                LumberYard = 2
            }

            public override string ToString()
            {
                var toReturn = new StringBuilder();
                toReturn.AppendLine();

                for (var row = 0; row < Rows; row++)
                {
                    for (var col = 0; col < Cols; col++)
                    {
                        toReturn.Append(GetCharFromSpot(GetSpot(row, col)));
                    }
                    toReturn.AppendLine();
                }
                return toReturn.ToString();
            }

            private Spot GetSpotFromChar(char spot)
            {
                switch (spot)
                {
                    case '.':
                        return Spot.Open;
                    case '|':
                        return Spot.Trees;
                    case '#':
                        return Spot.LumberYard;
                }
                throw new ApplicationException($"Invalid character: {spot}");
            }

            private char GetCharFromSpot(Spot spot)
            {
                switch (spot)
                {
                    case Spot.Open:
                        return '.';
                    case Spot.Trees:
                        return '|';
                    case Spot.LumberYard:
                        return '#';
                }
                return '?';
            }
        }

        public long SolveA(string input)
        {
            var grid = new Grid(input);
            grid.Run(10);

            return grid.Score;
        }

        public long SolveB(string input)
        {
            var grid = new Grid(input);
            grid.Run(1000);

            return grid.Score;
        }
    }
}
