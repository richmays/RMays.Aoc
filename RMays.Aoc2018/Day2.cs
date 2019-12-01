using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day2
    {
        public long SolveA(string input)
        {
            var myList = Parser.Tokenize(input);

            int appears2count = 0;
            int appears3count = 0;
            foreach(var token in myList)
            {
                var myDict = new Dictionary<char, int>();
                foreach(char c in token)
                {
                    if (!myDict.ContainsKey(c))
                    {
                        myDict.Add(c, 1);
                    }
                    else
                    {
                        myDict[c]++;
                    }
                }

                var appears2 = false;
                var appears3 = false;
                foreach(var key in myDict.Keys)
                {
                    if (myDict[key] == 2)
                    {
                        appears2 = true;
                    }
                    if (myDict[key] == 3)
                    {
                        appears3 = true;
                    }
                }

                if (appears2) appears2count++;
                if (appears3) appears3count++;

            }

            return appears2count * appears3count;
        }

        public string SolveB(string input)
        {
            var myList = Parser.Tokenize(input);

            foreach(var box1 in myList)
            {
                foreach(var box2 in myList)
                {
                    if (box1.GetHashCode() <= box2.GetHashCode()) continue;

                    bool foundDiff = false;
                    bool jumpOut = false;
                    int i = 0;
                    while(i < box1.Length && !jumpOut)
                    {
                        if (box1[i] != box2[i])
                        {
                            if (!foundDiff)
                            {
                                foundDiff = true;
                            }
                            else
                            {
                                jumpOut = true;
                            }
                        }

                        i++;
                    }

                    if (jumpOut)
                    {
                        continue;
                    }

                    // If we got this far, we found the boxes.
                    var result = "";
                    for(int j = 0; j < box1.Length; j++)
                    {
                        if (box1[j] == box2[j])
                        {
                            result += box1[j];
                        }
                    }
                    return result;
                }
            }

            return "?";
        }
    }
}
