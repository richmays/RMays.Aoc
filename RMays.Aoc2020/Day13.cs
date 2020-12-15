using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 13
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day13 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (IsPartB)
            {
                return SolveB(Parser.TokenizeLines(input)[1]);
            }

            var lines = Parser.TokenizeLines(input);
            var earliestDepart = long.Parse(lines[0]);
            var Busses = new List<long>();
            foreach(var token in Parser.Tokenize(lines[1], ','))
            {
                if (token == "x")
                {
                    continue;
                }

                Busses.Add(long.Parse(token));
            }

            long bestBus = -1;
            long bestDepart = earliestDepart * 2;
            for(int i = 0; i < Busses.Count; i++)
            {
                var busNextDepart = (earliestDepart / Busses[i] + 1) * Busses[i];
                if (busNextDepart < bestDepart)
                {
                    bestDepart = busNextDepart;
                    bestBus = Busses[i];
                }
            }

            return bestBus * (bestDepart - earliestDepart);
        }

        private long SolveB(string input)
        {
            var Busses = new Dictionary<long, long>();

            int i = 0;
            foreach (var token in Parser.Tokenize(input, ','))
            {
                if (token == "x")
                {
                    i++;
                    continue;
                }

                Busses.Add(i, long.Parse(token));
                i++;
            }

            // Assume all busses are primes.
            // I hope we can make this assumption.  I'll scan the input...  YES!

            // Maybe we can combine busses?
            // Bus 0: 3
            // Bus 1: 5
            //   answer: 9
            //     Bus 0 (#3) arrives at 9
            //     Bus 1 (#5) arrives at 10.
            //     Therefore: Bus 0 (3) + Bus 1 (5) = Bus 6 (15).  (6 is 15 minus 9)
            // ... identical to: Bus 9 (15)

            while (Busses.Count >= 2)
            {
                // Let's try combining busses.  Let's combine the largest
                var firstBus = Busses.Where(x => x.Value == Busses.Max(x2 => x2.Value)).First();
                Busses.Remove(firstBus.Key);
                var lastBus = Busses.Where(x => x.Value == Busses.Max(x2 => x2.Value)).First();
                Busses.Remove(lastBus.Key);

                long n2 = firstBus.Value - firstBus.Key;

                while ((n2 + lastBus.Key) % lastBus.Value != 0)
                {
                    n2 += firstBus.Value;
                }

                Busses.Add((firstBus.Value * lastBus.Value) - n2, firstBus.Value * lastBus.Value);
            }

            return Busses.First().Value - Busses.First().Key;
        }

        private bool Check(Dictionary<int, int> Busses, long valToCheck)
        {
            foreach(var bus in Busses)
            {
                if ((valToCheck + bus.Key) % bus.Value != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
