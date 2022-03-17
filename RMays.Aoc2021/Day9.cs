using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 9
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day9 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var map = new byte[102,102];
            var lines = Parser.TokenizeLines(input);

            // Reset the map
            var row = 0;
            var col = 0;

            for (row = 0; row < 102; row++)
            {
                for (col = 0; col < 102; col++)
                {
                    map[row, col] = 9;
                }
            }

            row = 1;
            foreach (var line in lines)
            {
                col = 1;
                foreach(var cell in line.ToCharArray())
                {
                    map[row, col] = (byte)(cell - '0');
                    col++;
                }
                row++;
            }

            // Process
            if (IsPartB)
            {
                return GetBasinScore(map);
            }
            else
            {
                return GetLowPointsScore(map);
            }
        }

        private long GetBasinScore(byte[,] map)
        {
            var lowestPoints = GetLowPoints(map);
            var result = 1;
            var basinSizes = new List<int>();

            // Go through each point, get a score for each, and return.
            foreach(var point in lowestPoints)
            {
                // 'point' has Item1 and Item2 for Row and Col.
                basinSizes.Add(GetBasinSizeFromPoint(point, map));
            }

            basinSizes.Sort();
            basinSizes.Reverse();

            return basinSizes[0] * basinSizes[1] * basinSizes[2];
        }

        private int GetBasinSizeFromPoint((int, int) point, byte[,] map)
        {
            var pointsFound = new List<(int, int)>();
            FillAdjacentPoints(point, pointsFound, map);
            return pointsFound.Count;
        }

        private void FillAdjacentPoints((int, int) point, List<(int, int)> pointsFound, byte[,] map)
        {
            if (pointsFound.Contains(point)) return;

            pointsFound.Add(point);
            if (map[point.Item1 + 1, point.Item2] < 9)
            {
                FillAdjacentPoints((point.Item1 + 1, point.Item2), pointsFound, map);
            }
            if (map[point.Item1 - 1, point.Item2] < 9)
            {
                FillAdjacentPoints((point.Item1 - 1, point.Item2), pointsFound, map);
            }
            if (map[point.Item1, point.Item2 + 1] < 9)
            {
                FillAdjacentPoints((point.Item1, point.Item2 + 1), pointsFound, map);
            }
            if (map[point.Item1, point.Item2 - 1] < 9)
            {
                FillAdjacentPoints((point.Item1, point.Item2 - 1), pointsFound, map);
            }
        }

        private long GetLowPointsScore(byte[,] map)
        {
            long result = 0;
            var lowestPoints = GetLowPoints(map);
            foreach(var point in lowestPoints)
            {
                result += map[point.Item1, point.Item2] + 1;
            }
            return result;
        }

        private List<(int, int)> GetLowPoints(byte[,] map)
        {
            var result = new List<(int, int)>();
            for (var row = 1; row <= 100; row++)
            {
                for (var col = 1; col <= 100; col++)
                {
                    var curr = map[row, col];
                    if (curr < map[row + 1, col] && curr < map[row - 1, col] && curr < map[row, col + 1] && curr < map[row, col - 1])
                    {
                        result.Add((row, col));
                    }
                }
            }
            return result;
        }
    }
}
