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

    public class Day1 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLinesRaw(input);
            lines.Add("");
            var currCal = 0;

            if (!IsPartB)
            {
                var maxCal = 0;
                foreach (var line in lines)
                {
                    if (line.Length == 0)
                    {
                        if (currCal > maxCal)
                        {
                            maxCal = currCal;
                        }
                        currCal = 0;
                    }
                    else
                    {
                        currCal += int.Parse(line);
                    }
                }

                return maxCal;
            }

            // Part B!
            // Naive solution first; 3 variables.

            var max1 = 0; // greatest
            var max2 = 0; // 2nd greatest
            var max3 = 0; // 3rd greatest
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    if (currCal > max3)
                    {
                        if (currCal > max2)
                        {
                            if (currCal > max1)
                            {
                                max3 = max2;
                                max2 = max1;
                                max1 = currCal;
                            }
                            else
                            {
                                max3 = max2;
                                max2 = currCal;
                            }
                        }
                        else
                        {
                            max3 = currCal;
                        }
                    }
                    currCal = 0;
                }
                else
                {
                    currCal += int.Parse(line);
                }
            }

            return max1 + max2 + max3;
        }
    }
}
