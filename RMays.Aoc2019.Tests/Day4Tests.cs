﻿using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day4Tests
    {
        private string inputData = InputData.Day4;
        private string knownOutputA = "1019";
        private string knownOutputB = "660";

        private DayBase<long> GetDayObject()
        {
            return new Day4();
        }

        [Test]
        [TestCase("111111", 1)]
        [TestCase("223450", 0)]
        [TestCase("123789", 0)]
        [TestCase("111111-111112", 2)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("112233", 1)]
        [TestCase("123444", 0)]
        [TestCase("111122", 1)]
        [TestCase("111222", 0)]
        [TestCase("111234", 0)]
        [TestCase("111123", 0)]
        [TestCase("111111-111112", 0)]
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
