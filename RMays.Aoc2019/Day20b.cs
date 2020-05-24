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
You notice a strange pattern on the surface of Pluto and land nearby to get a closer look. Upon closer inspection, you realize
you've come across one of the famous space-warping mazes of the long-lost Pluto civilization!

Because there isn't much space on Pluto, the civilization that used to live here thrived by inventing a method for folding
spacetime. Although the technology is no longer understood, mazes like this one provide a small glimpse into the daily life of an ancient Pluto citizen.

This maze is shaped like a donut. Portals along the inner and outer edge of the donut can instantly teleport you from one side 
to the other. For example:

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
This map of the maze shows solid walls (#) and open passages (.). Every maze on Pluto has a start (the open tile next to AA) 
and an end (the open tile next to ZZ). Mazes on Pluto also have portals; this maze has three pairs of portals: BC, DE, and FG.
When on an open tile next to one of these labels, a single step can take you to the other tile with the same label. (You can 
only walk on . tiles; labels and empty space are not traversable.)

One path through the maze doesn't require any portals. Starting at AA, you could go down 1, right 8, down 12, left 4, and down
1 to reach ZZ, a total of 26 steps.

However, there is a shorter path: You could walk from AA to the inner BC portal (4 steps), warp to the outer BC portal (1 step),
walk to the inner DE (6 steps), warp to the outer DE (1 step), walk to the outer FG (4 steps), warp to the inner FG (1 step),
and finally walk to ZZ (6 steps). In total, this is only 23 steps.

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
Here, AA has no direct path to ZZ, but it does connect to AS and CP. By passing through AS, QG, BU, and JO, you can reach ZZ
in 58 steps.

In your maze, how many steps does it take to get from the open tile marked AA to the open tile marked ZZ?

Your puzzle answer was 516.

The first half of this puzzle is complete! It provides one gold star: *

--- Part Two ---
Strangely, the exit isn't open when you reach it. Then, you remember: the ancient Plutonians were famous for building recursive
spaces.

The marked connections in the maze aren't portals: they physically connect to a larger or smaller copy of the maze. Specifically,
the labeled tiles around the inside edge actually connect to a smaller copy of the same maze, and the smaller copy's inner labeled
tiles connect to yet a smaller copy, and so on.

When you enter the maze, you are at the outermost level; when at the outermost level, only the outer labels AA and ZZ function
(as the start and end, respectively); all other outer labeled tiles are effectively walls. At any other level, AA and ZZ count
as walls, but the other outer labeled tiles bring you one level outward.

Your goal is to find a path through the maze that brings you back to ZZ at the outermost level of the maze.

In the first example above, the shortest path is now the loop around the right side. If the starting level is 0, then taking 
the previously-shortest path would pass through BC (to level 1), DE (to level 2), and FG (back to level 1). Because this is 
not the outermost level, ZZ is a wall, and the only option is to go back around to BC, which would only send you even deeper 
into the recursive maze.

In the second example above, there is no path that brings you to ZZ at the outermost level.

Here is a more interesting example:

             Z L X W       C                 
             Z P Q B       K                 
  ###########.#.#.#.#######.###############  
  #...#.......#.#.......#.#.......#.#.#...#  
  ###.#.#.#.#.#.#.#.###.#.#.#######.#.#.###  
  #.#...#.#.#...#.#.#...#...#...#.#.......#  
  #.###.#######.###.###.#.###.###.#.#######  
  #...#.......#.#...#...#.............#...#  
  #.#########.#######.#.#######.#######.###  
  #...#.#    F       R I       Z    #.#.#.#  
  #.###.#    D       E C       H    #.#.#.#  
  #.#...#                           #...#.#  
  #.###.#                           #.###.#  
  #.#....OA                       WB..#.#..ZH
  #.###.#                           #.#.#.#  
CJ......#                           #.....#  
  #######                           #######  
  #.#....CK                         #......IC
  #.###.#                           #.###.#  
  #.....#                           #...#.#  
  ###.###                           #.#.#.#  
XF....#.#                         RF..#.#.#  
  #####.#                           #######  
  #......CJ                       NM..#...#  
  ###.#.#                           #.###.#  
RE....#.#                           #......RF
  ###.###        X   X       L      #.#.#.#  
  #.....#        F   Q       P      #.#.#.#  
  ###.###########.###.#######.#########.###  
  #.....#...#.....#.......#...#.....#.#...#  
  #####.#.###.#######.#######.###.###.#.#.#  
  #.......#.......#.#.#.#.#...#...#...#.#.#  
  #####.###.#####.#.#.#.#.###.###.#.###.###  
  #.......#.....#.#...#...............#...#  
  #############.#.#.###.###################  
               A O F   N                     
               A A D   M                     
One shortest path through the maze is the following:

Walk from AA to XF (16 steps)
Recurse into level 1 through XF (1 step)
Walk from XF to CK (10 steps)
Recurse into level 2 through CK (1 step)
Walk from CK to ZH (14 steps)
Recurse into level 3 through ZH (1 step)
Walk from ZH to WB (10 steps)
Recurse into level 4 through WB (1 step)
Walk from WB to IC (10 steps)
Recurse into level 5 through IC (1 step)
Walk from IC to RF (10 steps)
Recurse into level 6 through RF (1 step)
Walk from RF to NM (8 steps)
Recurse into level 7 through NM (1 step)
Walk from NM to LP (12 steps)
Recurse into level 8 through LP (1 step)
Walk from LP to FD (24 steps)
Recurse into level 9 through FD (1 step)
Walk from FD to XQ (8 steps)
Recurse into level 10 through XQ (1 step)
Walk from XQ to WB (4 steps)
Return to level 9 through WB (1 step)
Walk from WB to ZH (10 steps)
Return to level 8 through ZH (1 step)
Walk from ZH to CK (14 steps)
Return to level 7 through CK (1 step)
Walk from CK to XF (10 steps)
Return to level 6 through XF (1 step)
Walk from XF to OA (14 steps)
Return to level 5 through OA (1 step)
Walk from OA to CJ (8 steps)
Return to level 4 through CJ (1 step)
Walk from CJ to RE (8 steps)
Return to level 3 through RE (1 step)
Walk from RE to IC (4 steps)
Recurse into level 4 through IC (1 step)
Walk from IC to RF (10 steps)
Recurse into level 5 through RF (1 step)
Walk from RF to NM (8 steps)
Recurse into level 6 through NM (1 step)
Walk from NM to LP (12 steps)
Recurse into level 7 through LP (1 step)
Walk from LP to FD (24 steps)
Recurse into level 8 through FD (1 step)
Walk from FD to XQ (8 steps)
Recurse into level 9 through XQ (1 step)
Walk from XQ to WB (4 steps)
Return to level 8 through WB (1 step)
Walk from WB to ZH (10 steps)
Return to level 7 through ZH (1 step)
Walk from ZH to CK (14 steps)
Return to level 6 through CK (1 step)
Walk from CK to XF (10 steps)
Return to level 5 through XF (1 step)
Walk from XF to OA (14 steps)
Return to level 4 through OA (1 step)
Walk from OA to CJ (8 steps)
Return to level 3 through CJ (1 step)
Walk from CJ to RE (8 steps)
Return to level 2 through RE (1 step)
Walk from RE to XQ (14 steps)
Return to level 1 through XQ (1 step)
Walk from XQ to FD (8 steps)
Return to level 0 through FD (1 step)
Walk from FD to ZZ (18 steps)
This path takes a total of 396 steps to move from AA at the outermost layer to ZZ at the outermost layer.

In your maze, when accounting for recursion, how many steps does it take to get from the open tile marked AA to the open tile
marked ZZ, both at the outermost layer?

    */
    #endregion

    public class Day20b : IDay<long>
    {
        /// <summary>
        /// Contains the list of valid paths from starting portals to end portals.
        /// Example structure (as JSON):
        /// {[
        ///    "A": ["B", {steps: 20, leveldelta: 1}],
        ///         ["C", {steps: 25}]
        ///  ],
        ///    "B": ["A": {steps: 20, leveldelta: -1}]
        ///  ],
        ///    "C": ["A": {steps: 25}]
        ///  ]}
        /// </summary>
        internal class PathDict : Dictionary<char, Dictionary<char, PathData>>
        {
            public override string ToString()
            {
                var result = "";
                foreach(var key in this.Keys)
                {
                    var item = this[key];
                    result += $"{key}:{{";
                    foreach(var key2 in item.Keys)
                    {
                        result += $"({key2},{item[key2]})";
                    }
                    result += $"}}";
                }

                return result;
            }
        }

        internal class PathData
        {
            /// <summary>
            /// How many steps do you need to walk to take this path?
            /// </summary>
            public int Steps { get; set; }

            /// <summary>
            /// Are you going up, down, or staying at the same level?
            /// This is either -1 (inner to outer), 0 (inner to inner, or outer to outer), or 1 (outer to inner).
            /// </summary>
            public int LevelDelta { get; set; }

            public PathData()
            {
                Steps = 0;
                LevelDelta = 0;
            }

            public override string ToString()
            {
                return $"<{Steps}, {LevelDelta}>";
            }
        }

        public long Solve(string input, bool IsPartB = false)
        {
            // Maybe I don't need to start completely over.  Lots of the logic was fine as-is (reading in the maze).
            var grid = ReadGrid(input);
            var paths = GetPathsFromGrid(grid);

            // Collapse the paths; eg; replace 'A->B->C' with 'A->C'.
            CollapsePaths(ref paths);

            PrintGrid(grid);

            // Now, using the 'paths', solve it.
            var steps = SolveWithPaths(paths, IsPartB);

            return steps;
        }

        private void CollapsePaths(ref PathDict paths)
        {
            // If there's any paths with exactly 2 connections, we can remove it by updating the steps / leveldeltas of
            //   the connected paths.
            // Do this later.
        }

        private long SolveWithPaths(PathDict paths, bool IsPartB)
        {
            // Part B isn't supported yet.
            if (IsPartB) return -1;

            // Let's go for a walk.  Start with A, keep adding nodes until we reach Z.




            return -1;
        }

        private PathDict GetPathsFromGrid(char[,] grid)
        {
            var paths = new PathDict();
            for (var r = 0; r < grid.GetLongLength(1); r++)
            {
                for (var c = 0; c < grid.GetLongLength(0); c++)
                {
                    var g = grid[c, r];
                    if (g == '.' || g == '#') continue;

                    // We found a portal!  Let's get a list of all connections to this spot;
                    // the list has the steps and leveldeltas.
                    var result = GetConnectionsFromHere(grid, r, c);

                    if (paths.ContainsKey(g))
                    {
                        foreach(var key in result.Keys)
                        {
                            paths[g].Add(key, result[key]);
                        }
                    }
                    else
                    {
                        paths.Add(g, result);
                    }
                }
            }

            return paths;
        }

        /// <summary>
        /// Get the list of all portals that can be reached from this starting place.
        /// Yes, we have to walk the maze.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private Dictionary<char, PathData> GetConnectionsFromHere(char[,] grid, int row, int col)
        {
            var pathdata = new Dictionary<char, PathData>();

            var start = new Coords(row, col);
            //start = PortalWiggle(grid, start);
            //var end = GetCoords(grid, endChar)[0];

            var Checked = new List<string>();
            var CoordsToCheck = new List<Coords>();
            CoordsToCheck.Add(start);

            var steps = 0;
            while (CoordsToCheck.Any())
            {
                var CoordsAboutToCheck = new List<Coords>();
                foreach (var coordsInfo in CoordsToCheck)
                {
                    var g = grid[coordsInfo.Col, coordsInfo.Row];
                    if (g != '.' && g != '#' && steps > 0)
                    {
                        // TODO: Fix the LevelDelta.
                        pathdata.Add(g, new PathData { Steps = steps - 1, LevelDelta = 0 });

                        // This path is done; jump out.
                        // We'd remove this 'continue' if a portal could appear in the middle of a path.
                        continue;
                    }

                    var coords = coordsInfo;

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

                steps++;
            }

            // We built up PathData; return it.
            return pathdata;
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
            for (var r = 0; r < rows; r++)
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

            // Remove all dead-ends.
            var done = false;
            while (!done)
            {
                done = true;
                for (var r = 1; r < grid.GetLongLength(1) - 1; r++)
                {
                    for (var c = 1; c < grid.GetLongLength(0) - 1; c++)
                    {
                        if (grid[c, r] != '.') continue;
                        int wallCount = 0;
                        wallCount += (grid[c + 1, r] == '#' ? 1 : 0);
                        wallCount += (grid[c - 1, r] == '#' ? 1 : 0);
                        wallCount += (grid[c, r + 1] == '#' ? 1 : 0);
                        wallCount += (grid[c, r - 1] == '#' ? 1 : 0);
                        if (wallCount >= 3)
                        {
                            grid[c, r] = '#';
                            done = false;
                        }
                    }
                }
            }

            return grid;
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
            return (g >= 'A' && g <= 'Z') || (g >= 'a' && g <= 'z');
        }
    }
}
