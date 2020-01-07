using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    #region Day 20
    /*

--- Day 20: Donut Maze ---
You notice a strange pattern on the surface of Pluto and land nearby to get a closer look. Upon closer inspection, you realize you've come across one of
the famous space-warping mazes of the long-lost Pluto civilization!

Because there isn't much space on Pluto, the civilization that used to live here thrived by inventing a method for folding spacetime. Although the
technology is no longer understood, mazes like this one provide a small glimpse into the daily life of an ancient Pluto citizen.

This maze is shaped like a donut. Portals along the inner and outer edge of the donut can instantly teleport you from one side to the other. For example:

         A           
         A           
  #######.#########  
  #######.........#  
  #######.#######.#  
  #######.#######.#  
  #######.#######.#  
  #####  B    ###.#  
BC...##  C    ###.#  
  ##.##       ###.#  
  ##...DE  F  ###.#  
  #####    G  ###.#  
  #########.#####.#  
DE..#######...###.#  
  #.#########.###.#  
FG..#########.....#  
  ###########.#####  
             Z       
             Z       
This map of the maze shows solid walls (#) and open passages (.). Every maze on Pluto has a start (the open tile next to AA) and an end (the open tile
next to ZZ). Mazes on Pluto also have portals; this maze has three pairs of portals: BC, DE, and FG. When on an open tile next to one of these labels,
a single step can take you to the other tile with the same label. (You can only walk on . tiles; labels and empty space are not traversable.)

One path through the maze doesn't require any portals. Starting at AA, you could go down 1, right 8, down 12, left 4, and down 1 to reach ZZ, a total
of 26 steps.

However, there is a shorter path: You could walk from AA to the inner BC portal (4 steps), warp to the outer BC portal (1 step), walk to the inner DE 
(6 steps), warp to the outer DE (1 step), walk to the outer FG (4 steps), warp to the inner FG (1 step), and finally walk to ZZ (6 steps). In total,
this is only 23 steps.

Here is a larger example:

                   A               
                   A               
  #################.#############  
  #.#...#...................#.#.#  
  #.#.#.###.###.###.#########.#.#  
  #.#.#.......#...#.....#.#.#...#  
  #.#########.###.#####.#.#.###.#  
  #.............#.#.....#.......#  
  ###.###########.###.#####.#.#.#  
  #.....#        A   C    #.#.#.#  
  #######        S   P    #####.#  
  #.#...#                 #......VT
  #.#.#.#                 #.#####  
  #...#.#               YN....#.#  
  #.###.#                 #####.#  
DI....#.#                 #.....#  
  #####.#                 #.###.#  
ZZ......#               QG....#..AS
  ###.###                 #######  
JO..#.#.#                 #.....#  
  #.#.#.#                 ###.#.#  
  #...#..DI             BU....#..LF
  #####.#                 #.#####  
YN......#               VT..#....QG
  #.###.#                 #.###.#  
  #.#...#                 #.....#  
  ###.###    J L     J    #.#.###  
  #.....#    O F     P    #.#...#  
  #.###.#####.#.#####.#####.###.#  
  #...#.#.#...#.....#.....#.#...#  
  #.#####.###.###.#.#.#########.#  
  #...#.#.....#...#.#.#.#.....#.#  
  #.###.#####.###.###.#.#.#######  
  #.#.........#...#.............#  
  #########.###.###.#############  
           B   J   C               
           U   P   P               
Here, AA has no direct path to ZZ, but it does connect to AS and CP. By passing through AS, QG, BU, and JO, you can reach ZZ in 58 steps.

In your maze, how many steps does it take to get from the open tile marked AA to the open tile marked ZZ?

    */
    #endregion

    public class Day20 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var grid = ReadGrid(input);

            if (!IsPartB)
            {
                GetSteps(grid, 'A', 'Z');
            }

            return 456;
        }

        private long GetSteps(char[,] grid, char startChar, char endChar)
        {
            var start = GetCoords(grid, startChar)[0];
            start = PortalWiggle(grid, start);
            var end = GetCoords(grid, endChar)[0];

            var Checked = new List<string>();
            var CoordsToCheck = new List<Coords>();
            CoordsToCheck.Add(start);

            var count = 0;
            while (CoordsToCheck.Any())
            {
                var CoordsAboutToCheck = new List<Coords>();
                foreach (var coordsInfo in CoordsToCheck)
                {
                    var coords = coordsInfo;

                    var g = grid[coords.Col, coords.Row];

                    /*
                    if (g != '#' && g != '.' && count > 0)
                    {
                        // We found a portal.
                        var targetPortal = GetCoords(grid, g).First(x => x.Row != coords.Row || x.Col != coords.Col);
                        CoordsToCheck.Add(targetPortal);
                        continue;
                    }
                    */

                    Checked.Add(coords.ToString());
                    Coords coordToCheck;

                    coordToCheck = new Coords(coords.Row, coords.Col - 1);
                    if (IsSteppable(grid, coordToCheck) && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row, coords.Col + 1);
                    if (IsSteppable(grid, coordToCheck) && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row - 1, coords.Col);
                    if (IsSteppable(grid, coordToCheck) && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row + 1, coords.Col);
                    if (IsSteppable(grid, coordToCheck) && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }
                }
                CoordsAboutToCheck = CoordsAboutToCheck.Distinct().ToList();
                CoordsToCheck.Clear();
                foreach (var coords in CoordsAboutToCheck)
                {
                    CoordsToCheck.Add(coords);
                }
                count++;
            }

            //return result;

            return 123123;
        }

        private Coords PortalWiggle(char[,] grid, Coords coord)
        {
            if (grid[coord.Col - 1, coord.Row] == '.')
            {
                return new Coords { Col = coord.Col - 1, Row = coord.Row };
            }
            if (grid[coord.Col + 1, coord.Row] == '.')
            {
                return new Coords { Col = coord.Col + 1, Row = coord.Row };
            }
            if (grid[coord.Col, coord.Row - 1] == '.')
            {
                return new Coords { Col = coord.Col, Row = coord.Row - 1 };
            }
            if (grid[coord.Col, coord.Row + 1] == '.')
            {
                return new Coords { Col = coord.Col, Row = coord.Row + 1 };
            }
            throw new ApplicationException($"Can't wiggle: {coord}");
        }

        private bool IsSteppable(char[,] grid, Coords coord)
        {
            var g = grid[coord.Col, coord.Row];
            return g != '#';
        }

        private bool IsSteppable(char[,] grid, int col, int row)
        {
            return IsSteppable(grid, new Coords { Col = col, Row = row });
        }

        private List<Coords> GetCoords(char[,] grid, char g)
        {
            var results = new List<Coords>();
            for (var r = 0; r < grid.GetLongLength(1); r++)
            {
                for (var c = 0; c < grid.GetLongLength(0); c++)
                {
                    if (grid[c,r] == g)
                    {
                        results.Add(new Coords { Col = c, Row = r });
                    }
                }
            }
            return results;
        }

        private char[,] ReadGrid(string input)
        {
            var cols = input.Split('\r')[0].Length;
            var rows = input.ToCharArray().Where(x => x == '\r').Count() + 1;

            Console.WriteLine($"Rows: {rows}");
            Console.WriteLine($"Cols: {cols}");

            var grid = new char[cols, rows];
            var col = 0;
            var row = 0;
            foreach (char c in input.ToCharArray())
            {
                switch (c)
                {
                    case '\n':
                        continue;
                    case '\r':
                        col = 0;
                        row++;
                        break;
                    default:
                        grid[col, row] = c;
                        col++;
                        break;
                }
            }

            // Replace all portals ('AA', 'ZZ', 'XP', etc) portals with single letters.
            // Let's find the portals first.
            var Portals = new Dictionary<string, List<Coords>>();
            for(var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    var g = grid[c, r];
                    if (IsLetter(g))
                    {
                        // Found the top / left of a portal.
                        // Is it the TOP of a portal?
                        if (r + 2 < rows && IsLetter(grid[c, r + 1]) && grid[c, r + 2] == '.')
                        {
                            var key = $"{g}{grid[c, r + 1]}";
                            var newCoords = new Coords(r + 1, c);
                            AddToPortals(ref Portals, key, newCoords);
                            grid[c, r + 1] = '$';
                        }

                        // Is it the BOTTOM of a portal?
                        else if (r - 1 >= 0 && IsLetter(grid[c, r + 1]) && grid[c, r - 1] == '.')
                        {
                            var key = $"{g}{grid[c, r + 1]}";
                            var newCoords = new Coords(r, c);
                            AddToPortals(ref Portals, key, newCoords);
                            grid[c, r + 1] = '$';
                        }

                        // Is it the LEFT SIDE of the portal?
                        else if (c + 2 < cols && IsLetter(grid[c + 1, r]) && grid[c + 2, r] == '.')
                        {
                            var key = $"{g}{grid[c + 1, r]}";
                            var newCoords = new Coords(r, c + 1);
                            AddToPortals(ref Portals, key, newCoords);
                            grid[c + 1, r] = '$';
                        }

                        // Is it the RIGHT SIDE of the portal?
                        else if (c - 1 >= 0 && IsLetter(grid[c + 1, r]) && grid[c - 1, r] == '.')
                        {
                            var key = $"{g}{grid[c + 1, r]}";
                            var newCoords = new Coords(r, c);
                            AddToPortals(ref Portals, key, newCoords);
                            grid[c + 1, r] = '$';
                        }

                        else
                        {
                            // We missed something!
                            throw new ApplicationException($"Found letter '{g}' at position (c:{c},r:{r}) (max: (c:{cols},r:{rows})) but didn't count it.");
                        }
                    }
                }
            }

            //PrintGrid(grid);

            for (var r = 0; r < grid.GetLongLength(1); r++)
            {
                for (var c = 0; c < grid.GetLongLength(0); c++)
                {
                    var g = grid[c, r];
                    if (g != '#' && g != '.')
                    {
                        grid[c, r] = '#';
                    }
                }
            }

            //PrintGrid(grid);

            var portalAA = Portals["AA"][0];
            var portalZZ = Portals["ZZ"][0];
            grid[portalAA.Col, portalAA.Row] = 'A';
            grid[portalZZ.Col, portalZZ.Row] = 'Z';

            var currPortalId = 'B';
            foreach (var portal in Portals.Where(x => x.Key != "AA" && x.Key != "ZZ"))
            {
                grid[portal.Value[0].Col, portal.Value[0].Row] = currPortalId;
                grid[portal.Value[1].Col, portal.Value[1].Row] = currPortalId;
                currPortalId++;
                if (currPortalId == 'Z') currPortalId = 'b';
            }

            PrintGrid(grid);

            return grid;
        }

        private void PrintGrid(char[,] grid)
        {
            for (var r = 0; r < grid.GetLongLength(1); r++)
            {
                for (var c = 0; c < grid.GetLongLength(0); c++)
                {
                    Console.Write(grid[c, r]);
                }
                Console.WriteLine();
            }
        }

        private void AddToPortals(ref Dictionary<string, List<Coords>> Portals, string key, Coords coords)
        {
            if (Portals.ContainsKey(key))
            {
                Portals[key].Add(coords);
            }
            else
            {
                Portals.Add(key, new List<Coords> { coords });
            }
        }

        private bool IsLetter(char g)
        {
            return g >= 'A' && g <= 'Z';
        }
    }
}
