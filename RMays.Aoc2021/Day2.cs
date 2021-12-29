using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day2 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (IsPartB)
            {
                return SolveB(input);
            }
            var lines = Parser.TokenizeLines(input);
            var horiz = 0;
            var depth = 0;
            foreach(var line in lines)
            {
                switch(line.Split()[0])
                {
                    case "forward":
                        horiz += int.Parse(line.Split()[1]);
                        break;
                    case "down":
                        depth += int.Parse(line.Split()[1]);
                        break;
                    case "up":
                        depth -= int.Parse(line.Split()[1]);
                        break;
                    default:
                        break;
                }
            }

            return horiz * depth;
        }

        public long SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);
            long horiz = 0;
            long depth = 0;
            long aim = 0;
            foreach (var line in lines)
            {
                switch (line.Split()[0])
                {
                    case "forward":
                        var x = int.Parse(line.Split()[1]);
                        horiz += x;
                        depth += (aim * x);
                        break;
                    case "down":
                        aim += int.Parse(line.Split()[1]);
                        break;
                    case "up":
                        aim -= int.Parse(line.Split()[1]);
                        break;
                    default:
                        break;
                }
            }

            return horiz * depth;
        }
    }
}
