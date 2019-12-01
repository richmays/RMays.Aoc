using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        [TestCase("abcdef, bababc, abbcde, abcccd, aabcdd, abcdee, ababab", 12)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day2();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("abcde, fghij, klmno, pqrst, fguij, axcye, wvxyz", "fgij")]

        public void PartBTests(string input, string expectedOutput)
        {
            var day = new Day2();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 5390
        {
            var day = new Day2();
            Console.WriteLine(day.SolveA(InputData.Day2));
        }

        [Test]
        public void DoItB() // nvosmkcdtdbfhyxsphzgraljq
        {
            var day = new Day2();
            Console.WriteLine(day.SolveB(InputData.Day2));
        }
    }
}
