using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day6Tests
    {
        [Test]
        [TestCase(@"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9", 17)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day6();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9", 32, 16)]
        public void PartBTests(string input, int range, int expectedOutput)
        {
            var day = new Day6();
            var result = day.SolveB(input, range);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 3276
        {
            var day = new Day6();
            Console.WriteLine(day.SolveA(InputData.Day6));
        }

        [Test]
        public void DoItB() // 38380
        {
            var day = new Day6();
            Console.WriteLine(day.SolveB(InputData.Day6, 10000));
        }
    }
}
