using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day2 : DayBase<long>
    {
        public override long SolveA(string input)
        {
            var myList = Parser.Tokenize(input);
            var list = new List<int>();
            foreach(var item in myList)
            {
                list.Add(int.Parse(item));
            }

            int currId = 0;
            while(currId >= 0 && currId < myList.Count() && list[currId] != 99)
            {
                int firstId;
                int secondId;
                switch(list[currId])
                {
                    case 1:
                        firstId = list[currId + 1];
                        secondId = list[currId + 2];
                        list[list[currId + 3]] = list[firstId] + list[secondId];
                        break;
                    case 2:
                        firstId = list[currId + 1];
                        secondId = list[currId + 2];
                        list[list[currId + 3]] = list[firstId] * list[secondId];
                        break;
                    default:
                        return -1;
                }
                currId += 4;
            }

            return list[0];
        }

        public long SolveWithNounVerb(string input, int noun, int verb)
        {
            var myList = Parser.Tokenize(input);
            var list = new List<int>();
            foreach (var item in myList)
            {
                list.Add(int.Parse(item));
            }

            list[1] = noun;
            list[2] = verb;

            int currId = 0;
            while (currId >= 0 && currId < myList.Count() && list[currId] != 99)
            {
                int firstId;
                int secondId;
                switch (list[currId])
                {
                    case 1:
                        firstId = list[currId + 1];
                        secondId = list[currId + 2];
                        list[list[currId + 3]] = list[firstId] + list[secondId];
                        break;
                    case 2:
                        firstId = list[currId + 1];
                        secondId = list[currId + 2];
                        list[list[currId + 3]] = list[firstId] * list[secondId];
                        break;
                    default:
                        return -1;
                }
                currId += 4;
            }

            return list[0];
        }

        public override long SolveB(string input)
        {
            for(int noun = 0; noun < 100; noun++)
            {
                for(int verb = 0; verb < 100; verb++)
                {
                    var result = SolveWithNounVerb(input, noun, verb);
                    if (result == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }
    }
}
