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
    public class Day17Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs (92ms runtime)
        // part 1+2: XXmXX.XXs (3.5s runtime; pretty slow.)

        private string inputData = InputData.Day17;
        private string knownOutputA = "215";
        private string knownOutputB = "1728";

        private IDay<long> GetDayObject()
        {
            return new Day17();
        }

        [Test]
        [TestCase(@".#.
..#
###", 112)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@".#.
..#
###", 848)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = new Day17b();
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
            var day = new Day17b();
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
            var day = new Day17b();
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
