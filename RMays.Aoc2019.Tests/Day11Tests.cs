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
    public class Day11Tests
    {
        private string inputData = InputData.Day11;
        private string knownOutputA = "1876";
        private string knownOutputB = "456";

        private DayBase<long> GetDayObject()
        {
            return new Day11();
        }

        [Ignore("No need")]
        [Test]
        [TestCase("1, 2, 3", 123)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Ignore("No need")]
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
