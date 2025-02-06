using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2023
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
            var lines = Parser.TokenizeLines(input);
            var sum = 0;
            if (!IsPartB)
            {
                foreach (var line in lines)
                {
                    var d1 = -1;
                    var d2 = -1;
                    foreach (var c in line.ToCharArray())
                    {
                        if (c >= '0' && c <= '9')
                        {
                            d1 = int.Parse($"{c}");
                            break;
                        }
                    }

                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        char c = line[i];
                        if (c >= '0' && c <= '9')
                        {
                            d2 = int.Parse($"{c}");
                            break;
                        }
                    }

                    sum += (d1 * 10) + d2;
                }
            }
            else
            {
                // Part B
                var letters = new List<string> {
                    "******",
                    "one",
                    "two",
                    "three",
                    "four",
                    "five",
                    "six",
                    "seven",
                    "eight",
                    "nine"
                };

                foreach (var line in lines)
                {
                    var d1 = -1;
                    var d2 = -1;

                    bool found = false;
                    for (int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];
                        if (c >= '0' && c <= '9')
                        {
                            d1 = int.Parse($"{c}");
                            break;
                        }

                        string substr = line.Substring(0, i+1);
                        //Console.WriteLine(substr);
                        for (int iIndex = 0; iIndex < letters.Count; iIndex++)
                        {
                            if (substr.Contains(letters[iIndex]))
                            {
                                //Console.WriteLine($"Found: {letters[iIndex]}");
                                d1 = iIndex;
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                    }

                    found = false;
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        char c = line[i];
                        if (c >= '0' && c <= '9')
                        {
                            d2 = int.Parse($"{c}");
                            break;
                        }

                        string substr = line.Substring(i);
                        //Console.WriteLine(substr);
                        for (int iIndex = 0; iIndex < letters.Count; iIndex++)
                        {
                            if (substr.Contains(letters[iIndex]))
                            {
                                //Console.WriteLine($"Found: {letters[iIndex]}");
                                d2 = iIndex;
                                found = true;
                                break;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                    }

                    //Console.WriteLine((d1 * 10) + d2);
                    sum += (d1 * 10) + d2;
                }
            }

            return sum;
        }
    }
}
