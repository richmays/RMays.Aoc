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
    public class Day2Tests
    {
        // Final times:
        // part 1:   2m49s
        // part 2:   3m17s
        // part 1+2: 7m16s

        private string inputData = InputData.Day2;
        private string knownOutputA = "1714950";
        private string knownOutputB = "1281977850";

        private IDay<long> GetDayObject()
        {
            return new Day2();
        }

        [Test]
        [TestCase(@"forward 5
down 5
forward 8
up 3
down 8
forward 2", 150)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"forward 5
down 5
forward 8
up 3
down 8
forward 2", 900)]
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
