using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day15 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var numbers = new Dictionary<long, Tuple<long, long>>();

            var line = Parser.Tokenize(input);
            long turn = 1;
            long lastNumberSpoken = 0;
            foreach (var token in line.Select(x => int.Parse(x)))
            {
                Say(numbers, token, turn);
                lastNumberSpoken = token;
                turn++;
            }

            long maxTurn = 2020;
            if (IsPartB)
            {
                maxTurn = 30000000;
            }

            while (turn <= maxTurn)
            {
                var currNumberSpoken = GetNextNumber(numbers, lastNumberSpoken);
                Say(numbers, currNumberSpoken, turn);
                lastNumberSpoken = currNumberSpoken;
                turn++;
            }

            // 2020!
            return lastNumberSpoken;
        }

        private void Say(Dictionary<long, Tuple<long, long>> numbers, long token, long turn)
        {
            if (numbers.ContainsKey(token))
            {
                var currTuple = numbers[token];
                numbers[token] = new Tuple<long, long>(turn, currTuple.Item1);
            }
            else
            {
                numbers.Add(token, new Tuple<long, long>(turn, turn));
            }
        }

        private long GetNextNumber(Dictionary<long, Tuple<long, long>> numbers, long lastNumberSpoken)
        {
            var item = numbers[lastNumberSpoken];
            return item.Item1 - item.Item2;
        }
    }
}
