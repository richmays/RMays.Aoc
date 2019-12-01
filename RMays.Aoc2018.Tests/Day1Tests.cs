using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day1Tests
    {
        [Test]
        [TestCase("+1, +1, +1", 3)]
        [TestCase("+1, +1, -2", 0)]
        [TestCase("-1, -2, -3", -6)]
        public void Part1aTests(string input, int expectedOutput)
        {
            var day1 = new Day1();
            var result = day1.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("+1, -1", 0)]
        [TestCase("+3, +3, +4, -2, -4", 10)]
        [TestCase("-6, +3, +8, +5, -6", 5)]
        [TestCase("+7, +7, -2, -7, -4", 14)]

        public void Part1bTests(string input, int expectedOutput)
        {
            var day1 = new Day1();
            var result = day1.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 538
        {
            var day1 = new Day1();
            Console.WriteLine(day1.SolveA(InputData.Day1));
        }

        [Test]
        public void DoItB() // 77271
        {
            var day1 = new Day1();
            Console.WriteLine(day1.SolveB(InputData.Day1));
        }
    }
}
