using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day14Tests
    {
        [Test]
        [TestCase(5, "0124515891")]
        [TestCase(18, "9251071085")]
        [TestCase(2018, "5941429882")]
        public void PartATests(int input, string expectedOutput)
        {
            var day = new Day14();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("51589", 9)]
        [TestCase("01245", 5)]
        [TestCase("92510", 18)]
        [TestCase("59414", 2018)]
        [TestCase("165061", 20181148)]
        [TestCase("147061", 20283721)]
        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day14();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 5992684592 (rank 520)
        {
            var day = new Day14();
            Console.WriteLine(day.SolveA(InputData.Day14));
        }

        //[Test]
        public void DoItB() // 20181148 (rank 463)
        {
            var day = new Day14();
            Console.WriteLine(day.SolveB(InputData.Day14.ToString()));
        }
    }
}
