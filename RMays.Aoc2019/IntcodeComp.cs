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
        private List<long> list; // the program that's running now; includes changed values.
        public bool IsHalted { get; set; } = false;
        public bool IsWaitingForInput { get; set; } = false;

        public List<long> Outputs { get; set; }

        public int RelativeBase { get; set; }

        public void Initialize()
        {
            var myList = Parser.Tokenize(this.Program);
            list = new List<long>();
            foreach (var item in myList)
            {
                list.Add(long.Parse(item));
            }

            this.IsHalted = false;
            this.IsWaitingForInput = false;
            this.CurrInputId = 0;
            this.CurrInstructionId = 0;
            this.RelativeBase = 0;
            this.Outputs = new List<long>();
        }

        public void InjectInput(long newInput)
        {
            ProgramInput.Add(newInput);
            PrintWarn($"Injecting Input ({this.AmpName}): {newInput}");
            IsWaitingForInput = false;
        }

        public List<long> Run9()
        {
            var output = Run();
            return new List<long> { output };
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
            long outputVal = 0;
            while (currId >= 0 && currId < list.Count() && !IsHalted)
            {
                long firstVal;
                long secondVal;
                long valToStore = -1;

                string instruction = list[currId].ToString("00000");
                string OpCode = instruction.Substring(3, 2);

                // 0: Position
                // 1: Immediate
                // 2: Relative
                var Param1Mode = (ParameterMode)int.Parse($"{instruction[2]}");
                var Param2Mode = (ParameterMode)int.Parse($"{instruction[1]}");
                var Param3Mode = (ParameterMode)int.Parse($"{instruction[0]}");

                // 1 is Immediate mode, 0 is Position mode.  the first computer was all Position mode.

                switch (OpCode)
                {
                    case "01": // add (3)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);
                        SetListValue(GetParamAddress(currId, 3, Param3Mode), firstVal + secondVal);
                        //list[GetParamAddress(currId + 3, Param3Mode)] = firstVal + secondVal;
                        //PrintLinePrefix(currId, 3);
                        //PrintDebug($"Add {firstVal} and {secondVal}, store in position {GetParamAddress(currId + 3, Param3Mode)}.");
                        currId += 4;
                        break;
                    case "02": // mult (3)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);
                        SetListValue(GetParamAddress(currId, 3, Param3Mode), firstVal * secondVal);
                        //list[GetParamAddress(currId + 3, Param3Mode)] = firstVal * secondVal;
                        //PrintLinePrefix(currId, 3);
                        //PrintDebug($"Multiply {firstVal} and {secondVal}, store in position {list[currId + 3]}.");
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

                        list[GetParamAddress(currId, 1, Param1Mode)] = (int)ProgramInput[CurrInputId];
                        CurrInputId++;
                        //PrintLinePrefix(currId, 1);
                        //PrintDebug($"Read input ({list[(int)list[currId + 1]]}), store in position {list[currId + 1]}.");
                        currId += 2;
                        break;
                    case "04": // write output (1)
                        outputVal = GetParam(currId, 1, Param1Mode);
                        //PrintLinePrefix(currId, 1);
                        //PrintDebug($"Write value of position {list[currId + 1]} ({outputVal}).");
                        PrintWarn($"OUTPUT ({this.AmpName}): " + outputVal);
                        Outputs.Add(outputVal);
                        currId += 2;
                        break;
                    case "05": // jump if true (2)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);
                        if (firstVal != 0)
                        {
                            //PrintLinePrefix(currId, 2);
                            //PrintDebug($"Value {firstVal} is true (non-0).  Jump to instruction {secondVal}.");
                            currId = (int)secondVal;
                        }
                        else
                        {
                            //PrintLinePrefix(currId, 2);
                            //PrintDebug($"Value {firstVal} is false (0).  Continue.");
                            currId += 3;
                        }
                        break;
                    case "06": // jump if false (2)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);
                        if (firstVal == 0)
                        {
                            //PrintLinePrefix(currId, 2);
                            //PrintDebug($"Value {firstVal} is false (0).  Jump to instruction {secondVal}.");
                            currId = (int)secondVal;
                        }
                        else
                        {
                            //PrintLinePrefix(currId, 2);
                            //PrintDebug($"Value {firstVal} is true.  Continue.");
                            currId += 3;
                        }
                        break;
                    case "07": // less than (3)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);

                        if (firstVal < secondVal)
                        {
                            valToStore = 1;
                        }
                        else
                        {
                            valToStore = 0;
                        }

                        SetListValue(GetParamAddress(currId, 3, Param3Mode), valToStore);
                        //list[GetParamAddress(currId + 3, Param3Mode)] = valToStore;
                        //PrintLinePrefix(currId, 2);
                        //PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}less than {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");

                        currId += 4;
                        break;
                    case "08": // equals (3)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        secondVal = GetParam(currId, 2, Param2Mode);

                        if (firstVal == secondVal)
                        {
                            valToStore = 1;
                        }
                        else
                        {
                            valToStore = 0;
                        }

                        SetListValue(GetParamAddress(currId, 3, Param3Mode), valToStore);
                        //list[GetParamAddress(currId + 3, Param3Mode)] = valToStore;
                        //PrintLinePrefix(currId, 3);
                        //PrintDebug($"Value {firstVal} is {(valToStore == 0 ? "NOT " : "")}equal to {secondVal}.  Write {valToStore} to position {list[currId + 3]}.");

                        currId += 4;
                        break;
                    case "09": // set relative base (1)
                        firstVal = GetParam(currId, 1, Param1Mode);
                        RelativeBase += (int)firstVal;
                        currId += 2;
                        break;
                    case "99": // halt
                        PrintWarn("HALT; end (99)");
                        PrintLinePrefix(currId, 0);
                        PrintDebug($"Halt!");
                        IsHalted = true;
                        break;
                    default:
                        PrintWarn("HALT; bad instruction: " + list[currId]);
                        return -1;
                }
            }

            return outputVal;
        }

        private void SetListValue(int position, long valueToSet)
        {
            while(list.Count() <= position)
            {
                list.Add(0);
            }
            list[position] = valueToSet;
        }

        private long GetListValue(int position)
        {
            if (position >= list.Count()) return 0;
            return list[position];
        }

        private long GetParam(int currId, int offset, ParameterMode ParamMode)
        {
            return GetListValue(GetParamAddress(currId, offset, ParamMode));
        }

        private int GetParamAddress(int currId, int offset, ParameterMode ParamMode)
        {

            return ParamMode == ParameterMode.Position ? (int)GetListValue(currId + offset)
                : ParamMode == ParameterMode.Immediate ? currId + offset
                : ParamMode == ParameterMode.Relative ? RelativeBase + (int)GetListValue(currId + offset)
                : -123; // throw new InvalidOperationException("Invalid parameter mode");
        }

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
            Console.WriteLine(debugLine);
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
    }

    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1,
        Relative = 2
    }
}

