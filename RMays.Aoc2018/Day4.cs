using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day4
    {
        public long SolveA(string input)
        {
            var lines = Parser.TokenizeLines(input);

            lines.Sort();

            int guard = 0;
            var guardsSleep = new Dictionary<int, List<int>>();
            int startSleepMin = 0;
            foreach (var line in lines)
            {
                var tokens = Parser.Tokenize(line, ' ');
                switch(tokens[2])
                {
                    case "Guard":
                        guard = int.Parse(tokens[3].Replace("#", ""));
                        if (!guardsSleep.Keys.Contains(guard))
                        {
                            var daysAsleep = new List<int>();
                            for(int d = 0; d < 60; d++)
                            {
                                daysAsleep.Add(0);
                            }
                            guardsSleep.Add(guard, daysAsleep);
                        }
                        break;
                    case "falls":
                        startSleepMin = int.Parse(tokens[1].Replace("]", "").Split(':')[1]);
                        break;
                    case "wakes":
                        var endSleepMin = int.Parse(tokens[1].Replace("]", "").Split(':')[1]);
                        for (int i = startSleepMin; i < endSleepMin; i++)
                        {
                            guardsSleep[guard][i]++;
                        }
                        break;
                }
            }

            // Who slept the most?
            int sleepiestGuard = -1;
            int sleepCount = -1;
            foreach(var g in guardsSleep.Keys)
            {
                if (guardsSleep[g].Sum() > sleepCount)
                {
                    sleepCount = guardsSleep[g].Sum();
                    sleepiestGuard = g;
                }
            }

            int sleepiestDay = -1;
            int sleepFreq = -1;
            for(int d = 0; d < 59; d++)
            {
                var sleepDay = guardsSleep[sleepiestGuard][d];
                if (sleepDay > sleepFreq)
                {
                    sleepFreq = sleepDay;
                    sleepiestDay = d;
                }
            }
            
            return sleepiestGuard * sleepiestDay;
        }

        public long SolveB(string input)
        {
            var lines = Parser.TokenizeLines(input);

            lines.Sort();

            int guard = 0;
            var guardsSleep = new Dictionary<int, List<int>>();
            int startSleepMin = 0;
            foreach (var line in lines)
            {
                var tokens = Parser.Tokenize(line, ' ');
                switch (tokens[2])
                {
                    case "Guard":
                        guard = int.Parse(tokens[3].Replace("#", ""));
                        if (!guardsSleep.Keys.Contains(guard))
                        {
                            var daysAsleep = new List<int>();
                            for (int d = 0; d < 60; d++)
                            {
                                daysAsleep.Add(0);
                            }
                            guardsSleep.Add(guard, daysAsleep);
                        }
                        break;
                    case "falls":
                        startSleepMin = int.Parse(tokens[1].Replace("]", "").Split(':')[1]);
                        break;
                    case "wakes":
                        var endSleepMin = int.Parse(tokens[1].Replace("]", "").Split(':')[1]);
                        for (int i = startSleepMin; i < endSleepMin; i++)
                        {
                            guardsSleep[guard][i]++;
                        }
                        break;
                }
            }

            // Who slept the most?
            int sleepiestGuard = -1;
            int sleepiestMin = -1;
            int sleepCount = -1;

            foreach (var g in guardsSleep.Keys)
            {
                for (int d = 0; d < 59; d++)
                {
                    if (guardsSleep[g][d] > sleepCount)
                    {
                        sleepCount = guardsSleep[g][d];
                        sleepiestGuard = g;
                        sleepiestMin = d;
                    }
                }
            }
/*
            int sleepiestDay = -1;
            int sleepFreq = -1;

                var sleepDay = guardsSleep[sleepiestGuard][d];
                if (sleepDay > sleepFreq)
                {
                    sleepFreq = sleepDay;
                    sleepiestDay = d;
                }
            }
            */
            return sleepiestGuard * sleepiestMin;
        }
    }
}
