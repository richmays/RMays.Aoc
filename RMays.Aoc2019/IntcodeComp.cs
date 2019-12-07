using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class IntcodeComp
    {
        public string Program { get; set; }

        public IntcodeComp() { }

        public IntcodeComp(string program, string ampName = "")
        {
            this.Program = program;
            this.AmpName = ampName;
        }

        private string AmpName;
        private List<long> ProgramInput = new List<long>();
        private int CurrInputId = 0;
        private int CurrInstructionId = 0;
        private List<int> list; // the program that's running now; includes changed values.

        public void Initialize()
        {
            var myList = Parser.Tokenize(this.Program);
            list = new List<int>();
            foreach (var item in myList)
            {
                list.Add(int.Parse(item));
            }

            this.IsHalted = false;
            this.IsWaitingForInput = false;
            this.CurrInputId = 0;
            this.CurrInstructionId = 0;
        }

        public long Run(List<long> NewInputVals)
        {
            this.CurrInputId = 0;
            ProgramInput = new List<long>();
            foreach(var inputval in NewInputVals)
            {
                InjectInput(inputval);
            }
            return Run(0);
        }

        public long Run()
        {
            return Run(CurrInstructionId);
        }

        public long Run(int startingInstructionId = 0)
        {
            int currId = startingInstructionId;
            int outputVal = 0;
            while (currId >= 0 && currId < list.Count() && !IsHalted)
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
                            PrintDebug($"Add {firstVal} and {secondVal}, store in position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = firstVal + secondVal;
                            PrintLinePrefix(currId, 3);
                            PrintDebug($"Add {firstVal} and {secondVal}, store in position {currId + 3}.");
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
                            PrintDebug($"Multiply {firstVal} and {secondVal}, store in position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = firstVal * secondVal;
                            PrintLinePrefix(currId, 3);
                            PrintDebug($"Multiply {firstVal} and {secondVal}, store in position {currId + 3}.");
                        }
                        currId += 4;
                        break;
                    case "03": // read input (1)
                        if (CurrInputId >= ProgramInput.Count())
                        {
                            this.IsWaitingForInput = true;
                            PrintWarn($"{this.AmpName} is waiting for input.");
                            this.CurrInstructionId = currId;
                            return outputVal;
                        }

                        if (Param1Pos)
                        {
                            list[list[currId + 1]] = (int)ProgramInput[CurrInputId];
                            CurrInputId++;
                            PrintLinePrefix(currId, 1);
                            PrintDebug($"Read input ({list[list[currId + 1]]}), store in position {list[currId + 1]}.");
                        }
                        else
                        {
                            list[currId + 1] = (int)ProgramInput[CurrInputId];
                            CurrInputId++;
                            PrintLinePrefix(currId, 1);
                            PrintDebug($"Read input ({list[list[currId + 1]]}), store in position {currId + 1}.");
                        }
                        currId += 2;
                        break;
                    case "04": // write output (1)
                        if (Param1Pos)
                        {
                            outputVal = list[list[currId + 1]];
                            PrintLinePrefix(currId, 1);
                            PrintDebug($"Write value of position {list[currId + 1]} ({outputVal}).");
                        }
                        else
                        {
                            outputVal = list[currId + 1];
                            PrintLinePrefix(currId, 1);
                            PrintDebug($"Write value of position {currId + 1} ({outputVal}).");
                        }
                        PrintWarn($"OUTPUT ({this.AmpName}): " + outputVal);
                        currId += 2;
                        break;
                    case "05": // jump if true (2)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal != 0)
                        {
                            PrintLinePrefix(currId, 2);
                            PrintDebug($"Value {firstVal} is true (non-0).  Jump to instruction {secondVal}.");
                            currId = secondVal;
                        }
                        else
                        {
                            PrintLinePrefix(currId, 2);
                            PrintDebug($"Value {firstVal} is false (0).  Continue.");
                            currId += 3;
                        }
                        break;
                    case "06": // jump if false (2)
                        firstVal = (Param1Pos ? list[list[currId + 1]] : list[currId + 1]);
                        secondVal = (Param2Pos ? list[list[currId + 2]] : list[currId + 2]);
                        if (firstVal == 0)
                        {
                            PrintLinePrefix(currId, 2);
                            PrintDebug($"Value {firstVal} is false (0).  Jump to instruction {secondVal}.");
                            currId = secondVal;
                        }
                        else
                        {
                            PrintLinePrefix(currId, 2);
                            PrintDebug($"Value {firstVal} is true.  Continue.");
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
                            PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}less than {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                            PrintLinePrefix(currId, 2);
                            PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}less than {secondVal}.  Write {valToStore} to position {currId + 3}.");
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
                            PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}equal to {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");
                        }
                        else
                        {
                            list[currId + 3] = valToStore;
                            PrintLinePrefix(currId, 3);
                            PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}equal to {secondVal}.  Write {valToStore} to position {currId + 3}.");
                        }

                        currId += 4;
                        break;
                    case "99": // halt
                        PrintDebug("HALT; end (99)");
                        PrintLinePrefix(currId, 0);
                        PrintDebug($"Halt!");
                        IsHalted = true;
                        break;
                    default:
                        PrintDebug("HALT; bad instruction: " + list[currId]);
                        return -1;
                }
            }

            return outputVal;
        }

        public bool IsHalted { get; set; } = false;
        public bool IsWaitingForInput { get; set; } = false;
       
        public long Solve(string program, List<long> inputVals)
        {
            this.Program = program;
            this.Initialize();
            return Run(inputVals);
        }

        private void PrintDebug(string debugLine)
        {
            //Console.WriteLine(debugLine);
        }

        private void PrintWarn(string debugLine)
        {
            //Console.WriteLine(debugLine);
        }

        private void PrintLinePrefix(int instructionId, int paramsToPrint)
        {
            /*
            Console.Write($"[{instructionId}");
            for (int i = 1; i <= paramsToPrint; i++)
            {
                Console.Write($",{instructionId + i}");
            }
            Console.Write($"] ");
            */
        }

        public void InjectInput(long newInput)
        {
            ProgramInput.Add(newInput);
            PrintWarn($"Injecting Input ({this.AmpName}): {newInput}");
            IsWaitingForInput = false;
        }

        
    }
}

