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

        private IDay<long> GetDayObject(long deckSize)
        {
            return new Day22
            {
                DeckSize = deckSize
            };
        }

        private IDay<long> GetDayObject(long deckSize, long cardToCheck)
        {
            return new Day22
            {
                DeckSize = deckSize,
                CardToCheck = cardToCheck
            };
        }

        private IDay<long> GetDayObject(long deckSize, long positionToCheck, long shuffleProcesses)
        {
            return new Day22
            {
                DeckSize = deckSize,
                PositionToCheck = positionToCheck,
                ShuffleProcesses = shuffleProcesses
            };
        }

        // Tests for Part A
        [Test]

        // Unshuffled decks should have cards in the same position.
        [TestCase(10, @"", 0, 0)]
        [TestCase(10, @"", 5, 5)]
        [TestCase(999999, @"", 999994, 999994)]

        // Dealing into a new deck reverses all cards' positions.
        [TestCase(5, @"deal into new stack", 4, 0)]
        [TestCase(5, @"deal into new stack", 3, 1)]
        [TestCase(5, @"deal into new stack", 2, 2)]
        [TestCase(5, @"deal into new stack", 1, 3)]
        [TestCase(5, @"deal into new stack", 0, 4)]

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

        [TestCase(@"deal into new stack
deal into new stack", "0 1 2 3 4 5 6 7 8 9")]
        [TestCase(@"deal with increment 7
deal into new stack
deal into new stack", "0 3 6 9 2 5 8 1 4 7")]
        [TestCase(@"cut 6
deal with increment 7
deal into new stack", "3 0 7 4 1 8 5 2 9 6")]
        [TestCase(@"deal with increment 7
deal with increment 9
cut -2", "6 3 0 7 4 1 8 5 2 9")]
        [TestCase(@"deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1", "9 2 5 8 1 4 7 0 3 6")]
        public void PartATests_Samples(string input, string expectedOrder)
        {
            Day22 day = (Day22)GetDayObject(10);
            var result = day.SolveFull(input);
            Assert.AreEqual(expectedOrder, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject(10007, 2019);
            Console.WriteLine(day.Solve(inputData));
        }

        /*
         * Bad part B tests.  These are worthless.
        // Tests for Part B
        [Test]

        // Unshuffled decks should have cards in the same position.
        [TestCase(10, @"", 0, 0)]
        [TestCase(10, @"", 5, 5)]
        [TestCase(999999, @"", 999994, 999994)]

        // Dealing into a new deck reverses all cards' positions.
        [TestCase(5, @"deal into new stack", 0, 4)]
        [TestCase(5, @"deal into new stack", 1, 3)]
        [TestCase(5, @"deal into new stack", 2, 2)]
        [TestCase(5, @"deal into new stack", 3, 1)]
        [TestCase(5, @"deal into new stack", 4, 0)]

        // cut N
        [TestCase(10, @"cut 3", 0, 3)]
        [TestCase(10, @"cut 3", 1, 4)]
        [TestCase(10, @"cut 3", 2, 5)]
        [TestCase(10, @"cut 3", 3, 6)]
        [TestCase(10, @"cut 3", 4, 7)]
        [TestCase(10, @"cut 3", 5, 8)]
        [TestCase(10, @"cut 3", 6, 9)]
        [TestCase(10, @"cut 3", 7, 0)]
        [TestCase(10, @"cut 3", 8, 1)]
        [TestCase(10, @"cut 3", 9, 2)]
        [TestCase(10, @"cut -4", 0, 6)]
        [TestCase(10, @"cut -4", 1, 7)]
        [TestCase(10, @"cut -4", 2, 8)]
        [TestCase(10, @"cut -4", 3, 9)]
        [TestCase(10, @"cut -4", 4, 0)]
        [TestCase(10, @"cut -4", 5, 1)]
        [TestCase(10, @"cut -4", 6, 2)]
        [TestCase(10, @"cut -4", 7, 3)]
        [TestCase(10, @"cut -4", 8, 4)]
        [TestCase(10, @"cut -4", 9, 5)]

        // deal with increment N
        [TestCase(10, @"deal with increment 3", 0, 0)]
        [TestCase(10, @"deal with increment 3", 1, 7)]
        [TestCase(10, @"deal with increment 3", 2, 4)]
        [TestCase(10, @"deal with increment 3", 3, 1)]
        [TestCase(10, @"deal with increment 3", 4, 8)]
        [TestCase(10, @"deal with increment 3", 5, 5)]
        [TestCase(10, @"deal with increment 3", 6, 2)]
        [TestCase(10, @"deal with increment 3", 7, 9)]
        [TestCase(10, @"deal with increment 3", 8, 6)]
        [TestCase(10, @"deal with increment 3", 9, 3)]
        public void PartBTests(long deckSize, string input, long positionToCheck, long expectedOutput)
        {
            Day22 day = new Day22 { DeckSize = deckSize, PositionToCheck = positionToCheck };
            var result = day.Solve(input, true);
            Assert.AreEqual(expectedOutput, result);
        }
        */

        // Tests for Part B
        [Test]

        // Unshuffled decks should have cards in the same position.
        [TestCase(10, @"", 0, 0)]
        [TestCase(10, @"", 5, 5)]
        [TestCase(999999, @"", 999994, 999994)]

        // Dealing into a new deck reverses all cards' positions.
        [TestCase(5, @"deal into new stack", 4, 0)]
        [TestCase(5, @"deal into new stack", 3, 1)]
        [TestCase(5, @"deal into new stack", 2, 2)]
        [TestCase(5, @"deal into new stack", 1, 3)]
        [TestCase(5, @"deal into new stack", 0, 4)]

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
        public void PartBTests(long deckSize, string input, long positionToCheck, long expectedOutput)
        {
            Day22 day = new Day22 { DeckSize = deckSize, PositionToCheck = positionToCheck };
            var result = day.Solve(input, true);
            Assert.AreEqual(expectedOutput, result);
        }



        [TestCase(@"deal into new stack
deal into new stack", "0 1 2 3 4 5 6 7 8 9")]
        [TestCase(@"deal with increment 7
deal into new stack
deal into new stack", "0 3 6 9 2 5 8 1 4 7")]
        [TestCase(@"cut 6
deal with increment 7
deal into new stack", "3 0 7 4 1 8 5 2 9 6")]
        [TestCase(@"deal with increment 7
deal with increment 9
cut -2", "6 3 0 7 4 1 8 5 2 9")]
        [TestCase(@"deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1", "9 2 5 8 1 4 7 0 3 6")]
        public void PartBTests_Samples(string input, string expectedOrder)
        {
            Day22 day = new Day22 { DeckSize = 10 };
            var result = day.SolveFull(input);
            Assert.AreEqual(expectedOrder, result);
        }

        [Test]
        public void DoItB_WithKnownGoodInput() // ?
        {
            var day = GetDayObject(10007, 3324, 1);
            var result = day.Solve(inputData, true);
            Assert.AreEqual(2019, result);
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
