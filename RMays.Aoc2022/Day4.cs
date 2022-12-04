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

    public class Day4 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var count = 0;
            foreach(var line in lines)
            {
                var s1 = int.Parse(line.Split(',')[0].Split('-')[0]);
                var e1 = int.Parse(line.Split(',')[0].Split('-')[1]);
                var s2 = int.Parse(line.Split(',')[1].Split('-')[0]);
                var e2 = int.Parse(line.Split(',')[1].Split('-')[1]);
                if (!IsPartB)
                {
                    if (s1 >= s2 && e1 <= e2)
                    {
                        count++;
                    }
                    else if (s1 <= s2 && e1 >= e2)
                    {
                        count++;
                    }
                }
                else
                {
                    if (s1 >= s2 && s1 <= e2)
                    {
                        count++;
                    }
                    else if (e1 >= s2 && e1 <= e2)
                    {
                        count++;
                    }
                    else if (s2 >= s1 && s2 <= e1)
                    {
                        count++;
                    }
                    else if (e2 >= s1 && e2 <= e1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
