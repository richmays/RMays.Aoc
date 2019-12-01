using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day16Tests
    {
        [Test]
        [TestCase(@"Before: [3, 2, 1, 1]
9 2 1 2
After:  [3, 2, 2, 1]", 1)]
        [TestCase(@"Before: [3, 2, 1, 1]
9 2 1 2
After:  [3, 2, 2, 1]

Before: [3, 2, 1, 1]
9 2 1 2
After:  [3, 2, 2, 1]", 2)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day16();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 560 (rank 635)
        {
            var day = new Day16();
            Console.WriteLine(day.SolveA(InputData.Day16a));
        }

        [Test]
        public void DoItB() // 622 (rank 594)
        {
            var day = new Day16();
            Console.WriteLine(day.SolveB(InputData.Day16b));
        }
    }
}
