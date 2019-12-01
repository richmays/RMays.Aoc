using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day12Tests
    {
        [Test]
        [TestCase(@"initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #", 20,  325)]
        public void PartATests(string input, long generations, int expectedOutput)
        {
            var day = new Day12();
            var result = day.SolveA(input, generations);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestCase(20, 4386)]
        [TestCase(1000, 110166)]
        [TestCase(2000, 219166)]
        [TestCase(50000000000, 5450000001166)]
        [Test]
        public void PartATestsRealData(long generations, long expectedOutput)
        {
            var day = new Day12();
            var result = day.SolveA(InputData.Day12, generations);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 4386
        {
            var day = new Day12();
            Console.WriteLine(day.SolveA(InputData.Day12, 20));
        }

        [Test]
        public void DoItB() // 5450000001166
        {
            var day = new Day12();
            Console.WriteLine(day.SolveA(InputData.Day12, 50000000000));
        }

        [TestCase(20, 3230)]
        [TestCase(1000, 88304)]
        [TestCase(2000, 176304)]
        [TestCase(50000000000, 4400000000304)]
        [Test]
        public void TryingNewData(long generations, long expectedOutput)
        {
            var day = new Day12();
            var result = day.SolveA(InputData.Day12b, generations);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
