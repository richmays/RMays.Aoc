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

    public class Day11 : IDay<long>
    {
        internal class Monkey
        {
            public int Id { get; set; }
            public Queue<long> Items { get; set; }
            public string Operation { get; set; }
            public int DivisibleBy { get; set; }
            public int Inspections { get; set; }
            public int TrueMonkey { get; set; }
            public int FalseMonkey { get; set; }

            public Monkey()
            {
                Items = new Queue<long>();
                Operation = "old + 0";
                Inspections = 0;
                DivisibleBy = 1;
                TrueMonkey = -1;
                FalseMonkey = -1;
            }

            public long Inspect(long old)
            {
                Inspections++;

                // Update worry level, and return the new worry level.
                if (Operation[4] == '+')
                {
                    return old + long.Parse(Operation.Substring(6));
                }
                else if (Operation[4] == '*')
                { 
                    if (Operation[6] == 'o')
                    {
                        return old * old;
                    }
                    else
                    {
                        return old * long.Parse(Operation.Substring(6));
                    }
                }

                throw new ApplicationException($"Unhandled operation: {Operation}");
            }

            public override string ToString()
            {
                return $"Monkey {Id}: {string.Join(", ", Items)}";
            }
        }

        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var Monkeys = new Dictionary<int, Monkey>();
            Monkey monkey = null;
            foreach(var line in lines)
            {
                var tokens = line.Split(' ');
                if (tokens.Length == 0)
                {
                    Monkeys.Add(monkey.Id, monkey);
                }
                switch(tokens[0])
                {
                    case "Monkey":
                        if (monkey != null)
                        {
                            Monkeys.Add(monkey.Id, monkey);
                        }
                        monkey = new Monkey();

                        // Assume there's less than 10 monkeys.
                        monkey.Id = int.Parse(tokens[1][0].ToString());
                        break;
                    case "Starting":
                        monkey.Items = new Queue<long>();
                        for (int i = 2; i < tokens.Count(); i++)
                        {
                            string token = tokens[i];
                            long itemValue = 0;
                            if (token.EndsWith(","))
                            {
                                itemValue = int.Parse(token.Substring(0, token.Length - 1));
                            }
                            else
                            {
                                itemValue = int.Parse(token);
                            }
                            monkey.Items.Enqueue(itemValue);
                        }
                        break;
                    case "Operation:":
                        monkey.Operation = line.Substring(17);
                        break;
                    case "Test:":
                        var divisor = int.Parse(line.Substring(19));
                        monkey.DivisibleBy = divisor;
                        break;
                    case "If":
                        if (tokens[1] == "true:")
                        {
                            monkey.TrueMonkey = int.Parse(tokens[5]);
                        }
                        else if (tokens[1] == "false:")
                        {
                            monkey.FalseMonkey = int.Parse(tokens[5]);
                        }
                        else
                        {
                            throw new ApplicationException($"Unexpected token: {tokens[5]}");
                        }
                        break;
                }

            }

            if (monkey != null)
            {
                Monkeys.Add(monkey.Id, monkey);
            }

            if (IsPartB)
            {
                return RunMonkeyBusiness(Monkeys, 10000, true);
            }
            else
            {
                return RunMonkeyBusiness(Monkeys, 20, false);
            }
        }

        private long RunMonkeyBusiness(Dictionary<int, Monkey> Monkeys, int totalRounds, bool isPartB)
        {
            // First, get the GCD.
            long GCD = 1;
            foreach(var monkey in Monkeys.Values)
            {
                GCD *= monkey.DivisibleBy;
            }

            for (int round = 1; round <= totalRounds; round++)
            {
                Log($"-- ROUND {round} --");
                for (int mID = 0; mID < Monkeys.Count; mID++)
                {
                    var monkey = Monkeys[mID];
                    Log($"Monkey {mID}:");
                    while (monkey.Items.Any())
                    {
                        var item = monkey.Items.Dequeue();
                        Log($"  Monkey inspects an item with a worry level of {item}.");
                        var newValue = monkey.Inspect(item);
                        Log($"    Worry level is now {newValue}.");
                        if (newValue > GCD)
                        {
                            newValue = newValue % GCD;
                            Log($"  REDUCE worry to {newValue}");
                        }
                        if (!isPartB)
                        {
                            newValue = newValue / 3;
                            Log($"    Monkey gets bored with item. Worry level is divided by 3 to {newValue}.");
                        }
                        int targetMonkey;
                        if (newValue % monkey.DivisibleBy == 0)
                        {
                            Log($"    Current worry level is divisible by {monkey.DivisibleBy}.");
                            targetMonkey = monkey.TrueMonkey;
                        }
                        else
                        {
                            Log($"    Current worry level is not divisible by {monkey.DivisibleBy}.");
                            targetMonkey = monkey.FalseMonkey;
                        }
                        Log($"   Item with worry level {newValue} is thrown to monkey {targetMonkey}.");
                        Monkeys[targetMonkey].Items.Enqueue(newValue);
                    }
                }

                /*
                Console.WriteLine($"After round {round}, the monkeys are holding items with these worry levels:");
                for (int mID = 0; mID < Monkeys.Count; mID++)
                {
                    Console.WriteLine($"Monkey {mID}: {Monkeys[mID].ToString()}");
                }
                Console.WriteLine("");
                */

                Log("");
            }

            // Get the monkey inspections, put in a list, then sort. Take top 2.
            List<long> Inspections = new List<long>();
            foreach(var m in Monkeys.Keys)
            {
                var monkey = Monkeys[m];
                Console.WriteLine($"Monkey {monkey.Id} inspected items {monkey.Inspections} times.");
                Inspections.Add(Monkeys[m].Inspections);
            }

            Inspections.Sort();
            Inspections.Reverse();

            return Inspections[0] * Inspections[1];

        }

        private void Log(string log)
        {
            //Console.WriteLine(log);
        }
    }
}
