using NUnit.Framework;
using RMays.Aoc;
using RMays.Aoc2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day1Tests
    {
        private string inputData = InputData.Day1;
        private string knownOutputA = "3397667";
        private string knownOutputB = "5093620";

        private DayBase<long> GetDayObject()
        {
            return new Day1();
        }

        [Test]
        [TestCase("12", 2)]
        [TestCase("14", 2)]
        [TestCase("1969", 654)]
        [TestCase("100756", 33583)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("14", 2)]
        [TestCase("1969", 966)]
        [TestCase("100756", 50346)]
        public void PartBTests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.SolveA(inputData));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.SolveB(inputData));
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = GetDayObject();
            var result = day.SolveA(inputData);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = GetDayObject();
            var result = day.SolveB(inputData);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
