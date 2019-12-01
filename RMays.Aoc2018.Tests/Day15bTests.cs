using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day15bTests
    {
        [Test]
        [TestCase(@"######
#.GE.#
######", 134)]
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
            var day = new Day15b();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 264384, found after 4 minutes.  yikes.
        {
            //return;
            var day = new Day15b();
            Console.WriteLine(day.SolveA(InputData.Day15));
        }

        [Test]
        public void DoItB() // 67022, 22 minutes.  AP = 20
        {
            // 1 - 200
            // 2 - 100
            // 3 - 67
            // 4 - 50
            // 5 - 40
            // 6 - 34
            // 7 - 29
            // 8 - 25
            // 9 - 23
            // 10 - 20
            // 11 - 19
            // 12 - 17
            // 13 - 16
            // 14 - 15

            var elfAps = new List<int> {
                3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                15, 16, 17, 19, 20, 23, 25, 29, 34, 40, 50, 67,
                100, 200 };

            var day = new Day15b();
            foreach (var i in elfAps)
            {
                var result = day.SolveB(InputData.Day15, i);
                if (result > 0)
                {
                    Console.WriteLine($"Success with AP {i}!");
                    Console.WriteLine(result);
                    return;
                }
                Console.WriteLine($"With AP {i}, an elf died.");
            }

            
        }

        [TestCase(1, 1, 2, 2, -1)]
        [TestCase(1, 2, 2, 2, -1)]
        [TestCase(0, 0, 2, 2, -1)]
        [TestCase(2, 2, 1, 1, 1)]
        [TestCase(2, 1, 1, 1, 1)]
        [TestCase(1, 2, 1, 1, 1)]
        [TestCase(1, 1, 1, 1, 0)]
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(1, 1, 1, 0, 1)]
        [TestCase(1, 1, 0, 1, 1)]
        [TestCase(1, 0, 1, 1, -1)]
        [TestCase(0, 1, 1, 1, -1)]
        public void CoordsTests(int row1, int col1, int row2, int col2, int expected)
        {
            /*
            int x = 0;
            int y = 1;
            Assert.AreEqual(-1, x.CompareTo(y));
            Assert.AreEqual(1, y.CompareTo(x));
            Assert.AreEqual(0, x.CompareTo(x));
            Assert.AreEqual(0, y.CompareTo(y));
            */

            var coords1 = new Coords { Row = row1, Col = col1 };
            var coords2 = new Coords { Row = row2, Col = col2 };
            Assert.AreEqual(expected, coords1.CompareTo(coords2));
        }

    }
}
