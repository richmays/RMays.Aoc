using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day16 : DayBase<long>
    {
        public override long SolveA(string input)
        {
            return Solve(input);
        }

        public long Solve(string input, int offset = 0, bool isPartB = false)
        {
            var signal = input;

            //Console.WriteLine($"{0:000}: {signal}");
            int maxPhases = 100;
            for(int currPhase = 1; currPhase <= maxPhases; currPhase++)
            {
                var newSignal = new StringBuilder(input.Length + 5);

                if (offset > input.Length / 2)
                {
                    var newSignalString = new char[signal.Length];
                    for(int i = 0; i < signal.Length; i++)
                    {
                        newSignalString[i] = '0';
                    }
                    // Faster way: O(N)
                    byte sum = 0;
                    int currDigitId = signal.Length - 1;
                    while(currDigitId >= offset)
                    {
                        sum = (byte)((sum + signal[currDigitId] - '0') % 10);
                        newSignalString[currDigitId] = (char)(sum + '0');
                        currDigitId--;
                    }

                    newSignal = new StringBuilder(new string(newSignalString));
                }
                else
                {
                    // General
                    for (int currDigitId = 0; currDigitId < signal.Length; currDigitId++)
                    {
                        long sum = 0;
                        for (int tmpDigitId = currDigitId; tmpDigitId < signal.Length; tmpDigitId++)
                        {
                            if (tmpDigitId < currDigitId / 2)
                            {
                                sum += (signal[tmpDigitId] - '0');
                            }
                            else
                            {
                                var mod = pattern[(int)Math.Floor(((tmpDigitId + 1) / ((currDigitId + 1) * 1.0)) % 4)];
                                sum += ((signal[tmpDigitId] - '0') * mod);
                            }
                        }

                        newSignal.Append((char)((Math.Abs(sum) % 10) + '0'));
                    }
                }

                signal = newSignal.ToString();
                //Console.WriteLine($"{currPhase:000}: {signal}");
            }

            string result = "";
            for(int i = offset; i < offset+8; i++) // each (var elem in signal)
            {
                result += signal[i];
            }

            return long.Parse(result); // long.Parse(result.Substring(offset, offset + 8));
        }

        private List<int> pattern = new List<int> { 0, 1, 0, -1 };

        private int GetMod(int digit1, int digit2)
        {
            //if (digit2 > digit1) return 0;
            //if (digit2 == digit1) return 1;
            // Fluctuates between 0, 1, 0, -1, ...
            return pattern[(int)Math.Floor(((digit1 + 1) / ((digit2 + 1) * 1.0)) % 4)];
        }

        public new long SolveB(string input)
        {
            var offset = int.Parse(input.Substring(0, 7));
            var trueInput = new StringBuilder();
            for(int i = 0; i < 10000; i++)
            {
                trueInput.Append(input);
            }
            return Solve(trueInput.ToString(), offset, true);
        }
    }
}
