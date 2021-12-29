using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
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
            if (IsPartB)
            {
                return SolveB(input);
            }

            // Naive approach; one value per bit.
            var lines = Parser.TokenizeLines(input);
            int[] counts = new int[lines[0].Length];
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    counts[i] += (line[i] == '1' ? 1 : -1);
                }
            }

            var gamma = 0;
            var epsilon = 0;
            var gammaBin = "";
            var epsilonBin = "";
            for (int i = 0; i < lines[0].Length; i++)
            {
                gamma *= 2;
                epsilon *= 2;
                if (counts[i] > 0)
                {
                    gamma += 1;
                    gammaBin = "1" + gammaBin;
                    epsilonBin = "0" + epsilonBin;
                }
                else
                {
                    epsilon += 1;
                    gammaBin = "0" + gammaBin;
                    epsilonBin = "1" + epsilonBin;
                }
            }

            return gamma * epsilon;
        }

        public long SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);

            var oxy = GetBestBinary(lines, true);
            var co2 = GetBestBinary(lines, false);

            var oxyLong = Bin2Long(oxy);
            var co2Long = Bin2Long(co2);

            return oxyLong * co2Long;
        }

        private long Bin2Long(string binary)
        {
            long result = 0;
            foreach(char c in binary.ToCharArray())
            {
                result *= 2;
                if (c == '1') result++;
            }

            return result;
        }

        private string GetBestBinary(List<string> lines, bool useHigh = true)
        {
            if (lines.Count() == 1)
            {
                return lines[0];
            }

            int freq = 0;
            foreach(var line in lines)
            {
                freq += (line[0] == '1' ? 1 : -1);
            }

            char goodChar;
            if (useHigh)
            {
                goodChar = (freq >= 0 ? '1' : '0');
            }
            else
            {
                goodChar = (freq < 0 ? '1' : '0');
            }

            var newList = new List<string>();
            foreach (var item in lines)
            {
                if (item[0] == goodChar)
                {
                    newList.Add(item.Substring(1));
                }
            }

            return goodChar + GetBestBinary(newList, useHigh);
        }
    }
}
