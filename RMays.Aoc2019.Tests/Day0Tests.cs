using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day0Tests
    {
        [Test]
        [TestCase("1, 2, 3", 123)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day0();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("4, 5, 6", 456)]

        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day0();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = new Day0();
            Console.WriteLine(day.SolveA(InputData.Day0));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = new Day0();
            Console.WriteLine(day.SolveB(InputData.Day0));
        }
    }
}
