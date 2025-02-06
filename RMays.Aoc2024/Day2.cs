using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024
{
    public class Day2 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var safeReports = 0;
            var lines = Parser.TokenizeLines(input);
            foreach (var line in lines)
            {
                if (!IsPartB)
                {
                    if (!ReportHasFault(line.Split(' ').Select(x => int.Parse(x)).ToList()))
                    {
                        safeReports++;
                    }
                }
                else
                {
                    // Brute force.  Ugh.
                    var hasNoFaults = false;
                    var originalList = line.Split(' ').Select(x => int.Parse(x)).ToList();
                    for (int i = 0; i < originalList.Count; i++)
                    {
                        var newList = new List<int>();
                        for (int j = 0; j < originalList.Count; j++)
                        {
                            if (i == j) continue;
                            newList.Add(originalList[j]);
                        }

                        if (!ReportHasFault(newList))
                        {
                            hasNoFaults = true;
                        }
                    }

                    if (hasNoFaults)
                    {
                        safeReports++;
                    }

                }
            }

            return safeReports;
        }

        private bool ReportHasFault(List<int> levels)
        {
            if (levels.Count <= 1) return false;
            int prev = levels[0];
            int direction = levels[0] < levels[1] ? 1 : -1;
            for (int i = 1; i < levels.Count; i++)
            {
                if (Math.Abs(levels[i] - prev) > 3)
                {
                    return true;
                }

                if (levels[i] == prev)
                {
                    return true;
                }

                if ((levels[i] - prev) * direction < 0)
                {
                    return true;
                }

                prev = levels[i];
            }

            return false;
        }
    }
}
