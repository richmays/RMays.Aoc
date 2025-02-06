using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024.Tests
{
    [TestFixture]
    public class Day1Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs

        private string inputData = InputData.Day1;
        private string knownOutputA = "1110981";
        private string knownOutputB = "24869388";

        private IDay<long> GetDayObject()
        {
            return new Day1();
        }

        [Test]
        [TestCase(@"3   4
4   3
2   5
1   3
3   9
3   3", 11)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"3   4
4   3
2   5
1   3
3   9
3   3", 31)]
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
