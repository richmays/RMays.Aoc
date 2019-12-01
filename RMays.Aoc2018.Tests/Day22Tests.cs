using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day22Tests
    {
        [Test]
        [TestCase(@"depth: 510
target: 10,10", 114)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day22();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"depth: 510
target: 10,10", 45)]
        public void PartBTests(string input, int expectedOutput)
        {
            // requires:  ExtendX >= 1, ExtendY >= 3
            var day = new Day22();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void PartATest_Real()
        {
            var day = new Day22();
            var result = day.SolveA(InputData.Day22);
            Assert.AreEqual(11575, result);
        }

        [Test]
        public void DoItA() // 11575, not too tricky.
        {
            var day = new Day22();
            Console.WriteLine(day.SolveA(InputData.Day22));
        }

        [Test]
        public void DoItB() // 1068. took a LONG time.  my current algorithm is terrible.  :(  finally solved by increasing the width / depth of the search area.
        {
            // Extend(12,12) = 1072 (too high)
            // Extend(15,15) = 1068 (22s)
            // Extend(25,25) = 1068 (29s)

            var day = new Day22();
            var result = day.SolveB(InputData.Day22);
            Console.WriteLine(result);
            Assert.AreNotEqual(1076, result);
            Assert.IsTrue(result < 1069);
        }
    }
}
