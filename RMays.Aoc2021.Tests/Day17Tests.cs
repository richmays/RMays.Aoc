using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021.Tests
{
    [TestFixture]
    public class Day17Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs
        // Not proud of this at all; I brute-forced it, thinking that there's very little cost to throwing a
        // projectile and seeing if it hit the target or not.  LOTS of room for optimization.
        // 11 seconds runtime for both parts, and they're not generalized.

        private string inputData = InputData.Day17;
        private string knownOutputA = "10585";
        private string knownOutputB = "5247";

        private IDay<long> GetDayObject()
        {
            return new Day17b();
        }

        [Test]
        [TestCase(@"target area: x=20..30, y=-10..-5", 45)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"target area: x=20..30, y=-10..-5", 112)]
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
