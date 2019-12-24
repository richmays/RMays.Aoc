using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day17 : IDay<long>
    {
        // start: 12:05, 12/24/2019
        // end:  1:04 (59 minutes for both parts).  that would've been probably top-200 or top-300 (100th was 45 minutes)
        // I printed the grid, then solved it by hand.  Not too bad.
        public long Solve(string input, bool IsPartB = false)
        {
            if (IsPartB)
            {
                return SolveB(input);
            }

            var grid = GetGrid(input);

            // Now, get intersections.
            var sum = 0;
            for (int top = 1; top < grid.GetLongLength(0) - 1; top++)
            {
                for (int left = 1; left < grid.GetLongLength(0) - 1; left++)
                {
                    if (grid[left, top] && grid[left - 1, top] && grid[left + 1, top] && grid[left, top - 1] && grid[left, top + 1])
                    {
                        // Found an intesection.
                        Console.WriteLine($"({top},{left}");
                        sum += (top * left);
                    }
                }
            }

            return sum;
        }

        private long SolveB(string programInput)
        {
            var Compy = new IntcodeComp();
            Compy.Program = programInput;
            Compy.Initialize();
            Compy.SetAddress(0, 2);
            Compy.Run();
            PrintOutput(Compy);
            AddCompyCommandNL(Compy, "A,B,A,C,A,B,C,B,C,B");
            Compy.Run();
            PrintOutput(Compy);
            AddCompyCommandNL(Compy, "L,10,R,8,L,6,R,6");
            Compy.Run();
            PrintOutput(Compy);
            AddCompyCommandNL(Compy, "L,8,L,8,R,8");
            Compy.Run();
            PrintOutput(Compy);
            AddCompyCommandNL(Compy, "R,8,L,6,L,10,L,10");
            Compy.Run();
            PrintOutput(Compy);
            AddCompyCommandNL(Compy, "n");
            Compy.Run();

            var lastOutput = PrintOutput(Compy);

            return lastOutput;
        }

        private long PrintOutput(IntcodeComp Compy)
        {
            long lastOutput = 0;
            Console.WriteLine("** START **");
            while (Compy.Outputs.Any())
            {
                lastOutput = Compy.DequeueOutput();
                if (lastOutput == 10)
                {
                    Console.WriteLine();
                }
                else if (lastOutput <= 255)
                {
                    Console.Write((char)lastOutput);
                }
                else
                {
                    Console.Write(lastOutput);
                }
            }
            Console.WriteLine("** END **");
            return lastOutput;
        }

        private void AddCompyCommand(IntcodeComp Compy, string commands)
        {
            foreach (char c in commands.ToCharArray())
            {
                AddSingleCompyCommand(Compy, c);
            }
        }

        private void AddCompyCommandNL(IntcodeComp Compy, string commands)
        {
            AddCompyCommand(Compy, commands);
            AddSingleCompyCommand(Compy, (char)10);
        }

        private void AddSingleCompyCommand(IntcodeComp Compy, char command)
        {
            Console.Write(command);
            Compy.InjectInput(command);
        }

        private bool[,] GetGrid(string programInput)
        {
            var Compy = new IntcodeComp();
            Compy.Program = programInput;
            Compy.Initialize();
            Compy.Run();

            var grid = new bool[55, 55];
            int top = 0;
            int left = 0;

            while (Compy.Outputs.Any())
            {
                var out1 = Compy.DequeueOutput();
                if (out1 == 10)
                {
                    top++;
                    left = 0;
                    continue;
                }

                if ((char)out1 == '#')
                {
                    grid[left, top] = true;
                }
                left++;
            }

            return grid;
        }
    }
}
