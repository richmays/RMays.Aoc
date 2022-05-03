using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 14
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day14 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var polymer = "";
            var rules = new Dictionary<string, char>();

            foreach (var line in lines)
            {
                if (polymer == "")
                {
                    polymer = line;
                    continue;
                }
                var lineSplit = line.Split(' ');
                rules.Add(lineSplit[0], lineSplit[2][0]);
            }

            var freq = new Dictionary<char, long>();

            // Part B; use shortcuts!
            // Use a dictionary to track all the pairs.
            var freqDict = new Dictionary<string, long>();
            foreach (var item in rules)
            {
                freqDict.Add(item.Key, 0);
            }

            for (var sIndex = 0; sIndex < polymer.Length - 1; sIndex++)
            {
                var comp = $"{polymer[sIndex]}{polymer[sIndex + 1]}";
                freqDict[comp]++;
            }

            var runTotal = 10;
            if (IsPartB)
            {
                runTotal = 40;
            }

            for (var run = 0; run < runTotal; run++)
            {
                var newFreqDict = new Dictionary<string, long>();
                foreach (var item in rules)
                {
                    newFreqDict.Add(item.Key, 0);
                }

                foreach (var item in freqDict)
                {
                    if (item.Value == 0) continue;

                    var ruleResult = rules[item.Key];
                    newFreqDict[$"{item.Key[0]}{ruleResult}"] += item.Value;
                    newFreqDict[$"{ruleResult}{item.Key[1]}"] += item.Value;
                }

                freqDict = newFreqDict;

                freq = new Dictionary<char, long>();
                foreach (var item in freqDict)
                {
                    foreach (var letter in item.Key)
                    {
                        if (!freq.ContainsKey(letter))
                        {
                            freq.Add(letter, 0);
                        }
                        freq[letter] += item.Value;
                    }
                }

                var freq2 = new Dictionary<char, long>();
                foreach (var key in freq.Keys)
                {
                    freq2.Add(key, freq[key] / 2);
                }

                freq = freq2;
                freq[polymer.Last()]++;
                PrintPolymerFrequencies(run + 1, freq);
            }

            long max = freq.Max(x => x.Value);
            long min = freq.Min(x => x.Value);

            return max - min;

        }

        private void PrintPolymerFrequencies(int run, string polymer)
        {
            var freq = new Dictionary<char, long>();
            foreach (var c in polymer)
            {
                if (!freq.ContainsKey(c))
                {
                    freq.Add(c, 0);
                }
                freq[c]++;
            }

            PrintPolymerFrequencies(run, freq);
        }

        private void PrintPolymerFrequencies(int run, Dictionary<char, long> freq)
        {
            Console.Write($"{run} | ");
            foreach (var letter in freq.Keys)
            {
                Console.Write($"{letter}:{freq[letter]} ");
            }

            long max = freq.Max(x => x.Value);
            long min = freq.Min(x => x.Value);

            Console.WriteLine($" Score: {max - min}");
        }
    }
}
