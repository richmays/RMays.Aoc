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
    public class Day9Tests
    {
        private string inputData = InputData.Day9;
        private string knownOutputA = "18272118";
        private string knownOutputB = "2186361";

        private IDay<long> GetDayObject()
        {
            return new Day9();
        }

        [Test]
        [TestCase(@"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576", 127)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = new Day9();
            var result = day.Solve(input, 5);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576", 62)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = new Day9();
            var result = day.SolveB(input, 127);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = new Day9();
            var result = day.Solve(inputData, 25);
            Console.WriteLine(result);
        }

        [Test]
        public void DoItB() // ?
        {
            var day = new Day9();
            var result = day.SolveB(inputData, 18272118);
            Console.WriteLine(result);
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = new Day9();
            var result = day.Solve(inputData, 25);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = new Day9();
            var result = day.SolveB(inputData, 18272118);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
