using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day4 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var sum = 0;
            var lines = Parser.TokenizeLines(input);

            // Horizontal
            Log("Starting horizontal checks");
            foreach (var line in lines)
            {
                sum += GetXmasesCount(line);
                sum += GetXmasesCount(Reverse(line));
            }

            // Vertical
            Log("Starting vertical checks");
            sum += GetVerticalXmasesCount(lines);

            // Diagonal:  \ and /
            Log("Starting topleft to bottomright checks");
            // Shift everything to the right X columns, where X is the row minus the total rows minus 1.
            var newLinesTL = new List<string>();
            // Shift everything to the left X columns, where X is the row minus the total rows minus 1.
            var newLinesTR = new List<string>();
            var r = 0;
            foreach (var line in lines)
            {
                var newLineTL = new StringBuilder();
                var newLineTR = new StringBuilder();
                for (int c = lines.Count - r; c > 1; c--)
                {
                    newLineTL.Append(".");
                }
                for (int c = 0; c < r; c++)
                {
                    newLineTR.Append(".");
                }
                newLineTL.Append(line);
                newLineTR.Append(line);
                while (newLineTL.Length < lines.Count + lines[0].Length - 1)
                {
                    newLineTL.Append(".");
                }
                while (newLineTR.Length < lines.Count + lines[0].Length - 1)
                {
                    newLineTR.Append(".");
                }
                Log(newLineTL.ToString());
                Log(newLineTR.ToString());
                newLinesTL.Add(newLineTL.ToString());
                newLinesTR.Add(newLineTR.ToString());

                r++;
            }
            sum += GetVerticalXmasesCount(newLinesTL);
            sum += GetVerticalXmasesCount(newLinesTR);

            return sum;
        }

        private int GetVerticalXmasesCount(List<string> lines)
        {
            int sum = 0;
            for (int c = 0; c < lines[0].Length; c++)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var line in lines)
                {
                    sb.Append(line[c]);
                }

                sum += GetXmasesCount(sb.ToString());
                sum += GetXmasesCount(Reverse(sb.ToString()));
            }
            return sum;
        }

        private void Log(string log)
        {
            //Console.WriteLine(log);
        }


        private string Reverse(string source)
        {
            return new string(source.Reverse().ToArray());
        }

        private int GetXmasesCount(string input)
        {
            Log("Looking here: " + input);
            int c = 0;
            int found = 0;
            while (c < input.Length)
            {
                var loc = input.IndexOf("XMAS", c);
                if (loc >= 0)
                {
                    found++;
                    c = loc + 4;
                }
                else
                {
                    // Long way to jump out
                    c = input.Length + 1;
                }
            }
            return found;
        }
    }
}
