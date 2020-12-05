using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020.Tests
{
    [TestFixture]
    public class Day5Tests
    {
        private string inputData = InputData.Day5;
        private string knownOutputA = "123";
        private string knownOutputB = "456";

        private IDay<string> GetDayObject()
        {
            return new Day5();
        }

        [Test]
        [TestCase(@"FBFBBFFRLR", 44, 5, 357)]
        [TestCase(@"BFFFBBFRRR", 70, 7, 567)]
        [TestCase(@"FFFBBBFRRR", 14, 7, 119)]
        [TestCase(@"BBFFBBFRLL", 102, 4, 820)]
        public void PartATests(string input, int expectedRow, int expectedColumn, int expectedSeat)
        {
            var day = new Day5();
            var result = day.GetSeatValue(input);
            var expectedOutput = $"{expectedRow} {expectedColumn} {expectedSeat}";
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"4, 5, 6", 456)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input, true);
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
