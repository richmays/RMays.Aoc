using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 9
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day9 : IDay<long>
    {
        public long Solve(string input, int preambleLength)
        {
            var Preamble = new List<long>();
            var lines = Parser.TokenizeLines(input);
            for(int i = 0; i < preambleLength; i++)
            {
                Preamble.Add(long.Parse(lines[i]));
            }

            int lineNum = preambleLength;
            int indexToReplace = 0;
            while(lineNum < lines.Count())
            {
                long lineVal = long.Parse(lines[lineNum]);
                if (IsValid(Preamble, lineVal))
                {
                    // Keep going
                    Preamble[indexToReplace] = lineVal;
                    indexToReplace = (indexToReplace + 1) % preambleLength;
                }
                else
                {
                    return lineVal;
                }
                lineNum++;
            }

            return -1;
        }

        public long SolveB(string input, int sumToFind)
        {
            var linesStr = Parser.TokenizeLines(input);
            var lines = new List<long>();
            for (int i = 0; i < linesStr.Count(); i++)
            {
                lines.Add(long.Parse(linesStr[i]));
            }

            int iMin = 0;
            int iMax = 1;
            long sum = lines[0] + lines[1];
            while(iMax < lines.Count())
            {
                if (sum < sumToFind)
                {
                    iMax++;
                    sum += lines[iMax];
                }
                else if (sum > sumToFind)
                {
                    sum -= lines[iMin];
                    iMin++;
                }
                else
                {
                    var iSmallest = long.MaxValue;
                    var iLargest = long.MinValue;
                    for(int i = iMin; i <= iMax; i++)
                    {
                        if (lines[i] < iSmallest)
                        {
                            iSmallest = lines[i];
                        }
                        if (lines[i] > iLargest)
                        {
                            iLargest = lines[i];
                        }
                    }

                    return iSmallest + iLargest;
                }
            }

            return -1;
        }

        private bool IsValid(List<long> Preamble, long val)
        {
            for(int i = 0; i < Preamble.Count() - 1; i++)
            {
                for (int j = i+1; j < Preamble.Count(); j++)
                {
                    if (Preamble[i] + Preamble[j] == val)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public long Solve(string input, bool IsPartB = false)
        {
            return -1;
        }
    }
}
