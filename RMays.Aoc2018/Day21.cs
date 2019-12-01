using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day21
    {
        public long SolveA(string input)
        {
            var register = new Day19.Register(input);
            register.Go(day21: true, day21OnlyMinValue: true);

            return register.MinValue_Day21;
        }

        public long SolveB(string input)
        {
            var register = new Day19.Register(input);
            register.Go(day21: true);

            return register.MaxValue_Day21;
        }
    }
}
