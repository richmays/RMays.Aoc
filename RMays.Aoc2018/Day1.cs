using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day1
    {
        public long SolveA(string input)
        {
            var myList = Parser.Tokenize(input);

            long runningCount = 0;
            foreach (var token in myList)
            {
                runningCount += GetDelta(token);
            }

            return runningCount;
        }

        private long GetDelta(string token)
        {
            long delta = 0;
            var sign = token[0];
            var mag = long.Parse(token.Substring(1));
            switch (sign)
            {
                case '+':
                    delta = mag;
                    break;
                case '-':
                    delta = -1 * mag;
                    break;
            }
            return delta;
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);

            long runningCount = 0;
            var safety = 0;
            var foundNums = new HashSet<long>() { 0 };
            while (safety < 999999)
            {
                foreach (var token in myList)
                {
                    runningCount += GetDelta(token);

                    if (foundNums.Contains(runningCount))
                    {
                        return runningCount;
                    }

                    foundNums.Add(runningCount);
                    safety++;
                }
            }

            return -1;
        }
    }
}
