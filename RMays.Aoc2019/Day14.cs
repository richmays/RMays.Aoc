using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day14 : IDay<long>
    {
        public long SolveA(string input)
        {
            var lines = Parser.TokenizeLines(input);
            var Reactions = new List<Reaction>();
            foreach (var line in lines)
            {
                Reactions.Add(new Reaction(line));
            }

            var WeHave = new Dictionary<string, long>();
            WeHave.Add("FUEL", -1);

            while(ShouldKeepGoing(WeHave))
            {
                var outputName = WeHave.First(x => x.Value < 0 && x.Key != "ORE").Key;
                var outputQuantity = WeHave.First(x => x.Value < 0 && x.Key != "ORE").Value * -1;

                var possibleReactions = Reactions.Where(x => x.OutputName == outputName);
                if (possibleReactions.Count() != 1)
                {
                    throw new ApplicationException("More than one way to make this: " + outputName);
                }

                // How many times do we need to run this reaction?
                var possibleReactionsOutputQ = possibleReactions.First().OutputQuantity;
                var timesToRun = (long)Math.Ceiling(outputQuantity / (possibleReactionsOutputQ * 1.0)); // we might get remainders here.  that's fine!

                foreach(var inputReaction in possibleReactions.First().Inputs)
                {
                    if (WeHave.Keys.Contains(inputReaction.Key))
                    {
                        WeHave[inputReaction.Key] -= (timesToRun * inputReaction.Value);
                    }
                    else
                    {
                        WeHave.Add(inputReaction.Key, -1 * (timesToRun * inputReaction.Value));
                    }
                }

                // Now remove just enough.
                WeHave[outputName] += possibleReactionsOutputQ * timesToRun;

                PrintWeHave(WeHave);
            }

            return WeHave["ORE"] * -1;
        }

        private bool ShouldKeepGoing(Dictionary<string, long> WeHave)
        {
            return WeHave.Any(x => x.Key != "ORE" && x.Value < 0);
        }

        private void PrintWeHave(Dictionary<string, long> WeHave)
        {
            var result = "";
            foreach(var have in WeHave)
            {
                result += $"({have.Value} {have.Key}) ";
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Returns the amount of ore needed to make X fuel.
        /// </summary>
        /// <param name="Reactions"></param>
        /// <param name="FuelToOutput"></param>
        /// <returns></returns>
        private long Solve(List<Reaction> Reactions, long FuelToOutput)
        {
            var WeHave = new Dictionary<string, long>();
            WeHave.Add("FUEL", 0);
            WeHave.Add("ORE", 0);

            long fuelAdded = 0;
            bool finishedShortcut = false;
            // Whenever we make 1 fuel, add the combo here.
            // Once we find a combo we added previously, get the difference and extrapolate.
            Dictionary<string, ComboTuple> FoundCombos = new Dictionary<string, ComboTuple>();

                WeHave["FUEL"] -= FuelToOutput;
                fuelAdded += FuelToOutput;
                while (ShouldKeepGoing(WeHave))
                {
                    var outputName = WeHave.First(x => x.Value < 0 && x.Key != "ORE").Key;
                    var outputQuantity = WeHave.First(x => x.Value < 0 && x.Key != "ORE").Value * -1;

                    var possibleReactions = Reactions.Where(x => x.OutputName == outputName);
                    if (possibleReactions.Count() != 1)
                    {
                        throw new ApplicationException("More than one way to make this: " + outputName);
                    }

                    // How many times do we need to run this reaction?
                    var possibleReactionsOutputQ = possibleReactions.First().OutputQuantity;
                    var timesToRun = (long)Math.Ceiling(outputQuantity / (possibleReactionsOutputQ * 1.0)); // we might get remainders here.  that's fine!

                    foreach (var inputReaction in possibleReactions.First().Inputs)
                    {
                        if (WeHave.Keys.Contains(inputReaction.Key))
                        {
                            WeHave[inputReaction.Key] -= (timesToRun * inputReaction.Value);
                        }
                        else
                        {
                            WeHave.Add(inputReaction.Key, -1 * (timesToRun * inputReaction.Value));
                        }
                    }

                    // Now remove just enough.
                    WeHave[outputName] += possibleReactionsOutputQ * timesToRun;

                }


                //if (finishedShortcut) continue;

                /*
                // new shortcut code.  hmm.
                var oreForFirstFuel = WeHave["ORE"] * -1;
                var newUpperBoundOre = (long)Math.Floor(MaxOre * 0.90);
                var howManyTimesToRun = (long)Math.Floor(newUpperBoundOre / (oreForFirstFuel * 1.0));

                // Now do the multiplication.
                WeHave["ORE"] *= howManyTimesToRun;
                fuelAdded *= howManyTimesToRun;

                List<string> WeHaveKeys = new List<string>();
                foreach (var key in WeHave.Keys)
                {
                    if (key != "ORE")
                    {
                        WeHaveKeys.Add(key);
                    }
                }

                foreach(var item in WeHaveKeys)
                {
                    WeHave[item] *= howManyTimesToRun;
                }

                finishedShortcut = true;
                */


                //PrintWeHave(WeHave);



                /*
                 * Shortcut code works great on 3 test cases.  But I can do beter.
                if (finishedShortcut) continue;

                // Save what we have in 'FoundCombos'.
                var toSave = "";
                foreach(var have in WeHave.Where(x => x.Key != "ORE" && x.Key != "FUEL" && x.Value != 0))
                {
                    toSave += $"({have.Value} {have.Key})";
                }
                if (FoundCombos.ContainsKey(toSave))
                {
                    // Great!  We found it.
                    Console.WriteLine("Combo: " + toSave);
                    Console.WriteLine("Original ore used: " + FoundCombos[toSave].OreUsed);
                    Console.WriteLine("Original fuel output: " + FoundCombos[toSave].FuelOutput);
                    Console.WriteLine("Current ore: " + WeHave["ORE"] * -1);
                    Console.WriteLine("Current fuel output: " + fuelAdded);

                    // Jump ahead.
                    long oreDiff = (WeHave["ORE"] * -1) - FoundCombos[toSave].OreUsed;
                    long fuelDiff = fuelAdded - FoundCombos[toSave].FuelOutput;
                    while(WeHave["ORE"] >= -1 * MaxOre)
                    {
                        WeHave["ORE"] -= oreDiff;
                        fuelAdded += fuelDiff;
                    }

                    WeHave["ORE"] += oreDiff;
                    fuelAdded -= fuelDiff;

                    finishedShortcut = true;
                }
                else
                {
                    FoundCombos.Add(toSave, new ComboTuple(fuelAdded, WeHave["ORE"] * -1));
                }
                */

            return WeHave["ORE"] * -1;
        }

        public class ComboTuple
        {
            public long FuelOutput { get; set; }
            public long OreUsed { get; set; }

            public ComboTuple(long fuelOutput, long oreUsed)
            {
                FuelOutput = fuelOutput;
                OreUsed = oreUsed;
            }
        }

        public long SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);
            var Reactions = new List<Reaction>();
            foreach (var line in lines)
            {
                Reactions.Add(new Reaction(line));
            }

            long StartingOre = 1_000_000_000_000;
            long MinFuel = 1;
            long MaxFuel = 1_000_000_000_000;
            long result = -3;
            while(MinFuel < MaxFuel - 1)
            {
                var candidate = (MinFuel + MaxFuel) / 2;
                result = Solve(Reactions, candidate);
                if (result < StartingOre)
                {
                    MinFuel = candidate;
                }
                else if (result > StartingOre)
                {
                    MaxFuel = candidate - 1;
                }
                else
                {
                    MinFuel = candidate;
                    MaxFuel = candidate;
                }
            }

            // Check for off-by-one errors.
            var resultLow = Solve(Reactions, MinFuel - 1);
            var resultMid = Solve(Reactions, MinFuel);
            var resultHigh = Solve(Reactions, MinFuel + 1);
            if (resultHigh < StartingOre) return MinFuel + 1;
            if (resultMid < StartingOre) return MinFuel;
            if (resultLow < StartingOre) return MinFuel - 1;


            return -4;
        }

        public class Reaction
        {
            public Dictionary<string, long> Inputs { get; set; }
            public string OutputName { get; set; }
            public long OutputQuantity { get; set; }

            public Reaction(string reactionLine)
            {
                Inputs = new Dictionary<string, long>();
                OutputName = "";
                OutputQuantity = 0;

                var inputs = reactionLine.Split('=')[0].Split(',');
                foreach(var input in inputs)
                {
                    Inputs.Add(input.Trim().Split(' ')[1].Trim(), long.Parse(input.Trim().Split(' ')[0].Trim()));
                }

                var outputs = reactionLine.Split('>')[1].Trim();
                OutputQuantity = long.Parse(outputs.Split(' ')[0]);
                OutputName = outputs.Split(' ')[1];
            }

            public override string ToString()
            {
                string result = "";
                foreach(var input in Inputs)
                {
                    result += $"({input.Value} {input.Key}) ";
                }
                result += $"=> {OutputQuantity} {OutputName}";
                return result;
            }
        }
    }
}
