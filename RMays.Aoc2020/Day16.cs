using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day16 : IDay<long>
    {
        private string FieldToFind = "?";

        public Day16()
        {
        }

        public Day16(string fieldToFind)
        {
            FieldToFind = fieldToFind;
        }

        public long Solve(string input, bool IsPartB = false)
        {
            var lines = input.Split('\r').Select(x => x.Trim()).ToList();
            var valid = new bool[1000]; // all are false
            var section = 0;
            var sum = 0;
            var yourTicket = "";
            Dictionary<string, string> Fields = new Dictionary<string, string>();
            List<string> NearbyTickets = new List<string>();

            foreach (var line in lines)
            {
                if (line == "")
                {
                    section++;
                    continue;
                }

                switch (section)
                {
                    case 0:
                        Fields.Add(line.Split(':')[0], line.Split(':')[1].Trim().Replace(" or ", ","));
                        var s = line.Split(':')[1].Trim();
                        var range1 = s.Substring(0, s.IndexOf(' '));
                        var range2 = s.Substring(s.IndexOf(" or ") + 4);
                        //Console.WriteLine($"s: [{s}]");
                        //Console.WriteLine($"Range1: [{range1}]");
                        //Console.WriteLine($"Range2: [{range2}]");
                        //Console.WriteLine();

                        var start1 = int.Parse(range1.Split('-')[0]);
                        var end1 = int.Parse(range1.Split('-')[1]);
                        var start2 = int.Parse(range2.Split('-')[0]);
                        var end2 = int.Parse(range2.Split('-')[1]);

                        for (int i = start1; i <= end1; i++)
                        {
                            valid[i] = true;
                        }
                        for (int i = start2; i <= end2; i++)
                        {
                            valid[i] = true;
                        }

                        // ranges
                        break;
                    case 1:
                        // your ticket
                        if (line.StartsWith("your ticket:")) continue;
                        yourTicket = line;
                        break;
                    case 2:
                        if (line.StartsWith("nearby tickets:")) continue;
                        // nearby tickets
                        //Console.WriteLine("Line: " + line);
                        var rejectTicket = false;
                        foreach (var t in line.Split(','))
                        {
                            var num = int.Parse(t);
                            if (!valid[num])
                            {
                                rejectTicket = true;
                                sum += num;
                            }
                        }

                        if (!rejectTicket)
                        {
                            NearbyTickets.Add(line);
                        }

                        break;
                }
            }

            if (!IsPartB)
            {
                return sum;
            }

            // NOW, work with Fields and NearbyTickets to figure out which field is which.

            // Possibles[x, y] means Field X (eg. 'class') could be the Yth field on the ticket.
            var FieldCount = Fields.Count;
            var Possibles = new bool?[FieldCount, FieldCount];
            for (int r = 0; r < FieldCount; r++)
            {
                for (int c = 0; c < FieldCount; c++)
                {
                    Possibles[r, c] = null;
                }
            }

            var RowRanges = new List<RowRange>();
            foreach (var key in Fields.Keys)
            {
                RowRanges.Add(new RowRange(
                    int.Parse(Fields[key].Split(',')[0].Split('-')[0]),
                    int.Parse(Fields[key].Split(',')[0].Split('-')[1]),
                    int.Parse(Fields[key].Split(',')[1].Split('-')[0]),
                    int.Parse(Fields[key].Split(',')[1].Split('-')[1])
                    ));
            }


            // Simple pass; go through each ticket, and eliminate possibilites.
            foreach (var ticket in NearbyTickets)
            {
                // ticket: "3,9,18"
                for (int i = 0; i < FieldCount; i++)
                {
                    // i: 0
                    var tv = int.Parse(ticket.Split(',')[i]);
                    // tv: 3
                    for (int r = 0; r < FieldCount; r++)
                    {
                        if (!RowRanges[r].NumberContainsRange(tv))
                        {
                            Possibles[r, i] = false;
                        }
                    }
                }
            }

            while (!DoneSolving(Possibles, FieldCount))
            {
                // Find some truths.
                // Look for any row that has one NULL and the rest FALSE;
                //   when we find one, replace the NULL with TRUE, and convert all other items in that row / column to FALSE.
                // Then keep going!

                for (int r = 0; r < FieldCount; r++)
                {
                    // Look at all entries in row r.
                    var nulls = 0;
                    var truths = 0;
                    var falses = 0;
                    var lastNull = -1;
                    for (int c = 0; c < FieldCount; c++)
                    {
                        switch (Possibles[r, c])
                        {
                            case true:
                                truths++;
                                break;
                            case false:
                                falses++;
                                break;
                            case null:
                                nulls++;
                                lastNull = c;
                                break;
                        }
                    }

                    if (truths == 0 && falses == FieldCount - 1 && nulls == 1)
                    {
                        // Change everything in this row / column to False ... except for this value.
                        for (int x = 0; x < FieldCount; x++)
                        {
                            Possibles[x, lastNull] = false;
                        }
                        Possibles[r, lastNull] = true;
                    }
                }

                // I didn't have to add column-checking.  None of the test cases required it.
            }

            // They're mapped!  ... kinda.
            // Let's clean it up.
            var fieldMapping = new Dictionary<string, int>();
            int row = 0;
            foreach (var field in Fields.Keys)
            {
                for (int col = 0; col < FieldCount; col++)
                {
                    if (Possibles[row, col] ?? false)
                    {
                        fieldMapping.Add(field, col);
                    }
                }
                row++;
            }

            // Now, map your ticket.
            long multTotal = 1;
            foreach (var key in Fields.Keys)
            {
                if (key.Contains(this.FieldToFind))
                {
                    multTotal *= long.Parse(yourTicket.Split(',')[fieldMapping[key]]);
                }
            }

            return multTotal;
        }

        internal class RowRange
        {
            public int Range1Low { get; set; }
            public int Range1High { get; set; }
            public int Range2Low { get; set; }
            public int Range2High { get; set; }

            public RowRange() { }
            public RowRange(int start1, int end1, int start2, int end2)
            {
                Range1Low = start1;
                Range1High = end1;
                Range2Low = start2;
                Range2High = end2;
            }

            public bool NumberContainsRange(int numToCheck)
            {
                return (numToCheck >= Range1Low && numToCheck <= Range1High) || (numToCheck >= Range2Low && numToCheck <= Range2High);
            }

            public override string ToString()
            {
                return $"{Range1Low}-{Range1High}, {Range2Low}-{Range2High}";
            }
        }

        private bool DoneSolving(bool?[,] possibles, int fieldCount)
        {
            for(int r = 0; r < fieldCount; r++)
            {
                int truths = 0;
                for(int c = 0; c < fieldCount; c++)
                {
                    if (possibles[r,c] ?? false)
                    {
                        truths++;
                    }
                }

                // We expect exactly ONE value in each row to be true.
                if (truths != 1) return false;
            }

            for (int c = 0; c < fieldCount; c++)
            {
                int truths = 0;
                for (int r = 0; r < fieldCount; r++)
                {
                    if (possibles[r, c] ?? false)
                    {
                        truths++;
                    }
                }

                // We expect exactly ONE value in each col to be true.
                if (truths != 1) return false;
            }

            return true;
        }
    }
}
