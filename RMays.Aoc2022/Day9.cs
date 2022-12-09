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

    public class Day9 : IDay<long>
    {
        HashSet<(int, int)> SpotsVisited;
        List<(int, int)> Rope = new List<(int, int)>();

        public long Solve(string input, bool IsPartB = false)
        {
            int ropeLength = (IsPartB ? 10 : 2);
            for (int i = 0; i < ropeLength; i++)
            {
                Rope.Add((0, 0));
            }

            SpotsVisited = new HashSet<(int, int)>();
            var lines = Parser.TokenizeLines(input);

            foreach (var line in lines)
            {
                var dir = line[0];
                var steps = int.Parse(line.Split(' ')[1]);
                switch (dir)
                {
                    case 'U':
                        for (int i = 0; i < steps; i++)
                        {
                            Rope[0] = (Rope[0].Item1 - 1, Rope[0].Item2);
                            UpdateTail();
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < steps; i++)
                        {
                            Rope[0] = (Rope[0].Item1 + 1, Rope[0].Item2);
                            UpdateTail();
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < steps; i++)
                        {
                            Rope[0] = (Rope[0].Item1, Rope[0].Item2 - 1);
                            UpdateTail();
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < steps; i++)
                        {
                            Rope[0] = (Rope[0].Item1, Rope[0].Item2 + 1);
                            UpdateTail();
                        }
                        break;
                }
            }

            return SpotsVisited.Count();
        }

        public void UpdateTail()
        {
            for (int i = 1; i < Rope.Count(); i++)
            {
                var row = Rope[i - 1].Item1;
                var col = Rope[i - 1].Item2;
                var tRow = Rope[i].Item1;
                var tCol = Rope[i].Item2;

                if (tCol < col - 1)
                {
                    // Rope[i] = (Rope[i].Item1, Rope[i].Item2);
                    Rope[i] = (Rope[i].Item1, Rope[i].Item2 + 1);
                    if (tRow < row)
                    {
                        Rope[i] = (Rope[i].Item1 + 1, Rope[i].Item2);
                    }
                    else if (tRow > row)
                    {
                        Rope[i] = (Rope[i].Item1 - 1, Rope[i].Item2);
                    }
                }
                else if (tCol > col + 1)
                {
                    Rope[i] = (Rope[i].Item1, Rope[i].Item2 - 1);
                    if (tRow < row)
                    {
                        Rope[i] = (Rope[i].Item1 + 1, Rope[i].Item2);
                    }
                    else if (tRow > row)
                    {
                        Rope[i] = (Rope[i].Item1 - 1, Rope[i].Item2);
                    }
                }
                else if (tRow < row - 1)
                {
                    Rope[i] = (Rope[i].Item1 + 1, Rope[i].Item2);
                    if (tCol < col)
                    {
                        Rope[i] = (Rope[i].Item1, Rope[i].Item2 + 1);
                    }
                    else if (tCol > col)
                    {
                        Rope[i] = (Rope[i].Item1, Rope[i].Item2 - 1);
                    }
                }
                else if (tRow > row + 1)
                {
                    Rope[i] = (Rope[i].Item1 - 1, Rope[i].Item2);
                    if (tCol < col)
                    {
                        Rope[i] = (Rope[i].Item1, Rope[i].Item2 + 1);
                    }
                    else if (tCol > col)
                    {
                        Rope[i] = (Rope[i].Item1, Rope[i].Item2 - 1);
                    }
                }
            }

            //Console.WriteLine($"  T After: {tRow},{tCol}");

            var lastRope = Rope.Last();
            if (!SpotsVisited.Contains(lastRope))
            {
                SpotsVisited.Add(lastRope);
            }
        }
    }
}
