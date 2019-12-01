using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day22
    {
        public const int ExtendX = 25;
        public const int ExtendY = 25;

        // x = column
        // y = row
        // coords are: [column, row]
        public long[,] GeoIndexes { get; set; }
        public int[,] Erosions { get; set; }
        public long TargetX { get; set; }
        public long TargetY { get; set; }
        public long Depth { get; set; }
        
        public long GetGeoIndex(long x, long y)
        {
            if (x == 0 && y == 0)
            {
                return 0;
            }
            if (x == TargetX && y == TargetY)
            {
                return 0;
            }
            if (y == 0)
            {
                return 16807 * x;
            }
            if (x == 0)
            {
                return 48271 * y;
            }
            return Erosions[x - 1, y] * Erosions[x, y - 1];
        }

        public int GetErosionLevel(long x, long y)
        {
            return (int)((GetGeoIndex(x, y) + Depth) % 20183);
        }

        public void Build(string input)
        {
            // depth: 510
            // target: 10,10

            var lines = Parser.TokenizeLines(input);
            Depth = long.Parse(lines[0].Split(' ')[1]);
            TargetX = long.Parse(lines[1].Split(' ')[1].Split(',')[0]);
            TargetY = long.Parse(lines[1].Split(' ')[1].Split(',')[1]);

            GeoIndexes = new long[TargetX + ExtendX + 1, TargetY + ExtendY + 1];
            Erosions = new int[TargetX + ExtendX + 1, TargetY + ExtendY + 1];

            for (long y = 0; y <= TargetY + ExtendY; y++)
            {
                for (long x = 0; x <= TargetX + ExtendX; x++)
                {
                    GeoIndexes[x, y] = GetGeoIndex(x, y);
                    Erosions[x, y] = GetErosionLevel(x, y);
                }
            }

            Erosions[TargetX, TargetY] = 0;
        }

        #region Part A

        public long GetRiskLevel()
        {
            var riskLevel = 0;
            for (long y = 0; y <= TargetY; y++)
            {
                for (long x = 0; x <= TargetX; x++)
                {
                    riskLevel += Erosions[x, y] % 3;
                }
            }

            return riskLevel;
        }

        public string GetCave()
        {
            var sb = new StringBuilder();

            for (int y = 0; y < TargetY + ExtendY; y++)
            {
                for (int x = 0; x < TargetX + ExtendX; x++)
                {
                    var spotValue = Erosions[x, y];
                    switch(spotValue % 3)
                    {
                        case 0:
                            sb.Append(".");
                            break;
                        case 1:
                            sb.Append("=");
                            break;
                        case 2:
                            sb.Append("|");
                            break;
                    }
                }
                sb.Append(Environment.NewLine);
            }
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        #endregion

        #region Part B

        internal class GearGrid
        {
            // Tools: Climbing, Torch, Neither
            // Areas: Rocky, Wet, Narrow

            // Rocky: Climbing or Torch
            // Wet: Climbing or Neither
            // Narrow: Torch or Neither

            // level 0: neither (wet or narrow; 1 or 2)
            // level 1: torch (rocky or narrow; 0 or 2)
            // level 2: climbing (rocky or wet; 0 or 1)
            private int[,,] spots;

            private int MaxX; // columns
            private int MaxY; // rows

            public int TargetX { get; set; }
            public int TargetY { get; set; }

            // Turn a grid into a GearGrid.
            public GearGrid(int[,] erosions, int maxX, int maxY)
            {
                var wallValue = -1;
                var spaceValue = int.MaxValue;
                MaxX = maxX;
                MaxY = maxY;
                spots = new int[3, MaxX, MaxY];
                for(int y = 0; y < MaxY; y++)
                {
                    for (int x = 0; x < MaxX; x++)
                    {
                        switch(erosions[x, y] % 3)
                        {
                            case 0: // rocky
                                spots[0, x, y] = wallValue; // neither; you fall down
                                spots[1, x, y] = spaceValue;
                                spots[2, x, y] = spaceValue;
                                break;
                            case 1: // wet
                                spots[0, x, y] = spaceValue;
                                spots[1, x, y] = wallValue; // torch; it gets wet
                                spots[2, x, y] = spaceValue;
                                break;
                            case 2: // narrow
                                spots[0, x, y] = spaceValue;
                                spots[1, x, y] = spaceValue;
                                spots[2, x, y] = wallValue; // climbing; it won't fit
                                break;
                        }
                    }
                }
            }

            public string ToString_Old()
            {
                var sb = new StringBuilder();
                var envDict = new Dictionary<int, string>();
                envDict.Add(0, "Neither");
                envDict.Add(1, "Torch");
                envDict.Add(2, "Climbing");

                for (var env = 0; env < 3; env++)
                {
                    sb.Append($"{envDict[env]}:{Environment.NewLine}");
                    for (int y = 0; y < MaxY; y++)
                    {
                        for (int x = 0; x < MaxX; x++)
                        {
                            var spotValue = spots[env, x, y];
                            sb.Append(spotValue < 0 ? "X" :
                                spotValue > 1000000 ? "." : (spotValue % 10).ToString());
                        }
                        sb.Append(Environment.NewLine);
                    }
                    sb.Append(Environment.NewLine);
                }

                return sb.ToString();
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                var envDict = new Dictionary<int, string>();
                envDict.Add(0, "Neither");
                envDict.Add(1, "Torch");
                envDict.Add(2, "Climbing");

                //sb.Append($"{envDict[env]}:{Environment.NewLine}");
                for (int y = 0; y < MaxY; y++)
                {
                    for (var env = 0; env < 3; env++)
                    {
                        for (int x = 0; x < MaxX; x++)
                        {
                            var spotValue = spots[env, x, y];
                            sb.Append(spotValue < 0 ? "###" :
                                spotValue > 1000000 ? "..." : 
                                    (x == TargetX && y == TargetY ? "!" : " ") + (spotValue % 100).ToString("00"));
                        }
                        sb.Append("   ");
                    }
                    sb.Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);

                return sb.ToString();
            }

            public int GetShortestSteps()
            {
                var start = new ThreeCoord(1, 0, 0);
                var end = new ThreeCoord(1, TargetX, TargetY);

                // Walk around until we reach the end, then keep exploring until we find a shorter path, or we run out of paths.
                var coordsToCheck = new List<ThreeCoord>();
                coordsToCheck.Add(start);
                SetSpot(start, 0);
                while(coordsToCheck.Any())
                {
                    var best = GetSpot(end);

                    // Grab the closest coordinate.
                    //var coord = coordsToCheck.OrderBy(x => (x.Level == end.Level ? 0 : 7) + Math.Abs(x.X - end.X) + Math.Abs(x.Y - end.Y)).First();
                    var coord = coordsToCheck.First();
                    coordsToCheck.Remove(coord);
                    var currScore = GetSpot(coord);

                    if (currScore > best) continue;

                    var currCoord = new ThreeCoord(coord.Level, coord.X, coord.Y + 1);
                    var currCoordScore = GetSpot(currCoord);
                    if (currCoordScore > currScore + 1)
                    {
                        SetSpot(currCoord, currScore + 1);
                        if (!coordsToCheck.Contains(currCoord)) coordsToCheck.Add(currCoord);
                    }

                    currCoord = new ThreeCoord(coord.Level, coord.X, coord.Y - 1);
                    currCoordScore = GetSpot(currCoord);
                    if (currCoordScore > currScore + 1)
                    {
                        SetSpot(currCoord, currScore + 1);
                        if (!coordsToCheck.Contains(currCoord)) coordsToCheck.Add(currCoord);
                    }

                    currCoord = new ThreeCoord(coord.Level, coord.X + 1, coord.Y);
                    currCoordScore = GetSpot(currCoord);
                    if (currCoordScore > currScore + 1)
                    {
                        SetSpot(currCoord, currScore + 1);
                        if (!coordsToCheck.Contains(currCoord)) coordsToCheck.Add(currCoord);
                    }

                    currCoord = new ThreeCoord(coord.Level, coord.X - 1, coord.Y);
                    currCoordScore = GetSpot(currCoord);
                    if (currCoordScore > currScore + 1)
                    {
                        SetSpot(currCoord, currScore + 1);
                        if (!coordsToCheck.Contains(currCoord)) coordsToCheck.Add(currCoord);
                    }

                    for (var levelToCheck = 0; levelToCheck < 3; levelToCheck++)
                    {
                        if (coord.Level != levelToCheck)
                        {
                            currCoord = new ThreeCoord(levelToCheck, coord.X, coord.Y);
                            currCoordScore = GetSpot(currCoord);
                            if (currCoordScore > currScore + 7)
                            {
                                SetSpot(currCoord, currScore + 7);
                                if (!coordsToCheck.Contains(currCoord)) coordsToCheck.Add(currCoord);
                            }
                        }
                    }
                }

                /*
                // Now, let's check the cave.  If there's any unvisited square that's not 1 or 7 points away, then we failed somewhere.
                var visited = new HashSet<ThreeCoord>();
                var unvisited = new HashSet<ThreeCoord>();
                unvisited.Add(start);
                while(unvisited.Any())
                {
                    var coord = unvisited.First();
                    unvisited.Remove(coord);
                    var coordScore = GetSpot(coord);

                    var currCoord = new ThreeCoord(coord.Level, coord.X, coord.Y + 1);
                    var currCoordScore = GetSpot(currCoord);
                    if (currCoordScore != -1)
                    {
                        if (!visited.Contains(currCoord))
                        {
                            if (currCoordScore != coordScore + 1)
                            {
                                Console.WriteLine($"Problem walking from {coord} ({coordScore}) to {currCoord} ({currCoordScore}).");
                            }
                        }
                        if (!unvisited.Contains(currCoord)) unvisited.Add(currCoord);
                    }

                }
                */

                return GetSpot(end);
            }

            public void SetSpot(ThreeCoord coord, int valToSet)
            {
                if (coord.Level < 0 || coord.Level > 2 || coord.Y >= MaxY || coord.Y < 0 || coord.X >= MaxX || coord.X < 0) return;
                spots[coord.Level, coord.X, coord.Y] = valToSet;
            }

            public int GetSpot(ThreeCoord coord)
            {
                if (coord.Level < 0 || coord.Level > 2 || coord.Y >= MaxY || coord.Y < 0 || coord.X >= MaxX || coord.X < 0) return -1;
                return spots[coord.Level, coord.X, coord.Y];
            }
        }

        public class ThreeCoord : IEquatable<ThreeCoord>, ICloneable
        {
            public int Level { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public ThreeCoord()
            {
                Level = 0;
                X = 0;
                Y = 0;
            }

            public ThreeCoord(int level, int x, int y)
            {
                Level = level;
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({Level},{X},{Y})";
            }

            public bool Equals(ThreeCoord other)
            {
                return this.Level == other.Level && this.X == other.X && this.Y == other.Y;
            }

            public object Clone()
            {
                return new ThreeCoord(this.Level, this.X, this.Y);
            }
        }

        public override string ToString()
        {
            return this.GetCave();
        }

        #endregion

        public long SolveA(string input)
        {
            Build(input);
            var cave = this.ToString();
            return GetRiskLevel();
        }

        public long SolveB(string input)
        {
            Build(input);
            var gearGrid = new GearGrid(this.Erosions, (int)this.TargetX + ExtendX, (int)this.TargetY + ExtendY);
            gearGrid.TargetX = (int)this.TargetX;
            gearGrid.TargetY = (int)this.TargetY;

            return gearGrid.GetShortestSteps();
        }
    }
}
