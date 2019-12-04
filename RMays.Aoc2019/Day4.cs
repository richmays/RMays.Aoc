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
            return RealSolveA(248345, 746315);

            int thecount = 0;
            //var myList = Parser.Tokenize(input, '-');
            for(int a = 2; a <= 7; a++)
            {
                for (int b = a; b <= 9; b++)
                {
                    if (a == 2 && b < 4) continue;
                    for(int c = b; c <= 9; c++)
                    {
                        if (a == 2 && b == 4 && c < 8) continue;
                        for(int d = c; d <= 9; d++)
                        {
                            if (a == 2 && b == 4 && c == 8 && d < 3) continue;
                            for (int e = d; e <= 9; e++)
                            {
                                if (a == 2 && b == 4 && c == 8 && d == 3 && e < 4) continue;
                                for (int f = e; f <= 9; f++)
                                {
                                    if (a == 2 && b == 4 && c == 8 && d == 3 && e == 4 && f < 5) continue;
                                    
                                    // Adjacent
                                    if (a != b && b != c && c != d && d != e && e != f) continue;

                                    thecount++;

                                    if (a == 7 && b == 4 && c == 6 && d == 3 && e == 1 && f == 5) return thecount;
                                }
                            }
                        }
                    }
                }
            }

            return thecount;
        }

        private int RealSolveA(int start, int end)
        {
            // 1019
            int theCount = 0;
            for(int i = start; i <= end; i++)
            {
                var s = i.ToString();
                bool foundNonSequential = false;
                bool foundMatch = false;
                for(int x = 0; x <= 4; x++)
                {
                    if (s[x] == s[x + 1]) foundMatch = true;
                    if (s[x] > s[x + 1]) foundNonSequential = true;
                }

                if (foundMatch && !foundNonSequential) theCount++;
                
            }
            return theCount;
        }

        public long SolveB(string input)
        {
            return RealSolveB(248345, 746315);
        }

        private int RealSolveB(int start, int end)
        {
            // ?
            int theCount = 0;
            var matches = new List<char>();

            for (int i = start; i <= end; i++)
            {
                theCount += Matches(i) ? 1 : 0;
            }
            return theCount;
        }

        public bool Matches(int i)
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
