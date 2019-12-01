using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day7
    {
        public class Worker
        {
            public int Energy { get; set; }
            public char? Step { get; set; }

            public Worker()
            {
                Energy = 0;
                Step = null;
            }

            public override string ToString()
            {
                return $"{Energy}:{Step ?? '-'}";
            }
        }

        public string SolveA(string input)
        {
            var deps = GetDeps(input);

            var result = string.Empty;
            while (deps.Count > 0 && deps.Where(x => x.Value.Count == 0).Count() > 0)
            {
                var next = deps.Where(x => x.Value.Count == 0).OrderBy(x => x.ToString()).First().Key;
                result += next.ToString();

                // Now remove it everywhere.
                deps.Remove(next);
                foreach(var key in deps.Keys)
                {
                    deps[key].Remove(next);
                }
            }

            return result;
        }

        public Dictionary<char, List<char>> GetDeps(string input)
        {
            // Step C must be finished before step F can begin.
            var lines = Parser.TokenizeLines(input);
            var rawList = new List<string>();
            foreach (var line in lines)
            {
                var theSplit = line.Split(' ');
                rawList.Add($"{theSplit[1]}{theSplit[7]}");
            }

            var deps = new Dictionary<char, List<char>>();
            foreach (var line in rawList)
            {
                for (var index = 0; index < 2; index++)
                {
                    if (!deps.Keys.Contains(line[index]))
                    {
                        deps.Add(line[index], new List<char>());
                    }
                }
            }

            foreach (var line in rawList)
            {
                deps[line[1]].Add(line[0]);
            }

            return deps;
        }

        public int SolveB(string input, int workersCount, int extraSteps)
        {
            var deps = GetDeps(input);
            var workers = new List<Worker>();
            for (var workerId = 0; workerId < workersCount; workerId++)
            {
                workers.Add(new Aoc2018.Day7.Worker());
            }

            var result = string.Empty;
            var stepsTaken = 0;
            while (workers.Select(x => x.Energy).Sum() > 0 || deps.Count > 0)
            {
                // Do 1 unit of work.
                for (var workerId = 0; workerId < workersCount; workerId++)
                {
                    if (workers[workerId].Energy == 1)
                    {
                        var carriedChar = workers[workerId].Step.Value;
                        result += carriedChar.ToString();
                        deps.Remove(carriedChar);
                        foreach (var key in deps.Keys)
                        {
                            deps[key].Remove(carriedChar);
                        }

                        workers[workerId].Step = '?';
                    }

                    if (workers[workerId].Energy > 0)
                    {
                        workers[workerId].Energy--;
                    }
                }

                // While there's an available worker ...
                var workerLowestEnergy = workers.OrderBy(x => x.Energy).First();
                while (workerLowestEnergy.Energy == 0)
                {
                    if (deps.Count() == 0) break;
                    var nextKey = deps.Where(x => x.Value.Count == 0 && !workers.Select(w => w.Step).Contains(x.Key)).OrderBy(x => x.ToString()).FirstOrDefault();
                    if (nextKey.Key == '\0') break;
                    var next = nextKey.Key;
                    workerLowestEnergy.Step = next;
                    workerLowestEnergy.Energy = (next - 'A') + 1 + extraSteps;

                    workerLowestEnergy = workers.OrderBy(x => x.Energy).First();
                }

                /*
                Console.Write($"{stepsTaken,3}  ");
                foreach (var worker in workers)
                {
                    Console.Write($"{worker.Energy}:{worker.Step ?? '-'} ");
                }
                Console.WriteLine();
                */

                stepsTaken++;
            }

            return stepsTaken - 1;
        }
    }
}
