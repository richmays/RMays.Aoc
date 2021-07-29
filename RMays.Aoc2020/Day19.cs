using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 19
    /*
--- Day 19: Template ---

    */
    #endregion

    public class Day19 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            // Part B:  Replace these rules:
            //
            // 8: 42 | 42 8
            // 11: 42 31 | 42 11 31

            // Can we build up a regex of rules?  That might be too easy.  Let's try it anyway.
            // Input has 2 sections.
            var lines = Parser.TokenizeLines(input);
            var inTopSection = true;

            var rules = new List<Rule>();
            var messages = new List<string>();
            foreach(var line in lines)
            {
                //Console.WriteLine(line);

                if (line[0] == 'a' || line[0] == 'b')
                {
                    // Found a message
                    var message = line.Split('|')[0];
                    //if (line.EndsWith("|1"))
                    {
                        messages.Add(message);
                    }
                }
                else
                {
                    // Found a rule
                    var rule = new Rule(line);
                    rules.Add(rule);
                    //Console.WriteLine(rule);
                }
            }

            var matches = 0;
            var pattern = GetPattern(rules, IsPartB);

            foreach(var message in messages)
            {
                var match = Regex.Match(message, pattern);
                if (match.Success)
                {
                    matches++;
                }
            }

            return matches;
        }

        private string GetPattern(List<Rule> rules, bool IsPartB)
        {
            var pattern = "^[0]$";

            //Console.WriteLine(pattern);
            while (pattern.Contains('['))
            {
                var startRuleId = pattern.IndexOf('[');
                var endRuleId = pattern.IndexOf(']', startRuleId);
                var ruleId = int.Parse(pattern.Substring(startRuleId + 1, endRuleId - startRuleId - 1));

                // 8: 42 | 42 8
                // 11: 42 31 | 42 11 31

                // 8: (42)+
                // 11: (42 31)+

                var replaceTarget = "";
                if (IsPartB && ruleId == 8)
                {
                    replaceTarget = "([42])+";
                }
                else if (IsPartB && ruleId == 11)
                {
                    // Regex for:  ((xy)|(xxyy)|(xxxyyy)|(xxxxyyyy))
                    replaceTarget = "(([42][31])|([42][42][31][31])|([42][42][42][31][31][31])|([42][42][42][42][31][31][31][31]))";
                }
                else
                {
                    replaceTarget = rules.First(x => x.RuleId == ruleId).InnerReplace();
                }
                pattern = pattern.Replace($"[{ruleId}]", replaceTarget);
                int q = 999;
            }

            //Console.WriteLine(pattern);

            return pattern;
            //return "^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$";
        }

        internal class Rule
        {
            public int RuleId { get; set; }
            public string RuleRaw { get; set; }
            public List<List<int>> Options { get; set; }
            public char? Leaf { get; set; }

            public Rule(string lineRule)
            {
                RuleId = int.Parse(lineRule.Substring(0, lineRule.IndexOf(':')));
                RuleRaw = lineRule.Substring(lineRule.IndexOf(':') + 2);
                Options = new List<List<int>>();
                Leaf = null;
                if (RuleRaw[0] == '"')
                {
                    Leaf = RuleRaw[1];
                    return;
                }
                var options = RuleRaw.Split(' ');
                var currOption = new List<int>();
                foreach(var token in options)
                {
                    if (string.IsNullOrWhiteSpace(token.ToString())) continue;
                    if (token == "|")
                    {
                        Options.Add(currOption);
                        currOption = new List<int>();
                    }
                    else
                    {
                        currOption.Add(int.Parse(token));
                    }
                }

                if (currOption.Count() > 0)
                {
                    Options.Add(currOption);
                }
            }

            public string InnerReplace()
            {
                var result = "";
                foreach (var option in this.Options)
                {
                    result += "|(";
                    foreach(var suboption in option)
                    {
                        result += $"[{suboption}]";
                    }
                    result += ")";
                }
                if (result.Length > 0)
                {
                    result = result.Substring(1);
                }

                if (this.Options.Count == 1)
                {
                    // Remove the first and last parentheses.
                    result = result.Substring(1, result.Length - 2);
                }
                else if (this.Options.Count > 1)
                {
                    result = "(" + result + ")";
                }

                if (Leaf != null)
                {
                    result = $"{Leaf}";
                }

                return result;
            }

            public override string ToString()
            {
                var options = "";
                foreach (var option in this.Options)
                {
                    options += " | " + string.Join(" ", option);
                }
                if (options.Length > 1)
                {
                    options = options.Substring(3);
                }

                if (Leaf != null)
                {
                    options = $"\"{Leaf}\"";
                }

                return $"{this.RuleId}: {options}";
            }
        }
    }
}
