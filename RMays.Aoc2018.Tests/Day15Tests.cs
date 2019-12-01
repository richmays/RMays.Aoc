using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RMays.Aoc2018.Day15;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day15Tests
    {
        [Test]
        [TestCase(@"#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######", 27730)]
        [TestCase(@"#######
#G..#E#
#E#E.E#
#G.##.#
#...#E#
#...E.#
#######", 36334)]
        [TestCase(@"#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######", 39514)]
        [TestCase(@"#######
#E.G#.#
#.#G..#
#G.#.G#
#G..#.#
#...E.#
#######", 27755)]
        [TestCase(@"#######
#.E...#
#.#..G#
#.###.#
#E#G#G#
#...#G#
#######", 28944)]
        [TestCase(@"#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########", 18740)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day15();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestCase(0, 0, Spot.Wall)]
        [TestCase(1, 1, Spot.Space)]
        [TestCase(1, 2, Spot.Goblin)]
        [TestCase(2, 1, Spot.Space)]
        [TestCase(2, 4, Spot.Elf)]
        public void SpotCheck(int row, int col, Spot expectedSpot)
        {
            var grid = @"#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";
            var myGrid = new Spots(grid);
            Assert.AreEqual(expectedSpot, myGrid.GetSpot(row, col));
        }

        [TestCase(@"#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########")]
        public void PrintGrid(string grid)
        {
            var g = new Spots(grid);
            var result = g.Print();
            Assert.AreEqual(grid, result);
        }

        [Test]
        [TestCase("4, 5, 6", 456)]

        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day15();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        //[Test]
        public void DoItA() // ?
        {
            var day = new Day15();
            Console.WriteLine(day.SolveA(InputData.Day15));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = new Day15();
            Console.WriteLine(day.SolveB(InputData.Day15));
        }
    }
}
