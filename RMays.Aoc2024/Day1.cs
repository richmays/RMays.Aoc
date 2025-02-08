using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024
{
    #region Day 1
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day1 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lefts = new List<int>();
            var rights = new List<int>();
            var lines = Parser.TokenizeLines(input);
            foreach (var line in lines)
            {
                lefts.Add(int.Parse(line.Split(' ')[0]));
                rights.Add(int.Parse(line.Split(' ')[3]));
            }

            lefts.Sort();
            rights.Sort();

            var sum = 0;
            if (!IsPartB)
            { 
                for (int i = 0; i < lefts.Count; i++)
                {
                    sum += Math.Abs(lefts[i] - rights[i]);
                }
            }
            else
            {
                // part B!
                foreach(var item1 in lefts)
                {
                    foreach(var item2 in rights)
                    {
                        if (item1 == item2)
                        {
                            sum += item1;
                        }
                    }
                }
            }

            return sum;
        }
    }
}
