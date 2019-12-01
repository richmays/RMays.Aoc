using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day17Tests
    {
        [Test]
        [TestCase(@"x=495, y=2..7
y=7, x=495..501
x=501, y=3..7
x=498, y=2..4
x=506, y=1..2
x=498, y=10..13
x=504, y=10..13
y=13, x=498..504", 57)]
        [TestCase(@"x=495, y=12..17
y=17, x=495..501
x=501, y=13..17
x=498, y=12..14
x=506, y=11..12
x=498, y=20..23
x=504, y=20..23
y=23, x=498..504", 57)]
        [TestCase(@"y=10, x=499..501
x=515, y=8..9", 8)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day17();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 30495.  nice visualization: https://dylanowen.github.io/advent-of-code-2018/17/
        {
            var day = new Day17();
            Console.WriteLine(day.SolveA(InputData.Day17));
        }

        [Test]
        public void DoItB() // 24899
        {
            var day = new Day17();
            Console.WriteLine(day.SolveB(InputData.Day17));
        }
    }
}
