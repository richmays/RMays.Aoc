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
            if (IsPartB)
            {
                return Solve_PartB(input);
            }

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

        public int Solve_PartB(string input, int minutes = 200)
        {
            // Add 3 to ensure we have a blank topmost and bottommost layer.  Simplifies neighbor calculations later.
            int totalLayers = minutes * 2 + 3;

            long[] state = GetStateFromString_PartB(input, totalLayers);

            for(var currMinute = 1; currMinute <= minutes; currMinute++)
            {
                var newState = RunOncePartB(state);
                //PrintState(newState);
                state = newState;
            }

            // Now return the count.
            var count = 0;
            for (int currLayer = 0; currLayer < totalLayers; currLayer++)
            {
                count += GetCount(state[currLayer]);
            }

            return count;
        }

        private long[] RunOncePartB(long[] state)
        {
            var totalLayers = state.Length;
            long[] nextState = new long[totalLayers]; // Hopefully, this will initialize to all 0s.  Not sure if it will.

            // Don't check the bottommost and topmost layers.
            for (int currLayer = 1; currLayer < totalLayers - 1; currLayer++)
            {
                for (int c = 0; c < 25; c++)
                {
                    // Skip this if we're looking in the moddle.  It's always 0.
                    if (c == 12) continue;

                    var livingRelatives = 0;

                    // Check the cell to the north.
                    if (c >= 0 && c <= 4)
                    {
                        livingRelatives += IsAlive(state[currLayer + 1], 7) ? 1 : 0;
                    }
                    else if (c == 17)
                    {
                        livingRelatives += IsAlive(state[currLayer - 1], 20) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 21) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 22) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 23) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 24) ? 1 : 0;
                    }
                    else
                    {
                        livingRelatives += IsAlive(state[currLayer], c - 5) ? 1 : 0;
                    }

                    // Check the cell to the south.
                    if (c >= 20 && c <= 24)
                    {
                        livingRelatives += IsAlive(state[currLayer + 1], 17) ? 1 : 0;
                    }
                    else if (c == 7)
                    {
                        livingRelatives += IsAlive(state[currLayer - 1], 0) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 1) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 2) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 3) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 4) ? 1 : 0;
                    }
                    else
                    {
                        livingRelatives += IsAlive(state[currLayer], c + 5) ? 1 : 0;
                    }

                    // Check the cell to the east.
                    if (c % 5 == 4)
                    {
                        livingRelatives += IsAlive(state[currLayer + 1], 13) ? 1 : 0;
                    }
                    else if (c == 11)
                    {
                        livingRelatives += IsAlive(state[currLayer - 1], 0) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 5) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 10) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 15) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 20) ? 1 : 0;
                    }
                    else
                    {
                        livingRelatives += IsAlive(state[currLayer], c + 1) ? 1 : 0;
                    }

                    // Check the cell to the west.
                    if (c % 5 == 0)
                    {
                        livingRelatives += IsAlive(state[currLayer + 1], 11) ? 1 : 0;
                    }
                    else if (c == 13)
                    {
                        livingRelatives += IsAlive(state[currLayer - 1], 4) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 9) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 14) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 19) ? 1 : 0;
                        livingRelatives += IsAlive(state[currLayer - 1], 24) ? 1 : 0;
                    }
                    else
                    {
                        livingRelatives += IsAlive(state[currLayer], c - 1) ? 1 : 0;
                    }

                    bool nextIsAlive;
                    if (IsAlive(state[currLayer], c))
                    {
                        nextIsAlive = livingRelatives == 1;
                    }
                    else
                    {
                        nextIsAlive = livingRelatives == 1 || livingRelatives == 2;
                    }

                    if (nextIsAlive)
                    {
                        nextState[currLayer] += (long)Math.Pow(2, c);
                    }
                }
            }

            return nextState;
        }

        private int GetCount(long stateOneLayer)
        {
            int count = 0;
            for (int c = 0; c < 25; c++)
            {
                if (IsAlive(stateOneLayer, c))
                {
                    count++;
                }
            }

            return count;
        }

        private long[] GetStateFromString_PartB(string input, int totalLayers)
        {
            var state = new long[totalLayers];
            for (int i = 0; i < totalLayers; i++)
            {
                state[i] = 0;
            }

            state[totalLayers / 2] = GetStateFromString(input);
            return state;
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
