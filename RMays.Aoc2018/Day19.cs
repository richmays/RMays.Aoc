using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day19
    {
        public class Register
        {
            public enum OpCode
            {
                Unknown,
                addr,
                addi,
                mulr,
                muli,
                banr,
                bani,
                borr,
                bori,
                setr,
                seti,
                gtir,
                gtri,
                gtrr,
                eqir,
                eqri,
                eqrr
            }

            public long[] Memory { get; set; }

            public class Instruction
            {
                public OpCode Code { get; set; }
                public long Num1 { get; set; }
                public long Num2 { get; set; }
                public long Num3 { get; set; }

                public override string ToString()
                {
                    return $"{Code.ToString()} {Num1} {Num2} {Num3}";
                }
            }
                
            protected long InstructionPtr { get; set; }
            protected List<Instruction> Instructions { get; set; }

            public Register()
            {
                Memory = new long[6];
                for (int i = 0; i < 6; i++)
                {
                    Memory[i] = 0;
                }
            }

            public Register(string input) : this()
            {
                this.Initialize(input);
            }

            public void SetMemory(long memoryId, long value)
            {
                Memory[memoryId] = value;
            }

            public long GetMemory(long memoryId)
            {
                return Memory[memoryId];
            }

            public void Initialize(string input)
            {
                // example input:

                //   #ip 0
                //   seti 5 0 1
                //   seti 6 0 2 
                var lines = Parser.TokenizeLines(input);
                InstructionPtr = long.Parse(lines[0].Split(' ')[1]);

                Instructions = new List<Instruction>();
                for (var lineId = 1; lineId < lines.Count; lineId++)
                {
                    var lineSplit = lines[lineId].Split(' ');

                    // Bad performance, but we're only doing this once per line.
                    var newOpCode = OpCode.Unknown;
                    if (!Enum.TryParse(lineSplit[0], out newOpCode))
                    {
                        throw new ApplicationException($"Failed to parse: {lineSplit[0]}");
                    }

                    var newInstruction = new Instruction
                    {
                        Code = newOpCode,
                        Num1 = long.Parse(lineSplit[1]),
                        Num2 = long.Parse(lineSplit[2]),
                        Num3 = long.Parse(lineSplit[3])
                    };
                    Instructions.Add(newInstruction);
                }
            }

            public long MinValue_Day21 { get; set; }
            public long MaxValue_Day21 { get; set; }

            public void Go(bool day21 = false, bool day21OnlyMinValue = false)
            {
                //var found = new List<long>();
                var bigArray = new bool[16777216];
                long prevStep1 = 0;
                long prevStep2 = 0;
                //var UniqueStates = new HashSet<string>();
                while (Memory[InstructionPtr] >= 0 && Memory[InstructionPtr] < Instructions.Count)
                {
                    if (day21)
                    {
                        if ((int)Memory[InstructionPtr] == 28)
                        {
                            var mem = GetMemory(5);
                            if (MinValue_Day21 == 0)
                            {
                                MinValue_Day21 = mem;
                                if (day21OnlyMinValue)
                                {
                                    return;
                                }
                            }
                            prevStep1 = prevStep2;
                            prevStep2 = mem;
                            if (bigArray[mem])
                            {
                                MaxValue_Day21 = prevStep1;
                                return;
                            }
                            bigArray[mem] = true;
                        }
                    }

                    var currInstruction = Instructions[(int)Memory[InstructionPtr]];

                    switch (currInstruction.Code)
                    {
                        case OpCode.addr:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] + Memory[currInstruction.Num2];
                            break;
                        case OpCode.addi:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] + currInstruction.Num2;
                            break;
                        case OpCode.mulr:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] * Memory[currInstruction.Num2];
                            break;
                        case OpCode.muli:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] * currInstruction.Num2;
                            break;
                        case OpCode.banr:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] & Memory[currInstruction.Num2];
                            break;
                        case OpCode.bani:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] & currInstruction.Num2;
                            break;
                        case OpCode.borr:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] | Memory[currInstruction.Num2];
                            break;
                        case OpCode.bori:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1] | currInstruction.Num2;
                            break;
                        case OpCode.setr:
                            Memory[currInstruction.Num3] = Memory[currInstruction.Num1];
                            break;
                        case OpCode.seti:
                            Memory[currInstruction.Num3] = currInstruction.Num1;
                            break;
                        case OpCode.gtir:
                            Memory[currInstruction.Num3] = (currInstruction.Num1 > Memory[currInstruction.Num2] ? 1 : 0);
                            break;
                        case OpCode.gtri:
                            Memory[currInstruction.Num3] = (Memory[currInstruction.Num1] > currInstruction.Num2 ? 1 : 0);
                            break;
                        case OpCode.gtrr:
                            Memory[currInstruction.Num3] = (Memory[currInstruction.Num1] > Memory[currInstruction.Num2] ? 1 : 0);
                            break;
                        case OpCode.eqir:
                            Memory[currInstruction.Num3] = (currInstruction.Num1 == Memory[currInstruction.Num2] ? 1 : 0);
                            break;
                        case OpCode.eqri:
                            Memory[currInstruction.Num3] = (Memory[currInstruction.Num1] == currInstruction.Num2 ? 1 : 0);
                            break;
                        case OpCode.eqrr:
                            Memory[currInstruction.Num3] = (Memory[currInstruction.Num1] == Memory[currInstruction.Num2] ? 1 : 0);
                            break;
                    }

                    Memory[InstructionPtr]++;

                    /*
                    if (UniqueStates.Contains(this.ToString()))
                    {
                        throw new ApplicationException("Infinite loop detected; repeated states.");
                    }
                    UniqueStates.Add(this.ToString());
                    */
                }
            }

            public override string ToString()
            {
                return $"[{Memory[0]} ,{Memory[1]} ,{Memory[2]}, {Memory[3]}, {Memory[4]}, {Memory[5]}]";
            }
        }

        public long SolveA(string input)
        {
            var register = new Register(input);
            register.Go();

            return register.GetMemory(0);
        }

        public long SolveB(string input)
        {
            var register = new Register(input);
            register.SetMemory(0, 1);
            register.Go();

            return register.GetMemory(0);
        }
    }
}
