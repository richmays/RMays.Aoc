using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day18Tests
    {
        [Test]
        [TestCase(@".#.#...|#.
.....#|##|
.|..|...#.
..|#.....#
#.#|||#|#|
...#.||...
.|....|...
||...#|.#|
|.||||..|.
...#.|..|.", 1147)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day18();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        //[Test]
        //[TestCase("4, 5, 6", 456)]

        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day18();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 560091, no problem!
        {
            var day = new Day18();
            Console.WriteLine(day.SolveA(InputData.Day18));
        }

        [Test]
        public void DoItB() // 202301
        {
            var day = new Day18();
            Console.WriteLine(day.SolveB(InputData.Day18));
        }
    }
}
