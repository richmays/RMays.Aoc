using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day23Tests
    {
        [Test]
        [TestCase(@"pos=<0,0,0>, r=4
pos=<1,0,0>, r=1
pos=<4,0,0>, r=3
pos=<0,2,0>, r=1
pos=<0,5,0>, r=3
pos=<0,0,3>, r=1
pos=<1,1,1>, r=1
pos=<1,1,2>, r=1
pos=<1,3,1>, r=1", 7)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day23();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"pos=<10,12,12>, r=2
pos=<12,14,12>, r=2
pos=<16,12,12>, r=4
pos=<14,14,14>, r=6
pos=<50,50,50>, r=200
pos=<10,10,10>, r=5", 36)]
        public void PartBTests(string input, int expectedOutput)
        {
            var day = new Day23();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA_Solved()
        {
            var day = new Day23();
            Assert.AreEqual(674, day.SolveA(InputData.Day23));
        }

        [Test]
        public void DoItB_Solved()
        {
            var day = new Day23();
            Assert.AreEqual(129444177, day.SolveB(InputData.Day23));
        }

        [Test]
        public void DoItA() // 674, one of the easiest so far.
        {
            var day = new Day23();
            Console.WriteLine(day.SolveA(InputData.Day23));
        }

        [Test]
        public void DoItB() // 131926268 is too high.  131926259 is too high.  129444177 is right!  wow this was REALLY hard.
        {
            var day = new Day23();
            var result = day.SolveB(InputData.Day23);
            Console.WriteLine(result);
            Assert.IsTrue(result < 131926268, "Result is too high");
            Assert.IsTrue(result < 131926259, "Result is too high");
        }
    }
}
