using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day25Tests
    {
        [Test]
        [TestCase(@" 0,0,0,0
 3, 0, 0, 0
 0, 3, 0, 0
 0, 0, 3, 0
 0, 0, 0, 3
 0, 0, 0, 6
 9, 0, 0, 0
12, 0, 0, 0", 2)]
        [TestCase(@"-1,2,2,0
0,0,2,-2
0,0,0,-2
-1,2,0,0
-2,-2,-2,2
3,0,2,-1
-1,3,2,2
-1,0,-1,0
0,2,1,-2
3,0,0,0", 4)]
        [TestCase(@"1,-1,0,1
2,0,-1,0
3,2,-1,0
0,0,3,1
0,0,-1,-1
2,3,-2,0
-2,2,0,0
2,-2,0,-1
1,-1,0,-1
3,2,0,2", 3)]
        [TestCase(@"1,-1,-1,-2
-2,-2,0,1
0,2,1,3
-2,3,-2,1
0,2,3,-2
-1,-1,1,-2
0,-2,-1,0
-2,2,3,-1
1,2,2,0
-1,-2,0,-2", 8)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day25();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        //[Test]
        //[TestCase("4, 5, 6", 456)]

        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day25();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 390
        {
            var day = new Day25();
            Console.WriteLine(day.SolveA(InputData.Day25));
        }

        //[Test]
        public void DoItB() // ?
        {
            var day = new Day25();
            Console.WriteLine(day.SolveB(InputData.Day25));
        }
    }
}
