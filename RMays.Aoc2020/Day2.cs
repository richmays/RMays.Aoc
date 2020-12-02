using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 2
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day2 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            List<string> lines = Parser.TokenizeLines(input);
            var valids = 0;
            foreach(var line in lines)
            {
                if (IsPartB)
                {
                    if (IsValidB(line))
                    {
                        valids++;
                    }
                }
                else
                {


                    if (IsValid(line))
                    {
                        valids++;
                    }
                }
            }

            return valids;



        }

        private bool IsValid(string line)
        {
            var tokens = line.Split(' ');
            var min = int.Parse(tokens[0].Split('-')[0]);
            var max = int.Parse(tokens[0].Split('-')[1]);
            var ch = tokens[1][0];
            var pass = tokens[2];

            var freq = 0;
            for(int i = 0; i < pass.Length; i++)
            {
                if(pass[i] == ch)
                {
                    freq++;
                }

            }
            return (min <= freq && freq <= max);
        }

        private bool IsValidB(string line)
        {
            var tokens = line.Split(' ');
            var first = int.Parse(tokens[0].Split('-')[0]) - 1;
            var last = int.Parse(tokens[0].Split('-')[1]) - 1;
            var ch = tokens[1][0];
            var pass = tokens[2];

            var v1 = pass[first] == ch;
            var v2 = pass[last] == ch;
            return v1 != v2;
        }

    }
}
