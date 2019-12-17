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
    public class Day16Tests
    {
        private string inputData = InputData.Day16;
        private string knownOutputA = "25131128";
        private string knownOutputB = "53201602";

        private DayBase<long> GetDayObject()
        {
            return new Day16();
        }

        [Test]
        [TestCase("12345678", 23845678)]
        [TestCase("80871224585914546619083218645595", 24176176)]
        [TestCase("19617804207202209144916044189917", 73745418)]
        [TestCase("69317163492948606335995924319873", 52432133)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("80871224585914546619083218645595", 1, 0, 24176176)]
        [TestCase("19617804207202209144916044189917", 1, 0, 73745418)]
        [TestCase("69317163492948606335995924319873", 1, 0, 52432133)]
        [TestCase("80871224585914546619083218645595", 10, 0, 83795850)]
        [TestCase("19617804207202209144916044189917", 10, 0, 84434926)]
        [TestCase("69317163492948606335995924319873", 10, 0, 12578293)]
        [TestCase("80871224585914546619083218645595", 1, 20, 03876319)]
        [TestCase("19617804207202209144916044189917", 1, 20, 46659963)]
        [TestCase("69317163492948606335995924319873", 1, 20, 49597486)]
        [TestCase("80871224585914546619083218645595", 10, 20, 56680834)]
        [TestCase("19617804207202209144916044189917", 10, 20, 7772438)]
        [TestCase("69317163492948606335995924319873", 10, 20, 11301972)]
        public void PartATestsWithOffset(string input, int repeated, int offset, int expectedOutput)
        {
            var day = new Day16();
            var newInput = "";
            for(int i = 0; i < repeated; i++)
            {
                newInput += input;
            }
            var result = day.Solve(newInput, offset, isPartB: false);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("03036732577212944063491565474664", 84462026)]
        [TestCase("02935109699940807407585447034323", 78725270)]
        [TestCase("03081770884921959731165446850517", 53553731)]
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
