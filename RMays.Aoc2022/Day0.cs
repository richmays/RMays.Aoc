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

    public class Day0 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            foreach(var line in lines)
            {

            }

            return lines.Count;
        }
    }
}
