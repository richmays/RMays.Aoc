using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day11Tests
    {
        [Test]
        [TestCase("18", "33,45")]
        [TestCase("42", "21,61")]
        public void PartATests(string input, string expectedOutput)
        {
            var day = new Day11();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("18", "90,269,16")]
        [TestCase("42", "232,251,12")]
        public void PartBTests(string input, string expectedOutput)
        {
            var day = new Day11();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(3, 5, 8, 4)]
        [TestCase(122, 79, 57, -5)]
        [TestCase(217, 196, 39, 0)]
        [TestCase(101, 153, 71, 4)]
        public void GetPowerTest(int x, int y, int serial, sbyte expectedPower)
        {
            var day = new Day11();
            var power = day.GetPower(x, y, serial);
            Assert.AreEqual(expectedPower, power);
        }

        [Test]
        public void DoItA() // 19,41
        {
            var day = new Day11();
            Console.WriteLine(day.SolveA(InputData.Day11));
        }

        [Test]
        public void DoItB() // 237,284,11
        {
            var day = new Day11();
            Console.WriteLine(day.SolveB(InputData.Day11));
        }
    }
}
