using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day5
    {
        public long SolveA(string input)
        {
            return React(input).Length;
        }

        public string React(string input)
        {
            const short diff = 'A' - 'a';
            string polymer = input;
            int curr = 0;
            while (curr < polymer.Length - 1)
            {
                char first = polymer[curr];
                char next = polymer[curr + 1];
                if (first + diff == next || first - diff == next)
                {
                    polymer = polymer.Remove(curr, 2);
                    curr = curr - 2;
                }
                curr++;
                if (curr < 0) curr = 0;
            }
            return polymer;
        }

        public long SolveB(string input)
        {
            int shortest = React(input).Length;
            for (int c = 0; c < 26; c++)
            {
                var newInput = input;
                newInput = newInput.Replace(((char)('A' + c)).ToString(), "");
                newInput = newInput.Replace(((char)('a' + c)).ToString(), "");
                var newLength = React(newInput).Length;
                if (newLength < shortest) shortest = newLength;
            }
            return shortest;
        }
    }
}
