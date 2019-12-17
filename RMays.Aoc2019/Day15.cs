using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day15 : DayBase<long>
    {
        public long SolveA(string input)
        {
            int dummy1, dummy2;
            var grid = GetGrid(input, 42, 42, out dummy1, out dummy2);


            return 123;
        }

        public bool[,] GetGrid(string input, int rows, int cols, out int endRow, out int endCol)
        {

            var Compy = new IntcodeComp(input);
            Compy.Initialize();
            long lastOutput = -1;

            var currRow = rows / 2;
            var currCol = cols / 2;
            var facing = Direction.North;
            var grid = new bool[rows, cols];

            endRow = -1;
            endCol = -1;

            var startingRow = currRow;
            var startingCol = currCol;

            var laps = 0;
            var movedOff = false;

            while (laps < 2)
            {
                Compy.InjectInput((long)facing);
                Compy.Run();
                lastOutput = Compy.DequeueOutput();
                switch (lastOutput)
                {
                    case 0:
                        switch (facing)
                        {
                            case Direction.North:
                                grid[currRow - 1, currCol] = true;
                                break;
                            case Direction.South:
                                grid[currRow + 1, currCol] = true;
                                break;
                            case Direction.East:
                                grid[currRow, currCol + 1] = true;
                                break;
                            case Direction.West:
                                grid[currRow, currCol - 1] = true;
                                break;
                        }

                        if (laps == 0)
                        {
                            TurnRight(ref facing);
                        }
                        else if (laps == 1)
                        {
                            TurnLeft(ref facing);
                        }

                        break;
                    default: // 1 or 2
                        switch (facing)
                        {
                            case Direction.North:
                                currRow--;
                                break;
                            case Direction.South:
                                currRow++;
                                break;
                            case Direction.East:
                                currCol++;
                                break;
                            case Direction.West:
                                currCol--;
                                break;
                        }

                        if (laps == 0)
                        {
                            TurnLeft(ref facing);
                        }
                        else if (laps == 1)
                        {
                            TurnRight(ref facing);
                        }

                        break;
                }

                if (lastOutput == 2)
                {
                    endRow = currRow;
                    endCol = currCol;
                }

                if (currRow == startingRow && currCol == startingCol)
                {
                    if (movedOff)
                    {
                        laps++;
                        movedOff = false;
                    }
                }
                else
                {
                    movedOff = true;
                }

                //Console.WriteLine($"{currRow},{currCol} facing {facing.ToString()}");
                //PrintGrid(grid, startingRow, startingCol, endRow, endCol);
            }

            return grid;
        }

        private void TurnLeft(ref Direction facing)
        {
            if (facing == Direction.North)
            {
                facing = Direction.West;
            }
            else if (facing == Direction.West)
            {
                facing = Direction.South;
            }
            else if (facing == Direction.South)
            {
                facing = Direction.East;
            }
            else if (facing == Direction.East)
            {
                facing = Direction.North;
            }
        }

        private void TurnRight(ref Direction facing)
        {
            if (facing == Direction.North)
            {
                facing = Direction.East;
            }
            else if (facing == Direction.West)
            {
                facing = Direction.North;
            }
            else if (facing == Direction.South)
            {
                facing = Direction.West;
            }
            else if (facing == Direction.East)
            {
                facing = Direction.South;
            }

        }

        private void PrintGrid(bool[,] grid, int startingRow, int startingCol, int endRow, int endCol)
        {
            var result = "";
            for(var c = 0; c < grid.GetLongLength(1); c++)
            {
                for(var r = 0; r < grid.GetLongLength(0); r++)
                {
                    if (r == startingRow && c == startingCol)
                    {
                        result += "S";
                    }
                    else if (r == endRow && c == endCol)
                    {
                        result += "E";
                    }
                    else
                    {
                        result += (grid[r, c] ? "#" : ".");
                    }
                }
                result += Environment.NewLine;
            }

            // We have a map (boolean grid).
            // How do we navigate through it?  This was solved last year.  Hmm.

            //Console.WriteLine(result);


        }

        public enum Direction
        {
            North = 1,
            South = 2,
            West = 3,
            East = 4
        }

        public long SolveB(string input)
        {
            int endRow;
            int endCol;
            var grid = GetGrid(input, 42, 42, out endRow, out endCol);

            var count = 0;
            var Checked = new List<string>();
            var CoordsToCheck = new List<Coords>();
            //Checked.Add((new Coords { Row = endRow, Col = endCol }).ToString());
            CoordsToCheck.Add(new Coords { Row = endRow, Col = endCol });

            while (CoordsToCheck.Any())
            {
                var CoordsAboutToCheck = new List<Coords>();
                foreach(var coords in CoordsToCheck)
                {
                    Checked.Add(coords.ToString());
                    Coords coordToCheck;

                    coordToCheck = new Coords(coords.Row - 1, coords.Col);
                    if (!grid[coords.Row - 1, coords.Col] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row + 1, coords.Col);
                    if (!grid[coords.Row + 1, coords.Col] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row, coords.Col - 1);
                    if (!grid[coords.Row, coords.Col - 1] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }

                    coordToCheck = new Coords(coords.Row, coords.Col + 1);
                    if (!grid[coords.Row, coords.Col + 1] && !Checked.Contains(coordToCheck.ToString()))
                    {
                        CoordsAboutToCheck.Add(coordToCheck);
                    }
                }
                CoordsAboutToCheck = CoordsAboutToCheck.Distinct().ToList();
                CoordsToCheck.Clear();
                foreach(var coords in CoordsAboutToCheck)
                {
                    CoordsToCheck.Add(coords);
                }
                count++;
            }

            count--;

            //if (count >= 341) throw new ApplicationException("Too high!  Answer must be less than 341.");
            return count;
        }


    }
}
