using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day14
    {
        public string SolveA(int input)
        {
            var scores = new List<int>() { 3, 7 };
            int elf1pos = 0;
            int elf2pos = 1;
            while(scores.Count() < input + 12)
            {
                int sum = scores[elf1pos] + scores[elf2pos];
                if (sum >= 10)
                {
                    scores.Add(sum / 10);
                    scores.Add(sum % 10);
                }
                else
                {
                    scores.Add(sum);
                }
                elf1pos = elf1pos + scores[elf1pos] + 1;
                elf2pos = elf2pos + scores[elf2pos] + 1;
                while (elf1pos >= scores.Count()) elf1pos -= scores.Count();
                while (elf2pos >= scores.Count()) elf2pos -= scores.Count();
                //Console.WriteLine($"Elf1: {elf1pos}, elf2: {elf2pos}");
            }

            string toReturn = "";
            for(int pos = input; pos < input + 10; pos++)
            {
                toReturn += scores[pos].ToString();
            }

            return toReturn;
        }

        public int SolveB(string textToFind)
        {
            var scores = new List<byte>() { 3, 7 };
            int elf1pos = 0;
            int elf2pos = 1;
            int ceiling = 10;
            while (true)
            {
                while (scores.Count() < ceiling)
                {
                    byte sum = (byte)(scores[elf1pos] + scores[elf2pos]);
                    if (sum >= 10)
                    {
                        scores.Add((byte)(sum / 10));
                        scores.Add((byte)(sum % 10));
                    }
                    else
                    {
                        scores.Add(sum);
                    }
                    elf1pos = elf1pos + scores[elf1pos] + 1;
                    elf2pos = elf2pos + scores[elf2pos] + 1;
                    while (elf1pos >= scores.Count()) elf1pos -= scores.Count();
                    while (elf2pos >= scores.Count()) elf2pos -= scores.Count();
                    //Console.WriteLine($"Elf1: {elf1pos}, elf2: {elf2pos}");
                }

                // Traverse; hopefully we find it.
                int pos = 0;
                int matchPos = 0;
                while (pos < scores.Count())
                {
                    if ((char)(scores[pos] + '0') == textToFind[matchPos])
                    {
                        matchPos++;
                        if (matchPos >= textToFind.Length)
                        {
                            return pos - textToFind.Length + 1;
                        }
                    }
                    else
                    {
                        if (matchPos > 0)
                        {
                            matchPos = 0;
                            pos--;
                        }
                    }
                    pos++;
                }

                // We haven't found it yet.  Let's bump up the ceiling and try some more.
                ceiling = ceiling * 2;
            }
        }
    }
}
