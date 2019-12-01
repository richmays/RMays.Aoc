using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day8Tests
    {
        [Test]
        [TestCase("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", 138)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day8();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2", 66)]
        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day8();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 42254
        {
            var day = new Day8();
            Console.WriteLine(day.SolveA(InputData.Day8));
        }

        [Test]
        public void DoItB() // 25007
        {
            var day = new Day8();
            Console.WriteLine(day.SolveB(InputData.Day8));
        }
    }
}
