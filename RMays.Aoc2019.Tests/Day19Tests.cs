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
    public class Day19Tests
    {
        private string inputData = InputData.Day19;
        private string knownOutputA = "144";
        private string knownOutputB = "13561537";

        private IDay<long> GetDayObject()
        {
            return new Day19();
        }

        [Test]
        [TestCase("1, 2, 3", 123)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(1,  50006)]
        [TestCase(2, 150017)]
        [TestCase(3, 300034)]
        public void PartBTests(int size, int expectedOutput)
        {
            var day = new Day19();
            var result = day.SolveB(inputData, size);
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
