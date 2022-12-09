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

    public class Day8 : IDay<long>
    {
        private int Rows { get; set; }
        private int Cols { get; set; }
        private string Data { get; set; }

        private HashSet<int> VisibleTrees { get; set; }

        public long Solve(string input, bool IsPartB = false)
        {
            VisibleTrees = new HashSet<int>();
            Cols = Parser.TokenizeLines(input)[0].Length;
            Data = input.Replace("\r\n", "");
            Rows = Data.Length / Cols;

            if (IsPartB) return SolveB();

            // Works!
            //Console.WriteLine($"Height: {height}, width: {width}");

            for (int r = 0; r < Rows; r++)
            {
                int lowest = -1;
                for (int c = 0; c < Cols; c++)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }

                lowest = -1;
                for (int c = Cols - 1; c >= 0; c--)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }
            }

            for (int r = Rows - 1; r >= 0; r--)
            {
                int lowest = -1;
                for (int c = 0; c < Cols; c++)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }

                lowest = -1;
                for (int c = Cols - 1; c >= 0; c--)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }
            }

            for (int c = 0; c < Cols; c++)
            {
                int lowest = -1;
                for (int r = 0; r < Rows; r++)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }

                lowest = -1;
                for (int r = Rows - 1; r >= 0; r--)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }
            }

            for (int c = Cols - 1; c >= 0; c--)
            {
                int lowest = -1;
                for (int r = 0; r < Rows; r++)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }

                lowest = -1;
                for (int r = Rows - 1; r >= 0; r--)
                {
                    var cell = GetCell(r, c);
                    if (cell > lowest)
                    {
                        lowest = cell;
                        AddToSet(r, c);
                    }
                }
            }

            return VisibleTrees.Count();
        }

        private long SolveB()
        {
            //var getSS = GetScenicScore(3, 2);
            //return -1;



            long bestScore = -1;
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    var score = GetScenicScore(r, c);
                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                }
            }

            return bestScore;
        }

        private long GetScenicScore(int row, int col)
        {
            var score = 1;
            int visibility;
            var treeHeight = GetCell(row, col);

            visibility = 0;
            for (int r = row - 1; r >= 0; r--)
            {
                if (r < 0) break;
                var thisTreeHeight = GetCell(r, col);
                visibility++;
                if (thisTreeHeight >= treeHeight)
                {
                    break;
                }
            }
            //Console.WriteLine($"Up: {visibility}");
            score *= visibility;

            visibility = 0;
            for (int r = row + 1; r < Rows; r++)
            {
                if (r >= Rows) break;
                var thisTreeHeight = GetCell(r, col);
                visibility++;
                if (thisTreeHeight >= treeHeight)
                {
                    break;
                }

            }
            //Console.WriteLine($"Down: {visibility}");
            score *= visibility;

            visibility = 0;
            for (int c = col - 1; c >= 0; c--)
            {
                if (c < 0) break;
                var thisTreeHeight = GetCell(row, c);
                visibility++;
                if (thisTreeHeight >= treeHeight)
                {
                    break;
                }

            }
            //Console.WriteLine($"Left: {visibility}");
            score *= visibility;

            visibility = 0;
            for (int c = col + 1; c < Cols; c++)
            {
                if (c >= Cols) break;
                var thisTreeHeight = GetCell(row, c);
                visibility++;
                if (thisTreeHeight >= treeHeight)
                {
                    break;
                }

            }
            //Console.WriteLine($"Right: {visibility}");
            score *= visibility;

            return score;
        }

        private int GetCell(int r, int c)
        {
            return Data[Rows * r + c] - '0';
        }

        private void AddToSet(int r, int c)
        {
            var spot = Rows * r + c;
            if (!VisibleTrees.Contains(spot))
            {
                VisibleTrees.Add(spot);
            }
        }
    }
}
