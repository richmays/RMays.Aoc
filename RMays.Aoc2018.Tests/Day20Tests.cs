using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day20Tests
    {
        [Test]
        [TestCase("^WNE$", 3)]
        [TestCase("^ENWWW(NEEE|SSE(EE|N))$", 10)]
        [TestCase("^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$", 18)]
        [TestCase("^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$", 23)]
        [TestCase("^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$", 31)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day20();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void PartAActual()
        {
            var day = new Day20();
            var result = day.SolveA(InputData.Day20);
            Assert.AreEqual(4025, result);
        }

        [TestCase("^WNE$", 0, 4)]
        [TestCase("^WNE$", 1, 3)]
        [TestCase("^WNE$", 2, 2)]
        [TestCase("^WNE$", 3, 1)]
        [TestCase("^WNE$", 4, 0)]
        [TestCase("^WNE$", 100, 0)]
        public void PartBTests(string input, int doorThreshold, int expectedOutput)
        {
            var day = new Day20();
            var result = day.SolveB(input, doorThreshold);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 4025 , algorithm worked on the first try.  one of my greatest achievements ever.  :)
        {
            var day = new Day20();
            Console.WriteLine(day.SolveA(InputData.Day20));
        }

        [Test]
        public void DoItB() // 8186, wrote some good tests for the simple 4-cell grid, did some tricky math, and solve it with my first guess.
        {
            var day = new Day20();
            Console.WriteLine(day.SolveB(InputData.Day20, 1000));
        }
    }
}
