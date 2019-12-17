using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day5 : DayBase<long>
    {
        public override long SolveA(string program)
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
                    case "01": // add (3)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = firstVal + secondVal;
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Add {firstVal} and {secondVal}, store in position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = firstVal + secondVal;
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Add {firstVal} and {secondVal}, store in position {currId + 3}.");
                        }
                        currId += 4;
                        break;
                    case "02": // mult (3)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (Param3Pos)
                        {
                            list[list[currId + 3]] = firstVal * secondVal;
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Multiply {firstVal} and {secondVal}, store in position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = firstVal * secondVal;
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Multiply {firstVal} and {secondVal}, store in position {currId + 3}.");
                        }
                        currId += 4;
                        break;
                    case "03": // read input (1)
                        if (Param1Pos)
                        {
                            list[list[currId + 1]] = inputVal;
                            PrintLinePrefix(currId, 1);
                            Console.WriteLine($"Read input ({inputVal}), store in position {list[currId + 1]}.");
                        }
                        else
                        {
                            list[currId + 1] = inputVal;
                            PrintLinePrefix(currId, 1);
                            Console.WriteLine($"Read input ({inputVal}), store in position {currId + 1}.");
                        }
                        currId += 2;
                        break;
                    case "04": // write output (1)
                        if (Param1Pos)
                        {
                            outputVal = list[list[currId + 1]];
                            PrintLinePrefix(currId, 1);
                            Console.WriteLine($"Write value of position {list[currId + 1]} ({outputVal}).");
                        }
                        else
                        {
                            outputVal = list[currId + 1];
                            PrintLinePrefix(currId, 1);
                            Console.WriteLine($"Write value of position {currId + 1} ({outputVal}).");
                        }
                        Console.WriteLine("OUTPUT: " + outputVal);
                        currId += 2;
                        break;
                    case "05": // jump if true (2)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal != 0)
                        {
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is true (non-0).  Jump to instruction {secondVal}.");
                            currId = secondVal;
                        }
                        else
                        {
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is false (0).  Continue.");
                            currId += 3;
                        }
                        break;
                    case "06": // jump if false (2)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal == 0)
                        {
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is false (0).  Jump to instruction {secondVal}.");
                            currId = secondVal;
                        }
                        else
                        {
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is true.  Continue.");
                            currId += 3;
                        }
                        break;
                    case "07": // less than (3)
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
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}less than {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                            PrintLinePrefix(currId, 2);
                            Console.WriteLine($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}less than {secondVal}.  Write {valToStore} to position {currId + 3}.");
                        }

                        currId += 4;
                        break;
                    case "08": // equals (3)
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
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}equal to {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                            PrintLinePrefix(currId, 3);
                            Console.WriteLine($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}equal to {secondVal}.  Write {valToStore} to position {currId + 3}.");
                        }

                        currId += 4;
                        break;
                    case "99": // halt
                        Console.WriteLine("HALT; end (99)");
                        PrintLinePrefix(currId, 0);
                        Console.WriteLine($"Halt!");
                        break;
                    default:
                        Console.WriteLine("HALT; bad instruction: " + list[currId]);
                        return -1;
                }
            }

            return outputVal;
        }

        private void PrintLinePrefix(int instructionId, int paramsToPrint)
        {
            Console.Write($"[{instructionId}");
            for(int i = 1; i <= paramsToPrint; i++)
            {
                Console.Write($",{instructionId + i}");
            }
            Console.Write($"] ");
        }

        public override long SolveB(string program)
        {
            return Solve(program, 5);
        }
    }
}
