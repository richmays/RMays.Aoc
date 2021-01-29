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
    public class Day15Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs (didn't time it, but it took less than an hour.)
        // part 1+2: XXmXX.XXs (Each run / test took 9 seconds.  I didn't optimize yet.)

        private string inputData = InputData.Day15;
        private string knownOutputA = "1259";
        private string knownOutputB = "689";

        private IDay<long> GetDayObject()
        {
            return new Day15();
        }

        [Test]
        [TestCase(@"0,3,6", 436)]
        [TestCase(@"1,3,2", 1)]
        [TestCase(@"2,1,3", 10)]
        [TestCase(@"1,2,3", 27)]
        [TestCase(@"2,3,1", 78)]
        [TestCase(@"3,2,1", 438)]
        [TestCase(@"3,1,2", 1836)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"0,3,6", 175594)]
        [TestCase(@"1,3,2", 2578)]
        [TestCase(@"2,1,3", 3544142)]
        [TestCase(@"1,2,3", 261214)]
        [TestCase(@"2,3,1", 6895259)]
        [TestCase(@"3,2,1", 18)]
        [TestCase(@"3,1,2", 362)]
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
