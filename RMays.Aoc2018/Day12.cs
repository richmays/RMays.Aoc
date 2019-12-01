using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Pots
    {
        private const bool EnableShortcutCode = true;

        private HashSet<int> PotsSet;
        public Pots()
        {
            PotsSet = new HashSet<int>();
        }

        /// <summary>
        /// Returns whether or not there's a plant in the pot.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool GetPot(int index)
        {
            return PotsSet.Contains(index);
        }

        public void SetPot(int index, bool hasPlant)
        {
            PotsSet.Remove(index);
            if (hasPlant)
            {
                PotsSet.Add(index);
            }
        }

        private void CalcHighLow(out int LowPlant, out int HighPlant)
        {
            LowPlant = PotsSet.Min();
            HighPlant = PotsSet.Max();
        }

        public long Go(HashSet<string> rules, long generations)
        {
            var ShowPlantDebug = true;
            var myPredictor = new DataPredictor(generations);

            for (var gen = 1; gen <= generations; gen++)
            {
                int LowPlant;
                int HighPlant;
                CalcHighLow(out LowPlant, out HighPlant);
                var NewPotsSet = new HashSet<int>();
                string orientation = ".....";
                for (int index = LowPlant - 2; index <= HighPlant + 1; index++)
                {
                    orientation = orientation.Substring(1) + (this.GetPot(index+2) ? '#' : '.');

                    if (rules.Contains(orientation))
                    {
                        NewPotsSet.Add(index);
                    }
                }

                PotsSet.Clear();
                foreach (var pot in NewPotsSet)
                {
                    PotsSet.Add(pot);
                }

                if (ShowPlantDebug)
                {
                    var about = $"gen: {gen}, sum: {this.PlantSum()}";
                    Console.WriteLine($"{about}: {" "}{this}");
                }

                // If the last 4 sums were linear, then extrapolate and figure out the final result.
                myPredictor.AddData(gen, this.PlantSum());
                var predictionResult = myPredictor.Predict();
                if (predictionResult.HasPrediction)
                {
                    return (long)predictionResult.Prediction;
                }
            }

            return PlantSum();
        }

        public long PlantSum()
        {
            return PotsSet.Sum(x => x);
        }

        public override string ToString()
        {
            int LowPlant;
            int HighPlant;
            CalcHighLow(out LowPlant, out HighPlant);
            var toReturn = $"{LowPlant}: ";
            if (LowPlant >= 0)
            {
                toReturn += (" ").PadLeft(LowPlant + 1);
            }

            for (int i = LowPlant; i <= HighPlant; i++)
            {
                toReturn += (GetPot(i) ? '#' : '.');
            }

            return toReturn;
            //return "?";
        }
    }

    public class Day12
    {
        public long SolveA(string input, long generations)
        {
            // initial state: #..#.#..##......###...###
            var intialPots = Parser.TokenizeLines(input)[0].Split(' ')[2];

            var myPots = new Pots();
            int potId = 0;
            foreach(var pot in intialPots.ToCharArray())
            {
                if (pot == '#')
                {
                    myPots.SetPot(potId, true);
                }
                potId++;
            }

            // Now read the rules.

            // ...## => #
            var rulesText = Parser.TokenizeLines(input);
            var rules = new HashSet<string>();
            foreach(var line in rulesText)
            {
                var splitLine = line.Split(' ').ToList();
                if (splitLine[1] != "=>") continue;
                if (splitLine[2] == "#")
                {
                    rules.Add(splitLine[0]);
                }
            }

            return myPots.Go(rules, generations);
        }
    }
}
