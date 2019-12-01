using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day16
    {
        public enum OpCode
        {
            Unknown = -1,
            bani = 0,
            gtri = 1,
            seti = 2,
            eqir = 3,
            eqrr = 4,
            borr = 5,
            bori = 6,
            banr = 7,
            muli = 8,
            eqri = 9,
            mulr = 10,
            gtrr = 11,
            setr = 12,
            addr = 13,
            gtir = 14,
            addi = 15
        }

        public class Command
        {
            public OpCode CommandOpCode { get; set; }
            public int InputA { get; set; }
            public int InputB { get; set; }
            public int Output { get; set; }
        }

        public class Register
        {
            public Register()
            {
                Memory = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    Memory.Add(0);
                }
            }

            public Register(List<int> init)
            {
                Memory = new List<int>();
                foreach (var i in init)
                {
                    Memory.Add(i);
                }
            }

            public List<int> Memory { get; private set; }
            public void RunCommand(Command command)
            {
                switch(command.CommandOpCode)
                {
                    case OpCode.addr:
                        Memory[command.Output] = Memory[command.InputA] + Memory[command.InputB];
                        break;
                    case OpCode.addi:
                        Memory[command.Output] = Memory[command.InputA] + command.InputB;
                        break;
                    case OpCode.mulr:
                        Memory[command.Output] = Memory[command.InputA] * Memory[command.InputB];
                        break;
                    case OpCode.muli:
                        Memory[command.Output] = Memory[command.InputA] * command.InputB;
                        break;
                    case OpCode.banr:
                        Memory[command.Output] = Memory[command.InputA] & Memory[command.InputB];
                        break;
                    case OpCode.bani:
                        Memory[command.Output] = Memory[command.InputA] & command.InputB;
                        break;
                    case OpCode.borr:
                        Memory[command.Output] = Memory[command.InputA] | Memory[command.InputB];
                        break;
                    case OpCode.bori:
                        Memory[command.Output] = Memory[command.InputA] | command.InputB;
                        break;
                    case OpCode.setr:
                        Memory[command.Output] = Memory[command.InputA];
                        break;
                    case OpCode.seti:
                        Memory[command.Output] = command.InputA;
                        break;
                    case OpCode.gtir:
                        Memory[command.Output] = (command.InputA > Memory[command.InputB] ? 1 : 0);
                        break;
                    case OpCode.gtri:
                        Memory[command.Output] = (Memory[command.InputA] > command.InputB ? 1 : 0);
                        break;
                    case OpCode.gtrr:
                        Memory[command.Output] = (Memory[command.InputA] > Memory[command.InputB] ? 1 : 0);
                        break;
                    case OpCode.eqir:
                        Memory[command.Output] = (command.InputA == Memory[command.InputB] ? 1 : 0);
                        break;
                    case OpCode.eqri:
                        Memory[command.Output] = (Memory[command.InputA] == command.InputB ? 1 : 0);
                        break;
                    case OpCode.eqrr:
                        Memory[command.Output] = (Memory[command.InputA] == Memory[command.InputB] ? 1 : 0);
                        break;
                    default:
                        throw new ApplicationException($"Unexpected opcode: {command.CommandOpCode}");
                }
            }
        }

        public long SolveA(string input)
        {
            int matchesMoreThan3 = 0;
            List<OpCode> skipMe = new List<OpCode> {
                OpCode.bani, OpCode.borr, OpCode.bori, OpCode.muli,
                OpCode.mulr, OpCode.addi, OpCode.seti, OpCode.banr,
                OpCode.addr, OpCode.gtir, OpCode.eqri, OpCode.setr
            };

            for (var opCodeToCheck = (OpCode)0; opCodeToCheck < (OpCode)16; opCodeToCheck++)
            {
                if (skipMe.Contains(opCodeToCheck)) continue;

                matchesMoreThan3 = 0;
                // sample:
                //   Before: [3, 2, 1, 1]
                //   9 2 1 2
                //   After:  [3, 2, 2, 1]

                var lines = Parser.TokenizeLines(input);

                int currLine = 0;

                List<OpCode> possibleOpCodes = new List<OpCode>();
                for (OpCode opCode = 0; opCode < (OpCode)16; opCode++)
                {
                    if (!skipMe.Contains(opCode))
                    {
                        possibleOpCodes.Add(opCode);
                    }
                }
                //possibleOpCodes.Remove(OpCode.bani);


                while (currLine + 1 <= lines.Count)
                {
                    var line1 = lines[currLine].Substring(9).Split(']', ',', ' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();
                    var line2 = lines[currLine + 1].Split(' ').Select(x => int.Parse(x)).ToList();
                    var line3 = lines[currLine + 2].Substring(9).Split(']', ',', ' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();

                    var before = new List<int> { line1[0], line1[1], line1[2], line1[3] };
                    var command = new List<int> { line2[0], line2[1], line2[2], line2[3] };
                    var after = new List<int> { line3[0], line3[1], line3[2], line3[3] };

                    var matches = GetPossibleMatchesFromCommand(before, command, after);

                    if (matches.Count >= 3) matchesMoreThan3++;

                    if (command[0] == (int)opCodeToCheck)
                    {
                        var opCodesToRemove = new List<OpCode>();
                        foreach (var opCode in possibleOpCodes)
                        {
                            if (!matches.Contains(opCode) && !opCodesToRemove.Contains(opCode))
                            {
                                opCodesToRemove.Add(opCode);
                            }
                        }
                        foreach (var opCode in opCodesToRemove)
                        {
                            possibleOpCodes.Remove(opCode);
                        }
                    }

                    currLine += 3;
                }

                Console.Write($"code ID {(int)opCodeToCheck}: ");
                foreach (var opCode in possibleOpCodes)
                {
                    Console.Write($"{opCode} ");
                }
                Console.WriteLine();
            }
            return matchesMoreThan3;
        }

        public List<OpCode> GetPossibleMatchesFromCommand(List<int> before, List<int> command, List<int> after)
        {
            var matchingOpCodes = new List<OpCode>();
            var myCommand = new Command { CommandOpCode = OpCode.Unknown, InputA = command[1], InputB = command[2], Output = command[3] };
            for (var opCode = (OpCode)0; opCode < (OpCode)16; opCode++)
            {
                myCommand.CommandOpCode = opCode;
                var register = new Register(before);
                register.RunCommand(myCommand);

                var allMatch = true;
                for (int i = 0; i < 4; i++)
                {
                    if (register.Memory[i] != after[i])
                    {
                        allMatch = false;
                    }
                }
                if (allMatch) matchingOpCodes.Add(opCode);
            }

            return matchingOpCodes;
        }

        public long SolveB(string input)
        {
            // Sample: 
            var lines = Parser.TokenizeLines(input);
            var register = new Register();
            foreach (var line in lines)
            {
                var line2 = line.Split(' ').Select(x => int.Parse(x)).ToList();
                var command = new List<int> { line2[0], line2[1], line2[2], line2[3] };
                var myCommand = new Command { CommandOpCode = (OpCode)command[0], InputA = command[1], InputB = command[2], Output = command[3] };
                register.RunCommand(myCommand);
            }

            return register.Memory[0];
        }
    }
}
