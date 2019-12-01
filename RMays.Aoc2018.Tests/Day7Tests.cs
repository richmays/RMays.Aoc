using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018.Tests
{
    [TestFixture]
    public class Day7Tests
    {
        [Test]
        [TestCase(@"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.", "CABDFE")]
        public void PartATests(string input, string expectedOutput)
        {
            var day = new Day7();
            var result = day.SolveA(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.", 2, 0,  15)]

        public void PartBTests(string input, int workers, int extraSteps, int expectedOutput)
        {
            var day = new Day7();
            var result = day.SolveB(input, workers, extraSteps);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // GJFMDHNBCIVTUWEQYALSPXZORK
        {
            var day = new Day7();
            Console.WriteLine(day.SolveA(InputData.Day7));
        }

        [Test]
        public void DoItB() // 1050
        {
            var day = new Day7();
            Console.WriteLine(day.SolveB(InputData.Day7, 5, 60));
        }
    }
}
