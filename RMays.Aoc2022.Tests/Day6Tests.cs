using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2022.Tests
{
    [TestFixture]
    public class Day6Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs

        private string inputData = InputData.Day6;
        private string knownOutputA = "1953";
        private string knownOutputB = "2301";

        private IDay<long> GetDayObject()
        {
            return new Day6();
        }

        [Test]
        [TestCase(@"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase(@"bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase(@"nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase(@"nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase(@"zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
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
