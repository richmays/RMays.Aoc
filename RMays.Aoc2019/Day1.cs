using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day1 : IDay<long>
    {
        public long SolveA(string input)
        {
            long sum = 0;
            var myList = Parser.Tokenize(input);
            foreach(var item in myList)
            {
                sum += GetFuel(long.Parse(item));
            }

            return sum;
        }

        private long GetFuel(long input)
        {
            return (input / 3) - 2;
        }

        public long SolveB(string input)
        {
            long sum = 0;
            var myList = Parser.Tokenize(input);
            foreach (var item in myList)
            {
                sum += GetSuperFuel(long.Parse(item));
            }

            return sum;
        }

        private long GetSuperFuel(long input)
        {
            var fuel = GetFuel(input);
            if (fuel <= 0) return 0;
            return fuel + GetSuperFuel(fuel);
        }
    }
}
