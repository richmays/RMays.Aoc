using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day3Tests
    {
        [Test]
        [TestCase(@"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2", 4)]
        public void PartATests(string input, int expectedOutput)
        {
/*
            ........
            ...2222.
            ...2222.
            .11XX22.
            .11XX22.
            .111133.
            .111133.
            ........
*/
            var day = new Day3();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"#1 @ 1,3: 4x4
#2 @ 3,1: 4x4
#3 @ 5,5: 2x2", 3)]
        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day3();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 105231
        {
            var day = new Day3();
            Console.WriteLine(day.SolveA(InputData.Day3));
        }

        [Test]
        public void DoItB() // 164
        {
            var day = new Day3();
            Console.WriteLine(day.SolveB(InputData.Day3));
        }
    }
}
