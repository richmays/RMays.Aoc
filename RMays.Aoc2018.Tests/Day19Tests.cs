using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day19Tests
    { 
        [Test]
        [TestCase(@"#ip 0
seti 5 0 1
seti 6 0 2
addi 0 1 0
addr 1 2 3
setr 1 0 0
seti 8 0 4
seti 9 0 5", 7)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day19();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 1008 (sum of factors of 943)
        {
            var day = new Day19();
            Console.WriteLine(day.SolveA(InputData.Day19));
        }

        [Test]
        public void DoItB() // 11534976 (sum of factors of 10551343)
        {
            var day = new Day19();
            Console.WriteLine(day.SolveB(InputData.Day19));
        }
    }
}
