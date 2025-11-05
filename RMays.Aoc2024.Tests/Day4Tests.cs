using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2024.Tests
{
    [TestFixture]
    public class Day4Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs

        private string inputData = InputData.Day4;
        private string knownOutputA = "2567";
        private string knownOutputB = "456";

        private IDay<long> GetDayObject()
        {
            return new Day4();
        }

        [Test]
        [TestCase(@"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX", "Default", 18)]
        [TestCase(@"XMAS
SAMX", "Horizontal", 2)]
        [TestCase("XMASAMX", "Horizontal one line", 2)]
        [TestCase("XMASXMAS", "Horizontal two on one line", 2)]
        [TestCase(@"X
M
A
S
A
M
X", "Vertical", 2)]
        [TestCase(@"X......
.M.....
..A....
...S...
....A..
.....M.
......X", "TopLeft to BottomRight", 2)]
        [TestCase(@"......X
.....M.
....A..
...S...
..A....
.M.....
X......", "TopRight to BottomLeft", 2)]
        public void PartATests(string input, string testcaseName, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result, $"Failed test: {testcaseName}");
        }

        [Test]
        [TestCase(@"4, 5, 6", 456)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input, true);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData, true));
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
