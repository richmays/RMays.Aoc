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
    public class Day2Tests
    {
        private string inputData = InputData.Day2;
        private string knownOutputA = "5482655";
        private string knownOutputB = "4967";

        private IDay<long> GetDayObject()
        {
            return new Day2();
        }

        [Test]
        [TestCase("1,9,10,3,2,3,11,0,99,30,40,50", 3500)]
        [TestCase("1,0,0,0,99", 2)]
        [TestCase("2,3,0,3,99", 2)] // 6)]
        [TestCase("2,4,4,5,99,0", 2)] // 9801)]
        [TestCase("1,1,1,4,99,5,6,0,99", 30)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Ignore("Don't need to run B tests.")]
        [Test]
        [TestCase("4, 5, 6", 456)]

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
            Console.WriteLine(day.SolveA(InputData.Day2_A));
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
            var result = day.SolveA(InputData.Day2_A);
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
