using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day5Tests
    {
        [Test]
        [TestCase("dabAcCaCBAcCcaDA", 10)]
        [TestCase("AaAaAa", 0)]
        [TestCase("AaXbB", 1)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day5();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("dabAcCaCBAcCcaDA", 4)]

        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day5();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 11364
        {
            var day = new Day5();
            Console.WriteLine(day.SolveA(InputData.Day5));
        }

        [Test]
        public void DoItB() // 4212
        {
            var day = new Day5();
            Console.WriteLine(day.SolveB(InputData.Day5));
        }
    }
}
