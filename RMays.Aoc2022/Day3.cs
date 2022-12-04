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

    public class Day3 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var sum = 0;
            char cItem;

            if (!IsPartB)
            {
                foreach (var line in lines)
                {
                    cItem = GetSimilarItem(line);
                    if (cItem >= 'a' && cItem <= 'z')
                    {
                        sum += cItem - 'a' + 1;
                    }
                    else
                    {
                        sum += cItem - 'A' + 27;
                    }
                }

                return sum;
            }
            else
            {
                for(int i = 0; i < lines.Count; i += 3)
                {
                    var line1 = lines[i];
                    var line2 = lines[i + 1];
                    var line3 = lines[i + 2];

                    cItem = GetSimilarItem(line1, line2, line3);
                    if (cItem >= 'a' && cItem <= 'z')
                    {
                        sum += cItem - 'a' + 1;
                    }
                    else
                    {
                        sum += cItem - 'A' + 27;
                    }
                }

                return sum;
            }
        }

        private char GetSimilarItem(string line)
        {
            var linePart1 = line.Substring(0, line.Length / 2);
            var linePart2 = line.Substring(line.Length / 2);
            foreach (var c in linePart1.ToCharArray())
            {
                if (linePart2.ToCharArray().Contains(c))
                {
                    return c;
                }
            }

            throw new ApplicationException("Couldn't find a similar character: " + line);
        }

        private char GetSimilarItem(string line1, string line2, string line3)
        {
            var cLine2 = line2.ToCharArray();
            var cLine3 = line3.ToCharArray();
            foreach (var c in line1.ToCharArray())
            {
                if (cLine2.Contains(c) && cLine3.Contains(c))
                {
                    return c;
                }
            }

            throw new ApplicationException("Couldn't find a similar characterz " + line1);
        }
    }
}
