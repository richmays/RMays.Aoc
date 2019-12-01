using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day24Tests
    {
        [Test]
        [TestCase(@"Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4", 5216)]
        public void PartATests(string input, int expectedOutput)
        {
            var day = new Day24();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4", 51)]
        [TestCase(@"Immune System:
8233 units each with 2012 hit points (immune to radiation) with an attack that does 2 fire damage at initiative 5
2739 units each with 5406 hit points (immune to fire) with an attack that does 16 fire damage at initiative 3
229 units each with 6782 hit points (weak to slashing) with an attack that does 260 cold damage at initiative 7
658 units each with 12313 hit points with an attack that does 132 bludgeoning damage at initiative 4
3231 units each with 1872 hit points (weak to slashing, cold) with an attack that does 5 bludgeoning damage at initiative 1
115 units each with 10354 hit points (immune to fire, radiation, bludgeoning) with an attack that does 788 cold damage at initiative 2
1036 units each with 9810 hit points (weak to radiation) with an attack that does 94 bludgeoning damage at initiative 8
3389 units each with 6734 hit points with an attack that does 19 cold damage at initiative 18
2538 units each with 5597 hit points (weak to slashing, radiation) with an attack that does 15 slashing damage at initiative 16
6671 units each with 6629 hit points (immune to bludgeoning) with an attack that does 8 slashing damage at initiative 14

Infection:
671 units each with 17509 hit points with an attack that does 52 cold damage at initiative 12
7194 units each with 41062 hit points (immune to cold; weak to radiation) with an attack that does 11 bludgeoning damage at initiative 20
1147 units each with 37194 hit points (weak to radiation, fire) with an attack that does 56 slashing damage at initiative 11
569 units each with 27107 hit points (weak to slashing, bludgeoning) with an attack that does 93 slashing damage at initiative 17
140 units each with 19231 hit points (immune to slashing; weak to bludgeoning) with an attack that does 247 slashing damage at initiative 19
2894 units each with 30877 hit points (immune to radiation, bludgeoning) with an attack that does 15 radiation damage at initiative 10
1246 units each with 8494 hit points (weak to fire) with an attack that does 12 bludgeoning damage at initiative 9
4165 units each with 21641 hit points (weak to radiation; immune to fire) with an attack that does 10 radiation damage at initiative 6
7374 units each with 24948 hit points (weak to cold) with an attack that does 5 fire damage at initiative 13
4821 units each with 26018 hit points with an attack that does 10 fire damage at initiative 15", 862)]
        [TestCase(@"Immune System:
2987 units each with 5418 hit points (immune to slashing; weak to cold, bludgeoning) with an attack that does 17 cold damage at initiative 5
1980 units each with 9978 hit points (immune to cold) with an attack that does 47 cold damage at initiative 19
648 units each with 10733 hit points (immune to radiation, fire, slashing) with an attack that does 143 fire damage at initiative 9
949 units each with 3117 hit points with an attack that does 29 fire damage at initiative 10
5776 units each with 5102 hit points (weak to cold; immune to slashing) with an attack that does 8 radiation damage at initiative 15
1265 units each with 4218 hit points (immune to radiation) with an attack that does 24 radiation damage at initiative 16
3088 units each with 10066 hit points (weak to slashing) with an attack that does 28 slashing damage at initiative 1
498 units each with 1599 hit points (immune to bludgeoning; weak to radiation) with an attack that does 28 bludgeoning damage at initiative 11
3705 units each with 10764 hit points with an attack that does 23 cold damage at initiative 7
3431 units each with 3666 hit points (weak to slashing; immune to bludgeoning) with an attack that does 8 bludgeoning damage at initiative 8

Infection:
2835 units each with 33751 hit points (weak to cold) with an attack that does 21 bludgeoning damage at initiative 13
4808 units each with 32371 hit points (weak to radiation; immune to bludgeoning) with an attack that does 11 cold damage at initiative 14
659 units each with 30577 hit points (weak to fire; immune to radiation) with an attack that does 88 slashing damage at initiative 12
5193 units each with 40730 hit points (immune to radiation, fire, bludgeoning; weak to slashing) with an attack that does 14 cold damage at initiative 20
1209 units each with 44700 hit points (weak to bludgeoning, radiation) with an attack that does 71 fire damage at initiative 18
6206 units each with 51781 hit points (immune to cold) with an attack that does 13 fire damage at initiative 4
602 units each with 22125 hit points (weak to radiation, bludgeoning) with an attack that does 73 cold damage at initiative 3
5519 units each with 37123 hit points (weak to slashing, fire) with an attack that does 12 radiation damage at initiative 2
336 units each with 23329 hit points (weak to fire; immune to cold, bludgeoning, radiation) with an attack that does 134 cold damage at initiative 17
2017 units each with 50511 hit points (immune to bludgeoning) with an attack that does 42 fire damage at initiative 6", 434)]
        [TestCase(@"", 999)]
        [TestCase(@"", 999)]
        public void PartBTests(string input, int expectedOutput)
        {
            if (string.IsNullOrWhiteSpace(input)) return;
            var day = new Day24();
            var result = day.SolveB(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // 14799.  I think the example data was wrong.  But it worked.
        {
            var day = new Day24();
            Console.WriteLine(day.SolveA(InputData.Day24));
        }

        [Test]
        public void DoItA_Solved()
        {
            var day = new Day24();
            Assert.AreEqual(14799, day.SolveA(InputData.Day24));
        }

        [Test]
        public void DoItB() // 4456 is too high.  4452 is too high.  1876 is too low.  4390 is wrong.  argh.  4428!  because i couldn't read.  'initiative' is the 3rd tiebreaker when choosing a target.
        {
            var day = new Day24();
            var result = day.SolveB(InputData.Day24);
            Console.WriteLine(result);
            Assert.IsTrue(result != 4452, "Result can't be 4452.");
            Assert.IsTrue(result != 4456, "Result can't be 4456.");
            Assert.IsTrue(result != 4390, "Result can't be 4390.");
            Assert.IsTrue(result != 1876, "Result can't be 1876.");
            Assert.IsTrue(result < 4452, "Result must be less than 4452.");
            Assert.IsTrue(result > 1876, "Result must be greater than 1876.");
        }
    }
}
