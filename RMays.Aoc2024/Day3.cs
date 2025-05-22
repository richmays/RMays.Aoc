using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day3 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            // Look for: mul(5,5)

            int c = 0;
            int sum = 0;
            bool processMul = true;
            while (c < input.Length)
            {
                // Look for 'mul(', 'do()', and 'don't()'
                int locMul = input.IndexOf("mul(", c);
                int locDo = input.IndexOf("do()", c);
                int locDont = input.IndexOf("don't()", c);

                if (locDo == -1) locDo = int.MaxValue;
                if (locDont == -1) locDont = int.MaxValue;

                // Jump out if there's no more locMul
                if (locMul < 0) break;

                if (locMul < locDo && locMul < locDont)
                {
                    c = locMul + 4;
                    if (IsPartB && !processMul)
                    {
                        // Ignore this potential mul command
                        c += 4;
                        continue;
                    }
                }
                else if (locDo < locDont)
                {
                    processMul = true;
                    c = locDo + 4;
                    continue;
                }
                else if (locDont <= locDo)
                {
                    processMul = false;
                    c = locDont + 7;
                    continue;
                }

                // Eat until there's no digits
                int left = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (input[c] >= '0' && input[c] <= '9')
                    {
                        left = left * 10 + (input[c] - '0');
                    }
                    else
                    {
                        break;
                    }

                    c++;
                }

                // Look for ','
                if (input[c] != ',') continue;

                // Eat until there's no digits
                c++;
                int right = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (input[c] >= '0' && input[c] <= '9')
                    {
                        right = right * 10 + (input[c] - '0');
                    }
                    else
                    {
                        break;
                    }

                    c++;
                }

                // Look for ')'
                if (input[c] != ')') continue;

                sum += left * right;
            }
            return sum;
        }
    }
}
