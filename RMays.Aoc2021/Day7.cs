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

    public class Day7 : IDay<long>
    {
        private bool PartB = false;

        public long Solve(string input, bool IsPartB = false)
        {
            this.PartB = IsPartB;
            var lines = Parser.TokenizeLines(input);
            var crabs = lines[0].Split(',').Select(x => int.Parse(x)).ToList();

            var avg = (int)crabs.Average(x => x);

            var spent = CheckFuelSpent(crabs, avg);
            // Check the one-offs.
            var spentMore = CheckFuelSpent(crabs, avg + 1);
            var spentLess = CheckFuelSpent(crabs, avg - 1);

            if (spent < spentMore && spent < spentLess)
            {
                return spent;
            }

            var delta = (spent < spentMore ? -1 : 1);
            var spotToCheck = avg;
            var oldSpent = spent;
            while(oldSpent >= spent)
            {
                oldSpent = spent;
                spotToCheck += delta;
                spent = CheckFuelSpent(crabs, spotToCheck);
            }

            return oldSpent;
        }

        private long CheckFuelSpent(List<int> crabs, int position)
        {
            if (!PartB)
            {
                return crabs.Sum(x => Math.Abs(x - position));
            }
            return crabs.Sum(x => Math.Abs(x - position) * (Math.Abs(x - position) + 1) / 2);
        }
    }
}
