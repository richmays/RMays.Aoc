using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day10 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            long score = 0;
            long regX = 1;
            var currCycle = 1;
            var CycleCounters = new Queue<int>();
            for (int i = 20; i <= 220; i += 40)
            {
                CycleCounters.Enqueue(i);
            }

            foreach (var line in lines)
            {
                var cmd = line.Split(' ')[0];
                switch (cmd)
                {
                    case "addx":
                        var cmdValue = long.Parse(line.Split(' ')[1]);

                        currCycle++;
                        Console.WriteLine($"C:{currCycle}, X:{regX}");
                        if (CycleCounters.Any() && currCycle >= CycleCounters.Peek())
                        {
                            CycleCounters.Dequeue();
                            score += (currCycle * regX);
                            Console.WriteLine($"a  Adding {currCycle * regX} to score.  Score: {score}");
                        }

                        regX = regX + cmdValue;

                        currCycle++;
                        Console.WriteLine($"C:{currCycle}, X:{regX}");
                        if (CycleCounters.Any() && currCycle >= CycleCounters.Peek())
                        {
                            CycleCounters.Dequeue();
                            score += (currCycle * regX);
                            Console.WriteLine($"b  Adding {currCycle * regX} to score.  Score: {score}");
                        }
                        break;
                    case "noop":
                        currCycle++;
                        Console.WriteLine($"C:{currCycle}, X:{regX}");
                        if (CycleCounters.Any() && currCycle >= CycleCounters.Peek())
                        {
                            CycleCounters.Dequeue();
                            score += (currCycle * regX);
                            Console.WriteLine($"c  Adding {currCycle * regX} to score.  Score: {score}");
                        }
                        break;
                }
            }

            return score;
        }

        public string SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);
            long score = 0;

            // For part B, the sprite is 3 pixels: (regX-1, regX, regX+1).
            long regX = 1;
            var currCycle = 0;

            var result = new StringBuilder();

            foreach (var line in lines)
            {
                var cmd = line.Split(' ')[0];
                switch (cmd)
                {
                    case "addx":
                        var cmdValue = long.Parse(line.Split(' ')[1]);

                        currCycle++;
                        if (currCycle % 40 == 1)
                        {
                            result.Append(Environment.NewLine);
                        }
                        LogCycles(currCycle, regX);
                        result.Append(CheckCycle(currCycle, regX) ? "#" : ".");

                        currCycle++;
                        if (currCycle % 40 == 1)
                        {
                            result.Append(Environment.NewLine);
                        }
                        LogCycles(currCycle, regX);
                        result.Append(CheckCycle(currCycle, regX) ? "#" : ".");

                        regX += cmdValue;

                        break;
                    case "noop":
                        currCycle++;
                        if (currCycle % 40 == 1)
                        {
                            result.Append(Environment.NewLine);
                        }
                        LogCycles(currCycle, regX);
                        result.Append(CheckCycle(currCycle, regX) ? "#" : ".");
                        break;
                }
            }

            //Console.WriteLine(result);
            return result.ToString().Substring(2,250);
        }

        private void LogCycles(int currCycle, long regX)
        {
            //Console.WriteLine($"C:{currCycle}, X:{regX}");
        }

        private bool CheckCycle(int currCycle, long regX)
        {
            //return (Math.Abs(regX - (currCycle % 40)) <= 1);
            var c = currCycle % 40;
            var x = regX;
            return (c == x || c == (x + 1) % 40 || c == (x + 2) % 40);
            
        }
    }
            
}
