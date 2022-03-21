using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 10
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day10 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            long score = 0;
            var incompleteLineScores = new List<long>();
            foreach(var line in lines)
            {
                if (!IsPartB)
                {
                    score += GetScoreFromLine(line);
                }
                else
                {
                    long result = GetIncompleteScoreFromLine(line);
                    if (result != 0)
                    {
                        incompleteLineScores.Add(result);
                    }
                }
            }

            if (!IsPartB)
            {
                return score;
            }
            else
            {
                incompleteLineScores.Sort();
                return incompleteLineScores[incompleteLineScores.Count() / 2];
            }
        }

        private long GetIncompleteScoreFromLine(string line)
        {
            var stack = new Stack<char>();
            var openers = new List<char> { '(', '[', '<', '{' };
            var isValid = true;
            foreach (var c in line.ToCharArray())
            {
                if (openers.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }

                switch (c)
                {
                    case ')':
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isValid = false;
                        }
                        break;
                    case ']':
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isValid = false;
                        }
                        break;
                    case '>':
                        if (stack.Peek() == '<')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isValid = false;
                        }
                        break;
                    case '}':
                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            isValid = false;
                        }
                        break;
                }

                if (!isValid)
                {
                    // Invalid line; jump out
                    return 0;
                }
            }
            if (!stack.Any())
            {
                // Complete line; jump out
                return 0;
            }

            // Pop until there's nothing on the stack.
            long score = 0;
            while(stack.Any())
            {
                score *= 5;
                var next = stack.Pop();
                switch(next)
                {
                    case '(':
                        score += 1;
                        break;
                    case '[':
                        score += 2;
                        break;
                    case '{':
                        score += 3;
                        break;
                    case '<':
                        score += 4;
                        break;
                    default:
                        throw new ApplicationException($"Unexpected symbol: '{next}'");
                }
            }

            return score;

        }

        private long GetScoreFromLine(string line)
        {
            var stack = new Stack<char>();
            var openers = new List<char> { '(', '[', '<', '{' };
            foreach(var c in line.ToCharArray())
            {
                if (openers.Contains(c))
                {
                    stack.Push(c);
                    continue;
                }
                
                switch(c)
                {
                    case ')':
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return 3;
                        }
                        break;
                    case ']':
                        if (stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return 57;
                        }
                        break;
                    case '>':
                        if (stack.Peek() == '<')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return 25137;
                        }
                        break;
                    case '}':
                        if (stack.Peek() == '{')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            return 1197;
                        }
                        break;
                }
            }

            return 0;
        }
    }
}
