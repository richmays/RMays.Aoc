using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day14 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            var memDict = new Dictionary<long, long>();
            foreach(var line in lines)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    var memAddress = int.Parse(line.Substring(4, line.IndexOf("]") - 4));
                    var memValue = long.Parse(line.Substring(line.IndexOf("]") + 4));
                    /*
                    Console.WriteLine("Line: " + line);
                    Console.WriteLine($"  memLocation: {memLocation}, memValue: {memValue}");
                    Console.WriteLine($"  value to bitstring: {LongToString(memValue)}");
                    */

                    //Console.WriteLine("  Bitmask applied: " + appliedBitmask);

                    if (!IsPartB)
                    {
                        var appliedBitmask = ApplyBitmask(memValue, mask);
                        if (memDict.ContainsKey(memAddress))
                        {
                            memDict[memAddress] = appliedBitmask;
                        }
                        else
                        {
                            memDict.Add(memAddress, appliedBitmask);
                        }
                    }
                    else
                    {
                        var maskedAddress = ApplyBitmaskToAddress(memAddress, mask);
                        ApplyBitmaskB(maskedAddress, memValue, memDict);
                    }
                }


            }

            long sum = 0;
            foreach(var key in memDict.Keys)
            {
                sum += memDict[key];
            }
            return sum;
        }

        private string ApplyBitmaskToAddress(long memAddress, string mask)
        {
            var strMemAddress = LongToString(memAddress);
            var result = "";
            for (var i = 0; i < 36; i++)
            {
                switch (mask[i])
                {
                    case 'X':
                        result += "X";
                        break;
                    case '1':
                        result += "1";
                        break;
                    case '0':
                        result += strMemAddress[i];
                        break;
                }
            }
            return result;
        }

        private void ApplyBitmaskB(string maskedAddress, long memValue, Dictionary<long, long> memDict, int startIndex = 0)
        {
            for (var i = startIndex; i < 36; i++)
            {
                switch (maskedAddress[i])
                {
                    case 'X':
                        ApplyBitmaskB(ReplaceCharAt(maskedAddress, i, '0'), memValue, memDict, i);
                        ApplyBitmaskB(ReplaceCharAt(maskedAddress, i, '1'), memValue, memDict, i);
                        return;
                    case '1':
                        // Do nothing
                        break;
                    case '0':
                        // Do nothing
                        break;
                }
            }
            
            DictAddUpdate(memDict, StringToLong(maskedAddress), memValue);
        }

        private string ReplaceCharAt(string input, int index, char newChar)
        {
            if (input.Length != 36) throw new ApplicationException("Input wrong size: ReplaceCharAt");
            var result = input.Substring(0, index) + newChar + input.Substring(index + 1);
            if (result.Length != 36) throw new ApplicationException("Converted wrong: ReplaceCharAt");
            return result;
        }

        private void DictAddUpdate(Dictionary<long, long> dict, long key, long value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        private long ApplyBitmask(long memValue, string mask)
        {
            var strValue = LongToString(memValue);
            var result = "";
            for(var i = 0; i < 36; i++)
            {
                switch(mask[i])
                {
                    case 'X':
                        result += strValue[i];
                        break;
                    case '0':
                        result += "0";
                        break;
                    case '1':
                        result += "1";
                        break;
                }
            }
            return StringToLong(result);
        }

        private long StringToLong(string input)
        {
            if (input.Length != 36) throw new ApplicationException("Input wrong size: StringToLong");
            long result = 0;
            for(int i = 0; i < 36; i++)
            {
                result *= 2;
                if (input[i] == '1')
                {
                    result += 1;
                }
            }
            return result;
        }

        private string LongToString(long input)
        {
            var result = "";
            int bitsAdded = 0;
            long remain = input;
            while(bitsAdded < 36)
            {
                var nextBit = remain % 2;
                remain = remain / 2;
                result = $"{nextBit}{result}";
                bitsAdded++;
            }

            return result;
        }
    }
}
