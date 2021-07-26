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
    public class Day18Tests
    {
        private string inputData = InputData.Day18;
        private string knownOutputA = "45840336521334";
        private string knownOutputB = "328920644404583";

        private IDay<long> GetDayObject()
        {
            return new Day18();
        }

        [Test]
        [TestCase(@"1 + 2 * 3 + 4 * 5 + 6", 71)]
        [TestCase(@"1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase(@"2 * 3 + (4 * 5)", 26)]
        [TestCase(@"5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [TestCase(@"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [TestCase(@"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"1 + 2 * 3 + 4 * 5 + 6", 231)]
        [TestCase(@"1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [TestCase(@"2 * 3 + (4 * 5)", 46)]
        [TestCase(@"5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [TestCase(@"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [TestCase(@"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
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
