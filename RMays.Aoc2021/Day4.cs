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

    public class Day4 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            var calledNumbers = lines[0].Split(',').Select(x => int.Parse(x));
            var boards = new List<Board>();
            var lineId = 1;
            while (lineId <= lines.Count() - 5)
            {
                var board = new List<List<int>>();
                var boardValues = new List<int>();
                for (int row = 0; row < 5; row++)
                {
                    boardValues.AddRange(Parser.Tokenize(lines[row + lineId], ' ').Select(x => int.Parse(x)));
                }

                if (boardValues.Count() != 25)
                {
                    throw new ApplicationException("Expected exactly 25 values in boardValues.");
                }

                boards.Add(new Board(boardValues));
                lineId += 5;
            }

            // Now call out each number in 'calledNumbers', removing each number from each list as we find them.
            var boardsWon = 0;
            foreach (var called in calledNumbers)
            {
                foreach (var board in boards)
                {
                    // Skip if this board already won.
                    if (board.IsWinner()) continue;

                    board.CallNumber(called);
                    if (board.IsWinner())
                    {
                        // Do something!
                        if (!IsPartB)
                        {
                            return board.BoardValue(called);
                        }

                        boardsWon++;
                        if (boardsWon == boards.Count())
                        {
                            return board.BoardValue(called);
                        }
                    }
                }
            }

            return boards.Count();
        }

        internal class Board
        {
            private Tuple<int, bool>[] Spots = new Tuple<int, bool>[25];
            private bool _isWinner = false;

            public Board(List<int> spots)
            {
                for (int i = 0; i < 25; i++)
                {
                    Spots[i] = new Tuple<int, bool> ( spots[i], false );
                }
            }

            public int BoardValue(int lastCalled)
            {
                var sum = Spots.Where(x => !x.Item2).Sum(x => x.Item1);
                return sum * lastCalled;
            }

            public void CallNumber(int number)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (Spots[i].Item1 == number)
                    {
                        Spots[i] = new Tuple<int, bool>(number, true);
                        return;
                    }
                }
            }

            public bool IsWinner()
            {
                if (_isWinner) return true;

                for(var i = 0; i < 5; i++)
                {
                    if (RowHasWinner(i, 5))
                    {
                        _isWinner = true;
                        return true;
                    }
                    if (RowHasWinner(5 * i, 1))
                    {
                        _isWinner = true;
                        return true;
                    }
                }

                return false;
            }

            private bool RowHasWinner(int startId, int changeValue)
            {
                for (int offset = 0; offset < 5; offset++)
                {
                    if (!Spots[startId + (offset * changeValue)].Item2)
                    {
                        return false;
                    }
                }

                return true;
            }

            public override string ToString()
            {
                var result = new StringBuilder();
                for(int r = 0; r < 5; r++)
                {
                    for(int c = 0; c < 5; c++)
                    {
                        var spot = Spots[r * 5 + c];
                        result.Append($"{(spot.Item2 ? $"[{spot.Item1}]" : $"{spot.Item1}")} ");
                    }

                    result.Append(Environment.NewLine);
                }

                return result.ToString();
            }
        }
    }
}
