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
    public class Day5Tests
    {
        private string inputData = InputData.Day5;
        private string knownOutputA = "13547311";
        private string knownOutputB = "456";

        private IDay<long> GetDayObject()
        {
            return new Day5();
        }

        [Test]
        [TestCase("1, 2, 3", 123)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]

        // Equal to 8
        [TestCase("3,9,8,9,10,9,4,9,99,-1,8", 7, false)]
        [TestCase("3,9,8,9,10,9,4,9,99,-1,8", 8, true)]
        [TestCase("3,9,8,9,10,9,4,9,99,-1,8", 9, false)]

        // Less Than 8
        [TestCase("3,9,7,9,10,9,4,9,99,-1,8", 7, true)]
        [TestCase("3,9,7,9,10,9,4,9,99,-1,8", 8, false)]
        [TestCase("3,9,7,9,10,9,4,9,99,-1,8", 9, false)]

        // Equal to 8
        [TestCase("3,3,1108,-1,8,3,4,3,99", 7, false)]
        [TestCase("3,3,1108,-1,8,3,4,3,99", 8, true)]
        [TestCase("3,3,1108,-1,8,3,4,3,99", 9, false)]

        // Less Than 8
        [TestCase("3,3,1107,-1,8,3,4,3,99", 7, true)]
        [TestCase("3,3,1107,-1,8,3,4,3,99", 8, false)]
        [TestCase("3,3,1107,-1,8,3,4,3,99", 9, false)]
        public void PartBTests(string program, int input, bool expectedOutput)
        {
            var day = new Day5();
            var result = day.Solve(program, input);
            Assert.AreEqual(expectedOutput, result == 1);
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
