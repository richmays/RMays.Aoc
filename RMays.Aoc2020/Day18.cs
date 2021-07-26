using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 18
    /*
--- Day 18: Template ---

    */
    #endregion

    public class Day18 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            long runningSum = 0;
            foreach (var line in lines)
            {
                var tokens = TokenizeLine(line);
                runningSum += Eval(tokens, IsPartB);
            }

            return runningSum;
        }

        private long Eval(List<string> tokens, bool IsPartB = false)
        {
            // Get a list of tokens.  This will make it easier to evaluate the line.
            var myStack = new Stack<string>();
            List<char> opsToProcess = new List<char> { '+', '*' };
            if (IsPartB)
            {
                if (tokens.Contains("+"))
                {
                    opsToProcess = new List<char> { '+' };
                }
                else
                {
                    opsToProcess = new List<char> { '*' };
                }
            }

            // We want to push open-parentheses, operators, and numbers onto the stack.
            foreach (var token in tokens)
            {
                if (token[0] >= '0' && token[0] <= '9')
                {
                    PushOrCollapse(myStack, token, opsToProcess);
                }
                else if (token == "(")
                {
                    myStack.Push(token);
                }
                else if (token == ")")
                {
                    // Resolve everything back to the open-parentheses.
                    var num = myStack.Pop();
                    var openParenOrOp = myStack.Pop();
                    if (openParenOrOp == "(")
                    {
                        // Great; we can collapse down.
                        PushOrCollapse(myStack, num, opsToProcess);
                    }
                    else
                    {
                        // Can't collapse yet.
                        myStack.Push(openParenOrOp);
                        myStack.Push(num);
                        myStack.Push(token);
                    }
                }
                else
                {
                    myStack.Push(token);
                }
            }

            if (myStack.Count() != 1)
            {
                var newTokens = new List<string>();
                while(myStack.Any())
                {
                    newTokens.Insert(0, myStack.Pop());
                }

                // Let's resolve what's inside parentheses.
                var foundChange = false;
                while (newTokens.Contains("(") || foundChange)
                {
                    foundChange = false;
                    var startParam = -1;
                    for (int i = 0; i < newTokens.Count; i++)
                    {
                        if (newTokens[i] == "(")
                        {
                            startParam = i;
                        }
                        else if (newTokens[i] == ")")
                        {
                            // Replace the inner parentheses with a single number.
                            // Get the source...
                            var parenTokens = new List<string>();
                            for (int j = startParam + 1; j < i; j++)
                            {
                                parenTokens.Add((string)newTokens[j].Clone());
                            }

                            // Replace the inner-parens with a single number.
                            var innerResult = Eval(parenTokens, IsPartB);
                            for(int j = i; j >= startParam; j--)
                            {
                                newTokens.RemoveAt(startParam);
                            }

                            newTokens.Insert(startParam, innerResult.ToString());

                            // Jump out; simplify from the beginning.
                            return Eval(newTokens, IsPartB);
                        }
                    }
                }

                return Eval(newTokens, IsPartB);
            }

            return long.Parse(myStack.Pop());
        }

        private void PushOrCollapse(Stack<string> myStack, string token, List<char> opsToProcess)
        {
            if (myStack.Any() && opsToProcess.Contains(myStack.Peek()[0]))
            {
                // Process the operation, and push the result.
                var op = myStack.Pop();
                var prevNumberOrParen = myStack.Pop();
                if (prevNumberOrParen == ")")
                {
                    // Can't do anything yet; it's a closed-parentheses before this op and number.
                    // Jump out after pushing.
                    myStack.Push(prevNumberOrParen);
                    myStack.Push(op);
                    myStack.Push(token);
                }
                else
                {
                    // We found a number; reduce if we can.
                    var prevNumber = long.Parse(prevNumberOrParen);
                    if (op == "+")
                    {
                        myStack.Push($"{prevNumber + long.Parse(token)}");
                    }
                    else if (op == "*")
                    {
                        myStack.Push($"{prevNumber * long.Parse(token)}");
                    }
                    else
                    {
                        throw new ApplicationException("Invalid operation: " + op);
                    }
                }
            }
            else
            {
                // Push the number; we can't do anything with it yet.
                myStack.Push(token);
            }
        }

        private List<string> TokenizeLine(string line)
        {
            var readingNumber = false;
            var currNumber = "";
            var tokens = new List<string>();
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == ' ')
                {
                    if (readingNumber)
                    {
                        tokens.Add(currNumber);
                        readingNumber = false;
                    }
                }
                else if (c >= '0' && c <= '9')
                {
                    // Inside a character
                    if (readingNumber)
                    {
                        currNumber += c;
                    }
                    else
                    {
                        readingNumber = true;
                        currNumber = line[i].ToString();
                    }
                }
                else
                {
                    if (readingNumber)
                    {
                        tokens.Add(currNumber);
                        readingNumber = false;
                    }
                    tokens.Add(c.ToString());
                }
            }

            if (readingNumber)
            {
                tokens.Add(currNumber);
                readingNumber = false;
            }

            return tokens;
        }


    }


}
