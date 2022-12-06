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

    public class Day6 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lastFour = new Queue<char>();
            var toAdd = (IsPartB ? 14 : 4);
            for (int j = 0; j < toAdd; j++)
            {
                lastFour.Enqueue(input[j]);
            }
            for (int i = 4; i < input.Length; i++)
            {
                lastFour.Enqueue(input[i]);
                lastFour.Dequeue();
                if (lastFour.Select(x => x).Distinct().Count() == toAdd)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
