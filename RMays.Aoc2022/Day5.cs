using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day5
    {
        public string Solve(string input, bool IsPartB = false)
        {
            var wasReversed = false;
            var lines = Parser.TokenizeLinesKeepSpaces(input);
            var stacks = new List<Stack<char>>();
            for (int i = 0; i < 10; i++)
            {
                stacks.Add(new Stack<char>());
            }

            foreach(var line in lines)
            {
                if (line.Length == 0)
                {
                    // Reverse everything!
                    foreach (var stack in stacks)
                    {
                        ReverseStack(stack);
                    }
                }
                else if (line[0] == 'm')
                {
                    if (!IsPartB)
                    {
                        HandleMove(stacks, line);
                    }
                    else
                    {
                        HandleMoveB(stacks, line);
                    }
                    continue;
                }
                else
                {
                    var currStack = 1;
                    for (int i = 1; i < line.Length; i += 4)
                    {
                        var c = line[i];
                        if (c != ' ')
                        {
                            stacks[currStack].Push(c);
                        }
                        //Console.Write(c);
                        currStack++;
                    }
                    //Console.WriteLine();
                }
            }

            PrintStacks(stacks);

            var result = "";
            foreach(var stack in stacks)
            {
                if (stack.Any())
                {
                    result += stack.Peek();
                }
            }
            return result;
        }

        private void PrintStacks(List<Stack<char>> stacks)
        {
            return;
            for (var stackId = 0; stackId < 10; stackId++)
            {
                if (!stacks[stackId].Any())
                {
                    continue;
                }
                Console.WriteLine($"Stack {stackId}:");
                var tmpStack = new Stack<char>();
                var currStack = stacks[stackId];
                while (currStack.Any())
                {
                    var item = currStack.Pop();
                    Console.WriteLine($" {item}");
                    tmpStack.Push(item);
                }

                while (tmpStack.Any())
                {
                    currStack.Push(tmpStack.Pop());
                }
            }
        }

        private void HandleMove(List<Stack<char>> stacks, string line)
        {
            var quantity = int.Parse(line.Split(' ')[1]);
            var source = int.Parse(line.Split(' ')[3]);
            var dest = int.Parse(line.Split(' ')[5]);
            //Console.WriteLine($"Moving: {quantity} boxes from {source} to {dest}.");

            for (int moves = 0; moves < quantity; moves++)
            {
                //Console.WriteLine($"Moving box {stacks[source].Peek()} from {source} to {dest}.");
                stacks[dest].Push(stacks[source].Pop());
            }
        }
        private void HandleMoveB(List<Stack<char>> stacks, string line)
        {
            var quantity = int.Parse(line.Split(' ')[1]);
            var source = int.Parse(line.Split(' ')[3]);
            var dest = int.Parse(line.Split(' ')[5]);
            //Console.WriteLine($"Moving: {quantity} boxes from {source} to {dest}.");

            var tmpStack = new Stack<char>();
            for (int moves = 0; moves < quantity; moves++)
            {
                tmpStack.Push(stacks[source].Pop());
            }

            while(tmpStack.Any())
            {
                stacks[dest].Push(tmpStack.Pop());
            }
        }

        private void ReverseStack(Stack<char> stack)
        {
            var tmpStack = new Stack<char>();
            while(stack.Any())
            {
                tmpStack.Push(stack.Pop());
            }

            var tmpStack2 = new Stack<char>();
            while (tmpStack.Any())
            {
                tmpStack2.Push(tmpStack.Pop());
            }

            while (tmpStack2.Any())
            {
                stack.Push(tmpStack2.Pop());
            }
        }

    }
}
