using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day18Tests
    {
        private string inputData = InputData.Day18;
        private string knownOutputA = "4042"; // 10s
        private string knownOutputB = "2014"; // 3m 19s

        private IDay<long> GetDayObject()
        {
            return new Day18();
        }

        [Test]
        [TestCase(@"#########
#b.A.@.a#
#########", 8)]
        [TestCase(@"########################
#f.D.E.e.C.b.A.@.a.B.c.#
######################.#
#d.....................#
########################", 86)]
        [TestCase(@"########################
#...............b.C.D.f#
#.######################
#.....@.a.B.c.d.A.e.F.g#
########################", 132)]
        [TestCase(@"#################
#i.G..c...e..H.p#
########.########
#j.A..b...f..D.o#
########@########
#k.E..a...g..B.n#
########.########
#l.F..d...h..C.m#
#################", 136)]
        [TestCase(@"########################
#@..............ac.GI.b#
###d#e#f################
###A#B#C################
###g#h#i################
########################", 81)]

        public void PartATests(string input, int expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"#######
#a.#Cd#
##@#@##
#######
##@#@##
#cB#.b#
#######", 8)]
        [TestCase(@"###############
#d.ABC.#.....a#
######@#@######
###############
######@#@######
#b.....#.....c#
###############", 24)]
        [TestCase(@"#############
#DcBa.#.GhKl#
#.###@#@#I###
#e#d#####j#k#
###C#@#@###J#
#fEbA.#.FgHi#
#############", 32)]
        [TestCase(@"#############
#g#f.D#..h#l#
#F###e#E###.#
#dCba@#@BcIJ#
#############
#nK.L@#@G...#
#M###N#H###.#
#o#m..#i#jk.#
#############", 72)]
        public void PartBTests(string input, int expectedOutput)
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
