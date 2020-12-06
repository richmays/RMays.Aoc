using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 5
    /*
Advent of Code[About][Events][Shop][Settings][Log Out]sporkyfork2 8*
        //2020[Calendar][AoC++][Sponsors][Leaderboard][Stats]
Our sponsors help make Advent of Code possible:
GitHub - We're hiring engineers to make GitHub fast. Interested? Email fast@github.com with details of exceptional performance work you've done in the past.
--- Day 5: Binary Boarding ---
You board your plane only to discover a new problem: you dropped your boarding pass! You aren't sure which seat is yours, and all of the flight attendants are busy with the flood of people that suddenly made it through passport control.

You write a quick program to use your phone's camera to scan all of the nearby boarding passes (your puzzle input); perhaps you can find your seat through process of elimination.

Instead of zones or groups, this airline uses binary space partitioning to seat people. A seat might be specified like FBFBBFFRLR, where F means "front", B means "back", L means "left", and R means "right".

The first 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane (numbered 0 through 127). Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; the first letter indicates whether the seat is in the front (0 through 63) or the back (64 through 127). The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.

For example, consider just the first seven characters of FBFBBFFRLR:

Start by considering the whole range, rows 0 through 127.
F means to take the lower half, keeping rows 0 through 63.
B means to take the upper half, keeping rows 32 through 63.
F means to take the lower half, keeping rows 32 through 47.
B means to take the upper half, keeping rows 40 through 47.
B keeps rows 44 through 47.
F keeps rows 44 through 45.
The final F keeps the lower of the two, row 44.
The last three characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane (numbered 0 through 7). The same process as above proceeds again, this time with only three steps. L means to keep the lower half, while R means to keep the upper half.

For example, consider just the last 3 characters of FBFBBFFRLR:

Start by considering the whole range, columns 0 through 7.
R means to take the upper half, keeping columns 4 through 7.
L means to take the lower half, keeping columns 4 through 5.
The final R keeps the upper of the two, column 5.
So, decoding FBFBBFFRLR reveals that it is the seat at row 44, column 5.

Every seat also has a unique seat ID: multiply the row by 8, then add the column. In this example, the seat has ID 44 * 8 + 5 = 357.

Here are some other boarding passes:

BFFFBBFRRR: row 70, column 7, seat ID 567.
FFFBBBFRRR: row 14, column 7, seat ID 119.
BBFFBBFRLL: row 102, column 4, seat ID 820.
As a sanity check, look through your list of boarding passes. What is the highest seat ID on a boarding pass?

To begin, get your puzzle input.

Answer: 
 

You can also [Share] this puzzle.

    */
    #endregion

    public class Day5 : IDay<string>
    {
        public string Solve(string input, bool IsPartB = false)
        {
            if (IsPartB)
            {
                return SolveB(input);
            }
            var lines = Parser.TokenizeLines(input);
            var maxPass = 0;
            foreach(var line in lines)
            {
                var pass = GetSeatValue(line);
                var seatId = int.Parse(pass.Split(' ')[2]);
                if (seatId > maxPass)
                {
                    maxPass = seatId;
                }
            }
            return maxPass.ToString();
        }

        private string SolveB(string input)
        {
            List<int> IDs = new List<int>();
            var lines = Parser.TokenizeLines(input);
            //var maxPass = 0;
            foreach (var line in lines)
            {
                var pass = GetSeatValue(line);
                var seatId = int.Parse(pass.Split(' ')[2]);
                IDs.Add(seatId);
            }

            for(int i = 0; i < 872; i++)
            {
                if (!IDs.Contains(i))
                {
                    Console.WriteLine(i);
                }
            }

            /*
            foreach(var id in IDs.OrderBy(x => x))
            {
                Console.WriteLine(id);
            }
            */

            return "?";
        }

        /// <summary>
        /// Returns Row, Column, SeatID (space delimited).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetSeatValue(string input)
        {
            //int row = 0;
            //int col = 0;
            //int seat = 0;

            var currRow = new SeatRange { Min = 0, Max = 127 };
            for (int i = 0; i < 7; i++)
            {
                var c = input[i];
                switch(c)
                {
                    case 'F':
                        currRow.Front();
                        break;
                    case 'B':
                        currRow.Back();
                        break;
                    default:
                        return "?";
                }
            }

            var currCol = new SeatRange { Min = 0, Max = 7 };
            for (int i = 7; i < 10; i++)
            {
                var c = input[i];
                switch (c)
                {
                    case 'L':
                        currCol.Front();
                        break;
                    case 'R':
                        currCol.Back();
                        break;
                    default:
                        return "?";
                }
            }

            return $"{currRow.Max} {currCol.Max} {currRow.Max * 8 + currCol.Max}";
        }

        public class SeatRange
        {
            public int Min { get; set; } = 0;
            public int Max { get; set; } = 127;

            public void Front()
            {
                Max = Max - ((Max - Min + 1) / 2);
            }

            public void Back()
            {
                Min = Min + ((Max - Min + 1) / 2);
            }

            public override string ToString()
            {
                return $"({Min}-{Max})";
            }
        }


       
    }
}
