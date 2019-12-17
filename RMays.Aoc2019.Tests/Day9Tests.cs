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
    public class Day9Tests
    {
        private string inputData = InputData.Day9;
        private string knownOutputA = "123";
        private string knownOutputB = "456";

        private DayBase<long> GetDayObject()
        {
            return new Day9();
        }

        [Test]
        [TestCase("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", 16,
            109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99, 16)]
        [TestCase("1102,34915192,34915192,7,4,7,99,0", 1,
            1219070632396864)]
        [TestCase("104,1125899906842624,99", 1,
            1125899906842624)]
        public void PartATests(string input, int expectedOutputCount, params long[] expectedOutput)
        {
            var day = new Day9();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutputCount, result.Count(), "Counts were different");
            for(int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedOutput[i], result[i], "Output values were different");
            }
        }

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
