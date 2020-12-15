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
    public class Day13Tests
    {
        // Finished part B in about 96 minutes with some distractions.
        private string inputData = InputData.Day13;
        private string knownOutputA = "156";
        private string knownOutputB = "404517869995362";

        private IDay<long> GetDayObject()
        {
            return new Day13();
        }

        [Test]
        [TestCase(@"939
7,13,x,x,59,x,31,19", 295)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"B
7,13,x,x,59,x,31,19", 1068781)]
        [TestCase(@"B
17,x,13,19", 3417)]
        [TestCase(@"B
67,7,59,61", 754018)]
        [TestCase(@"B
67,x,7,59,61", 779210)]
        [TestCase(@"B
67,7,x,59,61", 1261476)]
        [TestCase(@"B
1789,37,47,1889", 1202161486)]
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
