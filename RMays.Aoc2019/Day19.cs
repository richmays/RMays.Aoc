using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    #region Day 19
    /*
--- Day 19: Tractor Beam ---
Unsure of the state of Santa's ship, you borrowed the tractor beam technology from Triton. Time to test it out.

When you're safely away from anything else, you activate the tractor beam, but nothing happens. It's hard to tell whether it's working
if there's nothing to use it on. Fortunately, your ship's drone system can be configured to deploy a drone to specific coordinates and
then check whether it's being pulled. There's even an Intcode program (your puzzle input) that gives you access to the drone system.

The program uses two input instructions to request the X and Y position to which the drone should be deployed. Negative numbers are
invalid and will confuse the drone; all numbers should be zero or positive.

Then, the program will output whether the drone is stationary (0) or being pulled by something (1). For example, the coordinate X=0, Y=0
is directly in front of the tractor beam emitter, so the drone control program will always report 1 at that location.

To better understand the tractor beam, it is important to get a good picture of the beam itself. For example, suppose you scan the 10x10
grid of points closest to the emitter:

       X
  0->      9
 0#.........
 |.#........
 v..##......
  ...###....
  ....###...
Y .....####.
  ......####
  ......####
  .......###
 9........##
In this example, the number of points affected by the tractor beam in the 10x10 area closest to the emitter is 27.

However, you'll need to scan a larger area to understand the shape of the beam. How many points are affected by the tractor beam in the
50x50 area closest to the emitter? (For each of X and Y, this will be 0 through 49.)

 
         --- Part Two ---
You aren't sure how large Santa's ship is. You aren't even sure if you'll need to use this thing on Santa's ship, but it doesn't hurt
to be prepared. You figure Santa's ship might fit in a 100x100 square.

The beam gets wider as it travels away from the emitter; you'll need to be a minimum distance away to fit a square of that size into
the beam fully. (Don't rotate the square; it should be aligned to the same axes as the drone grid.)

For example, suppose you have the following tractor beam readings:

#.......................................
.#......................................
..##....................................
...###..................................
....###.................................
.....####...............................
......#####.............................
......######............................
.......#######..........................
........########........................
.........#########......................
..........#########.....................
...........##########...................
...........############.................
............############................
.............#############..............
..............##############............
...............###############..........
................###############.........
................#################.......
.................########OOOOOOOOOO.....
..................#######OOOOOOOOOO#....
...................######OOOOOOOOOO###..
....................#####OOOOOOOOOO#####
.....................####OOOOOOOOOO#####
.....................####OOOOOOOOOO#####
......................###OOOOOOOOOO#####
.......................##OOOOOOOOOO#####
........................#OOOOOOOOOO#####
.........................OOOOOOOOOO#####
..........................##############
..........................##############
...........................#############
............................############
.............................###########
In this example, the 10x10 square closest to the emitter that fits entirely within the tractor beam has been marked O. Within it, the
point closest to the emitter (the only highlighted O) is at X=25, Y=20.

Find the 100x100 square closest to the emitter that fits entirely within the tractor beam; within that square, find the point closest
to the emitter. What value do you get if you take that point's X coordinate, multiply it by 10000, then add the point's Y coordinate?
(In the example above, this would be 250020.)
         
*/
    #endregion
    public class Day19 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            if (!IsPartB)
            {
                return SolveA(input);
            }

            return SolveB(input, 100);
        }

        public long SolveA(string program)
        {
            var count = 0;
            for (int c = 0; c < 50; c++)
            {
                for (int r = 0; r < 50; r++)
                {
                    var result = GetSpotInfo(program, c, r);
                    if (result == 1) count++;
                    if (c == 30 && r == 34)
                    {
                        if (result == 1)
                        {
                            Console.Write("!");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    else
                    {
                        Console.Write(result);
                    }
                }
                Console.WriteLine();
            }

            return count;
        }

        public long SolveB(string program, int size)
        {
            // General case (because I'm not pressed for time).
            // Find the first '1', where there's no other '1' above or to the left.
            int maxCR = 0;
            int c = 1;
            int r = 1;
            bool found = false;
            while (!found)
            {
                maxCR++;
                for (c = 0; c < maxCR; c++)
                {
                    r = maxCR;
                    if (GetSpotInfo(program, c, r) == 1)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) break;

                for (r = 0; r < maxCR; r++)
                {
                    c = maxCR;
                    if (GetSpotInfo(program, c, r) == 1)
                    {
                        found = true;
                        break;
                    }
                }
            }

            int startC = c;
            int startR = r;
            int MaxRowCol = 2000;

            int tmpSize = size;


            // For fun, let's print all spots that are TRUE, but are FALSE to the left and down.
            //Console.WriteLine("Lower-left bound:");
            c = startC;
            r = startR;
            while (r <= MaxRowCol && c <= MaxRowCol)
            {
                // NOW, actually check if we can fit a box here.
                if (GetSpotInfo(program, c + (tmpSize - 1), r - (tmpSize - 1)) == 1)
                {
                    return 10000 * c + (r - (tmpSize - 1));
                    /*
                    Console.WriteLine($"Size {tmpSize}: {c},{r} ({10000 * c + (r - (tmpSize - 1))}");
                    tmpSize++;
                    */
                }

                if (GetSpotInfo(program, c, r + 1) == 1)
                {
                    r++;
                }
                else if (GetSpotInfo(program, c + 1, r) == 1)
                {
                    c++;
                }
                else
                {
                    r++;
                    c++;
                }

                if (GetSpotInfo(program, c - 1, r) == 0 && GetSpotInfo(program, c, r + 1) == 0)
                {
                    //Console.WriteLine($"{c}, {r}");
                }
            }

            return -1;

            Console.WriteLine("Upper-right bound:");
            c = startC;
            r = startR;
            while (r <= MaxRowCol && c <= MaxRowCol)
            {
                if (GetSpotInfo(program, c + 1, r) == 1)
                {
                    c++;
                }
                else if (GetSpotInfo(program, c, r + 1) == 1)
                {
                    r++;
                }
                else
                {
                    r++;
                    c++;
                }

                if (GetSpotInfo(program, c, r - 1) == 0 && GetSpotInfo(program, c + 1, r) == 0)
                {
                    Console.WriteLine($"{c}, {r}");
                }
            }

            // .. This is hard.  Let's get the line.

            return c * 10000 + r;

        }

        private HashSet<string> Truthy = new HashSet<string>();
        private HashSet<string> Falsy = new HashSet<string>();

        private long GetSpotInfo(string program, int c, int r)
        {
            string key = $"{c},{r}";
            if (Truthy.Contains(key))
            {
                return 1;
            }
            if (Falsy.Contains(key))
            {
                return 0;
            }

            if (c < 0 || r < 0) return 0;
            var Compy = new IntcodeComp();
            Compy.Program = program;
            Compy.Initialize();
            Compy.InjectInput(c);
            Compy.InjectInput(r);
            Compy.Run();

            var result = Compy.DequeueOutput();
            if (result == 1)
            {
                Truthy.Add(key);
            }
            else if (result == 0)
            {
                Falsy.Add(key);
            }
            else
            {
                throw new ApplicationException("Got an unexpected value back from the compy: " + result);
            }
            return result;
        }
    }
}
