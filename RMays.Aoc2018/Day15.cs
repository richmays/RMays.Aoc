using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day15
    {
        public enum Spot
        {
            Unknown,
            Space,
            Wall,
            Elf,
            Goblin,
            ElfResting,
            GoblinResting
        };

        public class Spots
        {
            private List<List<Spot>> spots { get; set; }

            public Spots(string grid)
            {
                int row = 0;
                spots = new List<List<Spot>>();
                spots.Add(new List<Spot>());
                foreach (char c in grid)
                {
                    var currSpot = ConvertSpot(c);
                    if (currSpot == Spot.Unknown)
                    {
                        if (c == '\r')
                        {
                            row++;
                            spots.Add(new List<Spot>());
                        }
                    }
                    else
                    {
                        spots[row].Add(currSpot);
                    }
                }
            }

            public Spot GetSpot(int row, int col)
            {
                //if (row < 0 || col < 0) return Spot.Wall;
                try
                {
                    return spots[row][col];
                }
                catch
                {
                    return Spot.Wall;
                }
            }

            public Spot GetSpot(Coords coords)
            {
                return GetSpot(coords.Row, coords.Col);
            }

            public Spot ConvertSpot(char cSpot)
            {
                switch (cSpot)
                {
                    case '.':
                        return Spot.Space;
                    case '#':
                        return Spot.Wall;
                    case 'G':
                        return Spot.Goblin;
                    case 'E':
                        return Spot.Elf;
                    case 'g':
                        return Spot.GoblinResting;
                    case 'e':
                        return Spot.ElfResting;
                }
                return Spot.Unknown;
            }

            public char GetSpotChar(Spot spot)
            {
                switch(spot)
                {
                    case Spot.Wall:
                        return '#';
                    case Spot.Space:
                        return '.';
                    case Spot.Goblin:
                        return 'G';
                    case Spot.Elf:
                        return 'E';
                    case Spot.GoblinResting:
                        return 'G';
                    case Spot.ElfResting:
                        return 'E';
                    default:
                        return '?';
                }
            }
                
            public List<List<Spot>> Rows
            {
                get
                {
                    return spots;
                }
                private set
                {
                    spots = value;
                }
            }

            public string Print()
            {
                string result = "";
                foreach(var row in spots)
                {
                    foreach(var spot in row)
                    {
                        result += GetSpotChar(spot);
                    }
                    result += Environment.NewLine;
                }
                return result.TrimEnd();
            }

            public void MoveTowardsEnemy(Coords currLoc)
            {
                // Figure out what's on this square.
                var currUnit = this.GetSpot(currLoc.Row, currLoc.Col);

                // What are we looking for?
                var targetUnitTypes = (currUnit == Spot.Elf
                    ? new List<Spot> { Spot.Goblin, Spot.GoblinResting }
                    : new List<Spot> { Spot.Elf, Spot.ElfResting });

                // Do it the long way for now.
                // Get a list of all units of that type.  (Don't forget sleeping units.)
                var foundUnitCoords = new List<Coords>();
                for(int row = 0; row < spots.Count; row++)
                {
                    for(int col = 0; col < spots[row].Count; col++)
                    {
                        var spot = GetSpot(row, col);
                        if (targetUnitTypes.Contains(spot))
                        {
                            foundUnitCoords.Add(new Coords(row, col));
                        }
                    }
                }

                // Jump out if we didn't find any enemies.
                if (foundUnitCoords.Count == 0) return;

                // Now get all empty adjacent spots.
                var adjacentSpots = new List<Coords>();
                foreach(var coord in foundUnitCoords)
                {
                    if (GetSpot(coord.Up()) == Spot.Space)
                    {
                        adjacentSpots.Add(coord.Up());
                    }
                    if (GetSpot(coord.Left()) == Spot.Space)
                    {
                        adjacentSpots.Add(coord.Left());
                    }
                    if (GetSpot(coord.Right()) == Spot.Space)
                    {
                        adjacentSpots.Add(coord.Right());
                    }
                    if (GetSpot(coord.Down()) == Spot.Space)
                    {
                        adjacentSpots.Add(coord.Down());
                    }
                }

                // Get the closest spots in the 'adjacentSpots' list.
                List<Coords> alreadyReached = new List<Coords>();
                List<Coords> outerBounds = new List<Coords>();
                List<Coords> newOuterBounds = new List<Coords>();
                List<Coords> closestAdjacentSpots = new List<Coords>();
                outerBounds.Add(currLoc);
                var done = false;
                while (outerBounds.Count > 0 && !done)
                {
                    // Dont come back to these spots.
                    foreach(var coord in outerBounds)
                    {
                        alreadyReached.Add(coord);
                    }

                    newOuterBounds = new List<Coords>();
                    // Take a step in each direction.
                    foreach (var coord in outerBounds)
                    {
                        if (!alreadyReached.Contains(coord.Up()) && !newOuterBounds.Contains(coord.Up()))
                        {
                            if (GetSpot(coord.Up()) == Spot.Space)
                            {
                                newOuterBounds.Add(coord.Up());
                            }
                            else if (adjacentSpots.Contains(coord.Up()))
                            {
                                closestAdjacentSpots.Add(coord.Up());
                            }
                        }
                        if (!alreadyReached.Contains(coord.Left()) && !newOuterBounds.Contains(coord.Left()) && GetSpot(coord.Left()) == Spot.Space)
                        {
                            newOuterBounds.Add(coord.Left());
                        }
                        if (!alreadyReached.Contains(coord.Right()) && !newOuterBounds.Contains(coord.Right()) && GetSpot(coord.Right()) == Spot.Space)
                        {
                            newOuterBounds.Add(coord.Right());
                        }
                        if (!alreadyReached.Contains(coord.Down()) && !newOuterBounds.Contains(coord.Down()) && GetSpot(coord.Down()) == Spot.Space)
                        {
                            newOuterBounds.Add(coord.Down());
                        }
                    }



                }




            }
        }

        public long SolveA(string input)
        {
            var spots = new Spots(input);
            int rowNum = -1;
            foreach(var row in spots.Rows)
            {
                rowNum++;
                int colNum = -1;
                foreach(var spot in row)
                {
                    colNum++;
                    switch(spot)
                    {
                        case Spot.Wall:
                            continue;
                        case Spot.Space:
                            continue;
                        case Spot.Goblin:
                            // Choose the closest spot that's reachable, empty, and adjacent to an Elf.
                            // Move one spot towards that spot.
                            spots.MoveTowardsEnemy(new Coords( rowNum, colNum));

                            // Attack the weakest adjacent Elf.
                            //spots.Attack(new Coords(rowNum, colNum));

                            break;
                        case Spot.Elf:
                            // Move one spot towards a reachable, empty spot adjacent to a Goblin.

                            // Attack the weakest Goblin.
                            break;
                    }
                }
            }


            return 0;
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);
      

            return 0;
        }
    }
}
