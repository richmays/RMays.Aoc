using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 1
    /*
--- Day 1: Report Repair ---
After saving Christmas five years in a row, you've decided to take a vacation at a nice resort on a tropical island. Surely, Christmas will go on without you.

The tropical island has its own currency and is entirely cash-only. The gold coins used there have a little picture of a starfish; the locals just call them stars. None of the currency exchanges seem to have heard of them, but somehow, you'll need to find fifty of these coins by the time you arrive so you can pay the deposit on your room.

To save your vacation, you need to get all fifty stars by December 25th.

Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.

Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.

For example, suppose your expense report contained the following:

1721
979
366
299
675
1456
In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.

Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together?

    */
    #endregion

    public class Day1 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (!IsPartB)
            {
                List<string> itemsStr = Parser.TokenizeLines(input);
                List<int> items = new List<int>();
                foreach(var item in itemsStr)
                {
                    int newItem = int.Parse(item);
                    if (items.Contains(2020 - newItem))
                    {
                        return newItem * (2020 - newItem);
                    }
                    items.Add(newItem);
                }


                
            }

            return doB(input);

        }

        private long doB(string input)
        {
            List<string> itemsStr = Parser.TokenizeLines(input);
            List<long> items = new List<long>();
            foreach (var item in itemsStr)
            {
                int newItem = int.Parse(item);
                foreach (var item1 in items)
                {
                    foreach (var item2 in items)
                    {
                        if (item1 + item2 + newItem == 2020)
                        {

                            return item1 * item2 * newItem;
                        }
//                        if (item1 + item2 + item)
                 }
                }

                items.Add(newItem);
            }

            return -1;
        }
    }
}
