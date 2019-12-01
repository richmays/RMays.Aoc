using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day21Tests
    {
        [Test]
        public void DoItA() // 10846352, through debugging and translating each step.
        {
            var day = new Day21();
            Console.WriteLine(day.SolveA(InputData.Day21));
        }

        [Test]
        public void DoItB() // 5244670 through brute force.  Not proud, but ... it worked.
        {
            var day = new Day21();
            Console.WriteLine(day.SolveB(InputData.Day21));
        }

/*
        #ip 1
        00: seti 123 0 5      # F = 123;               //   0111 1011 <- 123
        01: bani 5 456 5      # F = F & 456;           // 1 1100 1000 <- 456
        02: eqri 5 72 5       # F = (F == 72 ? 1 : 0); //   0100 1000 <- 72
        03: addr 5 1 1        # if (F == 1) goto 05;
        04: seti 0 0 1        # goto 01;

        05: seti 0 9 5        # F = 0;
        06: bori 5 65536 2    # C = F | 65536;         //         1 0000 0000 0000 0000 <-- 65536
        07: seti 7571367 9 5  # F = 7571367;           //  111 0011 1000 0111 1010 0111 <-- 7571367
        08: bani 2 255 4      # E = C & 255;           //                     1111 1111 <-- 255
        09: addr 5 4 5        # F = F + E;
        10: bani 5 16777215 5 # F = F & 16777215;      // 1111 1111 1111 1111 1111 1111 <-- 16777215
        11: muli 5 65899 5    # F = F * 65899;
        12: bani 5 16777215 5 # F = F & 16777215;      // 1111 1111 1111 1111 1111 1111 <-- 16777215
        13: gtir 256 2 4      # E = (C < 256 ? 1 : 0);
        14: addr 4 1 1        # if (E == 1) goto 16;
        15: addi 1 1 1        # goto 17;
        16: seti 27 1 1       # goto 28;
        17: seti 0 2 4        # E = 0
        18: addi 4 1 3        # D = E + 1
        19: muli 3 256 3      # D = D * 256;
        20: gtrr 3 2 3        # D = (D > C ? 1 : 0);
        21: addr 3 1 1        # if (D == 1) goto 23;
        22: addi 1 1 1        # goto 24;
        23: seti 25 6 1       # goto 26;
        24: addi 4 1 4        # E = E + 1;
        25: seti 17 8 1       # goto 18;
        26: setr 4 6 2        # C = E;
        27: seti 7 4 1        # goto 8;

        28: eqrr 5 0 4        # E = (F == A ? 1 : 0);  ****** this can be anything!
        29: addr 4 1 1        # if (E == 1) exit;
        30: seti 5 5 1        # goto 6;
*/
    }
}
