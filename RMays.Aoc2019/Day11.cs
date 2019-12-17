using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day11 : DayBase<long>
    {
        public long SolveA(string input)
        {
            return Solve(input);
        }

        public long Solve(string input, bool isPartB = false)
        {
            var Compy = new IntcodeComp(input);
            Compy.Initialize();

            int height = 70;
            int width = 120;

            var grid = new bool[height, width];
            var gridTouched = new bool[height, width];
            var robot = new Robot { Row = height / 2, Col = width / 2, FacingDirection = Direction.North };

            grid[height / 2, width / 2] = isPartB;

            var totalInstructions = 0;
            do
            {
                Compy.InjectInput(grid[robot.Row, robot.Col] ? 1 : 0);
                Compy.Run();
                totalInstructions++;

                var colorToPaint = Compy.Outputs[0]; // 0 (false) is black, 1 (true) is white
                var dirToTurn = Compy.Outputs[1]; // 0 is left, 1 is right
                grid[robot.Row, robot.Col] = (colorToPaint == 1);
                gridTouched[robot.Row, robot.Col] = true;
                if (dirToTurn == 0)
                {
                    robot.TurnLeft();
                }
                else
                {
                    robot.TurnRight();
                }

                robot.StepForward();
                Compy.Outputs.Clear();
            } while (!Compy.IsHalted);

            int count = 0;
            for(int r = 0; r < height; r++)
            {
                for(int c = 0; c < width; c++)
                {
                    if (gridTouched[r,c])
                    {
                        count++;
                    }
                }
            }

            if (!isPartB)
            {
                return count;
            }

            var result = "";
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    result += (grid[r, c] ? "X" : " ");
                }
                result += Environment.NewLine;
            }



            return 456;
        }

        public class Robot
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public Direction FacingDirection { get; set; }
            public void StepForward()
            {
                switch(FacingDirection)
                {
                    case Direction.North:
                        Row--;
                        break;
                    case Direction.East:
                        Col++;
                        break;
                    case Direction.South:
                        Row++;
                        break;
                    case Direction.West:
                        Col--;
                        break;
                }
            }

            public void TurnRight()
            {
                if (FacingDirection == Direction.West)
                {
                    FacingDirection = Direction.North;
                }
                else
                {
                    FacingDirection++;
                }
            }

            public void TurnLeft()
            {
                if (FacingDirection == Direction.North)
                {
                    FacingDirection = Direction.West;
                }
                else
                {
                    FacingDirection--;
                }
            }
        }

        public enum Direction
        {
            North,
            East,
            South,
            West
        }

        public long SolveB(string input)
        {
            return Solve(input, true);
        }
    }
}
