using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day4 : IDay<long>
    {
        public long SolveA(string input)
        {
            return SolveBase(input, false);
        }

        public long SolveB(string input)
        {
            return SolveBase(input, true);
        }

        public long SolveBase(string input, bool isPartB = false)
        {
            var tokens = Parser.Tokenize(input, '-');
            var start = int.Parse(tokens[0]);
            int end;
            if (input.Contains("-"))
            {
                end = int.Parse(tokens[1]);
            }
            else
            {
                end = start;
            }

            int theCount = 0;
            for (int i = start; i <= end; i++)
            {
                theCount += Matches(i, isPartB) ? 1 : 0;
            }

            return theCount;
        }

        public bool Matches(int i, bool isPartB = false)
        {
            var s = i.ToString();

            // Quick sequential check.
            var foundNonSequential = false;
            for (int x = 0; x <= 4; x++)
            {
                if (s[x] > s[x + 1]) foundNonSequential = true;
            }
            if (foundNonSequential) return false;

            var matches = new List<char>();
            bool foundMatch = false;
            for (int x = 0; x <= 4; x++)
            {
                if (s[x] == s[x + 1])
                {
                    foundMatch = true;
                }
            }

            if (!foundMatch) return false;

            if (!isPartB) return true;

            // Now do the Dict check on each digit.
            var dict = new Dictionary<char, int>();
            for(int x = 0; x < 6; x++)
            {
                if (dict.ContainsKey(s[x]))
                {
                    dict[s[x]]++;
                }
                else
                { 
                    dict.Add(s[x], 1);
                }
            }

            foreach(var item in dict.Values)
            {
                if (item == 2) return true;
            }

            return false;
        }
    }
}
