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
    public class Day16Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs

        private string inputData = InputData.Day16;
        private string knownOutputA = "21071";
        private string knownOutputB = "3429967441937";

        private IDay<long> GetDayObject()
        {
            return new Day16();
        }

        [Test]
        [TestCase(@"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12", 71)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9", 999)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = new Day16("class");
            var result = day.Solve(input, true);
            Assert.AreEqual(12, result);

            day = new Day16("row");
            result = day.Solve(input, true);
            Assert.AreEqual(11, result);

            day = new Day16("seat");
            result = day.Solve(input, true);
            Assert.AreEqual(13, result);

            day = new Day16("?");
            result = day.Solve(input, true);
            Assert.AreEqual(1, result);
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
            var day = new Day16("departure");
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
            var day = new Day16("departure");
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
