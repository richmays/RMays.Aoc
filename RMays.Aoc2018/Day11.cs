using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day11
    {
        public string SolveA(string input)
        {
            var serial = int.Parse(input);
            var dict = BuildPowerDict(serial);

            string coords;
            int power;
            GetBestSquare(dict, 3, out coords, out power);
            return coords;
        }

        private void GetBestSquare(Dictionary<string, sbyte> dict, int gridSize, out string coords, out int power)
        {
            var dictSum = new Dictionary<string, int>();
            for (var x = 1; x <= 300 - gridSize + 1; x++)
            {
                for (var y = 1; y <= 300 - gridSize + 1; y++)
                {
                    var sum = 0;
                    for (var diffX = 0; diffX <= gridSize - 1; diffX++)
                    {
                        for (var diffY = 0; diffY <= gridSize - 1; diffY++)
                        {
                            sum += dict[$"{x + diffX},{y + diffY}"];
                        }
                    }
                    dictSum.Add($"{x},{y}", sum);
                }
            }

            // Now, find the greatest.
            string bestSoFar = "?";
            int highestPower = -100;
            for (var x = 1; x <= 300 - gridSize + 1; x++)
            {
                for (var y = 1; y <= 300 - gridSize + 1; y++)
                {
                    var currSum = dictSum[$"{x},{y}"];
                    if (currSum > highestPower)
                    {
                        highestPower = currSum;
                        bestSoFar = $"{x},{y}";
                    }
                }
            }

            coords = bestSoFar;
            power = highestPower;
        }

        private Dictionary<string, sbyte> BuildPowerDict(int serial)
        {
            var dict = new Dictionary<string, sbyte>();
            for (var x = 1; x <= 300; x++)
            {
                for (var y = 1; y <= 300; y++)
                {
                    var powerNum = GetPower(x, y, serial);
                    dict.Add($"{x},{y}", powerNum);
                }
            }
            return dict;
        }

        public sbyte GetPower(int x, int y, int serial)
        {
            var rackId = x + 10;
            long power = rackId * y;
            power += serial;
            power *= rackId;

            var powerString = power.ToString();
            var powerChar = powerString.Substring(powerString.Length - 3, 1);
            var powerNum = (sbyte)(sbyte.Parse(powerChar) - 5);

            return powerNum;
        }

        public string SolveB(string input)
        {
            var serial = int.Parse(input);
            var dict = BuildPowerDict(serial);

            string bestCoords = "?";
            int bestPower = -10000;
            int bestGridSize = -1;
            for (int gridSize = 11; gridSize <= 17; gridSize++)
            {
                string coords;
                int power;
                GetBestSquare(dict, gridSize, out coords, out power);
                if (power > bestPower)
                {
                    bestPower = power;
                    bestCoords = coords;
                    bestGridSize = gridSize;
                }
            }

            return $"{bestCoords},{bestGridSize}";
        }
    }
}
