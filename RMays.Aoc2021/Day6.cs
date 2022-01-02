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

    public class Day6 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var tokens = lines[0].Split(',').Select(x => int.Parse(x));
            var fish = new Dictionary<int, long>();
            for(int f = -1; f <= 9; f++)
            {
                fish.Add(f, 0);
            }

            foreach(var token in tokens)
            {
                fish[token]++;
            }

            int maxDays = (IsPartB ? 256 : 80);

            for (int d = 0; d < maxDays; d++)
            {
                PrintFish(d, fish);

                // Each fish loses 1.
                for (var f = 0; f <= 9; f++)
                {
                    fish[f - 1] = fish[f];
                }

                // Add the 8s.
                fish[8] += fish[-1];
                fish[6] += fish[-1];
                fish[-1] = 0;
            }

            PrintFish(maxDays, fish);

            return fish.Sum(x => x.Value);
        }

        private void PrintFish(int dayId, Dictionary<int, long> fish)
        {
            return; 

            Console.Write($"{dayId}: ");
            for(int i = 0; i <= 8; i++)
            {
                Console.Write($"{fish[i]} ");
            }
            Console.WriteLine();
        }
    }
}
