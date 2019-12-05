using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day5 : IDay<long>
    {
        public long SolveA(string program)
        {
            return Solve(program, 1);
        }

        public long Solve(string program, int inputVal)
        {
            var myList = Parser.Tokenize(program);
            var list = new List<int>();
            foreach (var item in myList)
            {
                list.Add(int.Parse(item));
            }

            int currId = 0;
            int outputVal = 0;
            while (currId >= 0 && currId < myList.Count() && list[currId] != 99)
            {
                int firstVal;
                int secondVal;
                int valToStore = -1;

                string instruction = list[currId].ToString("00000");
                string OpCode = instruction.Substring(3, 2);
                var Param1Pos = (instruction[2] == '0');
                var Param2Pos = (instruction[1] == '0');
                var Param3Pos = (instruction[0] == '0');

                // 1 is Immediate mode, 0 is Position mode.  the first computer was all Position mode.

                switch (OpCode)
                {
                    case "01": // add
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = firstVal + secondVal;
                        }
                        else
                        {
                            list[currId + 3] = firstVal + secondVal;
                        }
                        currId += 4;
                        break;
                    case "02": // mult
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = firstVal * secondVal;
                        }
                        else
                        {
                            list[currId + 3] = firstVal * secondVal;
                        }
                        currId += 4;
                        break;
                    case "03": // read input
                        if (Param1Pos)
                        {
                            list[list[currId + 1]] = inputVal;
                        }
                        else
                        {
                            list[currId + 1] = inputVal;
                        }
                        currId += 2;
                        break;
                    case "04": // write output
                        if (Param1Pos)
                        {
                            outputVal = list[list[currId + 1]];
                        }
                        else
                        {
                            outputVal = list[currId + 1];
                        }
                        Console.WriteLine("OUTPUT: " + outputVal);
                        currId += 2;
                        break;
                    case "05": // jump if true
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal != 0)
                        {
                            currId = secondVal;
                        }
                        else
                        {
                            currId += 3;
                        }
                        break;
                    case "06": // jump if false
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal == 0)
                        {
                            currId = secondVal;
                        }
                        else
                        {
                            currId += 3;
                        }
                        break;
                    case "07": // less than
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);

                        if (firstVal < secondVal)
                        {
                            valToStore = 1;
                        }
                        else
                        {
                            valToStore = 0;
                        }

                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = valToStore;
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                        }

                        currId += 4;
                        break;
                    case "08": // equals
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);

                        if (firstVal == secondVal)
                        {
                            valToStore = 1;
                        }
                        else
                        {
                            valToStore = 0;
                        }

                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = valToStore;
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                        }

                        currId += 4;
                        break;
                    case "99": // halt
                        Console.WriteLine("HALT; end (99)");
                        break;
                    default:
                        Console.WriteLine("HALT; bad instruction: " + list[currId]);
                        return -1;
                }
            }

            return outputVal;
        }

        public long SolveB(string program)
        {
            return Solve(program, 5);
        }
    }
}
