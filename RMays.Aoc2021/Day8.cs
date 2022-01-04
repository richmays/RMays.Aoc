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

    public class Day8 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (!IsPartB)
            {
                return SolveA(input);
            }

            var lines = Parser.TokenizeLines(input);
            var result = 0;
            foreach (var line in lines)
            {
                var signals = line.Split('|')[0].Split(' ')
                    .Select(x => string.Concat(x.OrderBy(c => c)))
                    .Where(x => !string.IsNullOrWhiteSpace(x));
                var outputValues = line.Split('|')[1].Split(' ')
                    .Select(x => string.Concat(x.OrderBy(c => c)))
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();
                //Console.WriteLine(string.Join(",", signals));
                //Console.WriteLine(string.Join(",", outputValues));

                var signalMap = new Dictionary<int, string>();

                // Add easy ones.
                signalMap.Add(1, signals.First(x => x.Length == 2));
                signalMap.Add(4, signals.First(x => x.Length == 4));
                signalMap.Add(7, signals.First(x => x.Length == 3));
                signalMap.Add(8, signals.First(x => x.Length == 7));

                // 3 contains 1.
                signalMap.Add(3, signals.First(x => x.Length == 5 && x.Contains(signalMap[1][0]) && x.Contains(signalMap[1][1])));

                // 6 does NOT contain 1.
                signalMap.Add(6, signals.First(x => x.Length == 6 && (!x.Contains(signalMap[1][0]) || !x.Contains(signalMap[1][1]))));

                // 9 contains 4.
                signalMap.Add(9, signals.First(x => x.Length == 6 && x.Contains(signalMap[4][0]) && x.Contains(signalMap[4][1]) && x.Contains(signalMap[4][2]) && x.Contains(signalMap[4][3])));

                // 0 is the remaining signal with six segments.
                signalMap.Add(0, signals.First(x => x.Length == 6 && x != signalMap[6] && x != signalMap[9]));

                // Get the most frequent letter.
                var freq = string.Concat(string.Join("", signals).OrderBy(c => c));
                var highCount = -1;
                var letter = '?';
                for(char c = 'a'; c <= 'g'; c++)
                {
                    var cCount = freq.ToCharArray().Count(x => x == c);
                    if (cCount > highCount)
                    {
                        highCount = cCount;
                        letter = c;
                    }
                }

                // now, 'letter' is the most common letter.  this is the only letter that isn't in the '2' signal.
                signalMap.Add(2, signals.First(x => x.Length == 5 && !x.Contains(letter)));

                // 5 is the last one.
                signalMap.Add(5, signals.First(x => x.Length == 5 && x != signalMap[2] && x != signalMap[3]));

                // Get the value of the 4 numbers, and add to 'result'.
                result += (1000 * signalMap.First(x => x.Value == outputValues[0]).Key)
                    + (100 * signalMap.First(x => x.Value == outputValues[1]).Key)
                    + (10 * signalMap.First(x => x.Value == outputValues[2]).Key)
                    + (1 * signalMap.First(x => x.Value == outputValues[3]).Key);
            }

            return result;
        }

        public string SortString(string orig)
        {
            return string.Concat(orig.OrderBy(x => x));
        }

        public long SolveA(string input)
        {
            var result = 0;
            var lines = Parser.TokenizeLines(input);
            foreach (var line in lines)
            {
                var tokens = line.Split('|')[1].Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x));
                result += tokens.Where(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7).Count();
            }

            return result;
        }
    }
}
