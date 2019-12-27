using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    // run time: 13 minutes.  yikes.  i can improve the algorithm by removing the pathfinding / wallbumping,
    // and store the path lengths in a dictionary of lists.
    public class Day18 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var grid = ReadGrid(input);
            PrintGrid(grid);

            RemoveDeadEnds(ref grid);
            PrintGrid(grid);

            var gridInfo = GetInfoFromGrid(grid);
            Console.WriteLine(gridInfo);

            // We start at 'Start' with no keys.
            // Pick a key, and walk to it.  Figure out how many steps it takes to walk there.

            // For now, let's brute force.
            var paths = new Dictionary<string, long> { { "", 0 } };
            GetAllPaths(grid, gridInfo, ref paths);

            return paths.Values.Min();

            /*
            if (IsPartB)
            {
                return 456;
            }

            return totalSteps;
            */
        }

        private void RemoveDeadEnds(ref char[,] grid)
        {
            var done = false;
            while (!done)
            {
                done = true;
                for (var r = 1; r < grid.GetLongLength(1) - 1; r++)
                {
                    for (var c = 1; c < grid.GetLongLength(0) - 1; c++)
                    {
                        if (grid[c, r] == '#') continue;
                        if (grid[c, r] == '@') continue;
                        if (grid[c, r] >= 'a' && grid[c, r] <= 'z') continue;

                        int walls = 0;
                        if (grid[c + 1, r] == '#') walls++;
                        if (grid[c - 1, r] == '#') walls++;
                        if (grid[c, r + 1] == '#') walls++;
                        if (grid[c, r - 1] == '#') walls++;

                        if (walls >= 3)
                        {
                            grid[c, r] = '#';
                            done = false;
                        }
                    }
                }
            }
        }

        private void GetAllPaths(char[,] grid, GridInfo gridInfo, ref Dictionary<string, long> paths)
        {
            var NewPaths = new Dictionary<string, long>();
            //Console.WriteLine($"GetAllPaths.  Paths: {paths.Count()}");
            foreach (var keysCollected in paths.Keys)
            {
                Coords start;
                if (keysCollected == "")
                {
                    start = gridInfo.Start;
                }
                else
                {
                    var lastKeyPickedUp = keysCollected.ToCharArray().Last();
                    start = gridInfo.Keys[lastKeyPickedUp];
                }
                //Console.WriteLine($"Getting steps from {start} to the best key.  Keys collected: [{keysCollected}]");
                var candidates = new Dictionary<char, long>();

                foreach (var gridKey in gridInfo.Keys.Keys)
                {
                    // Skip trying to get any keys that we already have.
                    if (keysCollected.Contains(gridKey))
                    {
                        continue;
                    }

                    var gridKeyCoord = gridInfo.Keys[gridKey];
                    var steps = GetSteps(grid, start, gridKeyCoord, keysCollected);
                    if (steps != -1)
                    {
                        candidates.Add(gridKey, steps);
                        //Console.WriteLine($"Steps from {start} to {gridKeyCoord}: {steps}");
                    }
                }

                if (!candidates.Any())
                {
                    // Don't include this path going forward.
                    // This happens when we just 'continue' (we don't add any candidates to the master list.)
                    continue;
                }
                else
                {
                    foreach (var candidate in candidates)
                    {
                        //Console.WriteLine($"  Collecting key: [{candidate.Key}].  (Steps to collect: {candidate.Value})");
                        NewPaths.Add(keysCollected + candidate.Key, paths[keysCollected] + candidate.Value);
                    }
                }
            }

            // Call recursively if there's anything in NewPaths.
            if (NewPaths.Count > 0)
            {
                paths = NewPaths;

                // We can clean the paths.  (Important if there's 8 keys we can reach immediately at the beginning.)
                // Group by the final character, then alphabetize within the group.  Keep the one with the lowest steps.
                Dictionary<string, long> BestPaths = new Dictionary<string, long>();
                foreach (var path in paths)
                {
                    var keyFull = path.Key;
                    var keyLast = keyFull.ToCharArray().Last().ToString();
                    var keyFirst = new string(keyFull.ToCharArray().Take(keyFull.Length - 1).ToArray());

                    // Now, sort keyFirst.
                    var x = keyFirst.ToCharArray().ToList();
                    x.Sort();
                    keyFirst = new string(x.ToArray());

                    var newDictKey = keyFirst + keyLast;
                    if (BestPaths.ContainsKey(newDictKey))
                    {
                        if (BestPaths[newDictKey] > path.Value)
                        {
                            BestPaths[newDictKey] = path.Value;
                        }
                        else
                        {
                            // Found it, but we won't replace.
                        }
                    }
                    else
                    {
                        BestPaths.Add(newDictKey, path.Value);
                    }
                }

                paths = BestPaths;

                //Console.WriteLine($"Let's do it again!  Paths to check: {paths.Count()}");
                GetAllPaths(grid, gridInfo, ref paths);
            }
            else
            {
                //Console.WriteLine($"End of this branch.  Paths to check: {paths.Count()}");
            }
        }

        private long GetSteps(char[,] gridChars, Coords start, Coords end, string keysCollected = "")
        {
            // Let's reuse the algorithm from a previous day.

            var Checked = new List<string>();
            var CoordsToCheck = new List<Coords>();
            CoordsToCheck.Add(new Coords { Row = start.Row, Col = start.Col });

            // Initialize a grid (booleans instead of chars).
            // Shortcut!  Treat all doors AND uncollected keys as walls.
            var grid = new bool[gridChars.GetLongLength(0), gridChars.GetLongLength(1)];
            for(var r = 0; r < gridChars.GetLongLength(1); r++)
            {
                for (var c = 0; c < gridChars.GetLongLength(0); c++)
                {
                    var v = gridChars[c, r];
                    switch(v)
                    {
                        case '@':
                            grid[c, r] = false;
                            break;
                        case '.':
                            grid[c, r] = false;
                            break;
                        case '#':
                            grid[c, r] = true;
                            break;
                        default:
                            if (keysCollected.Contains(v.ToString().ToLower()[0]))
                            {
                                grid[c, r] = false;
                            }
                            else
                            {
                                grid[c, r] = true;
                            }
                            break;
                    }
                }
            }
            // Turn the destination into a space we can reach.  Important because the keycheck above would normally make it a wall.
            grid[end.Col, end.Row] = false;

            var count = 0;
            while (CoordsToCheck.Any())
            {
                var CoordsAboutToCheck = new List<Coords>();
                foreach (var coords in CoordsToCheck)
                {
                    // Jump out if we're looking at the destination.
                    if (coords.ToString() == end.ToString())
                    {
                        return count;
                    }

                    Checked.Add(coords.ToString());
                    Coords coordToCheck;

                    coordToCheck = new Coords(coords.Row, coords.Col - 1);
                    if (!grid[coords.Col - 1, coords.Row] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row, coords.Col + 1);
                    if (!grid[coords.Col + 1, coords.Row] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row - 1, coords.Col);
                    if (!grid[coords.Col, coords.Row - 1] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row + 1, coords.Col);
                    if (!grid[coords.Col, coords.Row + 1] && !Checked.Contains(coordToCheck.ToString()))
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

            // We reached the end (we filled every spot), but didn't find the destination.  Return -1 (meaning we didn't find it.)
            return -1;
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

            return grid;
        }

        private GridInfo GetInfoFromGrid(char[,] grid)
        {
            var gridInfo = new GridInfo();
            for (var row = 0; row < grid.GetLongLength(1); row++)
            {
                for (var col = 0; col < grid.GetLongLength(0); col++)
                {
                    switch(grid[col,row])
                    {
                        case '@':
                            gridInfo.Start = new Coords(row, col);
                            break;
                        case '#':
                            break;
                        case '.':
                            break;
                        default:
                            var c = grid[col, row];
                            if (c >= 'a' && c <= 'z')
                            {
                                gridInfo.Keys.Add(c, new Coords(row, col));
                            }
                            else if (c >= 'A' && c <= 'Z')
                            {
                                gridInfo.Doors.Add(c, new Coords(row, col));
                            }
                            else
                            {
                                throw new ApplicationException($"Unexpected character: '{c}'");
                            }
                            break;
                    }
                }
            }
            return gridInfo;
        }

        public class Paths
        {
            // argh.  if i dont' get this now, i probably never will.
            // i need to store the list of paths that we need to try.
            // eg. if there's 2 keys we can reach, we need to store each key we could reach with its count.
            // each Path is distinct based on the keysCollected (this is the sequential list of the keys that are actually collected.)
            // ok that's not bad.

            public Dictionary<string, long> Path = new Dictionary<string, long>();
            // .. and the keysCollected's last character is the last key we collected, so we start there.
        }

        public class GridInfo
        {
            public Coords Start { get; set; }
            public Dictionary<char, Coords> Keys { get; set; }
            public Dictionary<char, Coords> Doors { get; set; }

            public GridInfo()
            {
                Start = new Coords();
                Keys = new Dictionary<char, Coords>();
                Doors = new Dictionary<char, Coords>();
            }

            public override string ToString()
            {
                var toReturn = "";
                toReturn += $"Start: {Start}{Environment.NewLine}";
                toReturn += $"Keys:{Environment.NewLine}";
                if (Keys.Any())
                {
                    foreach (var key in Keys)
                    {
                        toReturn += $"  {key.Key}: {key.Value}{Environment.NewLine}";
                    }
                }
                else
                {
                    toReturn += $"  No keys{Environment.NewLine}";
                }

                toReturn += $"Doors:{Environment.NewLine}";
                if (Doors.Any())
                {
                    foreach (var door in Doors)
                    {
                        toReturn += $"  {door.Key}: {door.Value}{Environment.NewLine}";
                    }
                }
                else
                {
                    toReturn += $"  No doors{Environment.NewLine}";
                }

                return toReturn;
            }
        }

        private void PrintGrid(char[,] grid)
        {
            for(var row = 0; row < grid.GetLongLength(1); row++)
            {
                for(var col = 0; col < grid.GetLongLength(0); col++)
                {
                    Console.Write(grid[col, row]);
                }
                Console.WriteLine();
            }
        }
    }
}
