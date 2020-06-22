using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    #region Day 24
    /*
    --- Day 24: Planet of Discord ---
    You land on Eris, your last stop before reaching Santa. As soon as you do,
    your sensors start picking up strange life forms moving around: Eris is 
    infested with bugs! With an over 24-hour roundtrip for messages between you
    and Earth, you'll have to deal with this problem on your own.

    Eris isn't a very large place; a scan of the entire area fits into a 5x5
    grid (your puzzle input). The scan shows bugs (#) and empty spaces (.).

    Each minute, The bugs live and die based on the number of bugs in the four 
    adjacent tiles:

      - A bug dies (becoming an empty space) unless there is exactly one bug
        adjacent to it.
      - An empty space becomes infested with a bug if exactly one or two bugs
        are adjacent to it.

    Otherwise, a bug or empty space remains the same. (Tiles on the edges of
    the grid have fewer than four adjacent tiles; the missing tiles count as
    empty space.) This process happens in every location simultaneously; that
    is, within the same minute, the number of adjacent bugs is counted for 
    every tile first, and then the tiles are updated.

    Here are the first few minutes of an example scenario:

    Initial state:
    ....#
    #..#.
    #..##
    ..#..
    #....

    After 1 minute:
    #..#.
    ####.
    ###.#
    ##.##
    .##..

    After 2 minutes:
    #####
    ....#
    ....#
    ...#.
    #.###

    After 3 minutes:
    #....
    ####.
    ...##
    #.##.
    .##.#

    After 4 minutes:
    ####.
    ....#
    ##..#
    .....
    ##...

    To understand the nature of the bugs, watch for the first time a layout of
    bugs and empty spaces matches any previous layout. In the example above,
    the first layout to appear twice is:

    .....
    .....
    .....
    #....
    .#...

    To calculate the biodiversity rating for this layout, consider each tile 
    left-to-right in the top row, then left-to-right in the second row, and so
    on. Each of these tiles is worth biodiversity points equal to increasing
    powers of two: 1, 2, 4, 8, 16, 32, and so on. Add up the biodiversity
    points for tiles with bugs; in this example, the 16th tile (32768 points) 
    and 22nd tile (2097152 points) have bugs, a total biodiversity rating of
    2129920.

    What is the biodiversity rating for the first layout that appears twice?

    */
    #endregion

    public class Day24 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (IsPartB) return -1;

            long state = GetStateFromString(input);
            PrintState(state);

            var AllStates = new HashSet<long>();
            AllStates.Add(state);
            var currIndex = 0;

            while (true) // && currIndex <= 5)
            {
                var newState = RunOnce(state);
                //PrintState(newState);
                state = newState;

                if (AllStates.Contains(state))
                {
                    return state;
                }
                else
                {
                    AllStates.Add(state);
                }

                currIndex++;
            }

            return -1;
        }

        private long RunOnce(long state)
        {
            long nextState = 0;

            for (int c = 0; c < 25; c++)
            {
                var livingRelatives = 0;
                livingRelatives += IsAlive(state, c - 5) ? 1 : 0;
                livingRelatives += IsAlive(state, c + 5) ? 1 : 0;
                if (c % 5 != 0)
                {
                    livingRelatives += IsAlive(state, c - 1) ? 1 : 0;
                }
                if (c % 5 != 4)
                {
                    livingRelatives += IsAlive(state, c + 1) ? 1 : 0;
                }

                bool nextIsAlive = false;
                if (IsAlive(state, c))
                {
                    nextIsAlive = livingRelatives == 1;
                }
                else
                {
                    nextIsAlive = livingRelatives == 1 || livingRelatives == 2;
                }

                if (nextIsAlive)
                {
                    nextState += (long)Math.Pow(2, c);
                }
            }

            return nextState;
        }

        private bool IsAlive(long state, int spot)
        {
            if (spot < 0 || spot >= 25)
            {
                return false;
            }

            return (state & (long)Math.Pow(2, spot)) != 0;
        }

        private long GetStateFromString(string input)
        {
            var chars = input.ToCharArray();
            var index = 0;
            long currState = 0;
            foreach (var c in chars)
            {
                switch (c)
                {
                    case '.':
                        index++;
                        break;
                    case '#':
                        currState += (long)Math.Pow(2, index);
                        index++;
                        break;
                    default:
                        break;
                }
            }

            return currState;
        }

        private void PrintState(long state)
        {
            Console.WriteLine($"{state}:");
            for (int c = 0; c < 25; c++)
            {
                if (IsAlive(state, c))
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }
                if (c % 5 == 4)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
