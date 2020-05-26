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
    public class Day22Tests
    {
        private string inputData = InputData.Day22;
        private string knownOutputA = "3324";
        private string knownOutputB = "456";

        private IDay<long> GetDayObject(long deckSize, long cardToCheck)
        {
            return new Day22(deckSize, cardToCheck);
        }

        private IDay<long> GetDayObject(long deckSize, long cardToCheck, long shuffleProcesses)
        {
            return new Day22(deckSize, cardToCheck, shuffleProcesses);
        }

        [Test]

        // Unshuffled decks should have cards in the same position.
        [TestCase(10, @"", 0, 0)]
        [TestCase(10, @"", 5, 5)]
        [TestCase(999999, @"", 999994, 999994)]

        // Dealing into a new deck reverses all cards' positions.
        [TestCase(10, @"deal into new stack", 0, 9)]

        // cut N
        [TestCase(10, @"cut 3", 3, 0)]
        [TestCase(10, @"cut 3", 4, 1)]
        [TestCase(10, @"cut 3", 5, 2)]
        [TestCase(10, @"cut 3", 6, 3)]
        [TestCase(10, @"cut 3", 7, 4)]
        [TestCase(10, @"cut 3", 8, 5)]
        [TestCase(10, @"cut 3", 9, 6)]
        [TestCase(10, @"cut 3", 0, 7)]
        [TestCase(10, @"cut 3", 1, 8)]
        [TestCase(10, @"cut 3", 2, 9)]
        [TestCase(10, @"cut -4", 6, 0)]
        [TestCase(10, @"cut -4", 7, 1)]
        [TestCase(10, @"cut -4", 8, 2)]
        [TestCase(10, @"cut -4", 9, 3)]
        [TestCase(10, @"cut -4", 0, 4)]
        [TestCase(10, @"cut -4", 1, 5)]
        [TestCase(10, @"cut -4", 2, 6)]
        [TestCase(10, @"cut -4", 3, 7)]
        [TestCase(10, @"cut -4", 4, 8)]
        [TestCase(10, @"cut -4", 5, 9)]

        // deal with increment N
        [TestCase(10, @"deal with increment 3", 0, 0)]
        [TestCase(10, @"deal with increment 3", 7, 1)]
        [TestCase(10, @"deal with increment 3", 4, 2)]
        [TestCase(10, @"deal with increment 3", 1, 3)]
        [TestCase(10, @"deal with increment 3", 8, 4)]
        [TestCase(10, @"deal with increment 3", 5, 5)]
        [TestCase(10, @"deal with increment 3", 2, 6)]
        [TestCase(10, @"deal with increment 3", 9, 7)]
        [TestCase(10, @"deal with increment 3", 6, 8)]
        [TestCase(10, @"deal with increment 3", 3, 9)]

        public void PartATests(long deckSize, string input, long cardToCheck, long expectedOutput)
        {
            var day = GetDayObject(deckSize, cardToCheck);
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject(10007, 2019);
            Console.WriteLine(day.Solve(inputData));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = GetDayObject(119315717514047, 2020, 101741582076661);
            Console.WriteLine(day.Solve(inputData, true));
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = GetDayObject(10007, 2019);
            var result = day.Solve(inputData);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = GetDayObject(119315717514047, 2020, 101741582076661);
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}
