using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day24Tests
    {
        private string inputData = InputData.Day24;
        private string knownOutputA = "3186366";
        private string knownOutputB = "2031";

        private IDay<long> GetDayObject()
        {
            return new Day24();
        }

        [Test]
        [TestCase(@"....#
#..#.
#..##
..#..
#....", 2129920)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"....#
#..#.
#..##
..#..
#....", 10, 99)]
        public void PartBTest_Example(string input, int minutes, int expectedOutput)
        {
            var day = new Day24();
            var result = day.Solve_PartB(input, minutes);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData, true));
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
