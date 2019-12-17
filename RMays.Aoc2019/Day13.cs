using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day13 : DayBase<long>
    {
        public long SolveA(string input)
        {
            return Solve(input);
        }

        public long Solve(string input, bool isPartB = false)
        {
            int cols = 44;
            int rows = 24;
            var grid = new Tile[cols,rows];
            for(int c = 0; c < cols; c++)
            {
                for(int r = 0; r < rows; r++)
                {
                    grid[c, r] = Tile.Empty;
                }
            }

            var myList = Parser.Tokenize(input);
            var Compy = new IntcodeComp(input);
            Compy.Initialize();
            if (isPartB)
            {
                Compy.SetAddress(0, 2);
            }
            Compy.Run();

            int count = 0;
            long maxRow = 0;
            long maxCol = 0;
            long CurrentScore = 0;

            //Compy.InjectInput(0);

            while (true)
            {
                long BallCol = -1;
                long PaddleCol = -1;
                //Console.Clear();

                while (Compy.Outputs.Any())
                {

                    var output1 = Compy.DequeueOutput();
                    var output2 = Compy.DequeueOutput();
                    var output3 = Compy.DequeueOutput();

                    if (output1 == -1 && output2 == 0)
                    {
                        CurrentScore = output3;
                        //Console.WriteLine("Current Score: " + CurrentScore);
                        continue;
                    }

                    grid[output1, output2] = (Tile)output3;
                    if (output3 == (long)Tile.Ball)
                    {
                        BallCol = output1;
                    }
                    if (output3 == (long)Tile.HorizontalPaddle)
                    {
                        PaddleCol = output1;
                    }

                    // Junk
                    if (output1 > maxCol) maxCol = output1;
                    if (output2 > maxRow) maxRow = output2;
                    if (output3 == 2) count++;

                }

                if (Compy.IsHalted) return CurrentScore;

                Compy.InjectInput(BallCol == PaddleCol ? 0 : BallCol > PaddleCol ? 1 : -1);
                Compy.Run();
            }

            PrintGrid(grid);

            if (!isPartB) return count;

            /*
            foreach(var result in Compy.Outputs)
            {
                Console.WriteLine(result);
            }
            */

            return 123;
        }

        public void PrintGrid(Tile[,] grid)
        {
            Console.WriteLine("Grid:");
            for (int r = 0; r < grid.GetLongLength(1); r++)
            {
                for (int c = 0; c < grid.GetLongLength(0); c++)
                {
                    switch(grid[c, r])
                    {
                        case Tile.Empty:
                            Print(' ');
                            break;
                        case Tile.Wall:
                            Print('W');
                            break;
                        case Tile.Block:
                            Print('B');
                            break;
                        case Tile.HorizontalPaddle:
                            Print('=');
                            break;
                        case Tile.Ball:
                            Print('o');
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void Print(char c)
        {
            Console.Write(c);
        }

        public long SolveB(string input)
        {
            return Solve(input, true);
        }
    }

    public enum Tile
    {
        Empty = 0,
        Wall = 1,
        Block = 2,
        HorizontalPaddle = 3,
        Ball = 4
    }
}
