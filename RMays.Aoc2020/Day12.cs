using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day12 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (IsPartB)
            {
                return SolveB(input);
            }

            var lines = Parser.TokenizeLines(input);
            var facing = Direction.East;
            var eastSpots = 0;
            var southSpots = 0;
            foreach(var line in lines)
            {
                var command = GetCommand(line);
                switch(command.Action)
                {
                    case 'N':
                        southSpots -= command.Value;
                        break;
                    case 'S':
                        southSpots += command.Value;
                        break;
                    case 'W':
                        eastSpots -= command.Value;
                        break;
                    case 'E':
                        eastSpots += command.Value;
                        break;
                    case 'L':
                        for(int i = 0; i < command.Value / 90; i++)
                        {
                            TurnLeft(ref facing);
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < command.Value / 90; i++)
                        {
                            TurnRight(ref facing);
                        }
                        break;
                    case 'F':
                        switch (facing)
                        {
                            case Direction.East:
                                eastSpots += command.Value;
                                break;
                            case Direction.South:
                                southSpots += command.Value;
                                break;
                            case Direction.West:
                                eastSpots -= command.Value;
                                break;
                            case Direction.North:
                                southSpots -= command.Value;
                                break;
                            default:
                                throw new ApplicationException("INvalid facing direction.");
                        }
                        break;
                    default:
                        throw new ApplicationException("Invalid action.");
                }
            }

            return Math.Abs(eastSpots) + Math.Abs(southSpots);
        }

        private long SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);
            var shipEast = 0;
            var shipSouth = 0;
            var waypointEast = 10;
            var waypointSouth = -1;
            
            Console.WriteLine($"Ship: {shipEast}E, {shipSouth}S.  Waypoint: {waypointEast}E, {waypointSouth}S");

            foreach (var line in lines)
            {
                var command = GetCommand(line);
                switch (command.Action)
                {
                    case 'N':
                        waypointSouth -= command.Value;
                        break;
                    case 'S':
                        waypointSouth += command.Value;
                        break;
                    case 'W':
                        waypointEast -= command.Value;
                        break;
                    case 'E':
                        waypointEast += command.Value;
                        break;
                    case 'L':
                        for (int i = 0; i < command.Value / 90; i++)
                        {
                            RotateLeft(ref waypointEast, ref waypointSouth);
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < command.Value / 90; i++)
                        {
                            RotateRight(ref waypointEast, ref waypointSouth);
                        }
                        break;
                    case 'F':
                        shipEast += (command.Value * waypointEast);
                        shipSouth += (command.Value * waypointSouth);
                        break;
                    default:
                        throw new ApplicationException("Invalid action.");
                }

                //Console.WriteLine($"Ship: {shipEast}E, {shipSouth}S.  Waypoint: {waypointEast}E, {waypointSouth}S");
            }

            return Math.Abs(shipEast) + Math.Abs(shipSouth);
        }

        private void RotateLeft(ref int waypointEast, ref int waypointSouth)
        { // 4,10 => 10,-4
            var tmp = waypointEast;
            waypointEast = waypointSouth;
            waypointSouth = tmp * -1;
        }

        private void RotateRight(ref int waypointEast, ref int waypointSouth)
        { // 10,-4  =>  4,10
            var tmp = waypointEast;
            waypointEast = waypointSouth * -1;
            waypointSouth = tmp;
        }

        private Command GetCommand(string line)
        {
            return new Command { Action = line[0], Value = int.Parse(line.Substring(1)) };
        }

        internal enum Direction
        {
            East,
            South,
            West,
            North
        }

        private void TurnAround(ref Direction dir)
        {
            switch (dir)
            {
                case Direction.East:
                    dir = Direction.West;
                    return;
                case Direction.South:
                    dir = Direction.North;
                    return;
                case Direction.West:
                    dir = Direction.East;
                    return;
                case Direction.North:
                    dir = Direction.South;
                    return;
            }
        }

        private void TurnRight(ref Direction dir)
        {
            switch(dir)
            {
                case Direction.East:
                    dir = Direction.South;
                    return;
                case Direction.South:
                    dir = Direction.West;
                    return;
                case Direction.West:
                    dir = Direction.North;
                    return;
                case Direction.North:
                    dir = Direction.East;
                    return;
            }
        }

        private void TurnLeft(ref Direction dir)
        {
            switch (dir)
            {
                case Direction.East:
                    dir = Direction.North;
                    return;
                case Direction.North:
                    dir = Direction.West;
                    return;
                case Direction.West:
                    dir = Direction.South;
                    return;
                case Direction.South:
                    dir = Direction.East;
                    return;
            }
        }

        internal class Command
        {
            public char Action { get; set; }
            public int Value { get; set; }

            public Command() { }
        }
    }
}
