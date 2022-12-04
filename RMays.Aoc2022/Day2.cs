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

    public class Day2 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            if (IsPartB)
            {
                return SolveB(lines);
            }

            var score = 0;
            foreach(var line in lines)
            {
                var lineScore = 0;
                var p1 = line.Split(' ')[0][0];
                var p2 = line.Split(' ')[1][0];

                // Rock: A X
                // Paper: B Y
                // Scissors: C Z

                switch (p2)
                {
                    case 'X':
                        lineScore += 1;
                        break;
                    case 'Y':
                        lineScore += 2;
                        break;
                    case 'Z':
                        lineScore += 3;
                        break;
                }

                var result = GetResult(p1, p2);
                lineScore += (result * 3) + 3;

                score += lineScore;
            }

            return score;
        }

        private int GetResult(char p1, char p2)
        {
            //Console.WriteLine($"Getting result for: {p1} vs {p2}");
            if (p1 - 'A' == p2 - 'X')
            {
                //Console.WriteLine("  Tie!");
                return 0;
            }

            var tmpResult = -99999;
            switch(p1)
            {
                case 'A':
                    tmpResult = p2 == 'Y' ? 1 : -1;
                    break;
                case 'B':
                    tmpResult = p2 == 'Z' ? 1 : -1;
                    break;
                case 'C':
                    tmpResult = p2 == 'X' ? 1 : -1;
                    break;
            }

            //Console.WriteLine($"  Result: {tmpResult}");
            return tmpResult;
        }

        private long SolveB(List<string> lines)
        {
            var score = 0;
            foreach(var line in lines)
            {
                switch (line)
                {
                    case "A X":
                        score += 3;
                        break;
                    case "B X":
                        score += 1;
                        break;
                    case "C X":
                        score += 2;
                        break;
                    case "A Y":
                        score += 4;
                        break;
                    case "B Y":
                        score += 5;
                        break;
                    case "C Y":
                        score += 6;
                        break;
                    case "A Z":
                        score += 8;
                        break;
                    case "B Z":
                        score += 9;
                        break;
                    case "C Z":
                        score += 7;
                        break;
                }
            }

            return score;
        }
    }
}
