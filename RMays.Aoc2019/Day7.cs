using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day7 : DayBase<long>
    {
        public Day7() { }

        public long SolveA(string input)
        {
            long maxValue = 0;
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    if (a == b) continue;
                    for (int c = 0; c < 5; c++)
                    {
                        if (a == c || b == c) continue;
                        for (int d = 0; d < 5; d++)
                        {
                            if (a == d || b == d || c == d) continue;
                            for (int e = 0; e < 5; e++)
                            {
                                if (a == e || b == e || c == e || d == e) continue;
                                var comp1 = new IntcodeComp(input);
                                comp1.Initialize();
                                var output1 = comp1.Run(new List<long>() { a, 0 });
                                comp1.Initialize();
                                var output2 = comp1.Run(new List<long>() { b, output1 });
                                comp1.Initialize();
                                var output3 = comp1.Run(new List<long>() { c, output2 });
                                comp1.Initialize();
                                var output4 = comp1.Run(new List<long>() { d, output3 });
                                comp1.Initialize();
                                var output5 = comp1.Run(new List<long>() { e, output4 });
                                if (output5 > maxValue) maxValue = output5;
                            }
                        }
                    }
                }
            }

            return maxValue;
        }

        public long SolveB(string program)
        {
            long maxValue = 0;
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    if (a == b) continue;
                    for (int c = 0; c < 5; c++)
                    {
                        if (a == c || b == c) continue;
                        for (int d = 0; d < 5; d++)
                        {
                            if (a == d || b == d || c == d) continue;
                            for (int e = 0; e < 5; e++)
                            {
                                if (a == e || b == e || c == e || d == e) continue;

                                var AmpIds = new List<int> { a, b, c, d, e };
                                var result = GetCountForSignals(program, AmpIds);
                                /*
                                var comp1 = new Day7();
                                var output1 = comp1.Solve(input, new List<int>() { a, 0 });
                                var output2 = comp1.Solve(input, new List<int>() { b, (int)output1 });
                                var output3 = comp1.Solve(input, new List<int>() { c, (int)output2 });
                                var output4 = comp1.Solve(input, new List<int>() { d, (int)output3 });
                                var output5 = comp1.Solve(input, new List<int>() { e, (int)output4 });
                                */
                                if (result > maxValue) maxValue = result;
                            }
                        }
                    }
                }
            }

            return maxValue;
        }

        private long GetCountForSignals(string program, List<int> AmpIds)
        {
            var amp1 = new IntcodeComp(program, $"Amp1 ({AmpIds[0] + 5})");
            amp1.Initialize();
            var amp2 = new IntcodeComp(program, $"Amp2 ({AmpIds[1] + 5})");
            amp2.Initialize();
            var amp3 = new IntcodeComp(program, $"Amp3 ({AmpIds[2] + 5})");
            amp3.Initialize();
            var amp4 = new IntcodeComp(program, $"Amp4 ({AmpIds[3] + 5})");
            amp4.Initialize();
            var amp5 = new IntcodeComp(program, $"Amp5 ({AmpIds[4] + 5})");
            amp5.Initialize();

            amp1.InjectInput(AmpIds[0] + 5);
            amp2.InjectInput(AmpIds[1] + 5);
            amp3.InjectInput(AmpIds[2] + 5);
            amp4.InjectInput(AmpIds[3] + 5);
            amp5.InjectInput(AmpIds[4] + 5);

            amp1.InjectInput(0);

            int breakout = 0;
            while (true)
            {
                var output1 = amp1.Run();

                amp2.InjectInput(output1);
                var output2 = amp2.Run();

                amp3.InjectInput(output2);
                var output3 = amp3.Run();

                amp4.InjectInput(output3);
                var output4 = amp4.Run();

                amp5.InjectInput(output4);
                var output5 = amp5.Run();

                if (amp5.IsHalted)
                {
                    return output5;
                }
                else
                {
                    /*
                    amp1.InjectInput(AmpIds[0] + 5);
                    amp2.InjectInput(AmpIds[1] + 5);
                    amp3.InjectInput(AmpIds[2] + 5);
                    amp4.InjectInput(AmpIds[3] + 5);
                    amp5.InjectInput(AmpIds[4] + 5);
                    */
                    amp1.InjectInput(output5);
                }

                breakout++;
            }

            // bad times!
            return -1;
        }
    }
}
