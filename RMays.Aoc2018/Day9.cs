using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day9
    {
        public long SolveA(string input)
        {
            return SolveB(input);
        }

        public long SolveB(string input)
        {
            // input example:
            //  10 players; last marble is worth 1618 points
            var tokens = Parser.Tokenize(input, ' ');
            var players = int.Parse(tokens[0]);
            var lastMarble = int.Parse(tokens[6]);

            var marbles = new LinkedList<int>();
            marbles.AddFirst(0);
            var scores = new Dictionary<int, long>();
            for (int i = 1; i <= players; i++)
            {
                scores.Add(i, 0);
            }

            LinkedListNode<int> currPos = marbles.First;
            var currPlayer = 1;
            for (var currMarble = 1; currMarble <= lastMarble; currMarble++)
            {
                if (currMarble % 23 == 0)
                {
                    // Special rules
                    scores[currPlayer] += currMarble;
                    for(int i = 0; i < 6; i++)
                    {
                        currPos = currPos.Previous;
                        if (currPos == null)
                        {
                            currPos = marbles.Last;
                        }
                    }
                    scores[currPlayer] += currPos.Value;
                    var removeAt = currPos;
                    currPos = currPos.Next;
                    if (currPos == null) currPos = marbles.First;
                    marbles.Remove(removeAt);
                    currPos = currPos.Previous;
                    if (currPos == null) currPos = marbles.Last;
                }
                else
                {
                    // Normal rules
                    for (int i = 0; i < 2; i++)
                    {
                        currPos = currPos.Next;
                        if (currPos == null)
                        {
                            currPos = marbles.First;
                        }
                    }

                    marbles.AddAfter(currPos, currMarble);
                }

                currPlayer++;
                if (currPlayer > players)
                {
                    currPlayer = 1;
                }
            }

            return scores.Values.Max();
        }
    }
}
